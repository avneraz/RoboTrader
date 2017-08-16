using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra;
using TNS.API;
using TNS.API.ApiDataObjects;

namespace TNS.BL.UnlManagers
{
    /// <summary>
    /// Make the negotiation with the Stock market to sell or buy option in the best price.
    /// The object created by the OrdersManager, particular object to each order (1:1)
    /// </summary>
    public class OptionNegotiator
    {
        /// <summary>
        /// The interval in TimeSpan between 2 successive orders
        /// </summary>
        private static readonly TimeSpan OrderIntervalTimeSpan;

        static OptionNegotiator()
        {
            OrderIntervalTimeSpan = AllConfigurations.AllConfigurationsObject.Trading.OrderIntervalTimeSpan;
            
        }
        public OptionNegotiator(ITradingApi apiWrapper, UNLManager unlManager, bool simulatorAccount = false)
        {
            APIWrapper = apiWrapper;
            UnlManager = unlManager;
            MinPriceStep = AllConfigurations.AllConfigurationsObject.Trading.MinPriceStep;

            SetSimulatorAccountParameters(simulatorAccount);
        }

        #region Properties and Fields

        public double RequieredMargin { get; set; }
        /// <summary>
        /// The minimum step for price = 1 sent, (for option it will be 1$ if multiplier = 100) = 0.01.
        /// </summary>
        public double MinPriceStep { get; private set; }
        private bool TransactionAlreadySaved { get; set; }
        public bool SimulatorAccount { get; private set; }
        public string WhatIfOrderId { get; set; }
        private string ScheduledTaskId { get; set; }
        protected UNLManager UnlManager { get; set; }
        protected ITradingApi APIWrapper { get; }
        /// <summary>
        /// The time first order submitted.
        /// </summary>
        public DateTime StarTime { get; set; }
        public OptionData OptionData { get; set; }
        public OrderData OrderData { get; set; }
        private OrderStatusData OrderStatusData { get; set; }
        public double Margin { get; set; }
        private OrderAction OrderAction { get; set; } //OrderStatusData.Order.OrderAction;
        private int Quantity { get; set; }
        private int TradingCycleCount { get; set; }
        private int TradingCycleCounter { get; set; }
        private double FirstLimitPrice
            => OrderAction == OrderAction.SELL ? FirstAskPrice - MinPriceStep : FirstBidPrice + MinPriceStep;
        /// <summary>
        /// The very first bid price before first order submitted.
        /// </summary>
        private double FirstBidPrice { get; set; }
        /// <summary>
        /// The very first ask price before first order submitted.
        /// </summary>
        private double FirstAskPrice { get; set; }
        public double FirstAskOrBid => OrderAction == OrderAction.SELL ? FirstAskPrice : FirstBidPrice;
        private double NextStepPrice => OrderAction == OrderAction.SELL ? FirstAskPrice - MinPriceStep : FirstBidPrice + MinPriceStep;
        /// <summary>
        /// Get the calculated lowest price allowed for selling, Or 
        ///Highest price allowed for buying
        /// </summary>
        private double LastPriceLimit
        {
            get
            {
                if (SimulatorAccount)
                {
                    if (OrderAction == OrderAction.SELL)
                        return Math.Round(OptionData.BidPrice, 2);
                    //else
                    return Math.Round(OptionData.AskPrice, 2);

                }

                const double factorOfMax = 0.1;
                double priceLimit;// = OptionData.ModelPrice;
                int tradingCycleCount = (int)Math.Ceiling((OptionData.AskPrice - OptionData.BidPrice) / MinPriceStep);

                if (OrderAction == OrderAction.SELL)
                {

                    if (OptionData.ModelPrice < MinPriceStep)
                        priceLimit = OptionData.BidPrice + tradingCycleCount * factorOfMax * MinPriceStep;
                    else
                        priceLimit = OptionData.ModelPrice - 2 * MinPriceStep;
                }
                else
                {
                    if (OptionData.ModelPrice < MinPriceStep)
                        priceLimit = OptionData.AskPrice - tradingCycleCount * factorOfMax * MinPriceStep;
                    else
                        priceLimit = OptionData.ModelPrice + 2 * MinPriceStep;

                }
                //FirstAskPrice - MIN_PRICE_STEP : FirstBidPrice + MIN_PRICE_STEP; 
                return Math.Round(priceLimit, 2);
            }

        }
        public bool LastLimitOccurred { get; set; }
        private double CurrentLimitPrice { get; set; }
        /// <summary>
        ///  = OrderType.LMT, used for testing
        /// </summary>
        private OrderType DefaultOrderType { get; set; } = OrderType.LMT;

        #endregion  // Properties and Fields

        public void SetOrderStatusData(OrderStatusData orderStatusData)
        {
            OrderStatusData = orderStatusData;
        }
        private void SetSimulatorAccountParameters(bool simulatorAccount)
        {
            SimulatorAccount = simulatorAccount;
            if (simulatorAccount)
                MinPriceStep = 3 * AllConfigurations.AllConfigurationsObject.Trading.MinPriceStep;


        }

        public OrderData StartTradingOption(OptionData optionData, bool sell, int quantity)
        {
            if (OptionData != null)
                throw new ArgumentException("The OptionNegotiator already has open order!!!");

            OptionData = optionData ?? throw new Exception("The option data not exist!!!");

            OrderAction = sell ? OrderAction.SELL : OrderAction.BUY;
            Quantity = quantity;
            //InializeTrading:
            FirstBidPrice = Math.Round(OptionData.BidPrice, 2);
            FirstAskPrice = Math.Round(OptionData.AskPrice, 2);

            MinPriceStep = Math.Max(MinPriceStep, (FirstAskPrice - FirstBidPrice) / 10);

            TradingCycleCount = (int)Math.Ceiling((FirstAskPrice - FirstBidPrice) / MinPriceStep);
            TradingCycleCounter = 1;

            StarTime = DateTime.Now;
            RoundCurrentLimitPrice(FirstLimitPrice);
            //SendWhatIfOrder(CurrentLimitPrice);

            CreateOrder(CurrentLimitPrice);
            //Start negotiation proccess:
            ScheduledTaskId = UnlManager.AddScheduledTaskOnUnl(OrderIntervalTimeSpan, DoTrading, true);
            return OrderData;
        }

