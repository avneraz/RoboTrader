
using Infra.Bus;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    public enum OrderAction
    {
        Buy,
        Sell
    }

    public enum OrderType
    {
        LMT,
        MKT
    }
    public class OrderData : IMessage
    {
        public OrderData(OrderType orderType, OrderAction orderAction, double limitPrice, int quantity)
        {
            OrderType = orderType;
            OrderAction = orderAction;
            LimitPrice = limitPrice;
            Quantity = quantity;
        }
        public EapiDataTypes APIDataType => EapiDataTypes.OrderData;
        public string OrderId { get; set; }
        public OrderType OrderType { get; set; }
        public OrderAction OrderAction { get; set; }
        public double LimitPrice { get; set; }
        public int Quantity { get; set; }
        public bool WhatIf { get; set; } = false;

    }
}
