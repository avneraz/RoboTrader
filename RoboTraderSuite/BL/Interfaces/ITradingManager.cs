using System;
using TNS.API.ApiDataObjects;
using TNS.BL.DataObjects;

namespace TNS.BL.Interfaces
{
    public interface ITradingManager : IUnlBaseMemberManager
    {
        AccountSummaryData AccountSummaryData { get; set; }
        void TestTrading(TradeOrderData tradeOrderData);

        void CloseShortPositions(DateTime? expiryDate);

        void CloseEntireShortPositions();
        void CloseMateCouples(int cuoplesCount, DateTime expiryDate);
        void OptimizePositions(DateTime expiryDate);

        /// <summary>
        /// Sell Mate couple, Put and Call ATM.
        /// </summary>
        /// <param name="cuoplesCount"></param>
        /// <param name="expiryDate"></param>
        void SellMateCouples(int cuoplesCount, DateTime expiryDate);
        /// <summary>
        /// Optimize position for some mate couple.
        /// </summary>
        /// <param name="expiryDate"></param>
        /// <param name="mateCoupleCount"></param>
        void PerformPartialOptimization(DateTime expiryDate, int mateCoupleCount);

        event Action<TradingTimeEvent> SendTradingTimeEvent;
        event Action PositionNeedToOptimized;
    }
}