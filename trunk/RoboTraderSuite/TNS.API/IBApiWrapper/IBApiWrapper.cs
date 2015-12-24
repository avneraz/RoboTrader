using System;
using System.Collections.Generic;
using IBApi;
using TNS.API.ApiDataObjects;
using Infra.Bus;
using Infra.Extensions.ArrayExtensions;

namespace TNS.API.IBApiWrapper
{
    public class IBApiWrapper : ITradingApi
    {
        private readonly int _clientId;
        private readonly string _host;
        private readonly int _port;
        private readonly EClientSocket _clientSocket;
        private readonly IBMessageHandler _handler;
        private int? _currentOrderId;
        
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

        }
        public void ConnectToBroker()
        {
            //TODO: error handling
            _clientSocket.eConnect(_host, _port, _clientId);
        }

        public void RequestAccountData()
        {
            string tags = "NetLiquidation,EquityWithLoanValue,BuyingPower,ExcessLiquidity,FullMaintMarginReq,FullInitMarginReq";
            _clientSocket.reqAccountSummary(0, "All", tags);
            _clientSocket.reqAccountUpdates(true, _mainAccount);
        }

        public void RequestContinousOptionChainData(List<OptionContract> contracts)
        {
            _handler.GetCurrentOptionsRequestIds().ForEach(requestId =>
            {
                _clientSocket.cancelMktData(requestId);
            });


            contracts.ForEach(c =>
            {
                Contract ibContract = c.ToIbContract();
                //TODO: merge requestId for same contract? if it's requested few times? clear the old ones?
                int requestId = RequestId;
                _clientSocket.reqContractDetails(requestId, ibContract);
                _handler.RegisterOption(requestId, c);
                _clientSocket.reqMktData(requestId, ibContract, "100,225,233", false, new List<TagValue>());
            });

            
        }
        //public void RequestContinousMainSecuritiesData(List<ContractBase> contracts)
        //{
        //    _handler.GetCurrentOptionsRequestIds().ForEach(requestId =>
        //    {
        //        _clientSocket.cancelMktData(requestId);
        //    });


        //    contracts.ForEach(c =>
        //    {
        //        Contract ibContract = c.ToIbContract();
        //        //TODO: merge requestId for same contract? if it's requested few times? clear the old ones?
        //        int requestId = RequestId;
        //        _clientSocket.reqContractDetails(requestId, ibContract);
        //        _handler.RegisterOption(requestId, c);
        //        _clientSocket.reqMktData(requestId, ibContract, "100,225,233", false, new List<TagValue>());
        //    });


        //}

        public void RequestContinousPositionsData()
        {
            _clientSocket.reqPositions();
        }

        public string CreateOrder(OptionContract contract, OrderData order)
        {
            int orderId = CurrentOrderId;
            string orderIdStr = orderId.ToString();

            var ibOrder = order.ToIbOrder(_mainAccount, orderIdStr);

            _clientSocket.placeOrder(orderId, contract.ToIbContract(), ibOrder);
            return orderIdStr;
        }

        public void UpdateOrder(string orderId, OptionContract contract, OrderData order)
        {
            var ibOrder = order.ToIbOrder(_mainAccount, orderId);
            _clientSocket.placeOrder(Convert.ToInt32(orderId), contract.ToIbContract(), ibOrder);
        }

        public void CancelOrder(string orderId)
        {
            _clientSocket.cancelOrder(Convert.ToInt32(orderId));
        }
    }
}
