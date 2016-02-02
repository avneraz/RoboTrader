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

        public BnSCalculationData(string symbol, EOptionType optionType, double stockPrice, double strikePrice, int dayLefts, int multiplier = 100)
        {
            Symbol = symbol;
            OptionType = optionType;
            StockPrice = stockPrice;
            StrikePrice = strikePrice;
            DayLefts = dayLefts;
            ResultDataValues = new ResultData();
            Multiplier = multiplier;
        }

        public BnSCalculationData(OptionData optionData, double calculatedIV)
        {
            Symbol = optionData.OptionContract.Symbol;
            OptionType = optionData.OptionContract.OptionType;
            StockPrice = optionData.UnderlinePrice;
            StrikePrice = optionData.OptionContract.Strike;
            DayLefts = optionData.DaysLeft;
            ImpliedVolatilitiesBase = calculatedIV;
            Multiplier = optionData.Multiplier;
            ResultDataValues = new ResultData();
        }

        /// <summary>
        /// The associated underline symbol
        /// </summary>
        public string Symbol { get; set; }

        public EOptionType OptionType { get; set; }

        //public double CurrentUNLPrice { get; set; }

        //private double? _stockPrice;

        //public double StockPrice
        //{
        //    get
        //    {
        //        if (_stockPrice == null)
        //            _stockPrice = CurrentUNLPrice;
        //        return _stockPrice.Value;
        //    }
        //    set { _stockPrice = value; }
        //}
        public double StockPrice { get; set; }
        public double StrikePrice { get; set; }

        public double BaseOptionPrice { get; set; }

        public int DayLefts { get; set; }

        //public double ImpliedVolatilities => ImpliedVolatilitiesBase + IVChange;

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
}
