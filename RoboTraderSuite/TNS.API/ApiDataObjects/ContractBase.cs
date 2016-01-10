using System;
using System.Security.Authentication;
using IBApi;
using TNS.API.IBApiWrapper;

namespace TNS.API.ApiDataObjects
{
    /// <summary>
    /// = Stock, Option, Index
    /// </summary>
    public enum SecurityType
    {
        Stock,
        Option,
        Index
    }
    /// <summary>
    /// Contains data about: ## Symbol, SecurityType, Currency and Exchange. ##
    /// </summary>
    public abstract class ContractBase
    {
        protected ContractBase()
        {
            
        }
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

        // public Guid Id { get; set; }

        private string _id;

        public string Id
        {
            get { return _id ?? (_id = GetUniqueIdentifier()); }
            set { _id = value; }
        }

       
        public abstract string GetUniqueIdentifier();

        public virtual Contract ToIbContract()
        {
            return new Contract
            {
                Symbol = Symbol,
                Currency = Currency,
                SecType = IBExtensions.GetSecType(SecurityType),
                Exchange = Exchange,
                Expiry = "",
            };
        }

        public override string ToString()
        {
            return $"ContractBase: [Symbol: {Symbol}, SecurityType: {SecurityType}, Currency: " + $"{Currency}, Exchange: {Exchange}]";
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
