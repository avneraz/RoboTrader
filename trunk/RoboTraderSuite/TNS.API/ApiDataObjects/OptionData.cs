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

        public override string ToString()
        {
            return $"{base.ToString()}, Contract: {Contract}, Delta: {Delta}, Gamma:" +
                   $" {Gamma}, Vega: {Vega}, Theta: {Theta}, ImpliedVolatility: {ImpliedVolatility}," +
                   $" ModelPrice: {ModelPrice}";
        }
    }
}
