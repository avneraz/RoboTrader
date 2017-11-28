using System;
using System.Collections.Generic;
using System.Linq;
using Infra.Enum;
using log4net;
using TNS.API.ApiDataObjects;
using static System.Math;

namespace TNS.BL.UnlManagers
{
   
    /// <summary>
    /// Responsible for optimization of UNL's positions (for the same expiry date).
    /// When some options within position is exceeded the ATM delta (50), more than 10%, (Delta is less than or 45 greater than 55).
    /// The optimizer make the requird changes.
    /// </summary>
    internal class PositionsOptimizer
    {
        public event Action<PositionsOptimizer> MissionAccomplished;
        protected virtual void OnMissionAccomplished()
        {
            UNLManager.RemoveScheduledTaskOnUnl(_shutDownTaskId);
            ShutDown();
            MissionAccomplished?.Invoke(this);
        }


        private static readonly ILog Logger = LogManager.GetLogger(typeof(PositionsOptimizer));
        private bool _shutDownOptimizerReceived;
        public PositionsOptimizer(string symbol, DateTime expiryDate)
        {
            Symbol = symbol;
            ExpiryDate = expiryDate;
            UNLManager = AppManager.AppManagerSingleTonObject.UNLManagerDic[Symbol] as UNLManager;
        }

        private string Symbol { get; }
        private UNLManager UNLManager { get; }
        private DateTime ExpiryDate { get; }

        private bool _notAllPositionClosed;


        private Dictionary<string, OrderData> _pendingCloseDic;
        private Dictionary<string, OrderData> _pendingSellDic;

        /// <summary>
        /// Send buy option order for limited mate couple.
        /// Register to notification from OptionNegotiator for done. 
        /// And than send Sell orders for ATM options
        /// </summary>
        /// <param name="mateCoupleCount">The number of mate couple that need to be optimized.</param>
        /// <returns></returns>
        public bool PerformPartialOptimization(int mateCoupleCount)
        {
            Logger.Info($"Start optimize {Symbol} UNL, Expiry: {ExpiryDate}.");
            List<OptionsPositionData> outLimitList;
            bool doForPutPositions;
            bool doForCallPositions;
            if (!PrepareForOptimization(out outLimitList, out doForPutPositions, out doForCallPositions)) return false;

            int callCloseCount = 0, putCloseCount = 0;


            //Buy (Close them) only the positions that have an adequate ATM alternative option.
            foreach (var positionData in outLimitList)
            {
                var optionType = positionData.OptionType;
                int quantity;
                if ((optionType == EOptionType.Call && doForCallPositions && callCloseCount < mateCoupleCount))
                {
                    //Calculate the desired positions:
                    quantity =  Min((mateCoupleCount - callCloseCount++), positionData.Quantity);
                }
                else if (optionType == EOptionType.Put && doForPutPositions && putCloseCount < mateCoupleCount)
                {
                    //Calculate the desired positions:
                    quantity = 
                        Min(mateCoupleCount - putCloseCount++, positionData.Quantity);
                }
                else if (callCloseCount >= mateCoupleCount && putCloseCount >= mateCoupleCount)
                    break;
                else 
                    continue;

                var orderData = UNLManager.OrdersManager
                    .BuyOption(positionData.OptionData, quantity);
                _pendingCloseDic[orderData.OrderId] = orderData;
             
            }
            return true;
        }

        /// <summary>
        /// Send buy option order for all positions that are delta out of limit.
        /// Register to notification from OptionNegotiator for done. 
        /// </summary>
        /// <returns></returns>
        public bool OptimizePositions()
        {
            Logger.Info($"Start optimize {Symbol} UNL, Expiry: {ExpiryDate}.");

            List<OptionsPositionData> outLimitList;
            bool doForPutPositions;
            bool doForCallPositions;
            if (!PrepareForOptimization(out outLimitList, out doForPutPositions, out doForCallPositions)) return false;

            //Buy (Close them) only the positions that have an adequate ATM alternative option.
            foreach (var positionData in outLimitList)
            {
                if ((positionData.OptionType == EOptionType.Call && doForCallPositions) ||
                    positionData.OptionType == EOptionType.Put && doForPutPositions)
                {
                    var orderData = UNLManager.OrdersManager
                        .BuyOption(positionData.OptionData, positionData.Quantity);
                    _pendingCloseDic[orderData.OrderId] = orderData;
                }
            }

            return true;
        }

