using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using IBApi;
using Infra;
using TNS.API.ApiDataObjects;
using Infra.Bus;
using Infra.Enum;
using Infra.Extensions;
using Infra.Extensions.ArrayExtensions;
using log4net;
using log4net.Repository.Hierarchy;

namespace TNS.API.IBApiWrapper
{
    public class IBApiWrapper : ITradingApi 
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(IBMessageHandler));
        private readonly int _clientId;
        private readonly string _host;
        private readonly int _port;
        private readonly EClientSocket _clientSocket;
        private readonly IBMessageHandler _handler;
        private int? _currentOrderId;
        // ReSharper disable once InconsistentNaming
        private readonly TimeSpan RECONNECTION_TIMEOUT = TimeSpan.FromSeconds(30);
        
        private int _curReqId;
        private readonly string _mainAccount;
        private readonly IBaseLogic _consumer;

        

        private int GenerateRequestId()
        {
            return ++_curReqId;
        }
        /// <summary>
        /// Get the current updated OrderId.
        /// On the very first time it's taken from the TWS
        /// </summary>
        public int CurrentOrderId
        {
            get
            {
                if (_currentOrderId == null)
                    _currentOrderId = _handler.NextOrderId;
                else
                    _currentOrderId++;
                return _currentOrderId.Value;
            }
        }

        public IBApiWrapper(string host, int port, int clientId, IBaseLogic consumer, string mainAccount)
        {
            _host = host;
            _port = port;
            _clientId = clientId;
            _mainAccount = mainAccount;
            _consumer = consumer;
            _handler = new IBMessageHandler(consumer);
            _clientSocket = new EClientSocket(_handler);
            _curReqId = 0;
            _handler.ConnectivityIbTwsRestored += ResetAfterReconnection;

        }

        /// <summary>
        /// If the connection restored, reset the requests for continuous data like account and position.
        /// </summary>
        private void ResetAfterReconnection()
        {
            ResetAccountSummaryRequest();
            Debug.Print(" ResetAfterReconnection() called!!!");
            _clientSocket.reqPositions();
        }

        public bool IsConnected
        {
            get
            {
                if (_clientSocket == null)
                    return false;
                if(_clientSocket.IsConnected() == false)
                    ConnectToBroker();
                return _clientSocket.IsConnected();
            }
        }

        public void ConnectToBroker()
        {
            //TODO: error handling
            if (_clientSocket.IsConnected())
            {
                Logger.Warn("ConnectToBroker called although we already connected");
                return;
            }
            _clientSocket.eConnect(_host, _port, _clientId);
            if (!_clientSocket.IsConnected())
            {
                GeneralTimer.GeneralTimerInstance.AddTask(RECONNECTION_TIMEOUT, ConnectToBroker, false);
                Logger.Error($"Failed to connect to TWS, going to retry in {RECONNECTION_TIMEOUT}");
            }
            else
            {
                //this tells tws to send market data even when there is no active trading
                _clientSocket.reqMarketDataType(2);
                _consumer.Enqueue(new BrokerConnectionStatusMessage(
                                ConnectionStatus.Connected, null)
                                { AfterConnectionToApiWrapper = true } );
            }
            
        }

        public void DisconnectFromBroker()
        {
            if (IsConnected == false)
            {
                Logger.Warn("DisonnectFromBroker called although we already disconnected");
                return;
            }
            _clientSocket.eDisconnect();
            Logger.Warn("DisonnectFromBroker called. We are disconnected from TWS!");
            
        }
        public void RequestAccountData()
        {
            Logger.DebugFormat(nameof(RequestAccountData) , " called");
            string tags = "NetLiquidation,EquityWithLoanValue,BuyingPower,ExcessLiquidity,FullMaintMarginReq,FullInitMarginReq,FullExcessLiquidity";
            _clientSocket.reqAccountSummary(0, "All", tags);
            _clientSocket.reqAccountUpdates(true, _mainAccount);
        }

        /// <summary>
        /// Called when Connectivity between IB and TWS has been restored(Code 1102), 
        /// <para> Or when A market data farm is connected(Code 2104).Usually occurred after disconnection.</para>
        ///  </summary>
        public void ResetAccountSummaryRequest()
        {
            _clientSocket.cancelAccountSummary(0);
            RequestAccountData();
        }
        /// <summary>
        ///  Request Options chain for specific UNL, the request applies for several months ahead!
        /// </summary>
        /// <param name="optionToLoadParameters"></param>
        public async void RequestOptionChain(OptionToLoadParameters optionToLoadParameters)
        {
            Logger.Info($"{nameof(RequestOptionChain)} was called, loading {optionToLoadParameters}");
           
            //First: Load pivot option
            OptionContract optionContract = optionToLoadParameters.OptionContractPivotToLoad;
           
            var requestId = GenerateRequestId();
            var ibContract = optionContract.ToIbContract();
            var task = _handler.WaitForContractDetails(requestId);
            _clientSocket.reqContractDetails(requestId, ibContract);
            var contractDetailsList = await task;
            contractDetailsList.Where(c =>
                optionToLoadParameters.IsOptionWithinLoadBoundaries((OptionContract) c.Summary.ToContract())
            ).ForEach(RequestMarketData);
        }
    
      
        /// <summary>
        /// Request detail data for one security that is not option.
        /// The same like "RequestContinousContractData" but for 1 security.
        /// </summary>
        public async void RequestSecurityContractDetails(SecurityData securityData)
        {
            ContractBase contractBase = securityData.GetContract();

            if (contractBase.SecurityType == SecurityType.Option)
                throw new Exception("This method is for securities other than options!!!");

            Contract ibContract = contractBase.ToIbContract();
            _handler.AddManagedSecurity(ibContract);
            Logger.Info($"{nameof(RequestSecurityContractDetails)} " +
                            $"called, requesting {ibContract}");
            int reqId = GenerateRequestId();
            _clientSocket.reqContractDetails(reqId, ibContract);
            var contracts = await _handler.WaitForContractDetails(reqId);
            contracts.ForEach(RequestMarketData);
        }
        /// <summary>
        /// Request detail data for several securities taking place in trading.
        /// </summary>
        /// <param name="contracts"></param>
        public void RequestContinousContractData(List<ContractBase> contracts)
        {
            
            Logger.Info($"{nameof(RequestContinousContractData)} " + 
                            $"called, requesting {contracts.Count} contracts");
            contracts.ForEach(async contract =>
            {
                if (contract.SecurityType != SecurityType.Option)
                    throw new Exception("This method is for option request only!!!");
                var requestId = GenerateRequestId();
                var ibContract = contract.ToIbContract();
                var contractTask = _handler.WaitForContractDetails(requestId);
                _clientSocket.reqContractDetails(requestId, ibContract);
                var contractDetailsList = await contractTask;
                contractDetailsList.ForEach(RequestMarketData);
            });
            
        }

        private void RequestMarketData(ContractDetails contractDetails)
        {
            int reqId = GenerateRequestId();
            var baseContract = _handler.RegisterContract(reqId, contractDetails.Summary.ToContract(), contractDetails);
            _consumer.Enqueue(baseContract);
            _clientSocket.reqMktData(reqId, contractDetails.Summary, "100,225,233",
                                    false, new List<TagValue>());
        }
       
        /// <summary>
        /// IB Broker return all positions with this request it has to be only one request!
        /// </summary>
        private bool _requestContinousPositionsDataDone = false;

        

        public void RequestContinousPositionsData()
        {
            if(_requestContinousPositionsDataDone)
                return;

            Logger.Debug($"{nameof(RequestContinousPositionsData)} called");
            _clientSocket.reqPositions();
            _requestContinousPositionsDataDone = true;
        }

        public string CreateOrder(OrderData orderData)
        {
            if(!IsConnected) throw new Exception("TWS not connected to RoboTrader!");
            Logger.Info($"Create orderData was called with {orderData}");
            int orderId = CurrentOrderId;
            string orderIdStr = orderId.ToString();

            var ibOrder = orderData.ToIbOrder(_mainAccount, orderIdStr);
            ibOrder.Transmit = true;
            _clientSocket.placeOrder(orderId, orderData.Contract.ToIbContract(), ibOrder);
            return orderIdStr;
        }

        public void UpdateOrder(string orderId,  OrderData order)
        {
            Logger.Info($"UpdateOrder was called, orderId: {orderId}, Order: {order}");
            var ibOrder = order.ToIbOrder(_mainAccount, orderId);
            _clientSocket.placeOrder(Convert.ToInt32(orderId), order.Contract.ToIbContract(), ibOrder);
        }

        public void CancelOrder(string orderId)
        {
            // ReSharper disable once EmptyStatement
            Logger.Info($"CancelOrder was called, orderId: {orderId}");
            _clientSocket.cancelOrder(Convert.ToInt32(orderId));
        }
    }
}
