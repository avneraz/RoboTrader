using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Infra.Bus;
using Infra.Enum;
using log4net;
using TNS.API;
using TNS.API.ApiDataObjects;
using TNS.BL.Interfaces;

namespace TNS.BL.UnlManagers
{
    public class OptionsManager: UnlMemberBaseManager, IOptionsManager
    {

        public OptionsManager(ITradingApi apiWrapper, ManagedSecurity managedSecurity, UNLManager unlManager) : base(apiWrapper, managedSecurity, unlManager)
        {
            OptionDataDic = new Dictionary<string, OptionData>();
        }
        /// <summary>
        /// The max month ahead for loading optiondata
        /// </summary>
        private const int MONTH_AHEAD = 2;

        /// <summary>
        /// The minimum days left of the loading options.
        /// </summary>
        private const int DAYS_TO_EXPIRE = 15;
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
              
            }
            else
                OptionDataDic[optionData.GetOptionKey()] = optionData;

            
            if ((OptionDataDic.Count > _lastoptionCount) && 
                    (OptionDataDic.Count == _optionToLoadParameters.RequestOptionMarketDataCount))
                    LogEvent();
            
            return true;
        }

        private int _lastoptionCount = 11;
        private void LogEvent()
        {
            _lastoptionCount = OptionDataDic.Count;
            var elapsedMS = StopwatchT.ElapsedMilliseconds;
            var msg = string.Format(
                "OptionManager({0}), Elapsed time from connection: {1:N} ms, " +
                "OptionDataDic.Count:{2}", Symbol, elapsedMS,
                OptionDataDic.Count);
            Debug.WriteLine(msg);
            _logger.Warn(msg);
        }
       
        private Stopwatch StopwatchT { get; } = new Stopwatch();

        public override BaseSecurityData MainSecurityData
        {
            get { return base.MainSecurityData; }
            protected set
            {
                base.MainSecurityData = value;
              
                if (_requestOptionChainDone == false && (value != null) && 
                    base.MainSecurityData.LastPrice > 0)
                {
                    _requestOptionChainDone = true;
                    _optionToLoadParameters = new OptionToLoadParameters(base.MainSecurityData);
                    APIWrapper.RequestOptionChain(_optionToLoadParameters);
                }
                
            }
        }

        private OptionToLoadParameters _optionToLoadParameters;
        /// <summary>
        /// Used as flag for request option chain:
        /// </summary>
        private bool _requestOptionChainDone;
        /// <summary>
        /// Loads the options chain of all active session of the active underlines.
        /// It send Request Contract details to load the option chain of the specified UNL.
        /// </summary>
        public override void DoWorkAfterConnection()
        {
            //UNLManager.AddScheduledTaskOnUnl(TimeSpan.FromSeconds(10), RequestOptionData, true);
            StopwatchT.Start();
        }

        public void RequestContinousContractData(List<ContractBase> contractList)
        {
            APIWrapper.RequestContinousContractData(contractList);
        }
    }

    internal class LoadSessionInfo
    {
        public LoadSessionInfo(OptionData optionData)
        {
            OptionData = optionData;
        }

        public OptionData OptionData { get; set; }

        public DateTime ExpiryDate => OptionData?.OptionContract.Expiry ?? DateTime.MinValue;

        public bool OptionLoadRequestDone { get; set; }
    }
}
