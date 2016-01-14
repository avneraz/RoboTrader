﻿using System;
using System.Collections.Generic;
using DAL;
using log4net;
using TNS.API.ApiDataObjects;
using Infra.Bus;
using Infra.Enum;

namespace TNS.BL
{
    public class Distributer : SimpleBaseLogic
    {

        public Distributer()
        {
            
        }
        public void SetManagers(Dictionary<string, SimpleBaseLogic> unlManagerDic,
            AccountManager accountManager, ManagedSecuritiesManager managedSecuritiesManager,
            DBWriter writer)
        {
            _unlManagersDic = unlManagerDic;
            _accountManager = accountManager;
            _managedSecuritiesManager = managedSecuritiesManager;
            _dbWriter = writer;
        }


        private  Dictionary<string, SimpleBaseLogic> _unlManagersDic;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Distributer));

        private  ManagedSecuritiesManager _managedSecuritiesManager;
        private  AccountManager _accountManager;
        private DBWriter _dbWriter;
        private IBaseLogic _uiMessageHandler;

        protected override void HandleMessage(IMessage message)
        {
            ISymbolMessage symbolMessage;
            switch (message.APIDataType)
            {
                case EapiDataTypes.ExceptionData:
                    HandleException(message);
                    break;
                case EapiDataTypes.APIMessageData:
                    var apiMessageData = (APIMessageData)message ;
                    _uiMessageHandler?.Enqueue(message, false);
                    //APIMessageArrive?.Invoke(apiMessageData);
                    Logger.Debug(apiMessageData.ToString());
                    break;
                case EapiDataTypes.AccountSummaryData:
                    _accountManager.Enqueue(message, false);
                    break;
                case EapiDataTypes.OptionData:
                case EapiDataTypes.PositionData:
                case EapiDataTypes.OrderStatus:
                case EapiDataTypes.OrderData:
                    symbolMessage = (ISymbolMessage)message;
                    _unlManagersDic[symbolMessage.GetSymbolName()].Enqueue(symbolMessage, false);
                    _dbWriter.Enqueue(message,false);
                    break;
                case EapiDataTypes.SecurityData:
                    _managedSecuritiesManager.Enqueue(message, false);
                     symbolMessage = (ISymbolMessage)message;
                    var key = symbolMessage.GetSymbolName();
                    if (_unlManagersDic.ContainsKey(key))
                        _unlManagersDic[key].Enqueue(symbolMessage, false);
                    _dbWriter.Enqueue(message, false);
                    break;
                case EapiDataTypes.BrokerConnectionStatus:
                    SendToAllComponents(message);
                    break;
                case EapiDataTypes.EndAsynchData:
                    //SendToAllUnlManagers(message);
                    break;
                case EapiDataTypes.ContractDetailsData:
                    SendToAllUnlManagers(message);
                    break;
                default:
                     throw new ArgumentOutOfRangeException();
            }
        }

        private void SendToAllComponents(IMessage message)
        {
            _accountManager.Enqueue(message, false);
            _managedSecuritiesManager.Enqueue(message, false);
            _uiMessageHandler.Enqueue(message, false);
            SendToAllUnlManagers(message);
        }

        private void SendToAllUnlManagers(IMessage message)
        {
            foreach (var unlManager in _unlManagersDic.Values)
            {
                unlManager.Enqueue(message);
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

        public void AddUIMessageHandler(IBaseLogic uiMessageHandler)
        {
            _uiMessageHandler = uiMessageHandler;
        }
    }
}