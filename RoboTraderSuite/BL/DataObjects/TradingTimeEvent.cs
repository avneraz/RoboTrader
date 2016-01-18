using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Bus;
using Infra.Enum;

namespace TNS.BL.DataObjects
{
    /// <summary>
    /// Encapsulates the data of the trading time event.
    /// </summary>
    public class TradingTimeEvent:IMessage
    {
        public TradingTimeEvent(ETradingTimeEventType tradingTimeEventType)
        {
            TradingTimeEventType = tradingTimeEventType;
        }

        public EapiDataTypes APIDataType => EapiDataTypes.TradingTimeEvent;

        public ETradingTimeEventType TradingTimeEventType { get; }
        public DateTime EventTime { get; set; }
        public bool  Done { get; set; }
    }
}
