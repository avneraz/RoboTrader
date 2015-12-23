using TNS.Global.Bus;
using TNS.Global.Enum;


namespace TNS.API.ApiDataObjects
{
    public class OptionData : IMessage
    {

        public EapiDataTypes APIDataType => EapiDataTypes.OptionData;
        public OptionContract Contract { get; set; }
        public double LastPrice { get; set; }
        public double AskPrice { get; set; }

        public double BidPrice { get; set; }

        public double Delta { get; set; }

        public double Gamma { get; set; }

        public double Vega { get; set; }

        public double Theta { get; set; }

        public double ImpliedVolatility { get; set; }
        public double HighestPrice { get; set; }

        public double LowestPrice { get; set; }

        public double BasePrice { get; set; }

        public double OpeningPrice { get; set; }

        public double ModelPrice { get; set; }

        public double AskSize { get; set; }
        public double BidSize { get; set; }
        public double Volume { get; set; }


        public override string ToString()
        {
            return $"Contract: {Contract}, LastPrice: {LastPrice}," +
                   $" AskPrice: {AskPrice}, BidPrice: {BidPrice}," +
                   $" Delta: {Delta}, Gamma: {Gamma}, Vega: {Vega}," +
                   $" Theta: {Theta}, ImpliedVolatility: {ImpliedVolatility}," +
                   $" HighestPrice: {HighestPrice}, LowestPrice: {LowestPrice}," +
                   $" BasePrice: {BasePrice}, OpeningPrice: {OpeningPrice}, " +
                   $"ModelPrice: {ModelPrice}, AskSize: {AskSize}, BidSize: {BidSize}, Volume: {Volume}";
        }
    }
}
