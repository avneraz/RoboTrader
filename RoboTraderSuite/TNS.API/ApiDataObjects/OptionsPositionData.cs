

using System;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    public class OptionsPositionData : PositionData
    {
        public OptionsPositionData()
        {

        }

        //public override EapiDataTypes APIDataType => EapiDataTypes.PositionData;
        public OptionsPositionData(OptionContract contract, int position, double averageCost)
            : base(position, averageCost)
        {
            OptionContract = contract;
        }

        public OptionContract OptionContract { get; set; }

        public override ContractBase GetContract()
        {
            return OptionContract;
        }

        public override void SetContract(ContractBase contract)
        {
            OptionContract = (OptionContract) contract;
        }

        public override string ToString()
        {
            return
                $"OptionsPositionData: [{GetSymbolName()}] [{OptionContract}, Position: {Position}, AverageCost: {AverageCost}]";
        }

        public string Description
        {
            get
            {
                //var description = $"{Symbol}"
                var desc = $"{OptionContract.Description}. Position={Position}, AverageCost={AverageCost:F1}";
                return desc;
            }
        }

        public string Symbol => OptionContract.Symbol;
        public DateTime Expiry => OptionContract.Expiry;

        public string OptionKey => OptionContract.OptionKey;

        #region Option Calculated Properties

        #region Greek

        public double Delta => OptionData?.Delta ?? -1;
        public double DeltaTotal => OptionData?.Delta*OptionData?.Multiplier*Position ?? 0;
        public double GammaTotal => OptionData?.Gamma*OptionData?.Multiplier*Position ?? 0;
        public double Gamma => OptionData?.Gamma ?? -1;
        public double ThetaTotal => OptionData?.Theta*OptionData?.Multiplier*Position ?? 0;
        public double Theta => OptionData?.Theta ?? -1;
        public double VegaTotal => OptionData?.Vega*OptionData?.Multiplier*Position ?? 0;
        public double Vega => OptionData?.Vega ?? -1;

        #endregion

        public double MarketValue
        {
            get
            {
                if ((OptionData == null) || (Position == 0))
                    return 0;
                return CalculatedOptionPrice*Position*OptionData.Multiplier*CurrencyRate;
            }
        }

        public double IV => OptionData?.ImpliedVolatility ?? 0;

        public double CalculatedOptionPrice
        {
            get
            {
                if (OptionData != null)
                    return OptionData.CalculatedOptionPrice;
                return -1;
            }
        }


    public double TotalCost => AverageCost * Position * CurrencyRate * -1;
        public double PnL => MarketValue + TotalCost;
        /// <summary>
        /// This rate will be used when the currency will be none USD, it's needed to convert the foreign currency to USD.
        /// For now it's always 1!
        /// </summary>
        public double CurrencyRate { get; set; } = 1;
        /// <summary>
        /// Used to mark if PositionDataBuilder handle the object, used for UIDataBroker.
        /// </summary>
        public bool HandledByPositionDataBuilder { get; set; }

        #endregion
    }
}
