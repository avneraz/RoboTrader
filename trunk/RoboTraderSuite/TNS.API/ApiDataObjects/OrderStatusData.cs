using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBApi;
using Infra.Bus;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    public enum OrderStatus
    {
        //https://www.interactivebrokers.com/en/software/api/apiguide/csharp/orderstatus.htm
        Filled,
        Cancelled,
        WhatIf,
        Submitted,
        Inactive,
        PreSubmitted,
        PendingCancel,
        PendingSubmit


    }
    public class OrderStatusData : ISymbolMessage
    {
        public OrderStatusData(string orderId, OrderData order)
        {
            OrderId = orderId;
            Order = order;
            LastUpdateTime = DateTime.Now;
        }

        public OrderData Order { get;  }
        public EapiDataTypes APIDataType => EapiDataTypes.OrderStatus;
        public string GetSymbolName()
        {
            return Order.Contract.Symbol;
        }

        public OrderStatus OrderStatus { get; set; }
        public string OrderId { get;  }
        public double MaintMargin { get; set; }
        public DateTime LastUpdateTime { get; set; }

        public double Commission { get; set; }


        public override string ToString()
        {
            return $"OrderStatusData: [Order: {Order}, OrderId: {OrderId}, MaintMargin: {MaintMargin}, " +
                   $"Commission - {Commission}, LastUpdateTime: {LastUpdateTime}]";
        }
    }
}
