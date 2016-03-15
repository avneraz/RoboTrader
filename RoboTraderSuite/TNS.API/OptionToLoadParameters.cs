using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra;
using Infra.Enum;
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
        }

        public BaseSecurityData BaseSecurityData { get; set; }
        public string Symbol => BaseSecurityData.GetContract().Symbol;
        public double UnlPrice => BaseSecurityData.LastPrice;
        public int MinDaysToExpiration => AllConfigurations.AllConfigurationsObject.Session.MinimumDaysToExpiration;
        public int MaxDaysToExpiration => AllConfigurations.AllConfigurationsObject.Session.MaxmumDaysToExpiration;
        public double CallMinStrike => (UnlPrice * (1 - (double)(AllConfigurations.AllConfigurationsObject.Session.HighStrikePercentage) / 100));
        public double CallMaxStrike => (UnlPrice * (1 + (double)(AllConfigurations.AllConfigurationsObject.Session.LowStrikePercentage) / 100));
        public double PutMaxStrike =>  (UnlPrice * (1 + (double)(AllConfigurations.AllConfigurationsObject.Session.HighStrikePercentage) / 100));
        public double PutMinStrike =>  (UnlPrice * (1 - (double)(AllConfigurations.AllConfigurationsObject.Session.LowStrikePercentage) / 100));
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
        /// Check if the option is between the time boundary.
        /// 
        /// </summary>
        /// <param name="optionContract"></param>
        /// <returns></returns>
        public bool IsOptionWithinLoadBoundaries(OptionContract optionContract)
        {

            //Check expiration boundaries:
            if (DateTime.Now.AddDays(MinDaysToExpiration) > optionContract.Expiry)
                return false;
            if (optionContract.Expiry > DateTime.Now.AddDays(MaxDaysToExpiration))
                return false;

            //Check strike boundaries:
            switch (optionContract.OptionType)
            {
                case EOptionType.Call:
                    if (optionContract.Strike > CallMaxStrike)
                        return false;
                    if (optionContract.Strike < CallMinStrike)
                        return false;
                    break;
                case EOptionType.Put:
                    if (optionContract.Strike > PutMaxStrike)
                        return false;
                    if (optionContract.Strike < PutMinStrike)
                        return false;
                    break;
                default:
                    return false;
            }
            return true;
        }

        public override string ToString()
        {
            return $"Symbol: {Symbol}, MinDaysToExpiration: {MinDaysToExpiration}," +
                   $" MaxDaysToExpiration: {MaxDaysToExpiration}," +
                   $" CallMinStrike: {CallMinStrike}, CallMaxStrike: {CallMaxStrike}," +
                   $" PutMaxStrike: {PutMaxStrike}, PutMinStrike: {PutMinStrike}, Multiplier: {Multiplier}";
        }
    }
}
