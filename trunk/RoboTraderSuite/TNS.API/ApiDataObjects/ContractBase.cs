using System;
using System.Security.Authentication;

namespace TNS.API.ApiDataObjects
{
    public enum SecurityType
    {
        Stock,
        Option,
        Index
    }
    public abstract class ContractBase
    {
        protected ContractBase(string symbol, SecurityType type, 
                    string exchange="SMART", string currency = "USD")
        {
            Symbol = symbol;
            SecurityType = type;
            Currency = currency;
            Exchange = exchange;
        }
        public string Symbol { get; set; }
        public SecurityType SecurityType { get; set; }
        public string Currency { get; set; }

        public string Exchange { get; set; }

    }

 
}
