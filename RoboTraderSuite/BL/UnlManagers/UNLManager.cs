using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Infra;
using Infra.Bus;
using Infra.Enum;
using log4net;
using NHibernate.Linq;
using TNS.API;
using TNS.API.ApiDataObjects;
using TNS.BL.DataObjects;
using TNS.BL.Interfaces;
using IMessage = Infra.Bus.IMessage;

namespace TNS.BL.UnlManagers
{
    public class UNLManager : SimpleBaseLogic
    {
        public event Action<TradingTimeEvent> SendTradingTimeEvent;
        public event Action<UNLManager> PositionNeedToOptimized;
        protected virtual void OnPositionNeedToOptimized()
        {
            PositionNeedToOptimized?.Invoke(this);
        }
        public virtual void OnSendTradingTimeEvent(TradingTimeEvent tradingTimeEvent)
        {
            Action<TradingTimeEvent> handler = SendTradingTimeEvent;
            handler?.Invoke(tradingTimeEvent);
        }

        private static readonly ILog Logger = LogManager.GetLogger(typeof(UNLManager));
        public UNLManager(ManagedSecurity managedSecurity, ITradingApi apiWrapper, SimpleBaseLogic distributer)
        {
            ManagedSecurity = managedSecurity;
            APIWrapper = apiWrapper;
            //PendingTradingTimeEventDic = new Dictionary<ETradingTimeEventType, TradingTimeEvent>();
            Logger.InfoFormat("UNLManager({0}) was created!", managedSecurity.Symbol);
            Distributer = distributer;
            UnlTradingData = new UnlTradingData(ManagedSecurity);
        }


        #region Properties
        public AccountSummaryData AccountSummaryData { get; set; }
        public SimpleBaseLogic Distributer { get; }
        public UnlTradingData UnlTradingData { get; set; }
        public bool IsConnected => ConnectionStatus == ConnectionStatus.Connected;
        public ConnectionStatus ConnectionStatus { get; private set; }
        public string Symbol => ManagedSecurity.Symbol;
        public SecurityData MainSecurityData { get; set; }
        public SecurityContract SecurityContract { get; set; }
        private List<IUnlBaseMemberManager> _memberManagersList;
        public ITradingApi APIWrapper { get; }
        public ManagedSecurity ManagedSecurity { get; }
        public bool IsSimulatorAccount => !AllConfigurations.AllConfigurationsObject.Application.MainAccount.Equals(AccountSummaryData.MainAccount);
        protected override string ThreadName => ManagedSecurity.Symbol + "_UNLManager_Work";

        public Dictionary<EapiDataTypes, List<ISubscibeMessage>> SubscriberDic { get; set; }
        private readonly object _subscriberSync = new object();
        #endregion

        #region Methods
        public void RegisterForMessage(ISubscibeMessage subsciber, EapiDataTypes messageType)
        {
            if(SubscriberDic == null)
                SubscriberDic = new Dictionary<EapiDataTypes, List<ISubscibeMessage>>();

            lock (_subscriberSync)
            {
                if (SubscriberDic.ContainsKey(messageType))
                    SubscriberDic[messageType].Add(subsciber);
                else
                {
                    var subsciberList = new List<ISubscibeMessage> { subsciber };
                    SubscriberDic[messageType] = subsciberList;
                } 
            }
        }

        public void UnRegisterForMessage(ISubscibeMessage subsciber, EapiDataTypes messageType)
        {
            if (SubscriberDic == null) return;

            lock (_subscriberSync)
            {
                if (SubscriberDic.ContainsKey(messageType) && SubscriberDic[messageType].Contains(subsciber))
                    SubscriberDic[messageType].Remove(subsciber);
            }
        }

        public void CloseEntireShortPositions()
        {
            TradingManager.CloseEntireShortPositions();
        }
        public void CloseShortPositions(DateTime? expiry)
        {
            TradingManager.CloseShortPositions(expiry);
        }

        public string AddScheduledTaskOnUnl(TimeSpan span, Action task, bool reOccuring = false)
        {
            return AddScheduledTask(span, task, reOccuring);
        }

