using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Infra;
using Infra.Enum;
using Infra.Extensions;
using log4net;
using NHibernate;
using NHibernate.Linq;
using TNS.API.ApiDataObjects;
using TNS.BL.DataObjects;
using TNS.BL.Interfaces;
using IMessage = Infra.Bus.IMessage;
using OrderStatus = TNS.API.ApiDataObjects.OrderStatus;

namespace TNS.BL.UnlManagers
{
    public class TradingManager : UnlMemberBaseManager, ITradingManager
    {
        public event Action PositionNeedToOptimized;
        protected virtual void OnPositionNeedToOptimized()
        {
            PositionNeedToOptimized?.Invoke();
        }
        public event Action<TradingTimeEvent> SendTradingTimeEvent;

        public virtual void OnSendTradingTimeEvent(TradingTimeEvent tradingTimeEvent)
        {
            Action<TradingTimeEvent> handler = SendTradingTimeEvent;
            handler?.Invoke(tradingTimeEvent);
        }

        public TradingManager(ManagedSecurity managedSecurity, UNLManager unlManager) : base(
            managedSecurity, unlManager)
        {
            OrderManager = unlManager.OrdersManager;
            _pendingCloseDic = new Dictionary<string, OrderData>();
            _pendingSellDic = new Dictionary<string, OrderData>();
            OrderManager.OrderTradingNegotioationWasTerminated += OrderManager_OrderTradingNegotioationWasTerminated;
        }


        readonly Dictionary<int, PositionsOptimizer> _optimizersDic = new Dictionary<int, PositionsOptimizer>();
        private static readonly ILog Logger = LogManager.GetLogger(typeof(TradingManager));
        private static readonly AppManager AppManager = AppManager.AppManagerSingleTonObject;
        private const int TRADING_CYCLE_TYME = 10;

        /// <summary>
        /// MAX_DELTA_OFFSET = 0.55;
        /// </summary>
        private static readonly double MaxDeltaOffset = AllConfigurations.AllConfigurationsObject.Trading.MaxDeltaAllowed;//0.55;

        //MIN_DELTA_OFFSET = 0.45;
        private static readonly double MinDeltaOffset = AllConfigurations.AllConfigurationsObject.Trading.MinDeltaAllowed;//0.45;
        private string _taskId;

        private List<UnlOptions> UnlOptionsList { get; set; }
        private IOrdersManager OrderManager { get;  }
        public AccountSummaryData AccountSummaryData { get; set; }

        private IEnumerable<DateTime> ExpiryDateEnumerable => UNLManager.PositionsDataBuilder.PositionDataDic.Values
            .DistinctBy(p => p.Expiry).Select(p => p.Expiry);

       
        public override bool HandleMessage(IMessage message)
        {
            //ForTest:if(UnlTradingData.Margin > 0){ }

            if( base.HandleMessage(message))
                return true;
              
            switch (message.APIDataType)
            {
                case EapiDataTypes.AccountSummaryData:
                    AccountSummaryData = message as AccountSummaryData;
                    return true;
                case EapiDataTypes.TradingTimeEvent:
                    var tradingTimeEvent = (TradingTimeEvent) message;
                    try
                    {
                        var eventType = tradingTimeEvent.TradingTimeEventType;
                        switch (eventType)
                        {
                            case ETradingTimeEventType.StartTrading:
                                _taskId = UNLManager.AddScheduledTaskOnUnl(TimeSpan.FromSeconds(TRADING_CYCLE_TYME), DoTradingWork, true);
                                break;
                            case ETradingTimeEventType.EndTradingIn30Seconds:
                                break;
                            case ETradingTimeEventType.EndTradingIn60Seconds:
                                break;
                            case ETradingTimeEventType.EndTrading:
                                UNLManager.RemoveScheduledTaskOnUnl(_taskId);
                                break;
                        }
                    }
                    finally
                    {
                        //Propagate by event:
                        OnSendTradingTimeEvent(tradingTimeEvent);
                    }
                   
                    return true;
                case EapiDataTypes.BrokerConnectionStatus:
                    var connectionStatusMessage = (BrokerConnectionStatusMessage)message;
                    if (connectionStatusMessage.AfterConnectionToApiWrapper)
                        DoWorkAfterConnection();
                    return true;
                case EapiDataTypes.TransactionData:
                    //Create the adequate UnlOptins object and save it in db:
                    CreateOrUpdateUnlOption(message as TransactionData);
                    break;
            }
            return false;

        }

