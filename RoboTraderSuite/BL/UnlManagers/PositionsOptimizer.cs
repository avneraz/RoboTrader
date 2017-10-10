using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using TNS.API.ApiDataObjects;

namespace TNS.BL.UnlManagers
{
    /// <summary>
    /// Responsible for optimization of UNL's positions (for the same expiry date).
    /// When some options within position is exceeded the ATM delta (50), more than 10%, (Delta is less than or 45 greater than 55).
    /// The optimizer make the requird changes.
    /// </summary>
    internal class PositionsOptimizer
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(PositionsOptimizer));

        public PositionsOptimizer(string symbol, DateTime expiryDate)
        {
            Symbol = symbol;
            ExpiryDate = expiryDate;
            UNLManager = AppManager.AppManagerSingleTonObject.UNLManagerDic[Symbol] as UNLManager;
        }

        /// <summary>
        /// MAX_DELTA_OFFSET = 0.55;
        /// </summary>
        private const double MAX_DELTA_OFFSET = 0.55;

        //MIN_DELTA_OFFSET = 0.45;
        private const double MIN_DELTA_OFFSET = 0.45;

        private string Symbol { get; }
        private UNLManager UNLManager { get; }
        private DateTime ExpiryDate { get; set; }

        private bool _notAllPositionClosed;


        private Dictionary<string, OrderData> _pendingCloseDic;

        public bool OptimizePositions()
        {
            Logger.Info($"Start optimize {Symbol} UNL, Expiry: {ExpiryDate}.");
            //Check for trading time, Don't act if now isn't working time.
            if (UNLManager.IsNowWorkingTime == false)
                throw new Exception("The operation can't be done now! it can be done only within working time.");
            _notAllPositionClosed = false;

            if (_pendingCloseDic == null) _pendingCloseDic = new Dictionary<string, OrderData>();
            else _pendingCloseDic.Clear();

            var positionList = UNLManager.PositionsDataBuilder.PositionDataDic.Values
                .Where(pd => pd.Position < 0 && pd.OptionData.Expiry == ExpiryDate).ToList();
            if (positionList.Count == 0)
                return false;
            //Check for options out of the 10% percants.
            var outLimitList = positionList
                .Where(p => Math.Abs(p.Delta) >= MAX_DELTA_OFFSET || Math.Abs(p.Delta) <= MIN_DELTA_OFFSET).ToList();
            if (outLimitList.Count < 1)
                return false;
            //Buy them (Close them)

            foreach (var positionData in outLimitList)
            {
                var orderData = UNLManager.OrdersManager
                    .BuyOption(positionData.OptionData, positionData.Quantity);
                _pendingCloseDic[orderData.OrderId] = orderData;
            }

            UNLManager.OrdersManager.OrderTradingNegotioationWasTerminated +=
                OrdersManager_OrderTradingNegotioationWasTerminated;
            return true;
        }

        private void OrdersManager_OrderTradingNegotioationWasTerminated(OrderStatus orderStatus, string orderId)
        {
            if (!_pendingCloseDic.ContainsKey(orderId)) return;

            var orderData = _pendingCloseDic[orderId];
            _pendingCloseDic.Remove(orderId);
            switch (orderStatus)
            {
                case OrderStatus.Filled:
                    //Sell ATM Position:
                    Logger.Info($"Position Closed successfully: {orderData}");
                    SellATMPosition(orderData);
                    break;
                case OrderStatus.NegotiationFailed:
                    Logger.Info($"Negotiation Failed: {orderData}");
                    _notAllPositionClosed = true;
                    break;
                default:
                    //Add it to did not Done list
                    break;
            }
            if (_pendingCloseDic.Count != 0) return;

            //Unregister to the event:
            UNLManager.OrdersManager.OrderTradingNegotioationWasTerminated -=
                OrdersManager_OrderTradingNegotioationWasTerminated;
            if (_notAllPositionClosed)
                UNLManager.AddScheduledTaskOnUnl(TimeSpan.FromMilliseconds(100), () => { OptimizePositions(); });
        }

        private void SellATMPosition(OrderData orderData)
        {
            double offsetStep = 0.05;
            double maxOffset = 0.50;
            double minOffset = 0.50;
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
                //throw new ArgumentNullException(nameof(theATMOption));
            }
            var atmOrderData = UNLManager.OrdersManager
                .SellOption(theATMOption, orderData.Quantity);
            Logger.Info($"Optimizer send sell order {atmOrderData}");
        }
    }
}
