using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.Global.Enum
{
    public enum EapiDataTypes
    {
        Unknown = 0,
        ExceptionData = 1,
        AccountSummaryData = 2,
        OptionData = 3,
        PositionData = 4,
        OrderData = 5,
        APIMessageData = 6,
        AccountMemberData = 7,
        SecurityData,
    }
}
