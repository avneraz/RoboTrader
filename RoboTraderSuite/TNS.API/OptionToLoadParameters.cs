using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra;
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
        ////TODO ==> TAKE THE CONST FROM CONFIGURATION:
        ///// <summary>
        /////  = 5%;
        ///// </summary>
        //private const int HIGH_STRIKE_PRECENTAGE = 10;
        ///// <summary>
        /////   = 15%;
        ///// </summary>
        //private const int LOW_STRIKE_PRECENTAGE = 20;
        ///// <summary>
        ///// = 15 days.
        ///// </summary>
        //private const int MIN_DAYS_TO_EXPIRATION = 20;
        ///// <summary>
        ///// = 60 days
        ///// </summary>
        //private const int MAX_DAYS_TO_EXPIRATION = 60;
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
        public double AtTheMoneyStrike
        {
            get
            {
                if (_atTheMoneyStrike != null) return _atTheMoneyStrike.Value;

                _atTheMoneyStrike = (int)Math.Round(BaseSecurityData.LastPrice / 10, 0, MidpointRounding.AwayFromZero) * 10;
                return _atTheMoneyStrike.Value;
            }
        }
        private double? _atTheMoneyStrike;
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
                    Strike = AtTheMoneyStrike,
                    OptionType = OptionType.Call
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
                
                case OptionType.Call:
                    if (optionContract.Strike > CallMaxStrike)
                        return false;
                    if (optionContract.Strike < CallMinStrike)
                        return false;
                    break;
                case OptionType.Put:
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