        public void RemoveScheduledTaskOnUnl(string uniqueIdentifier)
        {
            RemoveScheduledTask(uniqueIdentifier);
        }
        protected override void HandleMessage(IMessage message)
        {
            //if (Symbol.Equals("MCD"))//For test
            //{}
            switch (message.APIDataType)
            {
                case EapiDataTypes.AccountSummaryData:
                    TradingManager.HandleMessage(message);
                    OrdersManager.HandleMessage(message);
                    AccountSummaryData = message as AccountSummaryData;
                    break;
                case EapiDataTypes.SecurityContract:
                    SecurityContract = (SecurityContract)message;
                    EvaluateTradingEvents();
                    break;
                case EapiDataTypes.SecurityData:
                    var securityData = (SecurityData) message;
                   
                    if (securityData.SecurityContract.Symbol == Symbol)
                    {
                        UnlTradingData.UnlSecurityData = securityData;
                        
                        MainSecurityData = securityData;
                        SendMessageToAllComponents(message);
                        
                    }
                    break;
                case EapiDataTypes.OptionData:
                    OptionsManager.HandleMessage(message);
                    break;
                case EapiDataTypes.PositionData:
                    PositionsDataBuilder.HandleMessage(message);
                    break;
                case EapiDataTypes.OrderData:
                    OrdersManager.HandleMessage(message);
                    break;
                case EapiDataTypes.OrderStatus:
                    OrdersManager.HandleMessage(message);
                    break;
                case EapiDataTypes.BrokerConnectionStatus:
                    var connectionStatusMessage = (BrokerConnectionStatusMessage)message;
                    ConnectionStatus = connectionStatusMessage.Status;
                    if (connectionStatusMessage.AfterConnectionToApiWrapper)
                        DoWorkAfterConnection();
                    SendMessageToAllComponents(message);
                    break;
                case EapiDataTypes.MarginData:
                    var marginData = (MarginData) message;
                    UnlTradingData.Margin = marginData.Margin;
                    break;
                case EapiDataTypes.TransactionData:
                    //Filter other unl messages:
                    var transactionData = message as TransactionData;
                    if (transactionData == null) break;

                    if (transactionData.OptionData.OptionContract.Symbol.Equals(Symbol)==false)
                        break;

                    var tradingManager = _memberManagersList.First(m => m is ITradingManager) as ITradingManager;
                    tradingManager?.HandleMessage(message);

                    break;
                case EapiDataTypes.ExceptionData:
                    
                    break;
            }
            SendMessageToSubscribers(message);
        }

        private void SendMessageToSubscribers(IMessage message)
        {
            if (SubscriberDic == null) return;
            if (!SubscriberDic.ContainsKey(message.APIDataType))
                return;

            lock (_subscriberSync)
            {
                foreach (var subsciber in SubscriberDic[message.APIDataType])
                {
                    subsciber.HandleMessage(message);
                } 
            }

        }
        private void SendMessageToAllComponents(IMessage message)
        {
            if (_memberManagersList == null)
                return;
            foreach (var manager in _memberManagersList)
            {
                manager.HandleMessage(message);
            }
        }

        protected void DoWorkAfterConnection()
        {
            CreateManagers();
            //Start repeated task (every 1 sec) to Distributer:
            AddScheduledTask(TimeSpan.FromSeconds(10),
                () => { AddScheduledTask(TimeSpan.FromSeconds(60),
                    () => { Distributer.Enqueue(UnlTradingData); }, true); });
        }


        #endregion

        #region Managers

        private void CreateManagers()
        {
            _memberManagersList = new List<IUnlBaseMemberManager>();

            OptionsManager = new OptionsManager( ManagedSecurity, this);
            _memberManagersList.Add(OptionsManager);

            PositionsDataBuilder = new PositionsDataBuilder( ManagedSecurity, this);	

            _memberManagersList.Add(PositionsDataBuilder);

            OrdersManager = new OrdersManager( ManagedSecurity, this);
            _memberManagersList.Add(OrdersManager);

            TradingManager = new TradingManager( ManagedSecurity, this);
            _memberManagersList.Add(TradingManager);
            TradingManager.SendTradingTimeEvent += TradingManager_SendTradingTimeEvent;
            TradingManager.PositionNeedToOptimized += TradingManagerOnPositionNeedToOptimized;
        }

        private void TradingManagerOnPositionNeedToOptimized()
        {
            OnPositionNeedToOptimized();
        }

        private void TradingManager_SendTradingTimeEvent(TradingTimeEvent tradingTimeEvent)
        {
           OnSendTradingTimeEvent(tradingTimeEvent);
            if(tradingTimeEvent.TradingTimeEventType != ETradingTimeEventType.EndTrading) return;
           

        }

        public IOptionsManager OptionsManager { get; set; }
        public IPositionsDataBuilder PositionsDataBuilder { get; set; }
        public ITradingManager TradingManager { get; set; }
        public IOrdersManager OrdersManager { get; set; } 
        #endregion

        #region TradingTime
        /// <summary>
        /// Get indication if today is working day for the UNL security.
        /// </summary>
        public bool IsWorkingDay => SecurityContract != null && SecurityContract.IsWorkingDay;

