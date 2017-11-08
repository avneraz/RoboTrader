using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IBApi;
using log4net;
using TNS.API.ApiDataObjects;
using Infra;
using Infra.Bus;
using Infra.Enum;
using Infra.Extensions;
using Infra.Extensions.ArrayExtensions;

namespace TNS.API.IBApiWrapper
{

    class SecuirtyDataWrapper
    {
        public BaseSecurityData Data { get; set; }
        public bool UpdatedSinceLastPubish { get; set; }

        public SecuirtyDataWrapper(BaseSecurityData data)
        {
            Data = data;
            UpdatedSinceLastPubish = true;
        }

    }
    class IBMessageHandler : EWrapper
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(IBMessageHandler));
        
        private const double EPSILON = 0.000000001;
        private const double LARGE_NUBMER = 100000000;

        /// <summary>
        /// max time to close orders that are filled/failed in OrderStatusDic dic
        /// = TimeSpan.FromMinutes(5);
        /// </summary>
        private readonly TimeSpan ORDER_MAX_TIME_SPAN = TimeSpan.FromMinutes(5);
        private ConnectionStatus _connectionStatus = ConnectionStatus.Connected;
        private readonly Dictionary<int, ContractDetailsWaiter> _contractWaiters;

        /// <summary>
        /// Invoked when: Connectivity between IB and TWS has been restored- data maintained. <para></para>
        /// Or when A market data farm is connected.
        /// </summary>
        public event Action ConnectivityIbTwsRestored;

        public IBMessageHandler(IBaseLogic consumer)
        {
            SecurityDataDic = new Dictionary<int, SecuirtyDataWrapper>();
            OrderStatusDic = new Dictionary<int, IBOrderStatusWrapper>();
            AccountSummary = new AccountSummaryData();
            Consumer = consumer;
            ManagedSecurityList = new List<Contract>();
            GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(3), PublishSecurities, true);
            _contractWaiters = new Dictionary<int, ContractDetailsWaiter>();
        }

        private Dictionary<int, IBOrderStatusWrapper> OrderStatusDic { get; }
        private Dictionary<int, SecuirtyDataWrapper> SecurityDataDic { get; }
        private IBaseLogic Consumer { get; }
        private AccountSummaryData AccountSummary { get; }
        /// <summary>
        /// Contains all the securities that are taking place in trading.
        /// </summary>
        private List<Contract> ManagedSecurityList { get; }
        public void managedAccounts(string accountsList)
        {
            AccountSummary.ManagedAccounts = new List<string>(accountsList.Split(','));
        }

        #region EWrapper Overrides

        #region NotUsedMethods

        /// <summary>
        /// All position data have been received already;
        /// </summary>
        public void positionEnd()
        {
            //var endAsynchData = new EndAsynchData(EapiDataTypes.PositionData);
            //Consumer.Enqueue(endAsynchData);
        }
        public void updatePortfolio(Contract contract, int position, double marketPrice, double marketValue,
           double averageCost, double unrealisedPNL, double realisedPNL, string accountName){ }
        public void scannerData(int reqId, int rank, ContractDetails contractDetails, string distance, string benchmark,
            string projection, string legsStr){}
        public void historicalData(int reqId, string date, 
            double open, double high, double low, double close,
            int volume, int count,double WAP, bool hasGaps){}
        public void tickString(int tickerId, int field, string value){}
        public void tickGeneric(int tickerId, int field, double value){}
        public void tickEFP(int tickerId, int tickType, double basisPoints, string formattedBasisPoints,double impliedFuture,int holdDays, 
            string futureExpiry, double dividendImpact, double dividendsToExpiry){}
        public void tickSnapshotEnd(int tickerId){}


        public void connectionClosed()
        {
            Consumer.Enqueue(new BrokerConnectionStatusMessage(ConnectionStatus.TWSDisconnected));
        }
        public void bondContractDetails(int reqId, ContractDetails contract){}
        public void updateAccountValue(string key, string value, 
            string currency, string accountName){}
        public void updateAccountTime(string timestamp){}
        public void accountDownloadEnd(string account){}
        public void openOrderEnd(){}
        public void execDetailsEnd(int reqId){}
        public void fundamentalData(int reqId, string data){}
        public void historicalDataEnd(int reqId, string start, string end){}
        public void marketDataType(int reqId, int marketDataType){}
        public void updateMktDepth(int tickerId, int position, int operation, 
            int side, double price, int size){}
        public void updateMktDepthL2(int tickerId, int position, 
            string marketMaker, int operation, int side,double price, int size){}
        public void updateNewsBulletin(int msgId, int msgType, 
            string message, string origExchange){}
        public void realtimeBar(int reqId, long time, double open, 
            double high, double low, double close, long volume,double wap,int count){}
        public void scannerParameters(string xml){}
        public void scannerDataEnd(int reqId){}
        public void receiveFA(int faDataType, string faXmlData){}
        public void verifyMessageAPI(string apiData){}
        public void verifyCompleted(bool isSuccessful, string errorText){}
        public void displayGroupList(int reqId, string groups){}
        public void displayGroupUpdated(int reqId, string contractInfo) {}
        public void error(string str){}
        public void currentTime(long time){}
        public void deltaNeutralValidation(int reqId, UnderComp underComp){}

        #endregion
        
        
        public void contractDetails(int reqId, ContractDetails contractDetails)
        {
            if (_contractWaiters.ContainsKey(reqId))
            {
                _contractWaiters[reqId].OnContractReceived(contractDetails);
            }            
        }

        public void contractDetailsEnd(int reqId)
        {
            if (_contractWaiters.ContainsKey(reqId))
            {
                _contractWaiters[reqId].OnContractReceiveEnd();
                _contractWaiters.Remove(reqId);
            }

        }
        public void commissionReport(CommissionReport commissionReport)
        {
            //find order by execId
            var orderStatus = OrderStatusDic.FirstOrDefault(o => o.Value.ExecId == commissionReport.ExecId);
            if (orderStatus.Equals(new KeyValuePair<int, IBOrderStatusWrapper>()))
            {
                Logger.Error("Received commission report with execId not found " + 
                    $"in orders list, execId is {commissionReport.ExecId}");
                return;
            }

            orderStatus.Value.Data.Commission = commissionReport.Commission;
            Consumer.Enqueue(orderStatus.Value.Data);
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

            if (!HandleSpecialApiMessages(apiMessageData))
            {
                Consumer.Enqueue(apiMessageData);
                Logger.Info(apiMessageData.ToString());
            }

        }
        private bool HandleSpecialApiMessages(APIMessageData data)
        {
            var  errorCode = (EtwsErrorCode) data.ErrorCode;
            switch (errorCode)
            {
                case EtwsErrorCode.NoSecurityFound:
                    var requestId = (int) data.AdditionalInfo;
                    lock (SecurityDataDic)
                    {
                        if (SecurityDataDic.ContainsKey(requestId))
                        {
                            Logger.Alert($"Request Id({requestId}) Not found. " + 
                                        $" {SecurityDataDic[requestId].Data.GetContract()}");
                            
                        } 
                    }
                    return true;
                case EtwsErrorCode.EntityIdNotFound:
                    HandleEntityIdNotFound(data);
                    return true;
                case EtwsErrorCode.IbTWSConnectivityLost:
                case EtwsErrorCode.ConnectivityTwsServerBroken:
                    if (_connectionStatus == ConnectionStatus.Connected)
                    {
                        _connectionStatus = ConnectionStatus.Disconnected;
                        Consumer.Enqueue(new BrokerConnectionStatusMessage(
                                            ConnectionStatus.Disconnected, data));
                        Logger.Warn($"Connection status changed to disconnected:  {data}");
                    }
                    Consumer.Enqueue(data);
                    return true;
                case EtwsErrorCode.IbTWSConnectivityRestoredDataLost:
                case EtwsErrorCode.IbTWSConnectivityRestoredDataMaintained:
                    if (_connectionStatus == ConnectionStatus.Disconnected)
                    {
                        Consumer.Enqueue(new BrokerConnectionStatusMessage(ConnectionStatus.Connected, data));
                        Logger.Warn($"Connection status changed to connected: {data}");
                        Consumer.Enqueue(data);
                    }
                    ConnectivityIbTwsRestored?.Invoke();
                    return true;

                case EtwsErrorCode.MarketDataFarmConnected:
                    Consumer.Enqueue(new BrokerConnectionStatusMessage(ConnectionStatus.Connected, data));
                    ConnectivityIbTwsRestored?.Invoke();
                    return true;
                default:
                    return false;
            }
        }
        private void HandleEntityIdNotFound(APIMessageData data)
        {
            int requestId = (int)data.AdditionalInfo;
            lock (SecurityDataDic)
            {
                if (!SecurityDataDic.ContainsKey(requestId)) return;
                Logger.Debug($"Request Id({requestId}) removed from SecurityDataDic, {data} {SecurityDataDic[requestId]}");
                SecurityDataDic.Remove(requestId);
                
            }
        }
        public void error(Exception ex)
        {
            ExceptionData exceptionData = new ExceptionData(ex);
            Consumer.Enqueue(exceptionData);
            Logger.Error(exceptionData);
        }
        public void tickPrice(int requestId, int field, double price, int canAutoExecute)
        {
            lock (SecurityDataDic)
            {
                var wrapper = SecurityDataDic[requestId];
                var securityData = wrapper.Data;
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
                        //If last price still not update set it with the base price:
                        if ((securityData.LastPrice <= 0) && (securityData.BasePrice > 0))
                            securityData.LastPrice = securityData.BasePrice;
                        break;
                    case TickType.OPEN:
                        securityData.OpeningPrice = price > int.MaxValue ? -1 : price;
                        break;
                    default:
                        return;
                }
                securityData.LastUpdate = DateTime.Now;
                wrapper.UpdatedSinceLastPubish = true;
                //SetValueForTesting(securityData);
            }
        }

        private static void SetValueForTesting(BaseSecurityData securityData)
        {
            var optionData = securityData as OptionData;

            if (optionData?.OptionContract.Strike - 80 <= 0.01)
            {
                optionData.LastPrice = 11.111;
            }
        }

        public void tickSize(int tickerId, int field, int size)
        {
            lock (SecurityDataDic)
            {
                var wrapper = SecurityDataDic[tickerId];
                var securityData = wrapper.Data;
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
                    default:
                        return;
                }
                securityData.LastUpdate = DateTime.Now;
                wrapper.UpdatedSinceLastPubish = true;
            }
        }
        public void tickOptionComputation(int tickerId, int field, 
            double impliedVolatility, double delta, double optPrice,
            double pvDividend, double gamma, double vega, double theta, double undPrice)
        {
            lock (SecurityDataDic)

            {
                var wrapper = SecurityDataDic[tickerId]; 
                var optionData = wrapper.Data as OptionData;
                if (impliedVolatility < LARGE_NUBMER)//Filter big long number
                {
                    optionData.ImpliedVolatility = impliedVolatility;
                }
                //optionData.ImpliedVolatility = impliedVolatility;
                double price;
                //TODO - reason for this switch case?
                switch (field)
                {
                    case TickType.BID_OPTION://10
                        price = optPrice > int.MaxValue ? -1 : optPrice;
                        if (optionData.BidPrice < 0)
                            optionData.BidPrice = price;
                        else if ((optionData.BidPrice > EPSILON) && (price > 0))
                            optionData.BidPrice = price;

                        break;
                    case TickType.ASK_OPTION://11
                        price = optPrice > int.MaxValue ? -1 : optPrice;
                        if (optionData.AskPrice < 0)
                            optionData.AskPrice = price;
                        else if ((optionData.AskPrice > EPSILON) && (price > 0))
                            optionData.AskPrice = price;

                        optionData.AskPrice = optPrice > int.MaxValue ? -1 : optPrice;
                        break;
                    case TickType.LAST_OPTION://12
                        optionData.LastPrice = optPrice > int.MaxValue ? -1 : optPrice;
                        break;
                    case TickType.MODEL_OPTION://13
                        optionData.ModelPrice = optPrice > int.MaxValue ? -1 : optPrice;
                        break;
                    default:
                        return;
                }
                optionData.LastUpdate = DateTime.Now;
                wrapper.UpdatedSinceLastPubish = true;
                //filter defected values coming from IB
                if (Math.Abs(delta) < 10)
                    optionData.Delta = delta;
                if (gamma < 10)
                    optionData.Gamma = gamma;
                if(optionData.Symbol.Equals("AMZN")){ }
                if (vega < 10)
                    optionData.Vega = vega;
                if (Math.Abs(theta) < 10)
                    optionData.Theta = theta;
                optionData.UnderlinePrice = undPrice > int.MaxValue ? -1 : undPrice;

                if ((optionData.ImpliedVolatility < EPSILON) && (impliedVolatility < LARGE_NUBMER))
                {
                    optionData.ImpliedVolatility = impliedVolatility;
                }
            }
        }
        #region Account Summary Tag
        /*
        * @params tags a comma separated list with the desired tags:
         *      - AccountType
         *      - NetLiquidation,
         *      - TotalCashValue — Total cash including futures pnl
         *      - SettledCash — For cash accounts, this is the same as TotalCashValue
         *      - AccruedCash — Net accrued interest
         *      - BuyingPower — The maximum amount of marginable US stocks the account can buy
         *      - EquityWithLoanValue — Cash + stocks + bonds + mutual funds
         *      - PreviousEquityWithLoanValue,
         *      - GrossPositionValue — The sum of the absolute value of all stock and equity option positions
         *      - RegTEquity,
         *      - RegTMargin,
         *      - SMA — Special Memorandum Account
         *      - InitMarginReq,
         *      - MaintMarginReq,
         *      - AvailableFunds,
         *      - ExcessLiquidity,
         *      - Cushion — Excess liquidity as a percentage of net liquidation value
         *      - FullInitMarginReq,
         *      - FullMaintMarginReq,
         *      - FullAvailableFunds,
         *      - FullExcessLiquidity,
         *      - LookAheadNextChange — Time when look-ahead values take effect
         *      - LookAheadInitMarginReq,
         *      - LookAheadMaintMarginReq,
         *      - LookAheadAvailableFunds,
         *      - LookAheadExcessLiquidity,
         *      - HighestSeverity — A measure of how close the account is to liquidation
         *      - DayTradesRemaining — The Number of Open/Close trades a user could put on before Pattern Day Trading is detected. A value of "-1" means that the user can put on unlimited day trades.
         *      - Leverage — GrossPositionValue / NetLiquidation
            
            
       */
        #endregion
        public void accountSummary(int reqId, string account, string tag, string value, string currency)
        {
            switch (tag)
            {
                case "BuyingPower":
                    AccountSummary.BuyingPower = Convert.ToDouble(value);
                    break;
                case "EquityWithLoanValue":
                    AccountSummary.EquityWithLoanValue = Convert.ToDouble(value);
                    break;
                case "ExcessLiquidity":
                    AccountSummary.ExcessLiquidity = Convert.ToDouble(value);
                    break;
                case "FullInitMarginReq":
                    AccountSummary.FullInitMarginReq = Convert.ToDouble(value);
                    break;
                case "FullMaintMarginReq":
                    AccountSummary.FullMaintMarginReq = Convert.ToDouble(value);
                    break;
                case "NetLiquidation":
                    AccountSummary.NetLiquidation = Convert.ToDouble(value);
                    break;
                case "FullExcessLiquidity":
                    AccountSummary.FullExcessLiquidity = Convert.ToDouble(value);
                    break;
                default:
                    return;
            }
            Consumer.Enqueue(AccountSummary);
        }
        public void accountSummaryEnd(int reqId)
        {
            Consumer.Enqueue(AccountSummary);
        }

        #region Order handling
        public void execDetails(int reqId, Contract contract, Execution execution)
        {
            IBOrderStatusWrapper data;
            if (OrderStatusDic.TryGetValue(execution.OrderId, out data))
            {
                data.ExecId = execution.ExecId;
            }
        }
        public void nextValidId(int orderId)
        {
            NextOrderId = orderId;
        }

        public void orderStatus(int orderId, string status, int filled,
            int remaining, double avgFillPrice, int permId, int parentId,
                            double lastFillPrice, int clientId, string whyHeld)
        {
            if (OrderStatusDic.ContainsKey(orderId))
            {
                OrderStatusData orderStatus = OrderStatusDic[orderId].Data;
                orderStatus.OrderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), status);
                orderStatus.LastUpdateTime = DateTime.Now;
                orderStatus.LastFillPrice = lastFillPrice;
                Consumer.Enqueue(orderStatus);
            }
            else
            {
                Logger.Error($"Received order status on request not in OrderStatusDic, orderId is {orderId}");
            }

        }
        public void openOrder(int orderId, Contract contract, Order order, OrderState orderState)
        {
            CloseIrrelevantOrders();
            IBOrderStatusWrapper status;
            if (!OrderStatusDic.TryGetValue(orderId, out status))
            {
                var orderData = order.ToOrderData();
                orderData.Contract = contract.ToContract();
                status = new IBOrderStatusWrapper(new OrderStatusData(orderId.ToString(), orderData) {Id = Guid.NewGuid()});
                OrderStatusDic[orderId] = status;
            }
            status.Data.LastUpdateTime = DateTime.Now;
            double maintMargin = Convert.ToDouble(orderState.MaintMargin);
            if (maintMargin < LARGE_NUBMER)
                status.Data.MaintMargin = maintMargin;
            Consumer.Enqueue(OrderStatusDic[orderId].Data);
        }

        public void position(string account, Contract contract, int pos, double avgCost)
        {
            var posData = PositionDataFactory.CreatePoisitionData(contract.ToContract(), pos, avgCost);
            posData.LastUpdate = DateTime.Now;
            Consumer.Enqueue(posData);
        }

        private void CloseIrrelevantOrders()
        {
            OrderStatusDic.RemoveAll(item => DateTime.Now - item.Data.LastUpdateTime > ORDER_MAX_TIME_SPAN &&
            item.Data.OrderStatus.In(OrderStatus.Cancelled, OrderStatus.Filled));
        }
        public int NextOrderId { get; set; }
        #endregion
        #endregion

        public Task<List<ContractDetails>> WaitForContractDetails(int requestId)
        {
            var waiter = new ContractDetailsWaiter();
            _contractWaiters[requestId] = waiter;
            return waiter.GetContracts();
        }
		
        internal void AddManagedSecurity(Contract ibContract)
        {
            ManagedSecurityList.Add(ibContract);
        }
        private void PublishSecurities()
        {
            lock (SecurityDataDic)
            {
                SecurityDataDic.Where(a=> a.Value.UpdatedSinceLastPubish).
                    ForEach(a =>
                    {
                        Consumer.Enqueue(a.Value.Data);
                        a.Value.UpdatedSinceLastPubish = false;
                    });
            }
        }
        public ContractBase RegisterContract(int requestId, ContractBase contract, ContractDetails IbContract)
        {
            lock (SecurityDataDic)
            {
                var optionContract = contract as OptionContract;
                BaseSecurityData securityData;
                if (optionContract != null)
                {
                    securityData = new OptionData {Account = AccountSummary.MainAccount};
                }
                else
                    securityData = new SecurityData{ Account = AccountSummary.MainAccount };
                securityData.SetContract(contract);
                IbContract.UpdateSecurityData(contract);
                SecurityDataDic.Add(requestId, new SecuirtyDataWrapper(securityData));
                return contract;
            }
        }
        public IEnumerable<int> GetCurrentOptionsRequestIds()
        {
            return SecurityDataDic.Keys;
        }
        public IEnumerable<int> GetCurrentMainSecuritiesRequestIds()
        {
            return SecurityDataDic.Keys;
        }
    }
}