        /// <summary>
        /// Called by the task scheduler
        /// </summary>
        private void DoTrading()
        {
            if (OrderStatusData == null)
                return;
           
            switch (OrderStatusData.OrderStatus)
            {
                case OrderStatus.Filled:
                    SaveTransaction();

                    TerminateNegotiation();
                    break;
                case OrderStatus.Cancelled:
                    TerminateNegotiation();
                    break;
                case OrderStatus.Inactive:
                    TerminateNegotiation();
                    CancelOrder(OrderData.OrderId);
                    break;
                case OrderStatus.WhatIf:
                    RequieredMargin = OrderStatusData.Margin;
                    //For test save:
                    //SaveTransaction();
                    break;
                case OrderStatus.Submitted:
                    if (UnlManager.IsNowWorkingTime == false)
                    {
                        TerminateNegotiation();
                        SaveTransaction();
                        CancelOrder(OrderData.OrderId);
                        break;
                    }
                    TradingCycleCounter++;
                    if (LastLimitOccurred)
                    {
                        TerminateNegotiation();
                        CancelOrder(OrderData.OrderId);
                    }
                    //UpdateFirstAskAndBid();
                    CalculateNextCurrentLimitPrice();
                    UpdateOrder(CurrentLimitPrice);
                    break;

                case OrderStatus.PreSubmitted:
                    //TradingCycleCounter++;
                    if (UnlManager.IsNowWorkingTime == false)
                    {
                        TerminateNegotiation();
                        SaveTransaction();
                        CancelOrder(OrderData.OrderId);
                    }
                    break;
                case OrderStatus.PendingCancel:
                    break;
                case OrderStatus.PendingSubmit:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SaveTransaction()
        {
            if(TransactionAlreadySaved) return;
            //Create Transuction Data object and send it:
            var transaction = new TransactionData()
            {
                TransactionTime = DateTime.Now,
                OrderStatus = OrderStatusData,
                Order = OrderStatusData.Order,
                OptionData = OptionData,
                OptionKey = OptionData.OptionKey,
                Symbol = UnlManager.Symbol,
                RequieredMargin = RequieredMargin,
            };
            //Update about the new transaction
            UnlManager.Distributer.Enqueue(transaction);
            TransactionAlreadySaved = true;
        }

        private void TerminateNegotiation()
        {
            UnlManager.RemoveScheduledTaskOnUnl(ScheduledTaskId);
            UnlManager.OrdersManager.SendOrderTaskAccomplished(OrderStatusData.OrderId);
        }

        private void CalculateNextCurrentLimitPrice()
        {
            if (OrderAction == OrderAction.SELL)
            {
                if (Math.Round(NextStepPrice, 2) >= CurrentLimitPrice)
                    RoundCurrentLimitPrice(CurrentLimitPrice - MinPriceStep);
                else
                    RoundCurrentLimitPrice(FirstAskPrice - MinPriceStep);
                if (LastPriceLimit < CurrentLimitPrice)
                {
                    LastLimitOccurred = true;
                }
                //Don't let limit below the allowed
                CurrentLimitPrice = Math.Max(CurrentLimitPrice, LastPriceLimit);
            }
            else//Buy
            {
                if (NextStepPrice < CurrentLimitPrice)
                    RoundCurrentLimitPrice(CurrentLimitPrice + MinPriceStep);
                else
                    RoundCurrentLimitPrice(FirstAskPrice + MinPriceStep);
                //Don't let limit above the allowed
                CurrentLimitPrice = Math.Min(CurrentLimitPrice, LastPriceLimit);

                if (LastPriceLimit < CurrentLimitPrice)
                {
                    LastLimitOccurred = true;
                }
            }
        }
        private void RoundCurrentLimitPrice(double price)
        {
            CurrentLimitPrice = Math.Round(price, 2);
        }
        private void UpdateFirstAskAndBid()
        {
            FirstBidPrice = Math.Round(OptionData.BidPrice,2);
            FirstAskPrice = Math.Round(OptionData.AskPrice, 2);
        }

        private OrderData SendWhatIfOrder(double limitPrice)
        {
            var orderData = new OrderData
            {
                OrderType = DefaultOrderType,
                OrderAction = OrderAction,
                LimitPrice = limitPrice,
                Quantity = Quantity,
                Contract = OptionData.OptionContract,
                WhatIf = true,
            };
            WhatIfOrderId = APIWrapper.CreateOrder(orderData);
            orderData.OrderId = WhatIfOrderId;
            return orderData;
        }

        private void CreateOrder(double limitPrice)
        {
            OrderData = new OrderData()
            {
                OrderType = DefaultOrderType, OrderAction = OrderAction, LimitPrice = limitPrice, Quantity = Quantity, Contract = OptionData.OptionContract
            };

            OrderData.OrderId = APIWrapper.CreateOrder(OrderData);
        }

        private void UpdateOrder(double limitPrice)
        {
            OrderData.LimitPrice = limitPrice;
            APIWrapper.UpdateOrder(OrderData.OrderId, OrderData);
        }

        public void CancelOrder(string orderId)
        {
            APIWrapper.CancelOrder(orderId);
        }
    }
}
