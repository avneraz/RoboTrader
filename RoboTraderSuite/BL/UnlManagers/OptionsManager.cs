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
using TNS.DbDAL;

namespace TNS.BL.UnlManagers
{
    public class OptionsManager: UnlMemberBaseManager, IOptionsManager
    {

        public OptionsManager(ITradingApi apiWrapper, MainSecurity mainSecurity, UNLManager unlManager) : base(apiWrapper, mainSecurity, unlManager)
        {
            OptionDataDic = new Dictionary<string, OptionData>();
        }

        private const int MONTH_AHEAD = 3;
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
            if (OptionDataDic.Count > _lastOptionCountForTest)
            {
                var elapsedMS = StopwatchT.ElapsedMilliseconds;
                var msg = string.Format(
                    "OptionManager({0}), Elapsed time from connection: {1:N} ms, OptionDataDic.Count:{2}", Symbol, elapsedMS,
                    OptionDataDic.Count);
                Debug.WriteLine(msg);
                _logger.Debug(msg);
                _lastOptionCountForTest = OptionDataDic.Count;
            }
            return true;
        }

        private int _lastOptionCountForTest = 176;
        private Stopwatch StopwatchT { get; } = new Stopwatch();

        public override BaseSecurityData MainSecurityData
        {
            get { return base.MainSecurityData; }
            protected set
            {
                bool isFirstCall = base.MainSecurityData == null;
                base.MainSecurityData = value;
                if (isFirstCall & (value != null))
                {
                   APIWrapper.RequestOptionChain(base.MainSecurityData, MONTH_AHEAD);
                }
                
            }
        }
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
