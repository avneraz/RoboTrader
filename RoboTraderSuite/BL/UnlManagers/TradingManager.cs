using System;
using Infra.Bus;
using Infra.Enum;
using TNS.API;
using TNS.API.ApiDataObjects;
using TNS.BL.DataObjects;
using TNS.BL.Interfaces;

namespace TNS.BL.UnlManagers
{
    public class TradingManager : UnlMemberBaseManager, ITradingManager
    {
        public TradingManager(ITradingApi apiWrapper, ManagedSecurity managedSecurity, UNLManager unlManager) : base(apiWrapper, managedSecurity, unlManager)
        {
            OrderManager = unlManager.OrdersManager;
        }

        private const int TRADING_CYCLE_TYME = 10;
        private string _taskId;
        private IOrdersManager OrderManager { get;  }
        public AccountSummaryData AccountSummaryData { get; set; }

        public override bool HandleMessage(IMessage message)
        {
            //ForTest:if(UnlTradingData.Margin > 0){ }

            bool result = base.HandleMessage(message);
            if (result)
                return true;
              
            switch (message.APIDataType)
            {
                case EapiDataTypes.AccountSummaryData:
                    AccountSummaryData = message as AccountSummaryData;
                    return true;
                case EapiDataTypes.TradingTimeEvent:
                    var tradingTimeEvent = (TradingTimeEvent) message;
                    var eventType = tradingTimeEvent.TradingTimeEventType;
                    switch (eventType)
                    {
                        case ETradingTimeEventType.StartTrading:
                            _taskId = UNLManager.AddScheduledTaskOnUnl(TimeSpan.FromSeconds(TRADING_CYCLE_TYME), TradingWork, true);
                            break;
                        case ETradingTimeEventType.EndTradingIn30Seconds:
                            break;
                        case ETradingTimeEventType.EndTradingIn60Seconds:
                            break;
                        case ETradingTimeEventType.EndTrading:
                            UNLManager.RemoveScheduledTaskOnUnl(_taskId);
                            break;
                    }
                    return true;
            }
            return false;

        }
        /// <summary>
        /// Do trading work initiated from scheduler task
        /// </summary>
        private void TradingWork()
        {
            //Check margin
            //this.UnlTradingData.MaxAllowedMargin
            
        }
        public override void DoWorkAfterConnection()
        {


        }

      
    }
}