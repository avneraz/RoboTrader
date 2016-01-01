using System;
using System.Collections.Generic;
using TNS.API.ApiDataObjects;
using TNS.DbDAL;
using Infra.Bus;
using Infra.Enum;
using log4net;


namespace TNS.BL
{

    /// <summary>
    /// Deals with all the issues involved with getting position data from the Broker,
    ///  and build all the position data of the UNLs contract.
    /// </summary>
    public class PositionsDataBuilder:UnlMemberBaseManager
    {

        public PositionsDataBuilder(ITradingApi apiWrapper, MainSecurity mainSecurity, 
            UNLManager unlManager, OptionsManager optionsManager) 
            : base(apiWrapper, mainSecurity, unlManager)
        {
            _optionsManager = optionsManager;
        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(OptionsManager));
       

        private readonly OptionsManager _optionsManager;
        public override void HandleMessage(IMessage message)
        {
            base.HandleMessage(message);
            if (message.APIDataType == EapiDataTypes.RequestDataReceived)
            {
                HandlePositionEnd();
                return;
            }

            if (message.APIDataType != EapiDataTypes.PositionData)
                return;

            var positionData = (PositionData) message;
            var contract = positionData.Contract;
            if ((contract is OptionContract) == false)
                return;

            var optionContract = (OptionContract) contract;
            var key = optionContract.OptionKey;
            if (_positionDataDic.ContainsKey(key) == false)
            {
                _positionDataDic.Add(key, positionData);
                _logger.DebugFormat("PositionsDataBuilder({0}, add PositionData: {1})",
                    Symbol, positionData);
            }
            else
                _positionDataDic[key] = positionData;

        }

        private string _addOptionDataToPositionTaskId;
        private void HandlePositionEnd()
        {

            _addOptionDataToPositionTaskId = UNLManager.AddScheduledTaskOnUnl(
                TimeSpan.FromSeconds(1), AddOptionDataToPosition, true);
        }

        private void AddOptionDataToPosition()
        {
            bool allPositionHaveOptionData = true;
            List<ContractBase> contractList = new List<ContractBase>();
            foreach (var optionKey in _positionDataDic.Keys)
            {
                var opData = _optionsManager.GetOptionData(optionKey);
                if (opData == null)
                {
                    allPositionHaveOptionData = false;
                    contractList.Add(_positionDataDic[optionKey].Contract);
                }
                else
                    _positionDataDic[optionKey].OptionData = opData;
            }
            if (allPositionHaveOptionData)
            {
                _optionsManager.OptionDataReceivd += OptionsManagerOnOptionDataReceivd;
                UNLManager.RemoveScheduledTaskOnUnl(_addOptionDataToPositionTaskId);
            }
            _optionsManager.RequestContractData(contractList);
        }
        private Dictionary<string, PositionData> _positionDataDic;
      
        protected override void DoWorkAfterConnection()
        {
            _positionDataDic = new Dictionary<string, PositionData>();

            _logger.InfoFormat("PositionsDataBuilder({0}) Start load positions from broker.", Symbol);
           
            APIWrapper.RequestContinousPositionsData();
           
        }

        private void OptionsManagerOnOptionDataReceivd(OptionData optionData)
        {
            if(optionData.Symbol != Symbol)
                return;
            var optionKey = optionData.OptionKey;
            if (_positionDataDic.ContainsKey(optionKey))
            {
                var posData = _positionDataDic[optionKey];
                posData.OptionData = optionData;
            }
        }

       
    }
}