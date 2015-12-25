using Infra.Bus;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    public class PositionData : ISymbolMessage
    {
        public PositionData(ContractBase contract, int position, double averageCost)
        {
            Contract = contract;
            Position = position;
            AverageCost = averageCost;
        }
        public EapiDataTypes APIDataType => EapiDataTypes.PositionData;
        public string GetSymbolName()
        {
            return Contract.Symbol;
        }

        public ContractBase Contract { get; set; }
        public int Position { get; set; }
        public double AverageCost { get; set; }

        public override string ToString()
        {
            return $"PositionData: [Contract: {Contract}, Position: {Position}, " +
                   $"AverageCost: {AverageCost}, Symbol: {GetSymbolName()}]";
        }
    }
}
