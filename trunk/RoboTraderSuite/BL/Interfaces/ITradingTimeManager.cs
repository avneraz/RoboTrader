using System;
using TNS.API.ApiDataObjects;

namespace TNS.BL.Interfaces
{
    public interface ITradingTimeManager : IUnlBaseMemberManager
    {
        void ScheduleTradingEndWorkingEventAsync();
        void ScheduleTradingStartWorkingEventAsync();
        event Action Trading30SecondsToEnd;
        event Action Trading60SecondsToEnd;
        event Action TradingEnd;
        event Action TradingStart;
        ContractDetailsData ContractDetailsData { get; set; }

        /// <summary>
        /// Get indication if today is working day for AAPL security.
        /// </summary>
        bool IsWorkingDay { get; }

        /// <summary>
        /// Check if the time on local is working time for AAPL trading
        /// </summary>
        bool IsNowWorkingTime { get; }

        DateTime EndTradingTime { get; }
        DateTime EndTradingTimeLocal { get; }
        DateTime NextWorkingDay { get; }
        DateTime StartTradingTimeLocal { get; }
    }
}