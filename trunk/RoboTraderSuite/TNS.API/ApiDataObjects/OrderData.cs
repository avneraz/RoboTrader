
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
        public ContractBase Contract { get; set; }
        public EapiDataTypes APIDataType => EapiDataTypes.OrderData;
        public string OrderId { get; set; }
        public OrderType OrderType { get; set; }
        public OrderAction OrderAction { get; set; }
        public double LimitPrice { get; set; }
        public int Quantity { get; set; }
        public bool WhatIf { get; set; } = false;

        public override string ToString()
        {
            return $"OrderData: [Contract: {Contract},  OrderId: {OrderId}," +
                   $" OrderType: {OrderType}, OrderAction: {OrderAction}," +
                   $" LimitPrice: {LimitPrice}, Quantity: {Quantity}, WhatIf: {WhatIf}]";
        }
    }
}
