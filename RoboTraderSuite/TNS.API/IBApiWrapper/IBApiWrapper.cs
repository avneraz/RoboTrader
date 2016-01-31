using System;
using System.Collections.Generic;
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
        private readonly Dictionary<ContractBase, int> _contractToRequestIds;
        private int? _currentOrderId;
        // ReSharper disable once InconsistentNaming
        private readonly TimeSpan RECONNECTION_TIMEOUT = TimeSpan.FromSeconds(30);
        
        private int _curReqId;
        private readonly string _mainAccount;
        private readonly IBaseLogic _consumer;


        public int RequestId => ++_curReqId;

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
            _contractToRequestIds = new Dictionary<ContractBase, int>();
            _handler.ContractDetailsMessageReceived += HandlerOnContractDetailsMessage;
        }

        

        public bool IsConnected
        {
            get
            {
                if (_clientSocket == null)
                    return false;
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
            string tags = "NetLiquidation,EquityWithLoanValue,BuyingPower,ExcessLiquidity,FullMaintMarginReq,FullInitMarginReq";
            _clientSocket.reqAccountSummary(0, "All", tags);
            _clientSocket.reqAccountUpdates(true, _mainAccount);
        }

        /// <summary>
        ///  Request Options chain for specific UNL, the request applies for several months ahead!
        /// </summary>
        /// <param name="optionToLoadParameters"></param>
        public void RequestOptionChain(OptionToLoadParameters optionToLoadParameters)
        {
            Logger.Info($"{nameof(RequestOptionChain)} was called, loading {optionToLoadParameters}");

            if(OptionToLoadParametersDic == null)
                OptionToLoadParametersDic = new Dictionary<string, OptionToLoadParameters>();

            lock (OptionToLoadParametersDic)
            {
                OptionToLoadParametersDic.Add(optionToLoadParameters.Symbol, optionToLoadParameters); 
            }
            //First: Load pivot option
            OptionContract optionContract = optionToLoadParameters.OptionContractPivotToLoad;
           
            var requestId = RequestId;
            var ibContract = optionContract.ToIbContract();
            _clientSocket.reqContractDetails(requestId, ibContract);
        }

        public void UpdateOutOfBoundaryOption(string symbol, List<OptionContract> optionContractList)
        {
            lock (OptionToLoadParametersDic)
            {
                OptionToLoadParametersDic[symbol].AddOutOfBoundaryOptionContract(optionContractList);
            }
        }
      
        public Dictionary<string, OptionToLoadParameters> OptionToLoadParametersDic { get; set; }
        /// <summary>
        /// Request detail data for one security that is not option.
        /// The same like "RequestContinousContractData" but for 1 security.
        /// </summary>
        public void RequestSecurityContractDetails(SecurityData securityData)
        {
            ContractBase contractBase = securityData.GetContract();

            if (contractBase.SecurityType == SecurityType.Option)
                throw new Exception("This method is for securities other than options!!!");

            Contract ibContract = contractBase.ToIbContract();
            _handler.AddManagedSecurity(ibContract);
            Logger.Info($"{nameof(RequestSecurityContractDetails)} " +
                            $"called, requesting {ibContract}");
            int reqId = RequestId;
            _handler.RegisterContract(reqId, contractBase);
            _clientSocket.reqContractDetails(reqId, ibContract);
        }
        /// <summary>
        /// Request detail data for several securities taking place in trading.
        /// </summary>
        /// <param name="contracts"></param>
        public void RequestContinousContractData(List<ContractBase> contracts)
        {
            
            Logger.Info($"{nameof(RequestContinousContractData)} " + 
                            $"called, requesting {contracts.Count} contracts");
            contracts.ForEach(contract =>
            {
                if (contract.SecurityType != SecurityType.Option)
                    throw new Exception("This method is for option request only!!!");
                var requestId = RequestId;
                var ibContract = contract.ToIbContract();
               
                _clientSocket.reqContractDetails(requestId, ibContract);
            
            });
            
        }
        /// <summary>
        /// handle all received ContractDetails and make decision to request the entire options.
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="contractDetails"></param>
        private void HandlerOnContractDetailsMessage(int requestId, ContractDetails contractDetails)
        {
            var contractBase = contractDetails.Summary.ToContract();

            //if (_contractToRequestIds.ContainsKey(contractBase))
            //    return;

            _contractToRequestIds[contractBase] = requestId;
            int reqId = RequestId;
            if (contractBase.SecurityType != SecurityType.Option)
            {//Get market data for main securities:
                _clientSocket.reqMktData(reqId, contractDetails.Summary,
                    "100,225,233", false, new List<TagValue>());
                _handler.RegisterContract(reqId, contractBase);
                return;
            }
            if(OptionToLoadParametersDic == null)
                return;

            OptionToLoadParameters optionToLoadParameters;
            lock (OptionToLoadParametersDic)
            {
                optionToLoadParameters = OptionToLoadParametersDic[contractBase.Symbol]; 
            }

            var optionContractOrginal = (OptionContract)contractBase;

            if (optionToLoadParameters.IsOptionWithinLoadBoundaries(optionContractOrginal) == false)
                return;
            //request market data for the current option:
            _clientSocket.reqMktData(reqId, contractDetails.Summary, "100,225,233",
                false, new List<TagValue>());

            optionToLoadParameters.IncreamentRequestOptionMarketDataCounter();
            _handler.RegisterContract(reqId, contractBase);

            Logger.DebugFormat("##Request Market Data#{0}:{1}==>{2}", optionToLoadParameters.RequestOptionMarketDataCount, 
                optionContractOrginal.Symbol, optionContractOrginal.OptionKey);
            //If it's option, request all session option chain:
            //First: check if already exist, register it if needed:
            OptionContract optionContract = optionContractOrginal.Copy();
            optionContract.OptionType = EOptionType.None;
            optionContract.Strike = 0;//Use zero to get all existing options contract.
            if (_contractToRequestIds.ContainsKey(optionContract))
            {//don't request option chain that already exist
                return;
            }
            int reqId2 = RequestId;
            _contractToRequestIds[optionContract] = reqId2;
            _clientSocket.reqContractDetails(reqId2, optionContract.ToIbContract());
            
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
            Logger.Info($"Create orderData was called with {orderData}");
            int orderId = CurrentOrderId;
            string orderIdStr = orderId.ToString();

            var ibOrder = orderData.ToIbOrder(_mainAccount, orderIdStr);

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
