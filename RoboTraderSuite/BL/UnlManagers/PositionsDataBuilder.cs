using System;
using System.Collections.Generic;
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
    
    /// <summary>
    /// Deals with all the issues involved with getting position data from the Broker,
    ///  and build all the position data of the UNLs contract.
    /// </summary>
    public class PositionsDataBuilder:UnlMemberBaseManager, IPositionsDataBuilder
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(PositionsDataBuilder));
        public PositionsDataBuilder(ITradingApi apiWrapper, MainSecurity mainSecurity, 
            UNLManager unlManager) 
            : base(apiWrapper, mainSecurity, unlManager)
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

            var positionData = (PositionData) message;
            var contract = positionData.GetContract();
            if ((contract is OptionContract) == false)
                return false;

            var optionContract = (OptionContract) contract;
            var key = optionContract.OptionKey;

            PositionDataDic[key] = positionData;
           
            if (OptionsManager.OptionDataDic.ContainsKey(key) == false)
                OptionsManager.RequestContinousContractData(new List<ContractBase>() {optionContract});
            else
            {
                positionData.OptionData = OptionsManager.OptionDataDic[key];
            }
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

                if (OptionsManager.OptionDataDic.ContainsKey(key))
                    positionData.OptionData = OptionsManager.OptionDataDic[key];
                else
                    contractList.Add(PositionDataDic[key].GetContract());
                
            }
            if(contractList.Count > 0)
                //Request option data
                OptionsManager.RequestContinousContractData(contractList);
            
        }

        public override void DoWorkAfterConnection()
        {
            Logger.InfoFormat("PositionsDataBuilder({0}) Start load positions from broker.", Symbol);
           
            //APIWrapper.RequestContinousPositionsData();
            UNLManager.AddScheduledTaskOnUnl(TimeSpan.FromSeconds(1), AddOptionDataToPosition, true);
        }

       
    }
}