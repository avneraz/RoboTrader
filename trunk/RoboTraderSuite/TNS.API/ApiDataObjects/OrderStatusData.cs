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
        Filled,
        Cancelled,
        WhatIf,
        Submitted,
        Inactive

    }
    public class OrderStatusData : IMessage
    {
        public OrderStatusData(string orderId, OrderData order)
        {
            OrderId = orderId;
            Order = order;
        }

        public OrderData Order { get;  }
        public EapiDataTypes APIDataType => EapiDataTypes.OrderStatus;
        public OrderStatus OrderStatus { get; set; }
        public string OrderId { get;  }
        public double MaintMargin { get; set; }

    }
}
