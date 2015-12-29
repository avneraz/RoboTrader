using System;
using System.Collections.Generic;
using log4net;
using TNS.API.ApiDataObjects;
using Infra.Bus;
using Infra.Enum;

namespace TNS.BL
{
    public class Distributer : SimpleBaseLogic
    {
        //private ITradingApi _apiWrapper;

        public Distributer()
        {
            
        }
        public void SetManagers(Dictionary<string, SimpleBaseLogic> unlManagerDic, AccountManager accountManager, MainSecuritiesManager mainSecuritiesManager)
        {
            _unlManagersDic = unlManagerDic;
            _accountManager = accountManager;
            _mainSecuritiesManager = mainSecuritiesManager;
        }

        public event Action<ExceptionData> ExceptionThrown;
        public event Action<APIMessageData> APIMessageArrive;
        public event Action<BrokerConnectionStatusMessage> ConnectionChanged;

        private  Dictionary<string, SimpleBaseLogic> _unlManagersDic;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Distributer));
        private  MainSecuritiesManager _mainSecuritiesManager;
        private  AccountManager _accountManager;

        protected override void HandleMessage(IMessage message)
        {

            switch (message.APIDataType)
            {
                case EapiDataTypes.ExceptionData:
                    HandleException(message);
                    break;
                case EapiDataTypes.APIMessageData:
                    var apiMessageData = message as APIMessageData;
                    if (apiMessageData == null)
                        break;
                    APIMessageArrive?.Invoke(apiMessageData);
                    Logger.Debug(apiMessageData.ToString());
                    break;
                case EapiDataTypes.AccountSummaryData:
                    _accountManager.Enqueue(message, false);
                    break;
                case EapiDataTypes.OptionData:
                case EapiDataTypes.PositionData:
                case EapiDataTypes.OrderStatus:
                    ISymbolMessage symbolMessage = message as ISymbolMessage;
                    _unlManagersDic[symbolMessage.GetSymbolName()].Enqueue(symbolMessage, false);
                    break;
                case EapiDataTypes.SecurityData:
                    _mainSecuritiesManager.Enqueue(message, false);
                    break;
                case EapiDataTypes.BrokerConnectionStatus:
                    BrokerConnectionStatusMessage connectionStatusMessage =
                        message as BrokerConnectionStatusMessage;
                    ConnectionChanged?.Invoke(connectionStatusMessage);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private  void HandleException(IMessage meesage)
        {

            try
            {
                ExceptionData exceptionData = meesage as ExceptionData;
                if (exceptionData == null)
                    return;
                ExceptionThrown?.Invoke(exceptionData);

                Logger.Error(exceptionData.ThrownException);
            }
            catch (Exception ex)
            {

                Logger.Error(ex);
            }
        }
        public override void DoWorkAfterConnection()
        {
            throw new NotImplementedException();
        }
    }
}