        public void OptimizePositions(DateTime expiryDate)
        {
            var optimizer = new PositionsOptimizer(Symbol, expiryDate);
            optimizer.OptimizePositions();
        }
        public void PerformPartialOptimization( DateTime expiryDate, int mateCoupleCount)
        {
            var optimizer = new PositionsOptimizer(Symbol, expiryDate);
            if(!optimizer.PerformPartialOptimization(mateCoupleCount))
                throw new Exception("There is no positions for optimization!");
        }
        private void CreateOrUpdateUnlOption(TransactionData transactionData)
        {
            try
            {
                UnlOptions unlOptions;
                //If the list was not load yet, load it.
                if (UnlOptionsList == null)
                    LoadUnlOptionsList();
                if (transactionData.Order.OrderAction == OrderAction.BUY)
                {
                    if (UnlOptionsList.Any(uo => uo.Id == 0))
                        //Reload the list to refresh the IDs:
                        LoadUnlOptionsList();

                    //Update an exsisting one with the max IV (Maximum profit) and remove it from the list
                    unlOptions = UnlOptionsList.Where(uo => uo.OptionKey.Equals(transactionData.OptionKey))
                        .OrderByDescending(uo => uo.OptionData.ImpliedVolatility).First();
                    if (unlOptions != null)
                    {
                        unlOptions.CloseTransaction = transactionData;
                        unlOptions.LastUpdate = DateTime.Now;
                        UnlOptionsList.Remove(unlOptions);
                    }
                }
                else
                {
                    //Create new one
                    unlOptions = new UnlOptions
                    {
                        OpenTransaction = transactionData,
                        Symbol = Symbol,
                        OptionKey = transactionData.OptionKey,
                        Account = AccountSummaryData.MainAccount,
                    };


                    UnlOptionsList.Add(unlOptions);
                }
                //Save
                UNLManager.Distributer.Enqueue(unlOptions);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
        }

        private void LoadUnlOptionsList()
        {
            ISession session = DBSessionFactory.Instance.OpenSession();

            try
            {
                UnlOptionsList = session.Query<UnlOptions>()
                    .Where(uo => (uo.Account.Equals(AccountSummaryData.MainAccount) && 
                                  uo.Symbol.Equals(Symbol) &&
                                  uo.Status == EStatus.Open))
                    .ToList();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Do trading work initiated from scheduler task
        /// </summary>
        private void DoTradingWork()
        {
            if (AllConfigurations.AllConfigurationsObject.Application.AllowAutoTrading == false) return;
            if (UNLManager.PositionsDataBuilder.PositionDataDic.Values.Count == 0) return;
            foreach (var expiry in ExpiryDateEnumerable)
            {
                try
                {
                    if (UNLManager.PositionsDataBuilder.PositionDataDic.Values.Any(
                                pd => pd.Position < 0 && pd.OptionData.Expiry == expiry &&
                                      (pd.OptionData.DeltaAbsValue >= MaxDeltaOffset ||
                                       pd.OptionData.DeltaAbsValue <= MinDeltaOffset)) == false)
                        continue;
                    OnPositionNeedToOptimized();
                    //return;
                    var optimizer = new PositionsOptimizer(Symbol, expiry);
                    _optimizersDic[optimizer.GetHashCode()] = optimizer;

                    optimizer.MissionAccomplished += OptimizerOnMissionAccomplished;
                    optimizer.OptimizePositions();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message, ex);
                }
            }
            
        }

        private void OptimizerOnMissionAccomplished(PositionsOptimizer positionsOptimizer)
        {
            var key = positionsOptimizer.GetHashCode();
            if (_optimizersDic.ContainsKey(key))
            {
                _optimizersDic.Remove(key);
            }
            //Remove registration:
            positionsOptimizer.MissionAccomplished -= OptimizerOnMissionAccomplished;
        }


        public override void DoWorkAfterConnection()
        {
            //Don't load the list now because the AccountSummaryData is not yet loaded!! Avner 18/8/2017
            //LoadUnlOptionsList();
        }

        public void CloseEntireShortPositions()
        {
            CloseShortPositions();
        }

        public void CloseShortPositions(DateTime? expiryDate=null)
        {
            if(UNLManager.IsNowWorkingTime == false)
                throw new Exception("Do this activity during working time!!!");
            List<OptionsPositionData> positionList;
            if (expiryDate.HasValue)
                positionList = UNLManager.PositionsDataBuilder.PositionDataDic.Values
                    .Where(pd => pd.Position < 0 && pd.OptionData.Expiry == expiryDate).ToList();
            else
                positionList = UNLManager.PositionsDataBuilder.PositionDataDic.Values
                    .Where(pd => pd.Position < 0).ToList();

            if (positionList.Count == 0)
                return;

            foreach (var positionData in positionList)
            {
                var orderData = UNLManager.OrdersManager.BuyOption(positionData.OptionData, positionData.Quantity);
                _pendingCloseDic[orderData.OrderId] = orderData;
            }
           
        }

        public void CloseMateCouples(int cuoplesCount, DateTime expiryDate)
        {
            if (UNLManager.IsNowWorkingTime == false)
                throw new Exception("Do this activity during working time!!!");
            var marginData = AppManager.MarginManager.MarginDataDic[Symbol];
            var totalCouplesCount = marginData.MateCouplesCount;
            cuoplesCount = Math.Min(cuoplesCount, totalCouplesCount);//In case the parameter greater then th ecouple total count.

            for (var i = 0; i < cuoplesCount; i++)
            {
                //Close Call:
                var position= UNLManager.PositionsDataBuilder.PositionDataDic.Values
                    .FirstOrDefault(pd => pd.Position < 0 && pd.OptionType == EOptionType.Call && pd.OptionData.Expiry == expiryDate);

                if (position != null)
                {
                    var orderData = OrderManager.BuyOption(position.OptionData, 1);
                    _pendingCloseDic[orderData.OrderId] = orderData;
                }
                else throw new Exception("CloseMateCouples: can't find match call position");
                //Close Put:
                position = UNLManager.PositionsDataBuilder.PositionDataDic.Values
                    .FirstOrDefault(pd => pd.Position < 0 && pd.OptionType == EOptionType.Put && pd.OptionData.Expiry == expiryDate);

                if (position != null)
                {
                    var orderData = OrderManager.BuyOption(position.OptionData, 1);
                    _pendingCloseDic[orderData.OrderId] = orderData;
                }
                else throw new Exception("CloseMateCouples: can't find match put position");
            }
            //Add task to check if all the orders done :
           // UNLManager.AddScheduledTaskOnUnl(TimeSpan.FromSeconds(30),(() => ) )
        }
        private readonly Dictionary<string, OrderData> _pendingCloseDic;
        private readonly Dictionary<string, OrderData> _pendingSellDic;
        private void OrderManager_OrderTradingNegotioationWasTerminated(OrderStatus orderStatus, string orderId)
        {
            if (_pendingSellDic.ContainsKey(orderId))
            {
                HandleSellOrderNotifications(orderStatus, orderId);
                return;
            }
            if (_pendingCloseDic.ContainsKey(orderId))
            {
                HandleCloseOrderNotifications(orderStatus, orderId);
                
            }
        }

        private void HandleCloseOrderNotifications(OrderStatus orderStatus, string orderId)
        {
            //Remove From list
            var oldOrderData = _pendingCloseDic[orderId];
            _pendingCloseDic.Remove(orderId);
            if(orderStatus == OrderStatus.Filled) return;
            //Stop resend order after 3 failed tryings.
            if (oldOrderData.OrderSentCount >= 3) return;
             
            var optionContract = oldOrderData.Contract as OptionContract;
            if (optionContract == null) return;
            
                var optionData =
                    UNLManager.OptionsManager.GetOptionData(optionContract.OptionKey);
            
            var orderData = OrderManager.BuyOption(optionData, oldOrderData.Quantity);
            orderData.OrderSentCount = oldOrderData.OrderSentCount + 1;
            _pendingCloseDic[orderData.OrderId] = orderData;

        }

        private void HandleSellOrderNotifications(OrderStatus orderStatus, string orderId)
        {
            //Remove From list
            var oldOrderData = _pendingSellDic[orderId];
            _pendingSellDic.Remove(orderId);
            if (orderStatus == OrderStatus.Filled) return;
            //Stop resend order after 3 failed tryings.
            if (oldOrderData.OrderSentCount >= 3) return;

            var optionContract = oldOrderData.Contract as OptionContract;
            if (optionContract == null) return;

            var optionData =
                UNLManager.OptionsManager.GetOptionData(optionContract.OptionKey);

            var orderData = OrderManager.SellOption(optionData, oldOrderData.Quantity);
            orderData.OrderSentCount = oldOrderData.OrderSentCount + 1;
            _pendingSellDic[orderData.OrderId] = orderData;
        }

        /// <summary>
        /// Sell Mate couple, Put and Call ATM.
        /// </summary>
        /// <param name="cuoplesCount"></param>
        /// <param name="expiryDate"></param>
        public void SellMateCouples(int cuoplesCount, DateTime expiryDate)
        {
            var callOption = GetATMOptionData(EOptionType.Call, expiryDate);
            var putOption = GetATMOptionData(EOptionType.Put, expiryDate);
            if (callOption == null || putOption == null) throw new Exception("No Mate option couple was found!");

            //Sell and register for watch:
            var callOrderData = OrderManager.SellOption(callOption, cuoplesCount);
            _pendingSellDic[callOrderData.OrderId] = callOrderData;
            var putOrderData = OrderManager.SellOption(putOption, cuoplesCount);
            _pendingSellDic[putOrderData.OrderId] = putOrderData;
        }
        OptionData GetATMOptionData(EOptionType opType, DateTime expiryDate)
        {
            var offsetStep = 0.005;
            var maxOffset = 0.495;
            var minOffset = 0.505;

            OptionData theATMOption = null;
            //Get optionATM:
            while (theATMOption == null)
            {
                maxOffset += offsetStep;
                minOffset -= offsetStep;

                theATMOption = UNLManager.OptionsManager.OptionDataDic.Values.FirstOrDefault(
                    o => o.Expiry.Equals(expiryDate) && o.OptionContract.OptionType == opType &&
                         o.DeltaAbsValue >= minOffset && o.DeltaAbsValue <= maxOffset);
                //Set for max iteration
                if (maxOffset > (0.50 + 20 * offsetStep))//Max will be: 0.555 <=> 0.445
                    return null;
            }
            return theATMOption;
        }
        public void TestTrading(TradeOrderData tradeOrderData)
        {
            string optionKey = GetOptionKey(tradeOrderData.ExpiryDate, tradeOrderData.OptionType, tradeOrderData.Strike);
            OptionData optionData = UNLManager.OptionsManager.GetOptionData(optionKey);
            if (optionData == null)
                throw new Exception("The Option doesn't exist in the Option list!!!");

            OrderData orderData;
            if (tradeOrderData.OrderAction == OrderAction.SELL)
            {
                orderData = OrderManager.SellOption(optionData, 1);
                _pendingSellDic[orderData.OrderId] = orderData;
            }
            else
            {
                orderData = OrderManager.BuyOption(optionData, 1);
                _pendingCloseDic[orderData.OrderId] = orderData;
            }
               
        }
        public string GetOptionKey(DateTime expiry, EOptionType optionType, double strike)
        {
            return $"{expiry}.{optionType}.{strike}";
        }

        
    }
}