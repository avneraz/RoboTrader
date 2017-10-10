using System;
using System.Collections.Generic;
using TNS.API.ApiDataObjects;
using TNS.BL.DataObjects;

namespace TNS.BL.Interfaces
{
    public interface IOrdersManager: IUnlBaseMemberManager
    {
        Dictionary<string, OrderStatusData> OrderStatusDataDic { get; }
        OrderData BuyOption(OptionData optionData, int quantity);
        OrderData SellOption(OptionData optionData,  int quantity);
        OrderData TestTrading(TradeOrderData tradeOrderData);
        void CancelOrder(string orderId);

        /// <summary>
        /// The method used by the OptionNegotiator when the order task accomplished.
        /// </summary>
        void SendOrderTaskAccomplished(string orderId, OrderStatus orderStatus);

        event Action<OrderStatus, string> OrderTradingNegotioationWasTerminated;
    }
}