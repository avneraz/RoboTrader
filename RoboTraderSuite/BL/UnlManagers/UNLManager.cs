using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Infra.Bus;
using Infra.Enum;
using log4net;
using NHibernate.Mapping;
using TNS.API;
using TNS.API.ApiDataObjects;
using TNS.BL.DataObjects;
using TNS.BL.Interfaces;

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

        private bool IsConnected => ConnectionStatus == ConnectionStatus.Connected;
        private ConnectionStatus ConnectionStatus { get; set; }
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
        public DateTime NextWorkingDay => SecurityContract.NextWorkingDay;
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
       
        /// <summary>
        /// Evaluate the trading events according to the trading time of the UNL.
        /// </summary>
        private void EvaluateTradingEvents()
        {
            if (IsNowWorkingTime == false)
            {
                if (IsWorkingDay)
                {
                    AddTimeEventTask(ETradingTimeEventType.StartTrading);
                    AddTimeEventTask(ETradingTimeEventType.EndTradingIn30Seconds);
                    AddTimeEventTask(ETradingTimeEventType.EndTradingIn60Seconds);
                    AddTimeEventTask(ETradingTimeEventType.EndTrading);

                }
                //Evaluate again tomorrow:
                 AddScheduledTask((DateTime.Today.AddDays(1).AddSeconds(1)).Subtract(DateTime.Now),EvaluateTradingEvents);
            }
            else //Now is Working Time, The trading is already start
            {
                //Set end events
                AddTimeEventTask(ETradingTimeEventType.StartTrading, 10);//Send also the start event because the trader will start in 10 sec
                AddTimeEventTask(ETradingTimeEventType.EndTradingIn30Seconds);
                AddTimeEventTask(ETradingTimeEventType.EndTradingIn60Seconds);
                AddTimeEventTask(ETradingTimeEventType.EndTrading);
                //Evaluate again tomorrow:
                AddScheduledTask((DateTime.Today.AddDays(1).AddSeconds(1)).Subtract(DateTime.Now), EvaluateTradingEvents);
            }
        }

        private void AddTimeEventTask(ETradingTimeEventType eventType, int startTimeDelaySec = 0)
        {
            var tradingTimeEvent = new TradingTimeEvent(eventType);
            switch (eventType)
            {
                case ETradingTimeEventType.StartTrading:
                    if (startTimeDelaySec == 0)
                        tradingTimeEvent.EventTime = StartTradingTimeLocal;
                    else
                        tradingTimeEvent.EventTime = DateTime.Now.AddSeconds(startTimeDelaySec);
                    break;
                case ETradingTimeEventType.EndTradingIn30Seconds:
                    tradingTimeEvent.EventTime = EndTradingTimeLocal.AddSeconds(-30);
                    break;
                case ETradingTimeEventType.EndTradingIn60Seconds:
                    tradingTimeEvent.EventTime = EndTradingTimeLocal.AddSeconds(-60);
                    break;
                case ETradingTimeEventType.EndTrading:
                    tradingTimeEvent.EventTime = EndTradingTimeLocal;
                    break;
                default:
                    return;
            }

            
            AddScheduledTask(tradingTimeEvent.EventTime.Subtract(DateTime.Now), () =>
            {
                SendMessageToAllComponents(tradingTimeEvent);
            });
        }

        #endregion
    }
}