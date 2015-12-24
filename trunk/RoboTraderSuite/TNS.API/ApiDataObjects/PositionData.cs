using Infra.Bus;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    public class PositionData : IMessage
    {
        public PositionData(OptionContract optionContract, int position, double averageCost)
        {
            OptionContract = optionContract;
            Position = position;
            AverageCost = averageCost;
        }
        public EapiDataTypes APIDataType => EapiDataTypes.PositionData;
        public OptionContract OptionContract { get; set; }
        public int Position { get; set; }
        public double AverageCost { get; set; }

        public string Symbol => OptionContract.Symbol;
    }
}
