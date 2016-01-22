

namespace TNS.API.ApiDataObjects
{
    public class OptionsPositionData : PositionData
    {
        public OptionsPositionData()
        {

        }
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
            return $"OptionsPositionData: [{GetSymbolName()}] [{OptionContract}, Position: {Position}, AverageCost: {AverageCost}]";
        }
        public string Description
        {
            get
            {
                //var description = $"{Symbol}"
                var desc = string.Format("{0}. Position={1}, AverageCost={2:F1}", OptionContract.Description, Position,
                    AverageCost);
                return desc;
            }
        }

        #region Option Calculated Properties

        #region Greek

        public double Delta => OptionData?.Delta ?? -1;
        public double DeltaTotal => OptionData?.Delta * OptionData?.Multiplier * Position ?? 0;
        public double GammaTotal => OptionData?.Gamma * OptionData?.Multiplier * Position ?? 0;
        public double Gamma => OptionData?.Gamma ?? -1;
        public double ThetaTotal => OptionData?.Theta * OptionData?.Multiplier * Position ?? 0;
        public double Theta => OptionData?.Theta ?? -1;
        public double VegaTotal => OptionData?.Vega * OptionData?.Multiplier * Position ?? 0;
        public double Vega => OptionData?.Vega ?? -1;
       
        #endregion

        public double MarketValue
        {
            get
            {
                if ((OptionData == null) || (Position == 0))
                    return 0;

                var optionPrice = ((OptionData.AskPrice <= 0) || OptionData.BidPrice <= 0)
                    ? ((OptionData.LastPrice <= 0 && OptionData.ModelPrice >= 0)
                        ? OptionData.ModelPrice
                        : OptionData.LastPrice)
                    : (OptionData.AskPrice + OptionData.BidPrice)/2;

                return optionPrice * Position * OptionData.Multiplier;
            }
        }
        public double TotalCost => AverageCost * Position * -1;
        public double PnL => MarketValue + TotalCost;

        #endregion
    }
}
