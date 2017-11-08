using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DAL;
using Infra;
using Infra.Bus;
using Infra.Enum;
using log4net;
using TNS.API;
using TNS.API.ApiDataObjects;
using TNS.BL.DataObjects;
using TNS.BL.Interfaces;

namespace TNS.BL.UnlManagers
{
    public class OptionsManager : UnlMemberBaseManager, IOptionsManager
    {

        public OptionsManager(ManagedSecurity managedSecurity, UNLManager unlManager) : base(
            managedSecurity, unlManager)
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
        public OptionData GetATMOptionData(DateTime expiry, EOptionType optionType)
        {
            const double epsilon = 0.005;
            //Get all the options nearest the ATM
            var options = OptionDataDic.Values
                .Where(od => od.Expiry == expiry && od.OptionContract.OptionType == optionType &&
                             od.DeltaOffsetFromATM < 0.05).ToList();
            if (options.Count == 0)
                return null;
            var minDeltaOffset = options.Min(od => od.DeltaOffsetFromATM);
            var atmOptionData = options.FirstOrDefault(od => od.DeltaOffsetFromATM < (minDeltaOffset + epsilon));
            if(atmOptionData == null)
                throw new Exception("ATM Option didn't found. check your calculation!!!");
            return atmOptionData;
        }
        /// <summary>
        /// Check if there is any option that close enugh to the ATM option.
        /// </summary>
        /// <param name="optionType"></param>
        /// <param name="expiryDate"></param>
        /// <returns></returns>
        public bool CheckForATMOption(EOptionType optionType, DateTime expiryDate)
        {
            //
            var exist = OptionDataDic.Values
                .Any(op => op.Expiry == expiryDate &&
                           op.OptionContract.OptionType == optionType &&
                           op.DeltaOffsetFromATM < AllConfigurations.AllConfigurationsObject.Trading
                               .MaxDeltaOffsetAllowed);
            return exist;
        }
        /// <summary>
        /// Get the Implied Volatility on the ATM option.
        /// </summary>
        public double GetImVolOnATMOption(EOptionType optionType, DateTime expiryDate)
        {
            var option = GetATMOptionData(expiryDate, optionType);
            if (option != null) return option.ImpliedVolatility;
            return 0;
        }
        public override bool HandleMessage(IMessage message)
        {
            bool result = base.HandleMessage(message);

            if ((RequestOptionChainDone == false) && (message.APIDataType == EapiDataTypes.SecurityData))
            {
                //Request detail contract only on the first time:
                if ((MainSecurityData != null) && !RequestOptionChainDone)
                {
                    RequestOptionChainDone = true;
                    _optionToLoadParameters = new OptionToLoadParameters(MainSecurityData);
                    APIWrapper.RequestOptionChain(_optionToLoadParameters);

                }
            }
            if (result)
                return true;
            //Handle only OptionData
            if (message.APIDataType != EapiDataTypes.OptionData) return false;

            var optionData = (OptionData) message;
            if (Symbol == "AMZN") { }//for testing
            //if (Symbol == "AMZN")
            //{
            //    double vega = -1111;
            //    vega = optionData.Vega;
            //}
            if (OptionDataDic.ContainsKey(optionData.GetOptionKey()) == false)
            {

                OptionDataDic.Add(optionData.GetOptionKey(), optionData);
                Logger.InfoFormat(
                    $"OptionManager({Symbol}), add OptionData: {optionData}). OptionDataDic.Contains {OptionDataDic.Count} members.");

            }
            else
                OptionDataDic[optionData.GetOptionKey()] = optionData;


            if ((OptionDataDic.Count > _lastoptionCount) &&
                (OptionDataDic.Count == _optionToLoadParameters.RequestOptionMarketDataCount))
                LogEvent();
            Logger.Debug($"++++++ Option count = {OptionDataDic.Count} for {Symbol}");
            //switch (Symbol) //For test
            //{
            //    case "AAPL":
            //        break;
            //    case "AMZN":
            //        break;
            //    case "FB":
            //        break;
            //    case "MCD":
            //        break;
            //}
            return true;

        }

        private int _lastoptionCount;

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

    //internal class LoadSessionInfo
    //{
    //    public LoadSessionInfo(OptionData optionData)
    //    {
    //        OptionData = optionData;
    //    }

    //    public OptionData OptionData { get; set; }

    //    public DateTime ExpiryDate => OptionData?.OptionContract.Expiry ?? DateTime.MinValue;

    //    public bool OptionLoadRequestDone { get; set; }
    //}
}
