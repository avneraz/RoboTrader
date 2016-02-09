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
            UnlTradingDataList = new List<UnlTradingData>();
            PositionDataDic = new Dictionary<string, OptionsPositionData>();
            PositionDataList = new List<OptionsPositionData>();
            OrderStatusDataDic = new Dictionary<string, OrderStatusData>();
            OptionDataList = new List<OptionData>();
            AccountSummaryDataList = new List<AccountSummaryData>() {new AccountSummaryData()};
        }

      
        protected override string ThreadName => "UIDataBroker";

        
        protected override void HandleMessage(IMessage message)
        {
            switch (message.APIDataType)
            {
               
                case EapiDataTypes.PositionData:
                    var optionsPositionData = (OptionsPositionData)message;

                    var existingPositionData =
                        PositionDataList.FirstOrDefault(data => data.OptionKey == optionsPositionData.OptionKey);
                    if(existingPositionData == null)
                        PositionDataList.Add(optionsPositionData);
                    else
                    {
                        var index = PositionDataList.IndexOf(existingPositionData);
                        PositionDataList[index] = optionsPositionData;
                    }


                    break;
               
                case EapiDataTypes.UnlTradingData:
                    var unlTradingData = (UnlTradingData)message;
                    UnlTradingDataDic[unlTradingData.Symbol] = unlTradingData;

                    var existingUnlTradingData =
                        UnlTradingDataList.FirstOrDefault(data => data.Symbol == unlTradingData.Symbol);
                    if (existingUnlTradingData == null)
                    {
                        UnlTradingDataList.Add(unlTradingData);
                    }
                    else
                    {
                        var index = UnlTradingDataList.IndexOf(existingUnlTradingData);
                        UnlTradingDataList[index] = unlTradingData;
                    }


                    break;
                case EapiDataTypes.OrderStatus:
                    var order = (OrderStatusData)message;
                    OrderStatusDataDic[order.OrderId] = order;
                    break;
                case EapiDataTypes.OptionData:
                    var optionData = (OptionData)message;

                    var optionDataExist = OptionDataList.FirstOrDefault(od => od.OptionKey == optionData.OptionKey);

                    if (optionDataExist == null)
                        OptionDataList.Add(optionData);
                    else
                    {
                        var index = OptionDataList.IndexOf(optionDataExist);
                        OptionDataList[index] = optionData;
                    }
                    break;
                case EapiDataTypes.AccountSummaryData:
                    var accountData = (AccountSummaryData)message;
                    AccountSummaryDataList[0] = accountData;

                    break;
            }
        }

        public List<AccountSummaryData> AccountSummaryDataList { get; set; }
       
        public List<UnlTradingData> UnlTradingDataList { get; set; }
        public Dictionary<string,UnlTradingData> UnlTradingDataDic { get; }
        public Dictionary<string, OptionsPositionData> PositionDataDic { get; }
        public List<OptionsPositionData> PositionDataList { get; }
        public List<OptionData> OptionDataList { get; set; }
        public Dictionary<string, OrderStatusData> OrderStatusDataDic { get; }
    }
}