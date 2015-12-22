using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.Global.Enum
{
    /// <summary>
    /// Represents the choosen algorithm for trading<para></para>
    /// Unknown = 0, ThetaOnMoney = 1, ThetaOTM = 2.
    /// </summary>
    public enum EAlgorithmType
    {
        Unknown = 0,
        ThetaOnMoney = 1,
        /// <summary>
        ///  OUT OF THE MONEY
        /// </summary>
        ThetaOTM = 2,

        ThetaOTMVolatilityCompensation = 3,
    }
}
