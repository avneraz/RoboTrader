using System;
using System.Collections.Generic;
using IBApi;
using Infra;
using TNS.API.ApiDataObjects;
using Infra.Bus;
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
        private readonly TimeSpan RECONNECTION_TIMEOUT = TimeSpan.FromSeconds(30);
        
        private int _curReqId;
        private readonly string _mainAccount;


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
            _handler = new IBMessageHandler(consumer);
            _clientSocket = new EClientSocket(_handler);
            _curReqId = 0;
            _contractToRequestIds = new Dictionary<ContractBase, int>();
            _handler.ContractDetailsMessageSent += HandlerOnContractDetailsMessageSent;
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

        public void RequestContinousContractData(List<ContractBase> contracts)
        {

            Logger.Info($"{nameof(RequestContinousContractData)} called, requesting {contracts.Count} contracts");
            contracts.ForEach(contract =>
            {
                if (_contractToRequestIds.ContainsKey(contract)) return;

                int requestId = RequestId;
                var ibContract = contract.ToIbContract();

                if (ibContract.Symbol == "MSFT")//For test only
                {
                    ibContract.PrimaryExch = "NASDAQ";
                }
                _contractToRequestIds[contract] = requestId;
                _clientSocket.reqContractDetails(requestId, ibContract);//TOADO ==> change the flow
                _handler.RegisterContract(requestId, contract);
                //_clientSocket.reqMktData(requestId, ibContract, "100,225,233", false, new List<TagValue>());
            });
            
        }
        private void HandlerOnContractDetailsMessageSent(int requestId, ContractDetails contractDetails)
        {
            _clientSocket.reqMktData(requestId, contractDetails.Summary,
                                     "100,225,233", false, new List<TagValue>());
        }
        public void RequestContinousPositionsData()
        {
            Logger.Debug($"{nameof(RequestContinousPositionsData)} called");
            _clientSocket.reqPositions();
        }

        public string CreateOrder(OrderData order)
        {
            Logger.Info($"Create order was called with {order}");
            int orderId = CurrentOrderId;
            string orderIdStr = orderId.ToString();

            var ibOrder = order.ToIbOrder(_mainAccount, orderIdStr);

            _clientSocket.placeOrder(orderId, order.Contract.ToIbContract(), ibOrder);
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
            Logger.Info($"CancelOrder was called, orderId: {orderId}");
            _clientSocket.cancelOrder(Convert.ToInt32(orderId));
        }
    }
}
