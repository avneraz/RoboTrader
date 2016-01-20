using System;
using System.Collections.Generic;
using System.Linq;
using Infra.Bus;
using Infra.Enum;
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
            PositionDataDic = new Dictionary<string, PositionData>();
            OptionsManager = unlManager.OptionsManager;
        }
        public IOptionsManager OptionsManager { get; }

        public Dictionary< string, PositionData> PositionDataDic { get; }

        public override bool HandleMessage(IMessage message)
        {
            bool result = base.HandleMessage(message);
            if (result)
                return true;

            if (message.APIDataType != EapiDataTypes.PositionData)
                return false;
            //This is position message:
            var positionData = (PositionData) message;
            var contract = positionData.GetContract();
            if ((contract is OptionContract) == false)
                return false;
            //It's Option:
            var optionContract = (OptionContract) contract;
            var key = optionContract.OptionKey;
            var optionsPositionData = PositionDataFactory.CreatePoisitionData(contract, positionData.Position,
                positionData.AverageCost);
            PositionDataDic[key] = optionsPositionData;//positionData;

            if (GetOptionData(positionData, key) == false)
                APIWrapper.RequestContinousContractData(new List<ContractBase>() { optionContract });

            return true;
        }


        public void AddOptionDataToPosition()
        {

            if (PositionDataDic.Values.Any(pd => pd.OptionData == null) == false)
                return;
           
            List<ContractBase> contractList = new List<ContractBase>();
            var list = PositionDataDic.Values.Where(pd => pd.OptionData == null).ToList();
            foreach (var positionData in list)
            {
                var key = ((OptionContract)(positionData.GetContract())).OptionKey;
                if (GetOptionData(positionData, key) == false)
                    contractList.Add(PositionDataDic[key].GetContract());
            }
            if(contractList.Count > 0)
                //Request option data
                APIWrapper.RequestContinousContractData(contractList);
            
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

            positionData.OptionData = optionData;
            return true;
        }

        public override void DoWorkAfterConnection()
        {
            Logger.InfoFormat("PositionsDataBuilder({0}) Start load positions from broker.", Symbol);
           
            APIWrapper.RequestContinousPositionsData();
            UNLManager.AddScheduledTaskOnUnl(TimeSpan.FromSeconds(1), AddOptionDataToPosition, true);
        }

       
    }
}