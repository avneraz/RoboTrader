using System;
using System.Collections.Generic;
using System.Diagnostics;
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
       
        private static readonly ILog Logger = LogManager.GetLogger(typeof(OptionsManager));
        //private static readonly ILog Logger = LogManager.GetLogger(typeof(UNLManager));

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

            if ((RequestOptionChainDone == false) && (message.APIDataType == EapiDataTypes.SecurityData))
            {
                //Request detail contract only on the first time:
                //if ((MainSecurityData != null) && MainSecurityData.LastPrice > 0)
                if ((MainSecurityData != null) && !RequestOptionChainDone)
                {
                    RequestOptionChainDone = true;
                    _optionToLoadParameters = new OptionToLoadParameters(MainSecurityData);
                    APIWrapper.RequestOptionChain(_optionToLoadParameters);
                    //ForTest: if (Symbol == "MSFT") { }
                }
            }
            if (result)
                return true;

            if (message.APIDataType != EapiDataTypes.OptionData) return false ;
            var optionData = (OptionData)message;

            if (OptionDataDic.ContainsKey(optionData.GetOptionKey()) == false)
            {
               
                OptionDataDic.Add(optionData.GetOptionKey(), optionData);
                Logger.InfoFormat($"OptionManager({Symbol}), add OptionData: {optionData}). OptionDataDic.Contains {OptionDataDic.Count} members.");
              
            }
            else
                OptionDataDic[optionData.GetOptionKey()] = optionData;

            
            if ((OptionDataDic.Count > _lastoptionCount) && 
                    (OptionDataDic.Count == _optionToLoadParameters.RequestOptionMarketDataCount))
                    LogEvent();
            
            return true;
        }

        private int  _lastoptionCount;
        private void LogEvent()
        {

            _lastoptionCount = OptionDataDic.Count;
            var elapsedMS = StopwatchT.ElapsedMilliseconds;
            var msg = $"OptionManager({Symbol}), Elapsed time from connection: {elapsedMS:N} ms, " +
                      $"OptionDataDic.Count:{OptionDataDic.Count}";
            Debug.WriteLine(msg);
            Logger.Warn(msg);
        }
       
        private Stopwatch StopwatchT { get; } = new Stopwatch();

      
        private OptionToLoadParameters _optionToLoadParameters;

      
        /// <summary>
        /// Loads the options chain of all active session of the active underlines.
        /// It send Request Contract details to load the option chain of the specified UNL.
        /// </summary>
        public override void DoWorkAfterConnection()
        {
            //UNLManager.AddScheduledTaskOnUnl(TimeSpan.FromSeconds(10), RequestOptionData, true);
            StopwatchT.Start();
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
