using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDataObjects
{
    public enum OptionType
    {
        Call,
        Put
    }
    public class OptionContract : ContractBase
    {
        public OptionContract(string symbol, double strike, DateTime expiry, OptionType type, int multiplier = 100, string currency = "USD")
            :base(symbol, SecurityType.Option)
            
        {
            Strike = strike;
            Expiry = expiry;
            OptionType = type;
            Multiplier = multiplier;
            Currency = currency;

        }
        public DateTime Expiry { get; set; }
        public double Strike { get; set; }
        public OptionType OptionType { get; set; }
        public int Multiplier { get; set; }
        public string Currency { get; set; }

        public override string ToString()
        {
            return $"Expiry: {Expiry}, Strike: {Strike}, OptionType: {OptionType}, Multiplier: {Multiplier}, Currency: {Currency}";
        }
    }
}
