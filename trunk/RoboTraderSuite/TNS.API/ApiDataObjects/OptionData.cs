using Infra.Bus;
using Infra.Enum;


namespace TNS.API.ApiDataObjects
{
    public class OptionData : BaseSecurityData
    {

        public override EapiDataTypes APIDataType => EapiDataTypes.OptionData;
        public override ContractBase GetContract()
        {
            return OptionContract;
        }

        public override void SetContract(ContractBase contract)
        {
            OptionContract = (OptionContract)contract;
        }

        public virtual OptionContract OptionContract { get; set; }

        public double Delta { get; set; }

        public double Gamma { get; set; }

        public double Vega { get; set; }

        public double Theta { get; set; }

        public double ImpliedVolatility { get; set; }
      
        public double ModelPrice { get; set; }

        public double UnderlinePrice { get; set; }


        public virtual string GetOptionKey()
        {
            return $"{OptionContract.Expiry}.{OptionContract.OptionType}.{OptionContract.Strike}";
        }

        //public virtual string OptionKey { get; set; }

        public override string ToString()
        {
            return $"OptionData : [{base.ToString()},  Delta: {Delta}, Gamma:" +
                   $" {Gamma}, Vega: {Vega}, Theta: {Theta}, ImpliedVolatility: {ImpliedVolatility}," +
                   $" ModelPrice: {ModelPrice}]";
        }
    }
}
