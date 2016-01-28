using System;
using System.Collections.Generic;
using System.Linq;
using Infra.Bus;
using Infra.Enum;
using TNS.API.ApiDataObjects;

namespace UILogic
{
    /// <summary>
    /// Used as broker between BL layer data and the UI. Used for evaluation and test purposes only.
    /// </summary>
    public class UIDataBroker:  SimpleBaseLogic
    {
       
        public UIDataBroker ()
        {
            UnlTradingDataDic = new Dictionary<string, UnlTradingData>();
            PositionDataDic = new Dictionary<string, OptionsPositionData>();
            OptionsPositionDataList = new List<OptionsPositionData>();
        }

      
        protected override string ThreadName => "UIDataBroker";

        
        protected override void HandleMessage(IMessage message)
        {
            switch (message.APIDataType)
            {
               
                case EapiDataTypes.PositionData:
                    var optionsPositionData = (OptionsPositionData)message;
                    var key = ((OptionContract)optionsPositionData.GetContract()).OptionKey;
                    //var existingposData = OptionsPositionDataList.FirstOrDefault(pd =>
                    //    ((OptionContract) pd.GetContract()).OptionKey == key);
                    PositionDataDic[key] = optionsPositionData;
                    break;
               
                case EapiDataTypes.UnlTradingData:
                    var unlTradingData = (UnlTradingData)message;
                    UnlTradingDataDic[unlTradingData.Symbol] = unlTradingData;
                    break;
             
            }
        }

        public Dictionary<string,UnlTradingData> UnlTradingDataDic { get; }
        public Dictionary<string, OptionsPositionData> PositionDataDic { get; }
        public List<OptionsPositionData> OptionsPositionDataList { get; set; }
    }
}
