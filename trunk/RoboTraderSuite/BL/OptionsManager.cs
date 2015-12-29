using System;
using System.Collections.Generic;
using System.Linq;
using Infra.Bus;
using log4net;
using TNS.API.ApiDataObjects;
using TNS.DbDAL;

namespace TNS.BL
{
    public class OptionsManager : SimpleBaseLogic
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(OptionsManager));
        public OptionsManager(UNLManager unlManager)
        {
            _unlManager = unlManager;
            _symbol = _unlManager.Symbol;
        }

        public Dictionary<string, OptionData> OptionDataDic { get; set; }

        private const double EPSILON = 0.000000001;
        private readonly UNLManager _unlManager;
        private string _symbol;
        /// <summary>
        /// Loads the options chain of all active session of the active underlines.
        /// It send Request Contract details to load the option chain of the specified UNL.
        /// </summary>
        private void LoadOptionsChain()
        {
            _symbol = _unlManager.Symbol;
            string exchange = _unlManager.MainSecurity.Exchange;//"SMART"
            int multiplier =  Convert.ToInt32(_unlManager.MainSecurity.Multiplier);
            string currency = _unlManager.MainSecurity.Currency;
            Logger.InfoFormat("OptionManager({0}) Start load options from broker.", _symbol);
            var expiryList = DbDalManager.GetUNLActiveExpiryList(_symbol);//securityChainList.Select(s => s.ExpiryDate);
            int lowStrike = 30;
            int highStrike = 80;
            if (_unlManager.MainSecurity.LowLoadingStrike != null)
            {
                lowStrike = _unlManager.MainSecurity.LowLoadingStrike.Value;
            }
            if (_unlManager.MainSecurity.HighLoadingStrike != null)
            {
                highStrike = _unlManager.MainSecurity.HighLoadingStrike.Value;
            }

            foreach (var expiryDate in expiryList)
            {
                List < ContractBase > contractList = new List<ContractBase>();
                for (int strike = lowStrike; strike <= highStrike; strike++)
                {
                    var optionContractCall = new OptionContract(_unlManager.Symbol, strike, expiryDate,
                        OptionType.Call, exchange, multiplier, currency);
                    contractList.Add(optionContractCall);
                    var optionContractPut = new OptionContract(_unlManager.Symbol, strike, expiryDate,
                        OptionType.Put, exchange, multiplier, currency);
                    contractList.Add(optionContractPut);
                }
                Logger.InfoFormat("OptionManager({0}) send {1} contracts to broker.", _symbol, contractList.Count);
                _unlManager.APIWrapper.RequestContinousContractData(contractList);
            }

            

        }
        protected override string ThreadName => _unlManager.Symbol + "_OptionManager_Work";
        protected override void HandleMessage(IMessage message)
        {
            var optionData = message as OptionData;

            if(optionData == null) return;

            if (IsOptionDataHasNoValues(optionData))
            {
                _unlManager.APIWrapper.CancelMarketData(optionData);
                return;
            }

            if (OptionDataDic.ContainsKey(optionData.OptionKey) == false)
            {
                OptionDataDic.Add(optionData.OptionKey, optionData);
                Logger.DebugFormat("OptionManager({0}, add OptionData: {1})", _symbol, optionData);
            }
            else
                OptionDataDic[optionData.OptionKey] = optionData;

        }

        private bool IsOptionDataHasNoValues(OptionData optionData)
        {
            return optionData.LastPrice < EPSILON && Math.Abs(optionData.Delta) < EPSILON &&
                          optionData.ImpliedVolatility < EPSILON;
           
        }
        public override void DoWorkAfterConnection()
        {
            OptionDataDic = new Dictionary<string, OptionData>();
            LoadOptionsChain();
        }

       
    }
}
