using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Enum;
using Infra.Bus;

namespace TNS.API.ApiDataObjects
{
    public abstract class BaseSecurityData : ISymbolMessage
    {

        public virtual EapiDataTypes APIDataType => EapiDataTypes.SecurityData;
        public virtual string GetSymbolName()
        {
            return GetContract().Symbol;
        }

        public string Account { get; set; }
        /// <summary>
        /// Index or underline data (symbol, currency, etc.)
        /// </summary>
        /// 
        public abstract ContractBase GetContract();
        public abstract void SetContract(ContractBase contract);

        /// <summary>
        /// Final price at which the security was traded (current day)
        /// </summary>
        public double LastPrice { get; set; }

        /// <summary>
        /// Highest price made for the security (current day)
        /// </summary>
        public double HighestPrice { get; set; }

        /// <summary>
        /// Lowest price made for the security (current day)
        /// </summary>
        public double LowestPrice { get; set; }

        /// <summary>
        /// Prior Close underline price
        /// </summary>
        public double PriorClosePrice { get; set; }

        /// <summary>
        /// The first price of the day. on opening trading.
        /// </summary>
        public double OpeningPrice { get; set; }

        public double Change
        {
            get => (LastPrice - PriorClosePrice) / PriorClosePrice;
            set
            {
                if (value < - int.MaxValue) throw new NotImplementedException();
            }
        }

        /// <summary>
        /// LastPrice a seller is willing to accept for a security
        /// </summary>
        public double Ask { get; set; }

        /// <summary>
        /// An offer made by an investor, a trader or a dealer to buy a security
        /// </summary>
        public double Bid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double AskSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double BidSize { get; set; }

        /// <summary>
        /// The number of shares or contracts traded in the security (current day)
        /// </summary>
        public double Volume { get; set; }

        public int Multiplier { get; set; } = 100;//TODO add it from the mainsecurity load from DB

        public virtual Guid Id { get; private set; }

        public DateTime LastUpdate { get; set; }

        public override string ToString()
        {
            return 
            $"SecurityData: [Contract: {GetContract()}, LastPrice: {LastPrice}," +
            $" Ask: {Ask}, Bid: {Bid}," +
            $" HighestPrice: {HighestPrice}, LowestPrice: {LowestPrice}," +
            $" PriorClosePrice: {PriorClosePrice}, OpeningPrice: {OpeningPrice}, " +
            $" AskSize: {AskSize}, BidSize: {BidSize}, Volume: {Volume}]";

        }
    }
}
