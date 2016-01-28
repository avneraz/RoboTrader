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
            DBWriter writer, MarginManager marginManager)
        {
            _unlManagersDic = unlManagerDic;
            _accountManager = accountManager;
            _managedSecuritiesManager = managedSecuritiesManager;
            _dbWriter = writer;
            _marginManager = marginManager;
        }


        private  Dictionary<string, SimpleBaseLogic> _unlManagersDic;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Distributer));

        private  ManagedSecuritiesManager _managedSecuritiesManager;
        private  AccountManager _accountManager;
        private DBWriter _dbWriter;
        private IBaseLogic _uiMessageHandler;
        private IBaseLogic UIDataBroker { get; set; }
        private MarginManager _marginManager;

        protected override void HandleMessage(IMessage message)
        {
            //For evaluation only:
            SendMessageToUIDataBroker(message);
            //if((message.APIDataType) == EapiDataTypes.PositionData)
            //{ }
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
                    _marginManager.UpdateAccountData((AccountSummaryData) message);
                    break;
                case EapiDataTypes.PositionData:
                    symbolMessage = (ISymbolMessage)message;
                    string symbol1 = symbolMessage.GetSymbolName();
                    if (_unlManagersDic.ContainsKey(symbol1))
                        _unlManagersDic[symbol1].Enqueue(symbolMessage, false);
                    _dbWriter.Enqueue(message, false);
                    break;
                case EapiDataTypes.OptionData:
                //case EapiDataTypes.PositionData:
                case EapiDataTypes.OrderStatus:
                case EapiDataTypes.OrderData:
                case EapiDataTypes.SecurityContract:
                    symbolMessage = (ISymbolMessage)message;
                    string symbol = symbolMessage.GetSymbolName();
                    if (_unlManagersDic.ContainsKey(symbol))
                        _unlManagersDic[symbol].Enqueue(symbolMessage, false);
                    _dbWriter.Enqueue(message,false);
                    break;
                case EapiDataTypes.SecurityData:
                    _managedSecuritiesManager.Enqueue(message, false);
                   
                    //ForTesting: if(securityData.SecurityContract.Symbol == "VIX"){ }
                    SendToAllUnlManagers(message);
                  
                    _dbWriter.Enqueue(message, false);
                    break;
                case EapiDataTypes.BrokerConnectionStatus:
                    SendToAllComponents(message);
                    break;
                case EapiDataTypes.UnlTradingData:
                    _marginManager.UpdateUnlTradingData((UnlTradingData) message);
                   break;
                case EapiDataTypes.MarginData:
                    var marginData = (MarginData) message;
                    if (_unlManagersDic.ContainsKey(marginData.Symbol))
                        _unlManagersDic[marginData.Symbol].Enqueue(marginData,false);
                    break;
                
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
                    UIDataBroker.Enqueue(message);
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
        }
    }
}