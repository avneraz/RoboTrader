using Infra.Bus;
using Infra.Enum;


namespace TNS.API.ApiDataObjects
{
    public class OptionData : SecurityData
    {
        public OptionData()
        {
            APIDataType = EapiDataTypes.OptionData;
        }

        //public EapiDataTypes APIDataType => EapiDataTypes.OptionData;
        public new OptionContract Contract { get; set; }

        public double Delta { get; set; }

        public double Gamma { get; set; }

        public double Vega { get; set; }

        public double Theta { get; set; }

        public double ImpliedVolatility { get; set; }
      
        public double ModelPrice { get; set; }
      
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
