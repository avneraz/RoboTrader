using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Bus;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    public class ContractDetailsData: ContractBase, IMessage
    {
        public ContractDetailsData(string symbol, SecurityType type, 
            string exchange = "SMART", string currency = "USD") 
            : base(symbol, type, exchange, currency)
        {
            APIDataType = EapiDataTypes.ContractDetailsData;
        }

        /// <summary>
        /// Check if the time on local is working time for AAPL trading
        /// </summary>
        public bool IsNowWorkingTime
        {
            get
            {
                DateTime now = DateTime.Now;

                return IsWorkingDay && now >= StartTradingTimeLocal && now < EndTradingTimeLocal;
            }
        }
        /// <summary>
        /// Get indication if today is working day for AAPL security.
        /// </summary>
        public bool IsWorkingDay { get;  set; }
        public DateTime NextWorkingDay { get; set; }
        public DateTime StartTradingTime { get; set; }
        public DateTime StartTradingTimeLocal { get; set; }
        public DateTime EndTradingTime { get; set; }
        public DateTime EndTradingTimeLocal { get; set; }
        public EapiDataTypes APIDataType { get; }

        public override string GetUniqueIdentifier()
        {
            throw new NotImplementedException();
        }
    }
}
