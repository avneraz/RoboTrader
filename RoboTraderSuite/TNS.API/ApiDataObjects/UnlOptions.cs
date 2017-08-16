using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    public class UnlOptions : BaseSecurityData
    {
        private TransactionData _openTransaction;
        private TransactionData _closeTransaction;
        private OptionData _optionData;
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

        public OptionData OptionData
        {
            get { return _optionData; }
            set
            {
                _optionData = value;
            }
        }

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
            get { return _closeTransaction; }
            set
            {
                _closeTransaction = value;
                Status = EStatus.Close;
                LastUpdate = DateTime.Now;
            }
        }

        public string Symbol { get; set; }

       

        public EStatus Status { get; set; }

        /// <summary>
        /// Hold the last update profit /loss
        /// </summary>
        public double PnL { get; set; }


    }
}

