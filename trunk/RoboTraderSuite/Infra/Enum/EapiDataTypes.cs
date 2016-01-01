using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Enum
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
        SecurityData = 7,
        OrderStatus = 8,
        BrokerConnectionStatus,
        RequestDataReceived,
    }
}
