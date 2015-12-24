using System;
using System.Collections.Generic;
using IBApi;
using log4net;
using TNS.API.ApiDataObjects;
using TNS.Global;
using TNS.Global.Bus;

namespace TNS.API.IBApiWrapper
{

    class IBMessageHandler : EWrapper
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(IBMessageHandler));
        private readonly Dictionary<int, OptionData> _optionsDic;
        //private readonly Dictionary<int, MainSecuritiesData> _mainSecuritiesDic;
        private readonly IBaseLogic _consumer;
        private const double EPSILON = 0.000000001;
         

        public IBMessageHandler(IBaseLogic consumer)
        {
            _optionsDic = new Dictionary<int, OptionData>();
            _consumer = consumer;
            GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(1), PublishOptions, true);

        }

        #region EWrapper Overrides

        #region NotUsedMethods

        public void error(Exception ex)
        {
            ExceptionData exceptionData = new ExceptionData(ex);
            _consumer.Enqueue(exceptionData);
            Logger.Error(exceptionData);
        }

        public void error(string str)
        {
        }

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

        public void currentTime(long time)
        {
        }

        public void deltaNeutralValidation(int reqId, UnderComp underComp)
        {
        }

        #endregion


        public void tickPrice(int tickerId, int field, double price, int canAutoExecute)
        {
            lock (_optionsDic)
            {
                var optionData = _optionsDic[tickerId];
                switch (field)
                {
                    case TickType.BID: //1
                        optionData.BidPrice = price > int.MaxValue ? -1 : price;
                        break;
                    case TickType.ASK:
                        optionData.AskPrice = price;
                        break;
                    case TickType.LAST:
                        optionData.LastPrice = price > int.MaxValue ? -1 : price;
                        break;
                    case TickType.HIGH:
                        optionData.HighestPrice = price > int.MaxValue ? -1 : price;
                        break;
                    case TickType.LOW:
                        optionData.LowestPrice = price > int.MaxValue ? -1 : price;
                        break;
                    case TickType.CLOSE:
                        optionData.BasePrice = price > int.MaxValue ? -1 : price;
                        if ((optionData.LastPrice <= 0) && (optionData.BasePrice > 0))
                            optionData.LastPrice = optionData.BasePrice;
                        break;
                    case TickType.OPEN:
                        optionData.OpeningPrice = price > int.MaxValue ? -1 : price;
                        break;
                }


            }

        }

        public void tickSize(int tickerId, int field, int size)
        {
            lock (_optionsDic)
            {
                var optionData = _optionsDic[tickerId];
                switch (field)
                {
                    case TickType.ASK_SIZE:
                        optionData.AskSize = size;
                        break;
                    case TickType.BID_SIZE:
                        optionData.BidSize = size;
                        break;
                    case TickType.LAST_SIZE:
                        break;
                    case TickType.VOLUME:
                        optionData.Volume = size;
                        break;
                }
            }
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



        public void tickOptionComputation(int tickerId, int field, 
            double impliedVolatility, double delta, double optPrice,
            double pvDividend, double gamma, double vega, double theta, double undPrice)
        {
            lock (_optionsDic)
            {
                var optionData = _optionsDic[tickerId];
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

        public void tickSnapshotEnd(int tickerId)
        {

        }

        public void nextValidId(int orderId)
        {
            NextOrderId = orderId;
        }

        public void managedAccounts(string accountsList)
        {

        }

        public void connectionClosed()
        {

        }

        public void accountSummary(int reqId, string account, string tag, string value, string currency)
        {

            AccountMemberData accountMemberData = new AccountMemberData(account, tag, value, currency);
            accountMemberData.UpdateAccountSummary();
            _consumer.Enqueue(AccountSummaryData.AccountSummaryDataObject);
            Logger.Debug(AccountSummaryData.AccountSummaryDataObject);
        }

        public void accountSummaryEnd(int reqId)
        {

        }

        public void bondContractDetails(int reqId, ContractDetails contract)
        {

        }

        public void updateAccountValue(string key, string value, string currency, string accountName)
        {
           
        }

        public void updatePortfolio(Contract contract, int position, double marketPrice, double marketValue,
            double averageCost,
            double unrealisedPNL, double realisedPNL, string accountName)
        {

        }

        public void updateAccountTime(string timestamp)
        {

        }

        public void accountDownloadEnd(string account)
        {

        }

        public void orderStatus(int orderId, string status, int filled, int remaining, double avgFillPrice, int permId,
            int parentId,
            double lastFillPrice, int clientId, string whyHeld)
        {

        }

        public void openOrder(int orderId, Contract contract, Order order, OrderState orderState)
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

        public void historicalData(int reqId, string date, double open, double high, double low, double close,
            int volume, int count,
            double WAP, bool hasGaps)
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

        public void position(string account, Contract contract, int pos, double avgCost)
        {
            var posData = new PositionData(contract.ToOptionContract(), pos, avgCost);
            _consumer.Enqueue(posData);
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

        public void scannerData(int reqId, int rank, ContractDetails contractDetails, string distance, string benchmark,
            string projection, string legsStr)
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

        #endregion

        public int NextOrderId { get; set; }

        private void PublishOptions()
        {
            lock (_optionsDic)
            {
                foreach (var optionData in _optionsDic.Values)
                {
                    _consumer.Enqueue(optionData);
                }
            }
        }

        public void RegisterOption(int requestId, OptionContract contract)
        {
            lock (_optionsDic)
            {
                _optionsDic.Add(requestId, new OptionData() { Contract = contract });
                
            }
        }

        public IEnumerable<int> GetCurrentOptionsRequestIds()
        {
            return _optionsDic.Keys;
        }

        public IEnumerable<int> GetCurrentMainSecuritiesRequestIds()
        {
            return _optionsDic.Keys;
        }
    }
}
