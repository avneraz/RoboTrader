using System;
using System.Security.Authentication;
using IBApi;
using TNS.API.IBApiWrapper;

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
        public string Symbol { get;  }
        public SecurityType SecurityType { get;  }
        public string Currency { get;  }

        public string Exchange { get;  }

        public virtual Contract ToIbContract()
        {
            return new Contract
            {
                Symbol = Symbol,
                Currency = Currency,
                SecType = IBExtensions.GetSecType(SecurityType),
                Exchange = Exchange
            };
        }

        public override string ToString()
        {
            return $"Symbol: {Symbol}, SecurityType: {SecurityType}, Currency: {Currency}, Exchange: {Exchange}";
        }


        public override bool Equals(object obj)
        {
            var otherContract = obj as ContractBase;
            if (otherContract == null)
                return false;
            return otherContract.Currency == Currency && otherContract.SecurityType == SecurityType
                   && otherContract.Exchange == Exchange && otherContract.Symbol == Symbol;
        }

        public override int GetHashCode()
        {
            return Currency.GetHashCode() + SecurityType.GetHashCode()+
                Exchange.GetHashCode() + Symbol.GetHashCode();
        }
    }

 
}
