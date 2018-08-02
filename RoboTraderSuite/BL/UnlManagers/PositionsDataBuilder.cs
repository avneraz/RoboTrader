using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Infra.Bus;
using Infra.Enum;
using Infra.Extensions;
using log4net;
using TNS.API.ApiDataObjects;
using static System.Math;
using TNS.BL.Interfaces;

namespace TNS.BL.UnlManagers
{
    
    /// <summary>
    /// Deals with all the issues involved with getting position data from the Broker,
    ///  and build all the position data of the UNLs contract.
    /// </summary>
    public class PositionsDataBuilder:UnlMemberBaseManager, IPositionsDataBuilder
    {
       

        private static readonly ILog Logger = LogManager.GetLogger(typeof(PositionsDataBuilder));

        public PositionsDataBuilder(ManagedSecurity managedSecurity,
            UNLManager unlManager)
            : base(managedSecurity, unlManager)
        {
            PositionDataDic = new Dictionary<string, OptionsPositionData>();
            OptionsManager = unlManager.OptionsManager;
            Logger.DebugFormat("{0}.OptionsManager created. Thread name: {1}.", Symbol, Thread.CurrentThread.Name);
            PositionsSummaryData = new PositionsSummaryData();
            if (UnlTradingData != null)
                UnlTradingData.PositionsSummaryData = PositionsSummaryData;
        }

        public PositionsSummaryData PositionsSummaryData { get; set; }
        public IOptionsManager OptionsManager { get; }

        public Dictionary< string, OptionsPositionData> PositionDataDic { get; }


        public override bool HandleMessage(IMessage message)
        {
            var result = base.HandleMessage(message);
            //APIWrapper.RequestContinousPositionsData();
            if ((_taskAddOptionToPosisionIsActive == false) && (PositionDataDic.Count > 0) &&
                (OptionsManager.RequestOptionChainDone))
            {
                //This call is occurred only once:
                AddTaskForUpdateOptionDataOnPosition();
                _taskAddOptionToPosisionIsActive = true;
            }
           
            if (result)
                return true;

            if (message.APIDataType != EapiDataTypes.PositionData)
                return false;
            //handle PositionData message:
            var positionData = (PositionData) message;
            var contract = positionData.GetContract();
            if ((contract is OptionContract) == false)
                return false;
            //It's Option:
            var key = ((OptionContract)contract).OptionKey;
            var optionsPositionData = (OptionsPositionData)message;
            optionsPositionData.HandledByPositionDataBuilder = true;
            //For logging purpose:
            var newPosition = PositionDataDic.ContainsKey(key) == false;
            //Add or update
            PositionDataDic[key] = optionsPositionData;
            //Log:
            var msg = $"{Symbol}.PDB +++ add PositionData:";
            if (newPosition == false)
            {
                msg = $"{Symbol}.PDB update PositionData:";
            }
            Logger.Debug($"{msg} {optionsPositionData.Description}. Total positions={PositionDataDic.Count}");
            return true;
           
        }


        private void AddTaskForUpdateOptionDataOnPosition()
        {
            //Add the repeated task to start in 10 sec, to let the options manager to load them.
            UNLManager.AddScheduledTaskOnUnl(TimeSpan.FromSeconds(10), () =>
            {
                UNLManager.AddScheduledTaskOnUnl(TimeSpan.FromSeconds(1), AddOrUpdateDataToPosition, true);
                Logger.InfoFormat("{0} PDB start repeated task for add or update options to position objects.", Symbol);
            });

        }

