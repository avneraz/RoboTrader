using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Enum;
using Infra.Bus;

namespace TNS.API.ApiDataObjects
{
    public class SecurityData : IMessage
    {

        public virtual EapiDataTypes APIDataType => EapiDataTypes.SecurityData;
        /// <summary>
        /// Index or underline data (symbol, currency, etc.)
        /// </summary>
        public ContractBase Contract { get; set; }

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
        /// Open quote (current day)
        /// </summary>
        public double BasePrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double OpeningPrice { get; set; }

        /// <summary>
        /// Price a seller is willing to accept for a security
        /// </summary>
        public double AskPrice { get; set; }

        /// <summary>
        /// An offer made by an investor, a trader or a dealer to buy a security
        /// </summary>
        public double BidPrice { get; set; }

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

        public string Symbol => Contract.Symbol;

        public override string ToString()
        {
            return 
            $"SecurityData: [Contract: {Contract}, LastPrice: {LastPrice}," +
            $" AskPrice: {AskPrice}, BidPrice: {BidPrice}," +
            $" HighestPrice: {HighestPrice}, LowestPrice: {LowestPrice}," +
            $" BasePrice: {BasePrice}, OpeningPrice: {OpeningPrice}, " +
            $" AskSize: {AskSize}, BidSize: {BidSize}, Volume: {Volume}]";

        }
    }
}
