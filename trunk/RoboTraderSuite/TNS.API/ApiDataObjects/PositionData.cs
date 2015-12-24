using Infra.Bus;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    public class PositionData : IMessage
    {
        public PositionData(ContractBase contract, int position, double averageCost)
        {
            OptionContract = contract;
            Position = position;
            AverageCost = averageCost;
        }
        public EapiDataTypes APIDataType => EapiDataTypes.PositionData;
        public ContractBase OptionContract { get; set; }
        public int Position { get; set; }
        public double AverageCost { get; set; }

        public string Symbol => OptionContract.Symbol;
    }
}
