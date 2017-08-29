using System;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    public class UnlOptions : BaseSecurityData
    {
        private TransactionData _openTransaction;
        private TransactionData _closeTransaction;
        public override EapiDataTypes APIDataType => EapiDataTypes.UnlOption;
        public override ContractBase GetContract()
        {
            return OptionData.OptionContract;
        }

        public override void SetContract(ContractBase contract)
        {
            OptionData.OptionContract = (OptionContract)contract;
        }

        public new int Id { get; protected set; }
        public OptionData OptionData { get; set; }

        public double IV => OptionData.ImpliedVolatility;
        public string OptionKey { get; set; }
        public TransactionData OpenTransaction
        {
            get => _openTransaction;
            set
            {
                if(value == null) return;
                _openTransaction = value;
                OptionKey = value.OptionKey;
                OptionData = value.OptionData;
                Status = EStatus.Open;
                LastUpdate = DateTime.Now;
            }
        }
        public TransactionData CloseTransaction
        {
            get => _closeTransaction;
            set
            {
                _closeTransaction = value;
                Status = EStatus.Close;
                LastUpdate = DateTime.Now;
            }
        }
        //public string Account { get; set; }
        public string Symbol { get; set; }
        public EStatus Status { get; set; }
        /// <summary>
        /// Hold the last update profit /loss
        /// </summary>
        public double PnL { get; set; }


    }
}

