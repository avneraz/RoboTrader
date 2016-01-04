using System;
using System.Collections.Generic;
using TNS.API.ApiDataObjects;

namespace TNS.BL.Interfaces
{
    public interface IOrdersManager: IUnlBaseMemberManager
    {
        Dictionary<string, OrderStatusData> OrderStatusDataDic { get; }
        OrderData BuyOption(OptionData optionData, double limitPrice, int quantity);
        OrderData SellOption(OptionData optionData, double limitPrice, int quantity);
        OrderData TestTrading(bool sell);

        event Action<OrderStatusData> OrderStatusDataUpdated;
    }
}