        private ( List<OptionsPositionData> ,  bool ,  bool ) PrepareForOptimizationNew()
        {
            //var atmOption = UNLManager.OptionsManager.GetATMOptionData(ExpiryDate, EOptionType.Call);
            //Check for trading time, Don't act if now isn't working time.
            if ((UNLManager.IsNowWorkingTime == false) && (UNLManager.IsSimulatorAccount == false))
                throw new Exception("The operation can't be done now! it can be done only within working time.");

            _notAllPositionClosed = false;

            if (_pendingCloseDic == null) _pendingCloseDic = new Dictionary<string, OrderData>();
            else _pendingCloseDic.Clear();

            if (_pendingSellDic == null) _pendingSellDic = new Dictionary<string, OrderData>();
            else _pendingSellDic.Clear();
            List<OptionsPositionData> outLimitList;
            if (!GetOutOfLimitPositions(out outLimitList))
            {
                throw new Exception($"{Symbol}: There is no out of limit Positions!");
            }

            bool doForPutPositions = UNLManager.OptionsManager.CheckForATMOption(EOptionType.Put, ExpiryDate);
            bool doForCallPositions = UNLManager.OptionsManager.CheckForATMOption(EOptionType.Call, ExpiryDate);
            if (!doForCallPositions && !doForPutPositions)
                throw new Exception("There are no ATM Positions!!");
                //return false;

            //Initialize watchDog: Finish all works immediatly:
            _shutDownTaskId = UNLManager.AddScheduledTaskOnUnl(TimeSpan.FromMinutes(1), ShutDown);

            //Register for done notifications.
            UNLManager.OrdersManager.OrderTradingNegotioationWasTerminated +=
                OrdersManager_OrderTradingNegotioationWasTerminated;
            //var outLimit = (outLimitList: List<OptionsPositionData>, doForPutPositions: bool, doForCallPositions: bool);
            return ( outLimitList,  doForPutPositions,  doForCallPositions);
        }
        private bool PrepareForOptimization(out List<OptionsPositionData> outLimitList, out bool doForPutPositions, out bool doForCallPositions)
        {
            //var atmOption = UNLManager.OptionsManager.GetATMOptionData(ExpiryDate, EOptionType.Call);
            //Check for trading time, Don't act if now isn't working time.
            if ((UNLManager.IsNowWorkingTime == false) && (UNLManager.IsSimulatorAccount == false))
                throw new Exception("The operation can't be done now! it can be done only within working time.");

            _notAllPositionClosed = false;

            if (_pendingCloseDic == null) _pendingCloseDic = new Dictionary<string, OrderData>();
            else _pendingCloseDic.Clear();

            if (_pendingSellDic == null) _pendingSellDic = new Dictionary<string, OrderData>();
            else _pendingSellDic.Clear();

            if (!GetOutOfLimitPositions(out outLimitList))
            {
                throw new Exception($"{Symbol}: There is no out of limit Positions!");
            }

            doForPutPositions = UNLManager.OptionsManager.CheckForATMOption(EOptionType.Put, ExpiryDate);
            doForCallPositions = UNLManager.OptionsManager.CheckForATMOption(EOptionType.Call, ExpiryDate);
            if (!doForCallPositions && !doForPutPositions)
                throw new Exception("There are no ATM Positions!!");
            //return false;

            //Initialize watchDog: Finish all works immediatly:
            _shutDownTaskId = UNLManager.AddScheduledTaskOnUnl(TimeSpan.FromMinutes(1), ShutDown);

            //Register for done notifications.
            UNLManager.OrdersManager.OrderTradingNegotioationWasTerminated +=
                OrdersManager_OrderTradingNegotioationWasTerminated;

            return true;
        }

