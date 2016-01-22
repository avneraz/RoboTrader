using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Infra.Bus;
using Infra.Enum;
using Infra.Extensions;
using log4net;
using TNS.API;
using TNS.API.ApiDataObjects;
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
        public PositionsDataBuilder(ITradingApi apiWrapper, ManagedSecurity managedSecurity, 
            UNLManager unlManager) 
            : base(apiWrapper, managedSecurity, unlManager)
        {
            PositionDataDic = new Dictionary<string, OptionsPositionData>();
            OptionsManager = unlManager.OptionsManager;
            Logger.DebugFormat("{0}.OptionsManager created. Thread name: {1}.", Symbol, Thread.CurrentThread.Name);
        }
        public IOptionsManager OptionsManager { get; }

        public Dictionary< string, OptionsPositionData> PositionDataDic { get; }

        public override bool HandleMessage(IMessage message)
        {
            var result = base.HandleMessage(message);

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
            var optionContract = (OptionContract) contract;
            var key = optionContract.OptionKey;
            var optionsPositionData = (OptionsPositionData) PositionDataFactory.CreatePoisitionData(
                optionContract, positionData.Position, positionData.AverageCost);

            var newPosition = PositionDataDic.ContainsKey(key) == false;
            PositionDataDic[key] = optionsPositionData;
            //Log:
            var msg = string.Format("{0}.PDB +++ add PositionData:", Symbol);
            if (newPosition == false)
                msg = string.Format("{0}.PDB update PositionData:", Symbol);
            Logger.NoticeFormat("{0} {1}. Total positions={2}", msg, optionsPositionData.Description, PositionDataDic.Count);
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

        public void AddOrUpdateDataToPosition()
        {

            List<OptionContract> contractList = new List<OptionContract>();

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var positionData in PositionDataDic.Values)
            {
                var key = ((OptionContract) (positionData.GetContract())).OptionKey;
                if (GetOptionData(positionData, key) == false)
                    contractList.Add((OptionContract) PositionDataDic[key].GetContract());
            }
            if (contractList.Count < 1)
                return;

            //Request option data
            OptionsManager.UpdateOutOfBoundaryOption(contractList);
            APIWrapper.RequestContinousContractData(contractList.Select(oc => (ContractBase) oc).ToList());
            Logger.InfoFormat("{0}.PDB send {1} contracts for not found options.", Symbol, contractList.Count);

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