using Infra.Bus;
using Infra.Enum;


namespace TNS.API.ApiDataObjects
{
    public class OptionData : SecurityData
    {

        public override EapiDataTypes APIDataType => EapiDataTypes.OptionData;
        public OptionContract OptionContract => Contract as OptionContract;

        public double Delta { get; set; }

        public double Gamma { get; set; }

        public double Vega { get; set; }

        public double Theta { get; set; }

        public double ImpliedVolatility { get; set; }
      
        public double ModelPrice { get; set; }

        public string OptionKey => $"{OptionContract.Expiry}.{OptionContract.OptionType}.{OptionContract.Strike}";

        public override string ToString()
        {
            return $"OptionData : [{base.ToString()},  Delta: {Delta}, Gamma:" +
                   $" {Gamma}, Vega: {Vega}, Theta: {Theta}, ImpliedVolatility: {ImpliedVolatility}," +
                   $" ModelPrice: {ModelPrice}]";
        }
    }
}
