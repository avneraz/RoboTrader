using System.Collections.Generic;
using System.Linq;
using DAL;
using log4net;
using TNS.API.ApiDataObjects;
using Infra.Bus;
using Infra.Enum;
using TNS.BL.Analysis;
using TNS.BL.UnlManagers;

namespace TNS.BL
{
    public class Distributer : SimpleBaseLogic
    {
        public void SetManagers(Dictionary<string, SimpleBaseLogic> unlManagerDic,
            AccountManager accountManager, ManagedSecuritiesManager managedSecuritiesManager,
            DBWriter writer, MarginManager marginManager)
        {
            _unlManagersDic = unlManagerDic;
            _accountManager = accountManager;
            _managedSecuritiesManager = managedSecuritiesManager;
            _dbWriter = writer;
            MarginManager = marginManager;
        }
        /// <summary>
        /// Indicate if the Greek  values of the options will be calculated locally, 
        /// usually it's activated by the user when the broker don't send Greek values.
        /// </summary>
        public bool CalculateGreekLocally { get; set; }

        BnSCalcHelpper BnSCalcHelpper => _bnsCalcHelpper ?? (_bnsCalcHelpper = new BnSCalcHelpper());

        private BnSCalcHelpper _bnsCalcHelpper;

        private  Dictionary<string, SimpleBaseLogic> _unlManagersDic;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Distributer));

        private  ManagedSecuritiesManager _managedSecuritiesManager;
        private  AccountManager _accountManager;
        private DBWriter _dbWriter;
        private IBaseLogic _uiMessageHandler;
        private IBaseLogic UIDataBroker { get; set; }
        private MarginManager MarginManager { get; set; }

        protected override string ThreadName => "Distributer";

        protected override void HandleMessage(IMessage message)
        {
            //For evaluation only:
            SendMessageToUIDataBroker(message);
            //if((message.APIDataType) == EapiDataTypes.PositionData)
            //{ }
            switch (message.APIDataType)
            {
                case EapiDataTypes.ExceptionData:
                    HandleException(message);
                    break;
                case EapiDataTypes.APIMessageData:
                    var apiMessageData = (APIMessageData)message ;
                    _uiMessageHandler?.Enqueue(message, false);
                    Logger.Debug(apiMessageData.ToString());
                    break;
                case EapiDataTypes.AccountSummaryData:
                    _accountManager.Enqueue(message, false);
                    MarginManager.UpdateAccountData((AccountSummaryData) message);
                    PropagateMessageToAllUnlManagers(message);
                    break;
                case EapiDataTypes.OptionData:
                    var optionData = (OptionData)message;
                    if (CalculateGreekLocally)
                    {
                        //ForTesting:
                        //if ((optionData.OptionContract.Symbol == "MSFT") && (optionData.OptionContract.Strike == 52) &
                        //    optionData.OptionContract.OptionType == EOptionType.Put )

                        {
                            optionData.UnderlinePrice =
                                ((UNLManager) (_unlManagersDic[optionData.OptionContract.Symbol])).
                                    MainSecurityData.LastPrice;
                            BnSCalcHelpper.UpdateGreekValues(optionData);
                        }

                    }
                    PropagateMessageToAdequateUnlManager(optionData);
                    WriteToDB(message);

                    break;
                case EapiDataTypes.PositionData:
                    var posData = (OptionsPositionData) message;
                    //in case that it was handled already, dont handle it agian, it can happen
                    //becasue the PositionDataBuilder send the position data again
                    if (posData.HandledByPositionDataBuilder)
                        break;
                    PropagateMessageToAdequateUnlManager(message);
                    WriteToDB(message);
                    break;
                case EapiDataTypes.OrderStatus:
                case EapiDataTypes.OrderData:
                case EapiDataTypes.SecurityContract:
                    PropagateMessageToAdequateUnlManager(message);
                    WriteToDB(message);
                    break;
                case EapiDataTypes.SecurityData:
                    _managedSecuritiesManager.Enqueue(message, false);
                   
                    //ForTesting: if(securityData.SecurityContract.Symbol == "VIX"){ }
                    PropagateMessageToAllUnlManagers(message);

                    WriteToDB(message);
                    break;
                case EapiDataTypes.BrokerConnectionStatus:
                    var statusMessage = message as BrokerConnectionStatusMessage;
                    if (statusMessage != null && statusMessage.Status == ConnectionStatus.TWSDisconnected)
                        AppManager.AppManagerSingleTonObject.OnTWSDisconnected();
                    PropagateMessageToAllComponents(message);
                    break;
                case EapiDataTypes.UnlTradingData:
                    MarginManager.UpdateUnlTradingData((UnlTradingData) message);
                    ((UnlTradingData)message).SetLastUpdate();
                    WriteToDB(message);
                    break;
                case EapiDataTypes.MarginData:
                    var marginData = (MarginData) message;
                    if (_unlManagersDic.ContainsKey(marginData.Symbol))
                        _unlManagersDic[marginData.Symbol].Enqueue(marginData,false);
                    break;
                case EapiDataTypes.UnlOption:
                    WriteToDB(message);
                    break;
            }
        }

        private UNLManager UnlManager => _unlManager ??
                                         (_unlManager = _unlManagersDic.Values.FirstOrDefault() as UNLManager);

        private void WriteToDB(IMessage message)
        {
            try
            {
                if (UnlManager.IsNowExtendedWorkingTime)
                {
                    _dbWriter.Enqueue(message, false);
                }
            }
            catch
            {
                _dbWriter.Enqueue(message, false);
            }
           
        }

        private void PropagateMessageToAdequateUnlManager(IMessage message)
        {
            var symbolMessage = (ISymbolMessage) message;
            string symbol = symbolMessage.GetSymbolName();
            if (_unlManagersDic.ContainsKey(symbol))
                _unlManagersDic[symbol].Enqueue(symbolMessage, false);
           
        }

        private void PropagateMessageToAllComponents(IMessage message)
        {
            _accountManager.Enqueue(message, false);
            _managedSecuritiesManager.Enqueue(message, false);
            _uiMessageHandler.Enqueue(message, false);
            PropagateMessageToAllUnlManagers(message);
        }

        private void PropagateMessageToAllUnlManagers(IMessage message)
        {
            foreach (var unlManager in _unlManagersDic.Values)
            {
                unlManager.Enqueue(message,false);
            }
        }

        private  void HandleException(IMessage message)
        {
            ExceptionData exceptionData = message as ExceptionData;
            if (exceptionData == null)
                return;
            _uiMessageHandler?.Enqueue(message, false);
            //ExceptionThrown?.Invoke(exceptionData);
            Logger.Error(exceptionData.ThrownException);
          
        }

        private int _optionDataHandledCount;
        private  UNLManager _unlManager;

        private void SendMessageToUIDataBroker(IMessage message)
        {
            switch (message.APIDataType)
            {
                case EapiDataTypes.PositionData:
                    var optionsPositionData = message as OptionsPositionData;
                    if((optionsPositionData != null) && optionsPositionData.HandledByPositionDataBuilder)
                        UIDataBroker.Enqueue(optionsPositionData);
                    break;
                case EapiDataTypes.UnlTradingData:
                case EapiDataTypes.OrderStatus:
                case EapiDataTypes.ManagedSecurity:
                case EapiDataTypes.AccountSummaryData:
                case EapiDataTypes.SecurityData:
                    UIDataBroker.Enqueue(message, false);
                    break;
                case EapiDataTypes.OptionData:
                    UIDataBroker.Enqueue(message, false);
                    Logger.Debug($"Distributer has sent to UIDataBroker {++_optionDataHandledCount} option data messages.@@@@"); 
                    break;
            }
        }

        public void AddUIMessageHandler(IBaseLogic uiMessageHandler)
        {
            _uiMessageHandler = uiMessageHandler;
        }
        public void AddUIDataBroker(IBaseLogic uiDataBroker)
        {
            UIDataBroker = uiDataBroker;
            _optionDataHandledCount = 0;

        }
    }
}