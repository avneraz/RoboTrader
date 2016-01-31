using System;
using Infra.Enum;
using log4net;

namespace Infra.BnS
{

    public class OptionCalculationData
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(OptionCalculationData));
        public OptionCalculationData(EOptionType optionType, int position, double currentUNLPrice, int multiplier)
        {
            OptionType = optionType;
            ResultDataValues = new ResultData();
            Position = position;
            CurrentUNLPrice = currentUNLPrice;
            Multiplier = multiplier;
        }

        public void Calculate()
        {
            var blackNScholesCaculator = new BlackNScholesCaculator
            {
                DayLefts = DayLefts,
                ImpliedVolatilities = ImpliedVolatilities,
                RiskFreeInterestRate = RiskFreeInterestRate,
                StockPrice = StockPrice,
                StrikePrice = StrikePrice,
                Multiplier = Multiplier
            };
            blackNScholesCaculator.CalculateAll();
            if (OptionType == EOptionType.Call)
            {
                ResultDataValues.OptionPrice = Double.IsNaN(blackNScholesCaculator.CallValue) ? 0 : blackNScholesCaculator.CallValue;
                ResultDataValues.Delta = blackNScholesCaculator.DeltaCall;
                ResultDataValues.Gamma = blackNScholesCaculator.GamaCall;
                ResultDataValues.Theta = blackNScholesCaculator.ThetaCall;
                ResultDataValues.Vega = blackNScholesCaculator.VegaCall;
            }
            else
            {
                ResultDataValues.OptionPrice = Double.IsNaN(blackNScholesCaculator.PutValue) ? 0 : blackNScholesCaculator.PutValue;
                //ResultDataValues.OptionPrice = blackNScholesCaculator.PutValue;
                ResultDataValues.Delta = blackNScholesCaculator.DeltaPut;
                ResultDataValues.Gamma = blackNScholesCaculator.GamaPut;
                ResultDataValues.Theta = blackNScholesCaculator.ThetaPut;
                ResultDataValues.Vega = blackNScholesCaculator.VegaPut;
            }
        }

        public double CalculateIVByOptionPrice(double stockPrice, int dayLefts)
        {
            var blackNScholesCaculator = new BlackNScholesCaculator()
            {
                DayLefts = dayLefts,

                RiskFreeInterestRate = RiskFreeInterestRate,
                StockPrice = stockPrice,
                StrikePrice = StrikePrice
            };
            double iv = 0;
            try
            {
                iv = OptionType == EOptionType.Call
                       ? blackNScholesCaculator.GetCallIVBisections(BaseOptionPrice)
                       : blackNScholesCaculator.GetPutIVBisections(BaseOptionPrice);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message + ": wrong calculation, ImpliedVolatilitiesBase = 0 !!!!", ex);
            }

            ImpliedVolatilitiesBase = iv;
            return iv;
        }

        //public string SessionKey { get; set; }

        public EOptionType OptionType { get; set; }

        public double CurrentUNLPrice  { get; set; }

        private double? _stockPrice;

        public double StockPrice
        {
            get
            {
                if (_stockPrice == null)
                    _stockPrice = CurrentUNLPrice;
                return _stockPrice.Value;
            }
            set { _stockPrice = value; }
        }

        public double StrikePrice { get; set; }

        public double BaseOptionPrice { get; set; }

        public int DayLefts { get; set; }

        public double ImpliedVolatilities => ImpliedVolatilitiesBase + IVChange;

        /// <summary>
        /// Gets or sets the base implied volatilities that calculated from the current option price.
        /// </summary>
        /// <value>
        /// The implied volatilities base.
        /// </value>
        public double ImpliedVolatilitiesBase { get; set; }

        public double IVChange { get; set; }

        public double RiskFreeInterestRate => AllConfigurations.AllConfigurationsObject.Trading.RiskFreeInterestRate;

        public ResultData ResultDataValues { get; set; }

        public double Cost { get; set; }

        public double PnL => (Cost + PositionPrice);


        public int  Position { get; set; }

        public int PositionActual => Position == 0 ? 1 : Position;
        public double DeltaTotal => ResultDataValues.Delta * PositionActual;

        public double GammaTotal => ResultDataValues.Gamma * PositionActual;

        public double ThetaTotal => ResultDataValues.Theta * PositionActual;

        public double VegaTotal => ResultDataValues.Vega * PositionActual;

        public double PositionPrice => ResultDataValues.OptionPrice * PositionActual;

        public double Delta => DeltaTotal/Position/Multiplier;

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
