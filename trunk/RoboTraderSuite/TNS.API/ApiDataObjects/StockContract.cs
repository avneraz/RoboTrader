using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.API.ApiDataObjects
{
    public class StockContract : ContractBase
    {
        public StockContract(string symbol, 
            string exchange = "SMART", string currency = "USD") : base(symbol, SecurityType.Stock, exchange, currency)
        {
        }
    }
}