        private string _shutDownTaskId;
        private bool GetOutOfLimitPositions(out List<OptionsPositionData> outLimitList)
        {
            outLimitList = UNLManager.PositionsDataBuilder.PositionDataDic.Values
                .Where(pd => pd.Position < 0 && pd.OptionData.Expiry == ExpiryDate)
                .Where(p => p.OptionData.IsDeltaOutOfATMLimit)
                .OrderBy(p => p.OptionData.DeltaOffsetFromATM).ToList();

            return outLimitList.Count >= 1;
        }

       
        /// <summary>
        /// Waiting for notifications from the OptionNegotiator and sell ATM option.
        /// </summary>
        /// <param name="orderStatus"></param>
        /// <param name="orderId"></param>
        private void OrdersManager_OrderTradingNegotioationWasTerminated(OrderStatus orderStatus, string orderId)
        {
            if (_shutDownOptimizerReceived)
            {
                _pendingSellDic.Clear();
                _pendingCloseDic.Clear();

            }
            if (_pendingSellDic.ContainsKey(orderId))
            {
                HandleSellOrders(orderStatus, orderId);
                return;
            }

            if (!_pendingCloseDic.ContainsKey(orderId)) return;

            var orderData = _pendingCloseDic[orderId];
            _pendingCloseDic.Remove(orderId);
            if (orderStatus == OrderStatus.Filled)
            {
                //Sell ATM Position:
                Logger.Info($"Position Closed successfully: {orderData}");
                SellATMPosition(orderData);
            }
            else if (orderStatus == OrderStatus.NegotiationFailed)
            {
                Logger.Info($"Negotiation Failed: {orderData}");
                _notAllPositionClosed = true;
            }
            else
            {
                Logger.Info($"Close position Failed ({orderStatus}): {orderData}");
                _notAllPositionClosed = true;
            }
            //Keep waiting for finish all pending close positions:
            if (_pendingCloseDic.Count != 0) return;

            //Unregister to the event:
            UNLManager.OrdersManager.OrderTradingNegotioationWasTerminated -=
                OrdersManager_OrderTradingNegotioationWasTerminated;

            //Resend for buy the positions that still not closed
            if (_notAllPositionClosed)
                UNLManager.AddScheduledTaskOnUnl(TimeSpan.FromMilliseconds(100), () => { OptimizePositions(); });
            else if(_pendingSellDic.Count == 0)
            {
              
                //Send notification that mission is accomplished:
                OnMissionAccomplished();
            }
        }

        private void HandleSellOrders(OrderStatus orderStatus, string orderId)
        {
            var orderData = _pendingSellDic[orderId];
            _pendingSellDic.Remove(orderId);
            if (orderStatus == OrderStatus.Filled)
            {
                //Sell ATM Position:
                Logger.Info($"Position Sold successfully: {orderData}");
            }
            else
            {
                Logger.Info($"Sell position Failed ({orderStatus}): {orderData}");
                //Try sell again
                SellATMPosition(orderData);
            }
            //Keep waiting for finish all pending close positions:
            if (_pendingSellDic.Count != 0) return;
            if (_pendingCloseDic.Count == 0)
            {
                //Send notification that mission is accomplished:
                OnMissionAccomplished();
            }
        }

        private void SellATMPosition(OrderData orderData)
        {
            var offsetStep = 0.005;
            var maxOffset = 0.495;
            var minOffset = 0.505;
            var optionContract = orderData.Contract as OptionContract;
            if (optionContract == null) return;

            var opType = optionContract.OptionType;
            OptionData theATMOption = null;
            //Get optionATM:
            while (theATMOption == null)
            {
                maxOffset += offsetStep;
                minOffset -= offsetStep;

                theATMOption = UNLManager.OptionsManager.OptionDataDic.Values.FirstOrDefault(
                    o => o.Expiry.Equals(ExpiryDate) && o.OptionContract.OptionType == opType &&
                         o.DeltaAbsValue >= minOffset && o.DeltaAbsValue <= maxOffset);
                //Set for max iteration
                if (maxOffset > (0.50 + 13 * offsetStep))
                    break;
            }
            if (theATMOption == null)
            {
                var ex = new ArgumentNullException(nameof(theATMOption));
                Logger.Error("Optimizer can't find adequate ATM option!", ex);
                return;
                //throw new ArgumentNullException(nameof(theATMOption));
            }
            var atmOrderData = UNLManager.OrdersManager
                .SellOption(theATMOption, orderData.Quantity);
            _pendingSellDic[atmOrderData.OrderId] = atmOrderData;

            Logger.Info($"Optimizer send sell order {atmOrderData}");
        }

        public void ShutDown()
        {
            _shutDownOptimizerReceived = true;
            UNLManager.OrdersManager.OrderTradingNegotioationWasTerminated -=
                OrdersManager_OrderTradingNegotioationWasTerminated;
        }
    }
}
