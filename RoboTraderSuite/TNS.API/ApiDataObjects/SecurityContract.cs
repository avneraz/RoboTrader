using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Bus;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    public class SecurityContract : ContractBase, ISymbolMessage
    {
        public SecurityContract()
        {
            
        }
        public SecurityContract(string symbol, SecurityType securityType,
            string exchange = "SMART", string currency = "USD") : base(symbol, securityType, exchange, currency)
        {
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
        public bool IsWorkingDay { get; set; }
        public DateTime NextWorkingDay { get; set; }
        public DateTime StartTradingTime { get; set; }
        public DateTime StartTradingTimeLocal { get; set; }
        public DateTime EndTradingTime { get; set; }
        public DateTime EndTradingTimeLocal { get; set; }

        public override string GetUniqueIdentifier()
        {
            return $"{Exchange}.{Symbol}"; 
        }

        public EapiDataTypes APIDataType => EapiDataTypes.SecurityContract;

        public string GetSymbolName()
        {
            return base.Symbol;
        }

        public ContractBase GetContract()
        {
            return this;
        }
    }
}
