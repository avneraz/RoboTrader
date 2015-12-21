using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IBApi;
using TNS.API.ApiDataObjects;

namespace TNS.API.IBApiWrapper
{
    public static class IBExtensions
    {
        public static OptionContract ToOptionContract(this Contract contract)
        {
            //TODO - fix expiry!
            var optionType = contract.Right == "C" ? OptionType.Call : OptionType.Put;
            return new OptionContract(contract.Symbol, contract.Strike, DateTime.MaxValue, optionType, Convert.ToInt32(contract.Multiplier),
                contract.Currency);
        }

        public static Contract ToIbContract(this OptionContract c)
        {
            return new Contract
            {
                Symbol = c.Symbol,
                Right = c.OptionType == OptionType.Call ? "C" : "P",
                Expiry = c.Expiry.ToString("yyyyMMdd"),
                Strike = c.Strike,
                Currency = c.Currency,
                Multiplier = c.Multiplier.ToString(),
                SecType = "OPT",
                Exchange = "SMART"
            };
        }

        public static Order ToIbOrder(this OrderData order, string mainAccount, string orderId)
        {
            var ibOrder = new Order
            {
                //TODO: orderId 0?
                OrderId = Convert.ToInt32(orderId),
                Action = order.OrderAction == OrderAction.Buy ? "BUY" : "SELL",
                OrderType = order.OrderType.ToString().ToUpper(), //"LMT", MKT "MKT PRT" - not suported
                LmtPrice = order.LimitPrice,
                TotalQuantity = order.Quantity,
                Account = mainAccount,
                Tif = "DAY",
                Transmit = true,
                OrderRef = "IB-AutoTrader-Raz",
                WhatIf = order.WhatIf
            };
            return ibOrder;
            
        }
        #region Update Account Summary

        public static void UpdateAccountSummary(this AccountMemberData accountMemberData)
        {
            var propInfo = AccountSummaryDataPropertiesInfoList.FirstOrDefault(pi => pi.Name == accountMemberData.Tag);
            propInfo?.SetValue(AccountSummaryData.AccountSummaryDataObject, Convert.ToDouble(accountMemberData.Values));
        }


        private static List<PropertyInfo> _propertiesInfoList;
        public static IEnumerable<PropertyInfo> AccountSummaryDataPropertiesInfoList
        {
            get
            {
                if (_propertiesInfoList != null) return _propertiesInfoList;

                var type = typeof(AccountSummaryData);
                _propertiesInfoList = type.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
                return _propertiesInfoList;
            }
        } 
        #endregion
    }
}
