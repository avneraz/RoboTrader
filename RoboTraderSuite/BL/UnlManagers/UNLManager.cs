using System;
using System.Collections.Generic;
using Infra.Bus;
using Infra.Enum;
using log4net;
using TNS.API;
using TNS.API.ApiDataObjects;
using TNS.BL.DataObjects;
using TNS.BL.Interfaces;
using IMessage = Infra.Bus.IMessage;

namespace TNS.BL.UnlManagers
{
    public class UNLManager : SimpleBaseLogic
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(UNLManager));
        public UNLManager(ManagedSecurity managedSecurity, ITradingApi apiWrapper)
        {
            ManagedSecurity = managedSecurity;
            APIWrapper = apiWrapper;
            //PendingTradingTimeEventDic = new Dictionary<ETradingTimeEventType, TradingTimeEvent>();
            Logger.InfoFormat("UNLManager({0}) was created!", managedSecurity.Symbol); 
        }

        internal string AddScheduledTaskOnUnl(TimeSpan span, Action task, bool reOccuring = false)
        {
            return AddScheduledTask(span, task, reOccuring);
        }

        internal void RemoveScheduledTaskOnUnl(string uniqueIdentifier)
        {
            RemoveScheduledTask(uniqueIdentifier);
        }

        public string Symbol => MainSecurityData != null ? MainSecurityData.GetContract().Symbol : string.Empty;
        public SecurityData MainSecurityData { get; set; }
        public SecurityContract SecurityContract { get; set; }
        private List<IUnlBaseMemberManager> _memberManagersList;
        private ITradingApi APIWrapper { get; }
        private ManagedSecurity ManagedSecurity { get; }
        protected override string ThreadName => ManagedSecurity.Symbol + "_UNLManager_Work";
        protected override void HandleMessage(IMessage message)
        {
            switch (message.APIDataType)
            {
                case EapiDataTypes.SecurityContract:
                    SecurityContract = (SecurityContract)message;
                    EvaluateTradingEvents();
                    break;
                case EapiDataTypes.SecurityData:
                    MainSecurityData = (SecurityData)message;
                    SendMessageToAllComponents(message);
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
                    SendMessageToAllComponents( message);
                    break;
            }
        }

        private void SendMessageToAllComponents(IMessage message)
        {
            if(_memberManagersList == null)
                return;
            foreach (var manager in _memberManagersList)
            {
                manager.HandleMessage(message);
            }
        }

        public bool IsConnected => ConnectionStatus == ConnectionStatus.Connected;
        public ConnectionStatus ConnectionStatus { get; private set; }
        protected void DoWorkAfterConnection()
        {
            CreateManagers();
        }

        private void CreateManagers()
        {
            _memberManagersList = new List<IUnlBaseMemberManager>();

            OptionsManager = new OptionsManager(APIWrapper, ManagedSecurity, this);
            _memberManagersList.Add(OptionsManager);

            PositionsDataBuilder = new PositionsDataBuilder(APIWrapper, ManagedSecurity,this);
            _memberManagersList.Add(PositionsDataBuilder);

            TradingManager = new TradingManager(APIWrapper, ManagedSecurity, this);
           _memberManagersList.Add(TradingManager);

            OrdersManager = new OrdersManager(APIWrapper, ManagedSecurity, this);
            _memberManagersList.Add(OrdersManager);
        }

        public IOptionsManager OptionsManager { get; set; }
        public IPositionsDataBuilder PositionsDataBuilder { get; set; }
        public ITradingManager TradingManager { get; set; }
        public IOrdersManager OrdersManager { get; set; }


        #region TradingTime
        /// <summary>
        /// Get indication if today is working day for the UNL security.
        /// </summary>
        public bool IsWorkingDay => SecurityContract.IsWorkingDay;
        public DateTime NextWorkingTime => SecurityContract.NextWorkingTime;
        public DateTime StartTradingTimeLocal => SecurityContract.StartTradingTimeLocal;
        public DateTime EndTradingTimeLocal => SecurityContract.EndTradingTimeLocal;

        public bool IsNowWorkingTime
        {
            get
            {
                DateTime now = DateTime.Now;

                return IsWorkingDay && now >= StartTradingTimeLocal && now < EndTradingTimeLocal;
            }
        }
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