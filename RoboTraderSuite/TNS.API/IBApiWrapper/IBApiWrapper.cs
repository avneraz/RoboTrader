using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using IBApi;
using Infra;
using TNS.API.ApiDataObjects;
using Infra.Bus;
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
        /// Request Options chain for specific UNL, the request applies for several months ahead!
        /// </summary>
        /// <param name="securityData"></param>
        /// <param name="months">The max month ahead for loading option data</param>
        /// <param name="minDaysToExpired">The minimum days left of the loading options.</param>
        /// <param name="multiplier"></param>
        public void RequestOptionChain(BaseSecurityData securityData, int months,
            int minDaysToExpired,int multiplier = 100)
        {
            _monthsAheadToLoadOptionChain = months;
            _minDaysToExpired = minDaysToExpired;
            ContractBase contractBase = securityData.GetContract();

            string exchange = contractBase.Exchange;
            var strike = (int) Math.Round(securityData.LastPrice/10, 0, MidpointRounding.AwayFromZero)*10; 
            //First: Load template
            OptionContract optionContract = new OptionContract
            {
                Exchange = exchange,
                Multiplier = multiplier,
                Symbol = contractBase.Symbol,
                SecurityType = SecurityType.Option,
                Strike = strike, //TODO Add it from MainSecurity
                OptionType = OptionType.Call
            };

            var requestId = RequestId;
            var ibContract = optionContract.ToIbContract();
            _clientSocket.reqContractDetails(requestId, ibContract);
        }

        private int _minDaysToExpired;
        private int _monthsAheadToLoadOptionChain;
        /// <summary>
        /// Request detail data for all securities taking place in trading.
        /// </summary>
        public void RequestContractDetailsData(BaseSecurityData securityData)
        {
            Contract ibContract = securityData.GetContract().ToIbContract();
            _handler.AddSecurityTrader(ibContract);
            Logger.Info($"{nameof(RequestContractDetailsData)} " +
                            $"called, requesting {ibContract}");

           _clientSocket.reqContractDetails(RequestId, ibContract);
        }

        public void RequestContinousContractData(List<ContractBase> contracts)
        {

            Logger.Info($"{nameof(RequestContinousContractData)} " + 
                            $"called, requesting {contracts.Count} contracts");
            contracts.ForEach(contract =>
            {
                var requestId = RequestId;
                var ibContract = contract.ToIbContract();
               
                _clientSocket.reqContractDetails(requestId, ibContract);
            
            });
            
        }
        private void HandlerOnContractDetailsMessage(int requestId, ContractDetails contractDetails)
        {
            
            var contractBase = contractDetails.Summary.ToContract();
            if (_contractToRequestIds.ContainsKey(contractBase))
                return;
            _contractToRequestIds[contractBase] = requestId;
            int reqId = RequestId;
            if (contractBase.SecurityType != SecurityType.Option)
            {//Get market data for main securities:
                _clientSocket.reqMktData(reqId, contractDetails.Summary,
                    "100,225,233", false, new List<TagValue>());
                _handler.RegisterContract(reqId, contractBase);
                return;
            }
            var optionContractOrginal = (OptionContract)contractBase;

            if (IsOptionWithinTimeBoundary(optionContractOrginal) == false)
                return;
            //request market data for the current option:
            _clientSocket.reqMktData(reqId, contractDetails.Summary,
                "100,225,233", false, new List<TagValue>());
            _handler.RegisterContract(reqId, contractBase);
            
            //If it's option, request all session option chain:
            //First: check if already exist, register it if needed:
            OptionContract optionContract = optionContractOrginal.Copy();
            optionContract.OptionType = OptionType.None;
            optionContract.Strike = 0;
            if (_contractToRequestIds.ContainsKey(optionContract))
            {//don't request option chain that already exist
                return;
            }
            int reqId2 = RequestId;
            _contractToRequestIds[optionContract] = reqId2;
            _clientSocket.reqContractDetails(reqId2, optionContract.ToIbContract());
            
        }

  

        /// <summary>
        /// Check if the option is between the time boundary.
        /// 
        /// </summary>
        /// <param name="optionContractOrginal"></param>
        /// <returns></returns>
        private bool IsOptionWithinTimeBoundary(OptionContract optionContractOrginal)
        {
            bool isExpiryTooClose = (DateTime.Now.AddDays(_minDaysToExpired) > optionContractOrginal.Expiry);
            bool isExpiryTooFar = (optionContractOrginal.Expiry > DateTime.Now.AddMonths(_monthsAheadToLoadOptionChain));
            if (isExpiryTooFar || isExpiryTooClose)
                return false;
            return true;
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