        private bool _taskAddOptionToPosisionIsActive;
        /// <summary>
        /// This method called by the General timer every 1 sec.
        /// </summary>
        public void AddOrUpdateDataToPosition()
        {

            var contractList = new List<OptionContract>();
            foreach (var positionData in PositionDataDic.Values)
            {
                var key = ((OptionContract) (positionData.GetContract())).OptionKey;
                if (GetOptionData(positionData, key) == false)
                    contractList.Add((OptionContract) PositionDataDic[key].GetContract());
                //used for UIDataBroker
                UNLManager.Distributer.Enqueue(positionData, false);
            }

            CalculateUnlTradingData();
            UNLManager.Distributer.Enqueue(UnlTradingData, false);
            if (contractList.Count < 1)
                return;

            //Request option data
            APIWrapper.RequestContinousContractData(contractList.Select(oc => (ContractBase) oc).ToList());
            Logger.InfoFormat("{0}.PDB send {1} contracts for not found options.", Symbol, contractList.Count);

        }

        private void CalculateUnlTradingData()
        {

            //UnlTradingData?.SetLastUpdate();

            PositionsSummaryData.CostTotal   = PositionDataDic.Values.Sum(pd => pd.TotalCost);
            PositionsSummaryData.DeltaTotal  = PositionDataDic.Values.Sum(pd => pd.DeltaTotal);
            PositionsSummaryData.NormalizedDeltaTotal = PositionDataDic.Values.Sum(pd => pd.NormalizedDeltaTotal);
            PositionsSummaryData.GammaTotal  = PositionDataDic.Values.Sum(pd => pd.GammaTotal);
            PositionsSummaryData.ThetaTotal  = PositionDataDic.Values.Sum(pd => pd.ThetaTotal);
            PositionsSummaryData.VegaTotal   = PositionDataDic.Values.Sum(pd => pd.VegaTotal);
            PositionsSummaryData.MarketValue = PositionDataDic.Values.Sum(pd => pd.MarketValue);
            PositionsSummaryData.Shorts      = PositionDataDic.Values.Where(pd=>pd.Position<0).Sum(pd => Abs(pd.Position));
            PositionsSummaryData.Longs       = PositionDataDic.Values.Where(pd=>pd.Position>0).Sum(pd => pd.Position);

            PositionsSummaryData.IVWeightedAvg = PositionDataDic.Values.Sum(pd => pd.IV * pd.Quantity) /
                                           PositionDataDic.Values.Sum(pd => pd.Quantity);
            
            CalculateATM_IV();
            
        }

        private void CalculateATM_IV()
        {
            OptionsPositionData firstPosition = PositionDataDic.Values.FirstOrDefault(p=>p.OptionType == EOptionType.Call);
            if (firstPosition != null)
                PositionsSummaryData.ImVolOnCallATM =
                    OptionsManager.GetImVolOnATMOption(firstPosition.OptionType, firstPosition.Expiry);

            firstPosition = PositionDataDic.Values.FirstOrDefault(p => p.OptionType == EOptionType.Put);
            if (firstPosition != null)
                PositionsSummaryData.ImVolOnPutATM =
                    OptionsManager.GetImVolOnATMOption(firstPosition.OptionType, firstPosition.Expiry);
        }

        /// <summary>
        /// Get OptionData from OptionManager.
        /// </summary>
        /// <param name="positionData"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private bool GetOptionData(PositionData positionData, string key)
        {
            OptionData optionData = OptionsManager.GetOptionData(key);
            if (optionData == null)
                return false;

            if(positionData.OptionData == null)//Log only on the very first time.
                Logger.NoticeFormat("{0}.PDB:: +++ OptionData {1}, HashCode({2}), is added to the Position object successfully. ", 
                    Symbol, optionData.GetOptionKey(), optionData.GetHashCode());
            //Log every 1 minute
            else if (DateTime.Now.Second%50 == 48) //TODO: The else part will be removed after evaluation and testing.
                Logger.InfoFormat(
                    "{0}.PDB:: ### OptionData {1}, HashCode({2}) was updated on the Position object successfully. ",
                    Symbol, optionData.GetOptionKey(), optionData.GetHashCode());

            positionData.OptionData = optionData;
           
            return true;
        }

        public override void DoWorkAfterConnection()
        {
            Logger.InfoFormat("PositionsDataBuilder({0}) Start load positions from broker.", Symbol);

            APIWrapper.RequestContinousPositionsData();
            
        }

       
    }
}