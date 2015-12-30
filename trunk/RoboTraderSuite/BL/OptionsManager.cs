using System;
using System.Collections.Generic;
using System.Linq;
using Infra.Bus;
using Infra.Enum;
using log4net;
using TNS.API.ApiDataObjects;
using TNS.DbDAL;

namespace TNS.BL
{
    public class OptionsManager: UnlMemberBaseManager
    {
        private  readonly ILog _logger = LogManager.GetLogger(typeof(OptionsManager));
      
        public OptionsManager(ITradingApi apiWrapper, MainSecurity mainSecurity) : base(apiWrapper, mainSecurity)
        {
            InitializeItems();
        }

        private Dictionary<string, OptionData> OptionDataDic { get; set; }

        /// <summary>
        /// Loads the options chain of all active session of the active underlines.
        /// It send Request Contract details to load the option chain of the specified UNL.
        /// </summary>
        protected void InitializeItems()
        {
            OptionDataDic = new Dictionary<string, OptionData>();
            string exchange = MainSecurity.Exchange;
            int multiplier = Convert.ToInt32(MainSecurity.Multiplier);//TOADO add it to the security data
            string currency = MainSecurity.Currency;

            _logger.InfoFormat("OptionManager({0}) Start load options from broker.", Symbol);

            var expiryList = DbDalManager.GetUNLActiveExpiryList(Symbol);

            var contractList = expiryList.Select
                (expiryDate => new OptionContract(Symbol, expiryDate, exchange, multiplier, currency)).
                Cast<ContractBase>().ToList();

            _logger.InfoFormat("OptionManager({0}) send {1} contracts to broker.", Symbol, contractList.Count);

            APIWrapper.RequestContinousContractData(contractList);
        }
       
        public override void HandleMessage(IMessage message)
        {
            base.HandleMessage(message);

            if (message.APIDataType != EapiDataTypes.OptionData) return;
            var optionData = (OptionData)message;

            if (OptionDataDic.ContainsKey(optionData.OptionKey) == false)
            {
                OptionDataDic.Add(optionData.OptionKey, optionData);
                _logger.DebugFormat("OptionManager({0}, add OptionData: {1})", Symbol, optionData);
            }
            else
                OptionDataDic[optionData.OptionKey] = optionData;
        }
        

       
    }

}
