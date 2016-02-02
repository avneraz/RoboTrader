using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Infra;
using Infra.BnS;
using Infra.Enum;
using log4net;
using log4net.Repository.Hierarchy;
using TNS.API.ApiDataObjects;
using TNS.BL.DataObjects;

namespace TNS.BL.Analysis
{
    /// <summary>
    /// Used for various calculation with Black and Scholes equation.
    /// In partnership with Infra.BlackNScholesCaculator
    /// </summary>
    public class BnSCalcHelpper
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(BnSCalcHelpper));
        public double RiskFreeInterestRate => AllConfigurations.AllConfigurationsObject.Trading.RiskFreeInterestRate;

        /// <summary>
        /// The method calculates the IV according the base parameters of the option =><para>
        /// (DaysLeft, Underline price, Strike and the known option price).<para></para>
        /// And than calculates all the Greek values using Black and Scholes equation
        /// and update the OptionData object accordingly! </para>
        /// </summary>
        /// <param name="optionData"></param>
        public void UpdateGreekValues(OptionData optionData)
        {
            BnSCalculationData bnSCalculationData = CalculateValuesByBnS(optionData);
            UpdateOptionData(bnSCalculationData, optionData);
        }

        public BnSCalculationData CalculateValuesByBnS(OptionData optionData)
        {
            double calculatedIV = CalculateIVByOptionPrice(optionData);
            return CalculateValuesByBnS(optionData, calculatedIV);
        }
        public BnSCalculationData CalculateValuesByBnS(OptionData optionData, double calculatedIV)
        {
            var calculationData = new BnSCalculationData(optionData, calculatedIV);
            CalculateBnSValues(calculationData);
            return calculationData;
        }

        public double CalculateIVByOptionPrice(OptionData optionData)
        {

            var blackNScholesCaculator = new BlackNScholesCaculator()
            {
                DayLefts = optionData.DaysLeft,
                Multiplier = optionData.Multiplier,
                RiskFreeInterestRate = RiskFreeInterestRate,
                StockPrice = optionData.UnderlinePrice,
                StrikePrice = optionData.OptionContract.Strike,
            };
            double iv = 0;
            try
            {
                iv = optionData.OptionContract.OptionType == EOptionType.Call
                       ? blackNScholesCaculator.GetCallIVBisections(optionData.PriceOfOneOption)
                       : blackNScholesCaculator.GetPutIVBisections(optionData.PriceOfOneOption);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message + ": wrong calculation, ImpliedVolatility = 0 !!!!", ex);
            }

            return iv;
        }
        private void CalculateBnSValues(BnSCalculationData bnSCalculationData)
        {
            var blackNScholesCaculator = new BlackNScholesCaculator
            {
                DayLefts = bnSCalculationData.DayLefts,
                ImpliedVolatilities = bnSCalculationData.ImpliedVolatilitiesBase,
                RiskFreeInterestRate = RiskFreeInterestRate,
                StockPrice = bnSCalculationData.StockPrice,
                StrikePrice = bnSCalculationData.StrikePrice,
                Multiplier = bnSCalculationData.Multiplier
            };
            int multiplier = bnSCalculationData.Multiplier;
            blackNScholesCaculator.CalculateAll();

            if (bnSCalculationData.OptionType == EOptionType.Call)
            {
                bnSCalculationData.ResultDataValues.OptionPrice = double.IsNaN(blackNScholesCaculator.CallValue)
                    ? 0
                    : blackNScholesCaculator.CallValue;
                bnSCalculationData.ResultDataValues.Delta = blackNScholesCaculator.DeltaCall/ multiplier;
                bnSCalculationData.ResultDataValues.Gamma = blackNScholesCaculator.GamaCall / multiplier;
                bnSCalculationData.ResultDataValues.Theta = blackNScholesCaculator.ThetaCall / multiplier;
                bnSCalculationData.ResultDataValues.Vega = blackNScholesCaculator.VegaCall / multiplier;
            }
            else
            {
                bnSCalculationData.ResultDataValues.OptionPrice = double.IsNaN(blackNScholesCaculator.PutValue)
                    ? 0
                    : blackNScholesCaculator.PutValue;
                bnSCalculationData.ResultDataValues.Delta = blackNScholesCaculator.DeltaPut / multiplier;
                bnSCalculationData.ResultDataValues.Gamma = blackNScholesCaculator.GamaPut / multiplier;
                bnSCalculationData.ResultDataValues.Theta = blackNScholesCaculator.ThetaPut / multiplier;
                bnSCalculationData.ResultDataValues.Vega = blackNScholesCaculator.VegaPut / multiplier;
            }
        }

        private void UpdateOptionData(BnSCalculationData bnSCalculationData, OptionData optionData)
        {
            optionData.ImpliedVolatility = bnSCalculationData.ImpliedVolatilitiesBase;
            
            optionData.Delta = bnSCalculationData.ResultDataValues.Delta;
            optionData.Gamma = bnSCalculationData.ResultDataValues.Gamma;
            optionData.Theta = bnSCalculationData.ResultDataValues.Theta;
            optionData.Vega = bnSCalculationData.ResultDataValues.Vega;
        }

      
    }
}

