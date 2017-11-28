using System;
using Infra.Enum;
using static System.Math;

namespace TNS.API.ApiDataObjects
{
    public abstract class PositionData : ISymbolMessage
    {
        private string _account;

        protected PositionData()
        {
            
        }

        protected PositionData(int position, double averageCost)
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
        public int Quantity => Abs(Position);
        public double AverageCost { get; set; }
        public DateTime LastUpdate { get; set; }
        /// <summary>
        /// Contains the associate OptionData object reside on OptionManager
        /// </summary>
        public OptionData OptionData { get; set; }

        public string Account

        {
            get
            {
                _account = OptionData == null ? string.Empty : OptionData.Account;
                return _account;
            }
            set => _account = value;
        }

        //public string Account {
        //    get { return OptionData == null ? string.Empty : OptionData.Account; }
        //    set { }
        //};

        public override string ToString()
        {
            return $"PositionData: [Contract: {GetContract()}, Position: {Position}, " +
                   $"AverageCost: {AverageCost}, Symbol: {GetSymbolName()}]";
        }
    }
}
