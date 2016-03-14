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
            MinPriceStep = AllConfigurations.AllConfigurationsObject.Trading.MinPriceStep;
        }

        /// <summary>
        /// The minimum step for price = 1 sent, (for option it will be 1$ if multiplier = 100) = 0.01.
        /// </summary>
        public static double MinPriceStep { get; private set; }


        public OptionNegotiator(ITradingApi apiWrapper, UNLManager unlManager, bool simulatorAccount = false)
        {
            APIWrapper = apiWrapper;
            UnlManager = unlManager;
            SetSimulatorAccountParameters(simulatorAccount);
        }

        private void SetSimulatorAccountParameters(bool simulatorAccount)
        {
            SimulatorAccount = simulatorAccount;
            if (simulatorAccount)
                MinPriceStep = 3 * AllConfigurations.AllConfigurationsObject.Trading.MinPriceStep;


        }
        public bool SimulatorAccount { get; private set; }

        public OrderData TradeOption(OptionData optionData, bool sell, int quantity)
        {
            if(OptionData != null)
                throw new ArgumentException("The OptionNegotiator already has open order!!!");
            OptionData = optionData;
            OrderAction = sell ? OrderAction.SELL : OrderAction.BUY;
            Quantity = quantity;
            InializeTrading();
            //Create Order
            StarTime = DateTime.Now;
            SetCurrentLimitPrice(FirstLimitPrice);
            var whatIfOrderData = SendWhatIfOrder(CurrentLimitPrice);
            if (UnlManager.IsNowWorkingTime == false)
            {
                //TerminateNegotiation();
                return whatIfOrderData;
            }
            CreateOrder(CurrentLimitPrice);
            ScheduledTaskId = UnlManager.AddScheduledTaskOnUnl(OrderIntervalTimeSpan, DoTrading, true);
            return OrderData;
        }

        public string  WhatIfOrderId { get; set; }
        private string ScheduledTaskId { get; set; }
        private void InializeTrading()
        {
            UpdateFirstAskAndBid();
            TradingCycleCount = (int)Math.Ceiling((FirstAskPrice - FirstBidPrice) / MinPriceStep);
            TradingCycleCounter = 1;
        }

        public void SellOption(OptionData optionData, int quantity)
        {
            TradeOption(optionData, true, quantity);
        }
        public void BuyOption(OptionData optionData, int quantity)
        {
            TradeOption(optionData, false, quantity);
        }

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
        public void SetOrderStatusData(OrderStatusData orderStatusData)
        {
            OrderStatusData = orderStatusData;
        }
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
                        priceLimit = OptionData.ModelPrice - 2*MinPriceStep;
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

        public bool  LastLimitOccurred { get; set; }
        private double CurrentLimitPrice { get; set; }

      
        /// <summary>
        ///  = OrderType.LMT, used for testing
        /// </summary>
        private OrderType DefaultOrderType { get; set; } = OrderType.LMT;

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
                case OrderStatus.Cancelled:
                case OrderStatus.Inactive:
                    TerminateNegotiation();
                    break;
                case OrderStatus.WhatIf:
                    break;
                case OrderStatus.Submitted:
                    TradingCycleCounter++;
                    if (LastLimitOccurred)
                    {
                        TerminateNegotiation();
                        CancelOrder(OrderData.OrderId);
                    }
                    if (TradingCycleCounter % 2 == 0)//Even CYCLE ==> reset order. Eliminate order price influence
                    {
                        UpdateOrder(Math.Round(FirstAskOrBid,2));
                        break;
                    }//ODD
                    UpdateFirstAskAndBid();
                    CalculateNextCurrentLimitPrice();
                    UpdateOrder(CurrentLimitPrice);
                    break;

                case OrderStatus.PreSubmitted:
                    break;
                case OrderStatus.PendingCancel:
                    break;
                case OrderStatus.PendingSubmit:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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
                    SetCurrentLimitPrice(CurrentLimitPrice - MinPriceStep);
                else
                    SetCurrentLimitPrice(FirstAskPrice - MinPriceStep);
                if (LastPriceLimit > CurrentLimitPrice)
                {
                    LastLimitOccurred = true;
                }
                //Don't let limit below the allowed
                CurrentLimitPrice = Math.Max(CurrentLimitPrice, LastPriceLimit);
            }
            else//Buy
            {
                if (NextStepPrice < CurrentLimitPrice)
                    SetCurrentLimitPrice(CurrentLimitPrice + MinPriceStep);
                else
                    SetCurrentLimitPrice(FirstAskPrice + MinPriceStep);
                //Don't let limit above the allowed
                CurrentLimitPrice = Math.Min(CurrentLimitPrice, LastPriceLimit);

                if (LastPriceLimit < CurrentLimitPrice)
                {
                    LastLimitOccurred = true;
                }
            }
        }
        private void SetCurrentLimitPrice(double price)
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
