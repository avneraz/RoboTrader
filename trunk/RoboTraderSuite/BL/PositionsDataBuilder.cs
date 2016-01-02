using System;
using System.Collections.Generic;
using System.Linq;
using TNS.API.ApiDataObjects;
using TNS.DbDAL;
using Infra.Bus;
using Infra.Enum;
using log4net;
using TNS.API;


namespace TNS.BL
{
    
    /// <summary>
    /// Deals with all the issues involved with getting position data from the Broker,
    ///  and build all the position data of the UNLs contract.
    /// </summary>
    public class PositionsDataBuilder:UnlMemberBaseManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(PositionsDataBuilder));
        public PositionsDataBuilder(ITradingApi apiWrapper, MainSecurity mainSecurity, 
            UNLManager unlManager, Dictionary<string, OptionData> optionDataDic) 
            : base(apiWrapper, mainSecurity, unlManager)
        {
            OptionDataDic = optionDataDic;
            PositionDataDic = new Dictionary<string, PositionData>();
        }
        private Dictionary<string, OptionData> OptionDataDic { get; }

        private Dictionary< string, PositionData> PositionDataDic { get; }

        public override void HandleMessage(IMessage message)
        {
            base.HandleMessage(message);
          
            if (message.APIDataType != EapiDataTypes.PositionData)
                return;

            var positionData = (PositionData) message;
            var contract = positionData.Contract;
            if ((contract is OptionContract) == false)
                return;

            var optionContract = (OptionContract) contract;
            var key = optionContract.OptionKey;

            PositionDataDic[key] = positionData;
           
            if (OptionDataDic.ContainsKey(key) == false)
                APIWrapper.RequestContinousContractData(new List<ContractBase>() {optionContract});
            else
            {
                positionData.OptionData = OptionDataDic[key];
            }
        }

    
        private void AddOptionDataToPosition()
        {

            if (PositionDataDic.Values.Any(pd => pd.OptionData == null) == false)
                return;
           
            List<ContractBase> contractList = new List<ContractBase>();
            var list = PositionDataDic.Values.Where(pd => pd.OptionData == null).ToList();
            foreach (var positionData in list)
            {
                var key = ((OptionContract)(positionData.Contract)).OptionKey;

                if (OptionDataDic.ContainsKey(key))
                    positionData.OptionData = OptionDataDic[key];
                else
                    contractList.Add(PositionDataDic[key].Contract);
                
            }
            if(contractList.Count > 0)
                //Request option data
                APIWrapper.RequestContinousContractData(contractList);
            
        }
    
        protected override void DoWorkAfterConnection()
        {
            Logger.InfoFormat("PositionsDataBuilder({0}) Start load positions from broker.", Symbol);
           
            APIWrapper.RequestContinousPositionsData();
            UNLManager.AddScheduledTaskOnUnl(TimeSpan.FromSeconds(1), AddOptionDataToPosition, true);
        }

       
    }
}