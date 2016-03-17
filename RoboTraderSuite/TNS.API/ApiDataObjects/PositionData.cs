using System;
using Infra.Bus;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    public abstract class PositionData : ISymbolMessage
    {
        public PositionData()
        {
            
        }
        public PositionData(int position, double averageCost)
        {
            Position = position;
            AverageCost = averageCost;
        }
        public virtual EapiDataTypes APIDataType => EapiDataTypes.PositionData;
        public string GetSymbolName()
        {
            return GetContract().Symbol;
        }

        public virtual Guid Id { get; private set; }
        public abstract ContractBase GetContract();
        public abstract void SetContract(ContractBase contract);
        public int Position { get; set; }
        public double AverageCost { get; set; }
        public DateTime LastUpdate { get; set; }
        /// <summary>
        /// Contains the associate OptionData object reside on OptionManager
        /// </summary>
        public OptionData OptionData { get; set; }

        public override string ToString()
        {
            return $"PositionData: [Contract: {GetContract()}, Position: {Position}, " +
                   $"AverageCost: {AverageCost}, Symbol: {GetSymbolName()}]";
        }
    }
}
