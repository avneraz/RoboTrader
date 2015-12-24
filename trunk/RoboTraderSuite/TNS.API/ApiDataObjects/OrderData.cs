
using IBApi;
using Infra.Bus;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    public enum OrderAction
    {
        BUY,
        SELL
    }

    public enum OrderType
    {
        LMT,
        MKT
    }
    public class OrderData : IMessage
    {
        public OrderData(OrderType orderType, OrderAction orderAction, double limitPrice, int quantity, 
            ContractBase contract)
        {
            OrderType = orderType;
            OrderAction = orderAction;
            LimitPrice = limitPrice;
            Quantity = quantity;
            Contract = contract;
        }

        public ContractBase Contract { get; set; }
        public EapiDataTypes APIDataType => EapiDataTypes.OrderData;
        public string OrderId { get; set; }
        public OrderType OrderType { get; set; }
        public OrderAction OrderAction { get; set; }
        public double LimitPrice { get; set; }
        public int Quantity { get; set; }
        public bool WhatIf { get; set; } = false;

    }
}
