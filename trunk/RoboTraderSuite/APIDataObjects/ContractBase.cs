using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDataObjects
{
    public enum SecurityType
    {
        Stock,
        Option,
        Index
    }
    public abstract class ContractBase
    {
        protected ContractBase(string symbol, SecurityType type)
        {
            Symbol = symbol;
            SecurityType = type;
        }
        public string Symbol { get; set; }
        public SecurityType SecurityType { get; set; }

    }
}
