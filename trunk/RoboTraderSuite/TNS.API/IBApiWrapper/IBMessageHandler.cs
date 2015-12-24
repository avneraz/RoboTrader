using System;
using System.Collections.Generic;
using IBApi;
using log4net;
using TNS.API.ApiDataObjects;
using Infra;
using Infra.Bus;
using Infra.Extensions;
using Infra.Extensions.ArrayExtensions;

namespace TNS.API.IBApiWrapper
{

    class IBMessageHandler : EWrapper
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(IBMessageHandler));
        private readonly Dictionary<int, SecurityData> _securityDatas;
        private readonly Dictionary<int, OrderStatusData> _orderStatus;
        private readonly AccountSummaryData _accountSummary;
        //private readonly Dictionary<int, MainSecuritiesData> _mainSecuritiesDic;
        private readonly IBaseLogic _consumer;
        private const double EPSILON = 0.000000001;
        private const double LARGE_NUBMER = 100000000;
        //max time to close orders that are filled/failed in _orderStatus dic
        private readonly TimeSpan ORDER_MAX_TIME_SPAN = TimeSpan.FromMinutes(5);
         

        public IBMessageHandler(IBaseLogic consumer)
        {
            _securityDatas = new Dictionary<int, SecurityData>();
            _orderStatus = new Dictionary<int, OrderStatusData>();
            _accountSummary = new AccountSummaryData();
            _consumer = consumer;
            GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(1), PublishOptions, true);

        }

        #region EWrapper Overrides

        #region NotUsedMethods


        public void scannerData(int reqId, int rank, ContractDetails contractDetails, string distance, string benchmark,
            string projection, string legsStr)
        {

        }


        public void historicalData(int reqId, string date, double open, double high, double low, double close,
       int volume, int count,
       double WAP, bool hasGaps)
        {

        }

        public void tickString(int tickerId, int field, string value)
        {

        }

        public void tickGeneric(int tickerId, int field, double value)
        {

        }

        public void tickEFP(int tickerId, int tickType, double basisPoints, string formattedBasisPoints,
               double impliedFuture,
               int holdDays, string futureExpiry, double dividendImpact, double dividendsToExpiry)
        {

        }

        public void tickSnapshotEnd(int tickerId)
        {

        }

        public void managedAccounts(string accountsList)
        {

        }

        public void connectionClosed()
        {

        }

        public void bondContractDetails(int reqId, ContractDetails contract)
        {

        }

        public void updateAccountValue(string key, string value, string currency, string accountName)
        {

        }

        public void updateAccountTime(string timestamp)
        {

        }

        public void accountDownloadEnd(string account)
        {

        }


        public void openOrderEnd()
        {

        }

        public void contractDetails(int reqId, ContractDetails contractDetails)
        {

        }

        public void contractDetailsEnd(int reqId)
        {

        }

        public void execDetails(int reqId, Contract contract, Execution execution)
        {

        }

        public void execDetailsEnd(int reqId)
        {

        }

        public void commissionReport(CommissionReport commissionReport)
        {

        }

        public void fundamentalData(int reqId, string data)
        {

        }

        public void historicalDataEnd(int reqId, string start, string end)
        {

        }

        public void marketDataType(int reqId, int marketDataType)
        {

        }

        public void updateMktDepth(int tickerId, int position, int operation, int side, double price, int size)
        {

        }

        public void updateMktDepthL2(int tickerId, int position, string marketMaker, int operation, int side,
            double price, int size)
        {

        }

        public void updateNewsBulletin(int msgId, int msgType, string message, string origExchange)
        {

        }


        public void positionEnd()
        {

        }

        public void realtimeBar(int reqId, long time, double open, double high, double low, double close, long volume,
            double WAP,
            int count)
        {

        }

        public void scannerParameters(string xml)
        {

        }

        public void scannerDataEnd(int reqId)
        {

        }

        public void receiveFA(int faDataType, string faXmlData)
        {

        }

        public void verifyMessageAPI(string apiData)
        {

        }

        public void verifyCompleted(bool isSuccessful, string errorText)
        {

        }

        public void displayGroupList(int reqId, string groups)
        {

        }

        public void displayGroupUpdated(int reqId, string contractInfo)
        {

        }

        public void error(string str)
        {
        }

       
        public void currentTime(long time)
        {
        }

        public void deltaNeutralValidation(int reqId, UnderComp underComp)
        {
        }

        #endregion

        public void error(int id, int errorCode, string errorMsg)
        {
            APIMessageData apiMessageData = new APIMessageData()
            {
                Message = errorMsg,
                ErrorCode = errorCode,
                AdditionalInfo = id,
                UpdateTime = DateTime.Now
            };
            _consumer.Enqueue(apiMessageData);
            Logger.Info(apiMessageData.ToString());
        }


        public void error(Exception ex)
        {
            ExceptionData exceptionData = new ExceptionData(ex);
            _consumer.Enqueue(exceptionData);
            Logger.Error(exceptionData);
        }
        public void tickPrice(int tickerId, int field, double price, int canAutoExecute)
        {
            lock (_securityDatas)
            {
                Console.WriteLine(tickerId);
                var securityData = _securityDatas[tickerId];
                switch (field)
                {
                    case TickType.BID: //1
                        securityData.BidPrice = price > int.MaxValue ? -1 : price;
                        break;
                    case TickType.ASK:
                        securityData.AskPrice = price;
                        break;
                    case TickType.LAST:
                        securityData.LastPrice = price > int.MaxValue ? -1 : price;
                        break;
                    case TickType.HIGH:
                        securityData.HighestPrice = price > int.MaxValue ? -1 : price;
                        break;
                    case TickType.LOW:
                        securityData.LowestPrice = price > int.MaxValue ? -1 : price;
                        break;
                    case TickType.CLOSE:
                        securityData.BasePrice = price > int.MaxValue ? -1 : price;
                        if ((securityData.LastPrice <= 0) && (securityData.BasePrice > 0))
                            securityData.LastPrice = securityData.BasePrice;
                        break;
                    case TickType.OPEN:
                        securityData.OpeningPrice = price > int.MaxValue ? -1 : price;
                        break;
                }
            }
        }

        public void tickSize(int tickerId, int field, int size)
        {
            lock (_securityDatas)
            {
                var securityData = _securityDatas[tickerId];
                switch (field)
                {
                    case TickType.ASK_SIZE:
                        securityData.AskSize = size;
                        break;
                    case TickType.BID_SIZE:
                        securityData.BidSize = size;
                        break;
                    case TickType.LAST_SIZE:
                        break;
                    case TickType.VOLUME:
                        securityData.Volume = size;
                        break;
                }
            }
        }
     
        public void tickOptionComputation(int tickerId, int field, 
            double impliedVolatility, double delta, double optPrice,
            double pvDividend, double gamma, double vega, double theta, double undPrice)
        {
            lock (_securityDatas)
            {
                var optionData = _securityDatas[tickerId] as OptionData;
                optionData.ImpliedVolatility = impliedVolatility;
                double price;
                //TODO - reason for this switch case?
                switch (field)
                {
                    case TickType.BID_OPTION:
                        price = optPrice > int.MaxValue ? -1 : optPrice;
                        if (optionData.BidPrice < 0)
                            optionData.BidPrice = price;
                        else if ((optionData.BidPrice > EPSILON) && (price > 0))
                            optionData.BidPrice = price;

                        break;
                    case TickType.ASK_OPTION:
                        price = optPrice > int.MaxValue ? -1 : optPrice;
                        if (optionData.AskPrice < 0)
                            optionData.AskPrice = price;
                        else if ((optionData.AskPrice > EPSILON) && (price > 0))
                            optionData.AskPrice = price;

                        optionData.AskPrice = optPrice > int.MaxValue ? -1 : optPrice;
                        //TODO - why is implied voltality is here?
                        //if (message.ImpliedVolatility <= 1)
                        //    optionData.ImpliedVolatility = message.ImpliedVolatility;
                        break;
                    case TickType.LAST_OPTION:
                        optionData.LastPrice = optPrice > int.MaxValue ? -1 : optPrice;
                        break;
                    case TickType.MODEL_OPTION:
                        optionData.ModelPrice = optPrice > int.MaxValue ? -1 : optPrice;
                        break;
                }
                //filter defected values coming from IB
                if (Math.Abs(delta) < 10)
                    optionData.Delta = delta;
                if (gamma < 10)
                    optionData.Gamma = gamma;
                if (vega < 10)
                    optionData.Vega = vega;
                if (Math.Abs(theta) < 10)
                    optionData.Theta = theta;
                if (optionData.ImpliedVolatility < EPSILON)
                {
                    optionData.ImpliedVolatility = impliedVolatility;
                }


            }
        }

      

        public void nextValidId(int orderId)
        {
            NextOrderId = orderId;
        }

    

        public void accountSummary(int reqId, string account, string tag, string value, string currency)
        {
            switch (tag)
            {
                case "BuyingPower":
                    _accountSummary.BuyingPower = Convert.ToDouble(value);
                    break;
                case "EquityWithLoanValue ":
                    _accountSummary.EquityWithLoanValue = Convert.ToDouble(value);
                    break;
                case "BuyingPExcessLiquidity":
                    _accountSummary.ExcessLiquidity = Convert.ToDouble(value);
                    break;
                case "FullInitMarginReq":
                    _accountSummary.FullInitMarginReq = Convert.ToDouble(value);
                    break;
                case "FullMaintMarginReq":
                    _accountSummary.FullMaintMarginReq = Convert.ToDouble(value);
                    break;
                case "BuyingPNetLiquidation":
                    _accountSummary.NetLiquidation = Convert.ToDouble(value);
                    break;
            }
            
        }

        public void accountSummaryEnd(int reqId)
        {
            _consumer.Enqueue(_accountSummary);
        }

      

        public void updatePortfolio(Contract contract, int position, double marketPrice, double marketValue,
            double averageCost,
            double unrealisedPNL, double realisedPNL, string accountName)
        {

        }

     

        public void orderStatus(int orderId, string status, int filled, int remaining, double avgFillPrice, int permId,
            int parentId,
            double lastFillPrice, int clientId, string whyHeld)
        {
            if (_orderStatus.ContainsKey(orderId))
            {
                OrderStatusData orderStatus = _orderStatus[orderId];
                orderStatus.OrderStatus = (OrderStatus) Enum.Parse(typeof (OrderStatus), status);
                orderStatus.LastUpdateTime = DateTime.Now; ;
                _consumer.Enqueue(orderStatus);
            }
            else
            {
                Logger.Error($"Received order status on request not in _orderStatus dic, orderId is {orderId}");
            }
            
        }

        public void openOrder(int orderId, Contract contract, Order order, OrderState orderState)
        {
            CloseIrrelevantOrders();
            OrderStatusData status;
            if (!_orderStatus.TryGetValue(orderId, out status))
            {
                var orderData = order.ToOrderData();
                orderData.Contract = contract.ToContract();
                status = new OrderStatusData(orderId.ToString(), orderData);
                _orderStatus[orderId] = status;
            }
            status.LastUpdateTime = DateTime.Now;
            double maintMargin = Convert.ToDouble(orderState.MaintMargin);
            if (maintMargin < LARGE_NUBMER)
                status.MaintMargin = maintMargin;

        }

    


   
       
        public void position(string account, Contract contract, int pos, double avgCost)
        {
            var posData = new PositionData(contract.ToContract(), pos, avgCost);
            _consumer.Enqueue(posData);
        }

   


        #endregion

        public int NextOrderId { get; set; }

        private void PublishOptions()
        {
            lock (_securityDatas)
            {
                foreach (var securityData in _securityDatas.Values)
                {
                    _consumer.Enqueue(securityData);
                }
            }
        }

        public void RegisterContract(int requestId, ContractBase contract)
        {
            lock (_securityDatas)
            {
                SecurityData data;
                var optionContract = contract as OptionContract;
                if (optionContract != null)
                {
                    data = new OptionData();
                }
                else
                {
                    data = new SecurityData();
                }
                data.Contract = contract;
                _securityDatas.Add(requestId, data);
            }
        }
        private void CloseIrrelevantOrders()
        {
            _orderStatus.RemoveAll(item => DateTime.Now - item.LastUpdateTime > ORDER_MAX_TIME_SPAN &&
            item.OrderStatus.In(OrderStatus.Cancelled, OrderStatus.Filled));
        }
        public IEnumerable<int> GetCurrentOptionsRequestIds()
        {
            return _securityDatas.Keys;
        }

        public IEnumerable<int> GetCurrentMainSecuritiesRequestIds()
        {
            return _securityDatas.Keys;
        }
    }
}
