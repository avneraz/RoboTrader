using System;
using System.Collections.Generic;
using Infra.Bus;
using Infra.Enum;
using log4net;
using TNS.API;
using TNS.API.ApiDataObjects;
using TNS.BL.Interfaces;
using TNS.DbDAL;

namespace TNS.BL.UnlManagers
{
    public class OptionsManager: UnlMemberBaseManager, IOptionsManager
    {

        public OptionsManager(ITradingApi apiWrapper, MainSecurity mainSecurity, UNLManager unlManager) : base(apiWrapper, mainSecurity, unlManager)
        {
            OptionDataDic = new Dictionary<string, OptionData>();
        }

        private  readonly ILog _logger = LogManager.GetLogger(typeof(OptionsManager));

        //public event Action<OptionData> OptionDataReceivd;

        public Dictionary<string, OptionData> OptionDataDic { get; }

        public OptionData GetOptionData(string optionKey)
        {
            var opDataExist = OptionDataDic.ContainsKey(optionKey);
            return opDataExist ? OptionDataDic[optionKey] : null;
        }

        public override bool HandleMessage(IMessage message)
        {
            bool result = base.HandleMessage(message);
            if (result)
                return true;

            if (message.APIDataType != EapiDataTypes.OptionData) return false ;
            var optionData = (OptionData)message;

            if (OptionDataDic.ContainsKey(optionData.GetOptionKey()) == false)
            {
                OptionDataDic.Add(optionData.GetOptionKey(), optionData);
                _logger.DebugFormat("OptionManager({0}, add OptionData: {1})", Symbol, optionData);
                //OptionDataReceivd?.Invoke(optionData);
            }
            else
                OptionDataDic[optionData.GetOptionKey()] = optionData;
            return true;
        }
       
        /// <summary>
        /// Loads the options chain of all active session of the active underlines.
        /// It send Request Contract details to load the option chain of the specified UNL.
        /// </summary>
        public override void DoWorkAfterConnection()
        {
            
            string exchange = MainSecurity.Exchange;
            int multiplier = Convert.ToInt32(MainSecurity.Multiplier);//TOADO add it to the security data
            string currency = MainSecurity.Currency;

            _logger.InfoFormat("OptionManager({0}) Start load options from broker.", Symbol);

            var expiryList = DbDalManager.GetUNLActiveExpiryList(Symbol);

            var contractList = new List<ContractBase>();
            foreach (var expiryDate in expiryList)
            {
                contractList.Add(new OptionContract(Symbol, expiryDate, OptionType.Call, exchange, multiplier, currency));
                contractList.Add(new OptionContract(Symbol, expiryDate, OptionType.Put, exchange, multiplier, currency));
            }

            _logger.InfoFormat("OptionManager({0}) send {1} contracts to broker.", 
                Symbol, contractList.Count);

            RequestContinousContractData(contractList);
        }

        public void RequestContinousContractData(List<ContractBase> contractList)
        {
            APIWrapper.RequestContinousContractData(contractList);
        }
    }

}
