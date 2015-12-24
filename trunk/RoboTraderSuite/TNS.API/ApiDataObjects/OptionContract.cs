using System;

namespace TNS.API.ApiDataObjects
{
    public enum OptionType
    {
        Call,
        Put
    }
    public class OptionContract : ContractBase
    {
        public OptionContract(string symbol, double strike, DateTime expiry, 
            OptionType type, string exchange="SMART", int multiplier = 100, string currency = "USD")
            :base(symbol, SecurityType.Option)
            
        {
            Strike = strike;
            Expiry = expiry;
            OptionType = type;
            Multiplier = multiplier;
            Currency = currency;
            Exchange = exchange;
        }


        public DateTime Expiry { get; set; }
        public double Strike { get; set; }
        public OptionType OptionType { get; set; }
        public int Multiplier { get; set; }

        public override string ToString()
        {
            return $"Expiry: {Expiry}, Strike: {Strike}, OptionType: {OptionType}, Multiplier: {Multiplier}, Currency: {Currency}, Exchange:{Exchange}";
        }
    }
}
