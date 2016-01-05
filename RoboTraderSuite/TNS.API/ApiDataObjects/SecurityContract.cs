using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.API.ApiDataObjects
{
    public class SecurityContract : ContractBase
    {
        public SecurityContract()
        {
            
        }
        public SecurityContract(string symbol, SecurityType securityType,
            string exchange = "SMART", string currency = "USD") : base(symbol, securityType, exchange, currency)
        {
        }

        public override string GetUniqueIdentifier()
        {
            return $"{Exchange}.{Symbol}"; 
            //return $"test2"; 
        }
    }
}
