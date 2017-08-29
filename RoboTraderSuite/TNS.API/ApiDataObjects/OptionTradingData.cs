using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.API.ApiDataObjects
{
    /// <summary>
    /// The object centers all trading information on this option.
    /// </summary>
    public class OptionTradingData
    {
        public OptionTradingData(OptionData optionData, UnlOptions unlOptions)
        {
            OptionData = optionData;
            UnlOptions = unlOptions;
        }

        /// <summary>
        /// The current option data
        /// </summary>
        public OptionData OptionData { get; }
        /// <summary>
        /// The data of selling the option
        /// </summary>
        public UnlOptions UnlOptions { get; }
        public string Symbol => OptionData.Symbol;
        public double CurrentPrice => OptionData.CalculatedOptionPrice;
        public double SellPrice => UnlOptions.OpenTransaction.LastPrice;
        public double PNL => SellPrice - CurrentPrice;
        /// <summary>
        /// The change of the IV between sell and now, in percetage.
        /// </summary>
        public double IVChange => 100 * (OptionData.ImpliedVolatility - UnlOptions.IV);
        public double DeltaChange => OptionData.Multiplier * (OptionData.Delta - UnlOptions.OptionData.Delta);
        public double ThetaChange => OptionData.Multiplier * (OptionData.Theta - UnlOptions.OptionData.Theta);
        public double GammaChange => OptionData.Multiplier * (OptionData.Gamma - UnlOptions.OptionData.Gamma);
        public double VegaChange => OptionData.Multiplier * (OptionData.Vega - UnlOptions.OptionData.Vega);
        public int DiffDays => OptionData.DaysLeft - UnlOptions.OptionData.DaysLeft;

    }
}
