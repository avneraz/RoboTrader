using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra;
using Infra.Enum;
using TNS.API.ApiDataObjects;

namespace TNS.BL.DataObjects
{
    public class BnSCalculationData
    {
        public BnSCalculationData(string symbol, EOptionType optionType)
        {
            Symbol = symbol;
            OptionType = optionType;
            ResultDataValues = new ResultData();
        }

        

        public BnSCalculationData(ParametersForCalc parametersForCalc)
                
        {
            Symbol = parametersForCalc.Symbol;
            OptionType = parametersForCalc.OptionType;
            StockPrice = parametersForCalc.StockPrice;
            Strike = parametersForCalc.OptionPrice;
            DayLeftsOriginal = parametersForCalc.DaysLeftToExpiry;
            Multiplier = parametersForCalc.Multiplier;
            IVChange = parametersForCalc.IVChange;
            DaysLeftChange = parametersForCalc.DaysLeftChange;
            ImpliedVolatilitiesBase = parametersForCalc.ImpliedVolatilitiesBase;
            // parametersForCalc.
            ResultDataValues = new ResultData();
           
        }

        public BnSCalculationData(string symbol, EOptionType optionType, double stockPrice, double strike,
            int dayLeftsOriginal, int multiplier = 100)
        {
            Symbol = symbol;
            OptionType = optionType;
            StockPrice = stockPrice;
            Strike = strike;
            DayLeftsOriginal = dayLeftsOriginal;
            ResultDataValues = new ResultData();
            Multiplier = multiplier;
        }

        public BnSCalculationData(OptionData optionData, double calculatedIV)
        {
            Symbol = optionData.OptionContract.Symbol;
            OptionType = optionData.OptionContract.OptionType;
            StockPrice = optionData.UnderlinePrice;
            Strike = optionData.OptionContract.Strike;
            DayLeftsOriginal = optionData.DaysLeft;
            ImpliedVolatilitiesBase = calculatedIV;
            Multiplier = optionData.Multiplier;
            ResultDataValues = new ResultData();
        }

        /// <summary>
        /// The associated underline symbol
        /// </summary>
        public string Symbol { get; set; }

        public EOptionType OptionType { get; set; }

       
        public double StockPrice { get; set; }

        public double Strike { get; set; }

        public double BaseOptionPrice { get; set; }

        public int DayLeftsOriginal { get; set; }
        public int DayLeftsForCalc => DayLeftsOriginal - DaysLeftChange;
        /// <summary>
        /// Get or Set the change on the left daye to expiry.
        /// </summary>
        public int DaysLeftChange { get; set; }

        /// <summary>
        /// Get or Set the change on the IV
        /// </summary>
        public double IVChange { get; set; }

        public double ImpliedVolatilitiesForCalc => ImpliedVolatilitiesBase + IVChange;

        /// <summary>
        /// Gets or sets the base implied volatilities that calculated from the current option price.
        /// </summary>
        /// <value>
        /// The implied volatilities base.
        /// </value>
        public double ImpliedVolatilitiesBase { get; set; }

        //public double IVChange { get; set; }

        public double RiskFreeInterestRate => AllConfigurations.AllConfigurationsObject.Trading.RiskFreeInterestRate;

        public ResultData ResultDataValues { get; }

        public double Cost { get; set; }

        public double PnL => (Cost + PositionPrice);


        public int Position { get; set; }

        public int Quantity => Math.Abs(Position);

        public int PositionActual => Position == 0 ? 1 : Position;
        public double DeltaTotal => ResultDataValues.Delta * PositionActual;

        public double GammaTotal => ResultDataValues.Gamma * PositionActual;

        public double ThetaTotal => ResultDataValues.Theta * PositionActual;

        public double VegaTotal => ResultDataValues.Vega * PositionActual;

        public double PositionPrice => ResultDataValues.OptionPrice * PositionActual;

        public double Delta => DeltaTotal / Position / Multiplier;

        public double Gamma => GammaTotal / Position / Multiplier;

        public double Theta => ThetaTotal / Position / Multiplier;

        public int Multiplier { get; set; }

        public class ResultData
        {
            public double OptionPrice { get; set; }

            public double Delta { get; set; }

            public double Gamma { get; set; }

            public double Theta { get; set; }

            public double Vega { get; set; }
        }
    }

    public struct ParametersForCalc
        {
            public ParametersForCalc(OptionData optionData, int daysLeftChange = 0, double ivChange = 0) : this()
            {
                SetParameters(optionData, daysLeftChange,ivChange);
            }

            public string Symbol { get; set; }

            public EOptionType OptionType { get; set; }

            public double StockPrice { get; set; }

            public double OptionPrice { get; set; }

            public double Strike { get; set; }

            public int DaysLeftToExpiry { get; set; }

            public int Multiplier { get; set; }

            /// <summary>
            /// Get or Set the change on the left daye to expiry.
            /// </summary>
            public int DaysLeftChange { get; set; }

            /// <summary>
            /// Get or Set the change on the IV
            /// </summary>
            public double IVChange { get; set; }

            public double ImpliedVolatilitiesBase { get; set; }

        public void SetParameters(OptionData optionData, int daysLeftChange = 0, double ivChange = 0)
            {
                Symbol = optionData.Symbol;
                OptionType = optionData.OptionContract.OptionType;
                StockPrice = optionData.UnderlinePrice;
                OptionPrice = optionData.LastPrice;
                Strike = optionData.OptionContract.Strike;
                DaysLeftToExpiry = optionData.DaysLeft;
                Multiplier = optionData.Multiplier;
                IVChange = ivChange;
                DaysLeftChange = daysLeftChange;
            }

        }
    
}
