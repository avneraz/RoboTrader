using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.Global.Enum;
using TNS.Global.Bus;

namespace TNS.API.ApiDataObjects
{
    public class SecurityData : IMessage
    {
        public SecurityData()
        {
            APIDataType = EapiDataTypes.SecurityData;
        }

        public EapiDataTypes APIDataType { get; set; }
        public ContractBase Contract { get; set; }
        public double LastPrice { get; set; }
        public double AskPrice { get; set; }

        public double BidPrice { get; set; }

        public double HighestPrice { get; set; }

        public double LowestPrice { get; set; }

        public double BasePrice { get; set; }

        public double OpeningPrice { get; set; }
        public double AskSize { get; set; }
        public double BidSize { get; set; }
        public double Volume { get; set; }

        public string Symbol => Contract.Symbol;

        public override string ToString()
        {
            return 
            $"Contract: {Contract}, LastPrice: {LastPrice}," +
            $" AskPrice: {AskPrice}, BidPrice: {BidPrice}," +
            $" HighestPrice: {HighestPrice}, LowestPrice: {LowestPrice}," +
            $" BasePrice: {BasePrice}, OpeningPrice: {OpeningPrice}, " +
            $" AskSize: {AskSize}, BidSize: {BidSize}, Volume: {Volume}";

        }
    }
}
