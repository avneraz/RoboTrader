using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Enum
{
    /// <summary>
    /// Describes the various events of the trading. 
    /// </summary>
    public enum ETradingTimeEventType
    {
        Unknown = 0,
        StartTrading,
        EndTradingIn30Seconds,
        EndTradingIn60Seconds,
        EndTrading,

    }

}
