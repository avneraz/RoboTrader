using System;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    public class TransactionData : BaseSecurityData
    {
        public override EapiDataTypes APIDataType => EapiDataTypes.TransactionData;
        public override ContractBase GetContract()
        {
            return OptionData.OptionContract;
        }

        public override void SetContract(ContractBase contract)
        {
            OptionData.OptionContract = (OptionContract)contract;
        }

        public virtual int Id { get; protected set; }

        public OptionData OptionData { get; set; }

        public OrderStatusData OrderStatus { get; set; }

        public OrderData Order { get; set; }

        public string OptionKey { get; set; }

        public DateTime TransactionTime { get; set; }

    }
}
