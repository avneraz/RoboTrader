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
            UnlTradingDataList = new List<UnlTradingData>();
            PositionDataList = new List<OptionsPositionData>();
            OrderStatusDataList = new List<OrderStatusData>();
            OptionsDataList = new List<OptionData>();
            AccountSummaryDataList = new List<AccountSummaryData>() {new AccountSummaryData()};
            SecurityDataList = new List<SecurityData>();
        }

      
        protected override string ThreadName => "UIDataBroker";

        
        protected override void HandleMessage(IMessage message)
        {
            //if (Symbol.Equals("MCD"))
            //{

            //}
            int index;
            switch (message.APIDataType)
            {
               
                case EapiDataTypes.PositionData:
                    var optionsPositionData = (OptionsPositionData)message;

                    var existingPositionData =
                        PositionDataList.FirstOrDefault(data => data.OptionKey == optionsPositionData.OptionKey && data.Symbol == optionsPositionData.Symbol);
                    if((existingPositionData == null) && (optionsPositionData.Position != 0))
                        PositionDataList.Add(optionsPositionData);
                    if (existingPositionData == null)
                        break;
                    //else
                    index = PositionDataList.IndexOf(existingPositionData);
                    //Remove no position entry:
                    if (optionsPositionData.Position == 0)
                        PositionDataList.RemoveAt(index);
                    else
                        PositionDataList[index] = optionsPositionData;



                    break;
               
                case EapiDataTypes.UnlTradingData:
                    var unlTradingData = (UnlTradingData)message;

                    var existingUnlTradingData =
                        UnlTradingDataList.FirstOrDefault(data => data.Symbol == unlTradingData.Symbol);
                    if (existingUnlTradingData == null)
                    {
                        UnlTradingDataList.Add(unlTradingData);
                    }
                    else
                    {
                        index = UnlTradingDataList.IndexOf(existingUnlTradingData);
                        UnlTradingDataList[index] = unlTradingData;
                    }


                    break;
                case EapiDataTypes.OrderStatus:
                    var order = (OrderStatusData)message;

                    if ((order.OrderStatus == OrderStatus.Filled) && (order.WhatIf))
                    {
                        order.Margin = order.MaintMargin -
                                                 this.AccountSummaryDataList[0].FullMaintMarginReq;
                    }

                    //OrderStatusDataDic[order.OrderId] = order;
                        var orderDataExist = OrderStatusDataList.FirstOrDefault(od => od.OrderId == order.OrderId);
                    if (orderDataExist == null)
                        OrderStatusDataList.Add(order);
                    else
                    {
                        index = OrderStatusDataList.IndexOf(orderDataExist);
                        OrderStatusDataList[index] = order;
                    }
                    break;
                case EapiDataTypes.OptionData:
                    var optionData = (OptionData)message;

                    var optionDataExist = OptionsDataList.FirstOrDefault(od => od.OptionKey == optionData.OptionKey);

                    if (optionDataExist == null)
                        OptionsDataList.Add(optionData);
                    else
                    {
                        index = OptionsDataList.IndexOf(optionDataExist);
                        OptionsDataList[index] = optionData;
                    }
                    break;
                case EapiDataTypes.AccountSummaryData:
                    var accountData = (AccountSummaryData)message;
                    AccountSummaryDataList[0] = accountData;

                    break;
                case EapiDataTypes.SecurityData:
                    var securityData = (SecurityData)message;
                    var securityDataExist = SecurityDataList.FirstOrDefault(od => od.Symbol == securityData.Symbol);

                    if (securityDataExist == null)
                        SecurityDataList.Add(securityData);
                    else
                    {
                        index = SecurityDataList.IndexOf(securityDataExist);
                        SecurityDataList[index] = securityData;
                    }
                    //Securities[securityData.GetSymbolName()] = securityData;
                    break;
            }
        }

        public List<SecurityData> SecurityDataList { get; set; }
        public List<AccountSummaryData> AccountSummaryDataList { get; set; }
        public List<UnlTradingData> UnlTradingDataList { get; set; }
        //public Dictionary<string,UnlTradingData> UnlTradingDataDic { get; }
        public List<OptionsPositionData> PositionDataList { get; }
        public List<OptionData> OptionsDataList { get; set; }

        public List<OrderStatusData> OrderStatusDataList{ get; set; }
    }
}