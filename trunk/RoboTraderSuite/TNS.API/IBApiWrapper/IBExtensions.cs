using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using IBApi;
using TNS.API.ApiDataObjects;

namespace TNS.API.IBApiWrapper
{
    public static class IBExtensions
    {
        public static ContractBase ToContract(this Contract contract)
        {
            switch (contract.SecType)
            {
                case "OPT":
                    var optionType = contract.Right == "C" ? OptionType.Call : OptionType.Put;
                    return new OptionContract(contract.Symbol, contract.Strike, GetExpiryDate(contract.Expiry), optionType,
                        contract.Exchange, Convert.ToInt32(contract.Multiplier), contract.Currency);
                case "STK":
                    return new StockContract(contract.Symbol);
                default:
                    throw new Exception("Invalid contract type received " +  contract.SecType);
            }
     }

      
        private static DateTime GetExpiryDate(string expDateStr)
        {
            if (string.IsNullOrEmpty(expDateStr))
                return DateTime.MinValue;
            DateTime expiryDate = DateTime.ParseExact(expDateStr, "yyyyMMdd", 
                        CultureInfo.CurrentCulture, DateTimeStyles.None);
            return expiryDate;
        }
        public static string GetSecType(SecurityType type)
        {
            switch (type)
            {
                case SecurityType.Stock:
                    return "STK";
                case SecurityType.Option:
                    return "OPT";
                case SecurityType.Index:
                    return "IND";
                default:
                    return string.Empty;
            }
        }

        public static Contract ToIbMainSecurityContract(this ContractBase msContract)
        {
            return new Contract
            {
                Symbol = msContract.Symbol,
                Currency = msContract.Currency,
                SecType = GetSecType(msContract.SecurityType),
                Exchange = msContract.Exchange
            };
        }
        public static Order ToIbOrder(this OrderData order, string mainAccount, string orderId)
        {
            var ibOrder = new Order
            {
                OrderId = Convert.ToInt32(orderId),
                Action = order.OrderAction == OrderAction.BUY ? "BUY" : "SELL",
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

        public static OrderData ToOrderData(this Order order)
        {
            return new OrderData((OrderType)Enum.Parse(typeof (OrderType), order.OrderType),
                (OrderAction)Enum.Parse(typeof (OrderAction), order.Action),
                order.LmtPrice, order.TotalQuantity, null);
        }
       
    }
}