        public DateTime NextWorkingTime => SecurityContract.NextWorkingTime;
        public DateTime StartTradingTimeLocal => SecurityContract.StartTradingTimeLocal;
        public DateTime EndTradingTimeLocal => SecurityContract.EndTradingTimeLocal;

        public bool IsNowWorkingTime => SecurityContract != null && SecurityContract.IsNowWorkingTime;
        

        /// <summary>
        /// Get indication if now is extended working time by 30 minutes :
        /// ==> between StartTrading - 30 minutes  and EndTrading + 30 minutes!
        /// </summary>
        public bool IsNowExtendedWorkingTime => SecurityContract != null && SecurityContract.IsNowExtendedWorkingTime;
        

        private Dictionary<ETradingTimeEventType, TradingTimeEvent> TradingTimeEventDic { get; } =
            new Dictionary<ETradingTimeEventType, TradingTimeEvent>();
        /// <summary>
        /// Evaluate the trading events according to the trading time of the UNL.
        /// </summary>
        private void EvaluateTradingEvents()
        {
            if (IsNowWorkingTime == false)
            {
                if (IsWorkingDay)
                {
                    AddTimeEventTasks();
                }
            }
            else //Now is Working Time, The trading is already start and doesn't end.
            {
                AddTimeEventTasks(10);
            }
            //Evaluate again tomorrow on first seconds:
            RefreshContractDetailOnNextDay();

        }

        private void RefreshContractDetailOnNextDay()
        {
            DateTime nextContractRefreshingTime = (DateTime.Today.AddDays(1).AddSeconds(1));

            //For test: nextContractRefreshingTime = (DateTime.Now.AddMinutes(1).AddSeconds(1));

            AddScheduledTask(nextContractRefreshingTime.Subtract(DateTime.Now), 
                () => { APIWrapper.RequestSecurityContractDetails(MainSecurityData); } );
            Logger.InfoFormat("~~~~~{0}: Scheduled task for refreshing contract at:  {1:G}",Symbol, nextContractRefreshingTime);
        }
        private void AddTimeEventTasks(int startTimeDelaySec = 0)
        {
            AddTimeEventTask(ETradingTimeEventType.StartTrading, startTimeDelaySec);
            AddTimeEventTask(ETradingTimeEventType.EndTradingIn60Seconds);
            AddTimeEventTask(ETradingTimeEventType.EndTradingIn30Seconds);
            AddTimeEventTask(ETradingTimeEventType.EndTrading);
        }

        private void AddTimeEventTask(ETradingTimeEventType eventType, int startTimeDelaySec = 0)
        {
            var tradingTimeEvent = new TradingTimeEvent(eventType);
            switch (eventType)
            {
                case ETradingTimeEventType.StartTrading:
                    tradingTimeEvent.EventTime = startTimeDelaySec == 0 ? StartTradingTimeLocal : DateTime.Now.AddSeconds(startTimeDelaySec);

                    break;
                case ETradingTimeEventType.EndTradingIn60Seconds:
                    tradingTimeEvent.EventTime = EndTradingTimeLocal.AddSeconds(-60);
                    break;
                case ETradingTimeEventType.EndTradingIn30Seconds:
                    tradingTimeEvent.EventTime = EndTradingTimeLocal.AddSeconds(-30);
                    break;
                case ETradingTimeEventType.EndTrading:
                    tradingTimeEvent.EventTime = EndTradingTimeLocal;
                    break;
               
                default:
                    return;
            }
            //Verify task time is logical
            if(DateTime.Now>=tradingTimeEvent.EventTime)
                return;
            
            AddTradingTimeEvent(tradingTimeEvent);
            Logger.InfoFormat("{0}: Event Registration: ***** {1} ",Symbol, tradingTimeEvent);
        }

        private void AddTradingTimeEvent(TradingTimeEvent tradingTimeEvent)
        {
            lock (TradingTimeEventDic)
            {
                if (TradingTimeEventDic.ContainsKey(tradingTimeEvent.TradingTimeEventType))
                {
                    RemoveScheduledTask(tradingTimeEvent.TaskUniqueIdentifier);
                    Logger.InfoFormat("{0}: RemoveScheduledTask: ----- {1}", Symbol,
                        TradingTimeEventDic[tradingTimeEvent.TradingTimeEventType]);
                }


                tradingTimeEvent.TaskUniqueIdentifier =
                    AddScheduledTask(tradingTimeEvent.EventTime.Subtract(DateTime.Now), () =>
                    {
                        Logger.InfoFormat("{0}: Event invocation: !!!!! {1}", Symbol, tradingTimeEvent);
                        SendMessageToAllComponents(tradingTimeEvent);
                    });
                TradingTimeEventDic[tradingTimeEvent.TradingTimeEventType] = tradingTimeEvent;
            }
        }

        #endregion

       
    }
}