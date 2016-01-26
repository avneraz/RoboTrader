using System;
using System.Collections.Generic;
using Infra.Bus;
using Infra.Enum;
using TNS.API.ApiDataObjects;

namespace UILogic
{
    /// <summary>
    /// Used as broker between BL layer data and the UI. Used for test purposes only.
    /// </summary>
    public class UIDataBroker:  SimpleBaseLogic
    {
       
        public UIDataBroker ()
        {
            UnlTradingDataDic = new Dictionary<string, UnlTradingData>();
        }

      
        protected override string ThreadName => "UIDataBroker";

        
        protected override void HandleMessage(IMessage message)
        {
            switch (message.APIDataType)
            {
                case EapiDataTypes.Unknown:
                    break;
                case EapiDataTypes.ExceptionData:
                    break;
                case EapiDataTypes.AccountSummaryData:
                    break;
                case EapiDataTypes.OptionData:
                    break;
                case EapiDataTypes.PositionData:
                    break;
                case EapiDataTypes.OrderData:
                    break;
                case EapiDataTypes.APIMessageData:
                    break;
                case EapiDataTypes.SecurityData:
                    break;
                case EapiDataTypes.OrderStatus:
                    break;
                case EapiDataTypes.BrokerConnectionStatus:
                    break;
                case EapiDataTypes.EndAsynchData:
                    break;
                case EapiDataTypes.SecurityContract:
                    break;
                case EapiDataTypes.TradingTimeEvent:
                    break;
                case EapiDataTypes.MarginData:
                    break;
                case EapiDataTypes.UnlTradingData:
                    var unlTradingData = (UnlTradingData)message;
                    UnlTradingDataDic[unlTradingData.Symbol] = unlTradingData;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Dictionary<string,UnlTradingData> UnlTradingDataDic { get;private set; }
    }
}
