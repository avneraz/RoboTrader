using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Enum
{
    /// <summary>
    /// Determines the start mode of the trading
    /// </summary>
    public enum ETradingStartMode
    {
        Unknown = 0,
        /// <summary>
        /// Start by user
        /// </summary>
        Manual = 1,

        /// <summary>
        /// Start automatically by the AutoTrader according the start trading time.
        /// </summary>
        Auto = 2
    }
}
