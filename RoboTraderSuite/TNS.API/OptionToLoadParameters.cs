using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra;
using Infra.Enum;
using Infra.Extensions;
using TNS.API.ApiDataObjects;

namespace TNS.API
{
    /// <summary>
    /// The object contains all the parameters for determining the options 
    /// that will be received from the broker.<para></para>
    /// For each UNL will be a different object
    /// </summary>
    public class OptionToLoadParameters
    {

        public OptionToLoadParameters(BaseSecurityData baseSecurityData)
        {
            BaseSecurityData = baseSecurityData;
            SetMinMaxStrike();
        }
  
        private void SetMinMaxStrike()
        {
           
            double highStrikeRatio = (double)AllConfigurations.AllConfigurationsObject.Session.HighStrikePercentage / 100;

            double factor = (UnlPrice / 2000);

            double strikeThreshold = highStrikeRatio * (1 - factor);

            MinStrike = UnlPrice * (1 - strikeThreshold);
            MaxStrike = UnlPrice * (1 + strikeThreshold);
        }
        public BaseSecurityData BaseSecurityData { get; set; }

        public string Symbol => BaseSecurityData.GetContract().Symbol;

        public double UnlPrice => BaseSecurityData.LastPrice <= 0 ? 150 : BaseSecurityData.LastPrice;

        public int MinDaysToExpiration => AllConfigurations.AllConfigurationsObject.Session.MinimumDaysToExpiration;
        public int MaxDaysToExpiration => AllConfigurations.AllConfigurationsObject.Session.MaxmumDaysToExpiration;


        private double MaxStrike { get; set; }
        
        private double MinStrike { get; set; }

        public int Multiplier => BaseSecurityData.Multiplier;
        /// <summary>
        /// Get or Set the number of request Data for options.
        /// </summary>
        public int RequestOptionMarketDataCount { get;private set; }

        public void IncreamentRequestOptionMarketDataCounter()
        {
            RequestOptionMarketDataCount++;
        }
     

        public OptionContract OptionContractPivotToLoad
        {
            get
            {
                ContractBase contractBase = BaseSecurityData.GetContract();
                OptionContract optionContract = new OptionContract
                {
                    Exchange = contractBase.Exchange,
                    Multiplier = Multiplier,
                    Symbol = contractBase.Symbol,
                    SecurityType = SecurityType.Option,
                    Strike = 0,
                    OptionType = EOptionType.None
                };
                return optionContract;
            }
        }


        /// <summary>
        /// Check if the option is between the striks boundary.
        /// 
        /// </summary>
        /// <param name="optionContract"></param>
        /// <returns></returns>
        public bool IsOptionWithinLoadBoundaries(OptionContract optionContract)
        {
            //Get only Monthly option chain, not weekly!, Every monthly expires at the 3'd friday of the month/
            if (optionContract.Expiry.Equals(optionContract.Expiry.GetThirdFridayOfMonth()) == false)
                return false;
            //Check expiration boundaries:
            if (DateTime.Now.AddDays(MinDaysToExpiration) > optionContract.Expiry)
                return false;
            if (optionContract.Expiry > DateTime.Now.AddDays(MaxDaysToExpiration))
                return false;
            //Check strike boundaries:
            if ((optionContract.Strike > MaxStrike) || (optionContract.Strike < MinStrike))
                return false;

            return true;
        }

        public override string ToString()
        {
            return $"Symbol: {Symbol}, MinDaysToExpiration: {MinDaysToExpiration}," +
                   $" MaxDaysToExpiration: {MaxDaysToExpiration}," +
                   $" MinStrikeToLoad: {MinStrike}, MaxStrikeToLoad: {MaxStrike}," +
                   $" Multiplier: {Multiplier}";
        }
    }
}
