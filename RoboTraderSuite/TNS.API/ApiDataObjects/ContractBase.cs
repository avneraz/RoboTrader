using System;
using IBApi;
using Infra.Enum;
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
    public abstract class ContractBase : ISymbolMessage
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
        public string Currency { get; }

        public string Exchange { get; set; }

        // public Guid Id { get; set; }

        private string _id;

        public string Id
        {
            get => _id ?? (_id = GetUniqueIdentifier());
            set => _id = value;
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
        /* return Currency.GetHashCode() + SecurityType.GetHashCode()+
                Exchange.GetHashCode() + Symbol.GetHashCode();
        }*/
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
        /// Get indication if now is extended working time by 30 minutes :
        /// ==> between StartTrading - 30 minutes  and EndTrading + 30 minutes!
        /// </summary>
        public bool IsNowExtendedWorkingTime
        {
            get
            {
                DateTime now = DateTime.Now;
                return IsWorkingDay && now >= StartTradingTimeLocal.AddMinutes(-30) && now < EndTradingTimeLocal.AddMinutes(30);
            }
        }
        /// <summary>
        /// Get indication if today is working day for AAPL security.
        /// </summary>
        public bool IsWorkingDay { get; set; }
        public DateTime NextWorkingTime { get; set; }
        public DateTime StartTradingTime { get; set; }
        public DateTime StartTradingTimeLocal { get; set; }
        public DateTime EndTradingTime { get; set; }
        public DateTime EndTradingTimeLocal { get; set; }
        public abstract EapiDataTypes APIDataType { get; }
        public string GetSymbolName()
        {
            return Symbol;
        }

        public ContractBase GetContract()
        {
            return this;
        }
    }

 
}
