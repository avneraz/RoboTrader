

namespace Infra.Enum
{
    /// <summary>
    /// Describes the trading state of the UNL trading.
    /// </summary>
    public enum ETradingState
    {
        /// <summary>
        /// The default value, the ENUM didn't set yet.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// The UNL trading is live and active, but in idle state, no trading done on it. value = 10.
        /// </summary>
        ActiveNoTrading = 10,

        /// <summary>
        /// The  UNL trading  is on trading. value = 100.
        /// </summary>
        OnTrading = 100,

        /// <summary>
        /// The UNL trading is on close all positions. value = 1000.
        /// </summary>
        OnClosePositionsTrading = 1000,
    }
}
