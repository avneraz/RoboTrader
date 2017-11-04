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
        private static readonly TimeSpan SuccesiveIntervalTimeSpan;

        static OptionNegotiator()
        {
            SuccesiveIntervalTimeSpan = AllConfigurations.AllConfigurationsObject.Trading.OrderIntervalTimeSpan;
        }
        public OptionNegotiator(UNLManager unlManager)
        {
            UnlManager = unlManager;
            APIWrapper =  unlManager.APIWrapper;
        }

        #region Properties and Fields

        private bool DoTradingWasTerminated { get; set; }
        public bool LastLimitOccurred { get; set; }
        /// <summary>
        /// The very first bid price before first order submitted.
        /// </summary>
        private double FirstBidPrice { get; set; }
        /// <summary>
        /// The very first ask price before first order submitted.
        /// </summary>
        private double FirstAskPrice { get; set; }
        /// <summary>
        /// The actual sent price limit.
        /// </summary>
        private double CurrentLimitPrice { get; set; }
        /// <summary>
        /// The minimum step for price = 1 sent, (for option it will be 1$ if multiplier = 100) = 0.01.
        /// </summary>
        public double PriceStep { get; private set; }
        private bool TransactionAlreadySaved { get; set; }
        public bool SimulatorAccount { get;  set; }
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
        public double RequierdMargin { get; set; }
        private OrderAction OrderAction { get; set; } //OrderStatusData.Order.OrderAction;
        private int Quantity { get; set; }
        private int TradingCycleIndex { get; set; }
        private int TradingCycleCount { get; set; }
       
        /// <summary>
        ///  = OrderType.LMT, used for testing
        /// </summary>
        private OrderType DefaultOrderType { get; set; } = OrderType.LMT;

        #endregion  // Properties and Fields

        public void SetOrderStatusData(OrderStatusData orderStatusData)
        {
            OrderStatusData = orderStatusData;
        }
      

        public OrderData StartTradingOption(OptionData optionData, bool sell, int quantity)
        {
            if (OptionData != null)
                throw new ArgumentException("The OptionNegotiator already has open order!!!");

            OptionData = optionData ?? throw new Exception("The option data not exist!!!");

            OrderAction = sell ? OrderAction.SELL : OrderAction.BUY;
            Quantity = quantity;
            //InializeTrading:
            InitializeNegotiationsTradingParameters();
            SendWhatIfOrder(CurrentLimitPrice);
            CreateOrder(CurrentLimitPrice);
            //Start negotiation proccess:
            ScheduledTaskId = UnlManager.AddScheduledTaskOnUnl(SuccesiveIntervalTimeSpan, DoTrading, true);
            return OrderData;
        }

      
        private void InitializeNegotiationsTradingParameters()
        {
            StarTime = DateTime.Now;
            var optionPrice = OptionData.CalculatedOptionPrice;
            if (optionPrice < 0.1) optionPrice = 50;
            FirstAskPrice = OptionData.AskPrice;
            FirstBidPrice = OptionData.BidPrice;
            var askBidDif = FirstAskPrice - FirstBidPrice;
            //Set  the resonable max diff
            var maxDiff = IsUNLGrater400 ?  300 * MinPriceStep : 70 * MinPriceStep ;

            //Check validity of the data and fix it if needed:
            if ((askBidDif > maxDiff) || askBidDif < 0.01)
            {
                askBidDif = IsUNLGrater400 ? optionPrice * 0.2 : optionPrice * 0.1;
                FirstAskPrice = optionPrice + 0.5 * askBidDif;
                FirstBidPrice = optionPrice - 0.5 * askBidDif;
            }
            CurrentLimitPrice = OrderAction == OrderAction.BUY ? FirstBidPrice : FirstAskPrice;
            TradingCycleCount = IsUNLGrater400 ? 15 : 10;//Set the default

            PriceStep = askBidDif / TradingCycleCount;

           
            if (PriceStep < MinPriceStep) //Less than 0.01
            {
                PriceStep = MinPriceStep;
                TradingCycleCount = (int)Math.Ceiling(askBidDif / PriceStep);
            }
            //Add an extra 3 cycles when it's simulation.
            TradingCycleCount = SimulatorAccount ? TradingCycleCount + 3 : TradingCycleCount;
            PriceStep = RoundPrice(Math.Max(MinPriceStep, PriceStep));
            TradingCycleIndex = 0;
        }

        private bool IsUNLGrater400 => UnlManager.UnlTradingData.UnderlinePrice > 400;//OptionData.UnderlinePrice > 400;
        public double MinPriceStep => AllConfigurations.AllConfigurationsObject.Trading.MinPriceStep;

        private void CalculateNextCurrentLimitPrice()
        {
            double multiplier = 1;
            if (IsUNLGrater400)
            {
                //On the first 5 steps make the priceStep double:
                multiplier = TradingCycleIndex > 10 ? 2 : 1;

                //Make smaler price step toward the end of negotioation:
                if (TradingCycleCount == 10)
                {
                    var diff = OrderAction == OrderAction.SELL
                        ? CurrentLimitPrice - FirstBidPrice
                        : FirstAskPrice - CurrentLimitPrice;

                    PriceStep = RoundPrice(Math.Max(MinPriceStep, diff / 10));
                }
            }
            
           
            if (OrderAction == OrderAction.SELL)
            {
                CurrentLimitPrice = FirstAskPrice - TradingCycleIndex * PriceStep * multiplier;
                if (CurrentLimitPrice < OptionData.BidPrice)
                    CurrentLimitPrice = OptionData.BidPrice;
            }
            else //Buy
            {
                CurrentLimitPrice = FirstBidPrice + TradingCycleIndex * PriceStep * multiplier;
                if (CurrentLimitPrice > OptionData.AskPrice)
                    CurrentLimitPrice = OptionData.AskPrice;
            }
        }

        /// <summary>
        /// Called by the task scheduler
        /// </summary>
        private void DoTrading()
        {
            if ((OrderStatusData == null) || DoTradingWasTerminated)
                return;
            //TerminateNegotiation();
            switch (OrderStatusData.OrderStatus)
            {
                case OrderStatus.Filled:
                    TerminateNegotiation(OrderStatus.Filled);
                    SaveTransaction();
                    break;
                case OrderStatus.Cancelled:
                    TerminateNegotiation(OrderStatus.Cancelled);
                    break;
                case OrderStatus.Submitted:
                    TradingCycleIndex++;
                    if (TradingCycleIndex > TradingCycleCount )
                    {
                        if (SimulatorAccount)
                        {
                            TradingCycleIndex = 3;
                            OrderData.OrderType = OrderType.MKT;
                            UpdateOrder(CurrentLimitPrice);
                            break;
                        }
                        TerminateNegotiation(OrderStatus.NegotiationFailed);
                        CancelOrder(OrderData.OrderId);
                        break;
                    }
                    CalculateNextCurrentLimitPrice();
                    UpdateOrder(CurrentLimitPrice);
                    break;
                case OrderStatus.Inactive:
                    CancelOrder(OrderData.OrderId);
                    TerminateNegotiation(OrderStatus.Cancelled);
                    break;
                case OrderStatus.PreSubmitted:
                    if (UnlManager.IsNowWorkingTime == false)
                    {
                        CancelOrder(OrderData.OrderId);
                        TerminateNegotiation(OrderStatus.Cancelled);
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
      
        /// <summary>
        /// Round the number to 2 decimal digits.
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        private double RoundPrice(double price)
        {
            return Math.Round(price, 2);
        }
        private void SaveTransaction()
        {
            if(TransactionAlreadySaved) return;
            TransactionAlreadySaved = true;
            for (int i = 0; i < OrderData.Quantity; i++)
            {
                //Create Transuction Data object and send it:
                var transaction = new TransactionData()
                {
                    TransactionTime = DateTime.Now,
                    OrderStatus = OrderStatusData,
                    Order = OrderStatusData.Order,
                    OptionData = OptionData,
                    OptionKey = OptionData.OptionKey,
                    Symbol = UnlManager.Symbol,
                    RequierdMargin = RequierdMargin,
                };
                transaction.SetContract(OptionData.GetContract());
                //Update about the new transaction
                UnlManager.TradingManager.HandleMessage(transaction);
            }
            
        }

        private void TerminateNegotiation(OrderStatus orderStatus)
        {
            DoTradingWasTerminated = true;
            UnlManager.RemoveScheduledTaskOnUnl(ScheduledTaskId);
            UnlManager.OrdersManager.SendOrderTaskAccomplished(OrderStatusData.OrderId, orderStatus);
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
                OrderType = DefaultOrderType,
                OrderAction = OrderAction,
                LimitPrice = RoundPrice(limitPrice),
                Quantity = Quantity,
                Contract = OptionData.OptionContract
            };

            //if (SimulatorAccount) OrderData.OrderType = OrderType.MKT;
            OrderData.OrderId = APIWrapper.CreateOrder(OrderData);
        }

        private void UpdateOrder(double limitPrice)
        {
            OrderData.LimitPrice = RoundPrice(limitPrice);
            APIWrapper.UpdateOrder(OrderData.OrderId, OrderData);
        }

        public void CancelOrder(string orderId)
        {
            APIWrapper.CancelOrder(orderId);
        }
    }
}
