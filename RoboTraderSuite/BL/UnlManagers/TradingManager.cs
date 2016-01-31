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
        }

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
                            break;
                        case ETradingTimeEventType.EndTradingIn30Seconds:
                            break;
                        case ETradingTimeEventType.EndTradingIn60Seconds:
                            break;
                        case ETradingTimeEventType.EndTrading:
                            break;
                    }
                    return true;
            }
            return false;

        }

        public override void DoWorkAfterConnection()
        {
        }

      
    }
}