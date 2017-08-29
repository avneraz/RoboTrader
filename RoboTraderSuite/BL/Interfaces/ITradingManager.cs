using System;
using TNS.API.ApiDataObjects;
using TNS.BL.DataObjects;

namespace TNS.BL.Interfaces
{
    public interface ITradingManager : IUnlBaseMemberManager
    {
        AccountSummaryData AccountSummaryData { get; set; }
        void TestTrading(TradeOrderData tradeOrderData);

        event Action<TradingTimeEvent> SendTradingTimeEvent;
    }
}