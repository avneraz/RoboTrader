using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Infra.Bus;
using Infra.Enum;
using log4net;
using NHibernate;
using NHibernate.Linq;
using TNS.API;
using TNS.API.ApiDataObjects;
using TNS.BL.DataObjects;
using TNS.BL.Interfaces;

namespace TNS.BL.UnlManagers
{
    public class TradingManager : UnlMemberBaseManager, ITradingManager
    {

        public event Action<TradingTimeEvent> SendTradingTimeEvent;

        public virtual void OnSendTradingTimeEvent(TradingTimeEvent tradingTimeEvent)
        {
            Action<TradingTimeEvent> handler = SendTradingTimeEvent;
            handler?.Invoke(tradingTimeEvent);
        }
        public TradingManager(ITradingApi apiWrapper, ManagedSecurity managedSecurity, UNLManager unlManager) : base(apiWrapper, managedSecurity, unlManager)
        {
            OrderManager = unlManager.OrdersManager;
        }
        private static readonly ILog Logger = LogManager.GetLogger(typeof(TradingManager));
        private const int TRADING_CYCLE_TYME = 10;
        private string _taskId;

        private List<UnlOptions> UnlOptionsList { get; set; }
        private IOrdersManager OrderManager { get;  }
        public AccountSummaryData AccountSummaryData { get; set; }

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
                                _taskId = UNLManager.AddScheduledTaskOnUnl(TimeSpan.FromSeconds(TRADING_CYCLE_TYME), TradingWork, true);
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

        private void CreateOrUpdateUnlOption(TransactionData transactionData)
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
        private void TradingWork()
        {
            //Check margin
            //this.UnlTradingData.MaxAllowedMargin
            
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
                UNLManager.OrdersManager.BuyOption(positionData.OptionData, positionData.Position);
            }
            //If something happend during the posions closing.
            UNLManager.AddScheduledTaskOnUnl(TimeSpan.FromSeconds(30),
                () => CloseShortPositions(expiryDate));
        }

        public void TestTrading(TradeOrderData tradeOrderData)
        {
            string optionKey = GetOptionKey(tradeOrderData.ExpiryDate, tradeOrderData.OptionType, tradeOrderData.Strike);
            OptionData optionData = UNLManager.OptionsManager.GetOptionData(optionKey);
            if (optionData == null)
                throw new Exception("The Option doesn't exist in the Option list!!!");

            OrderData orderData = tradeOrderData.OrderAction == OrderAction.SELL ?
                OrderManager.SellOption(optionData, 1) :
                OrderManager.BuyOption(optionData, 1);
        }
        public string GetOptionKey(DateTime expiry, EOptionType optionType, double strike)
        {
            return $"{expiry}.{optionType}.{strike}";
        }
    }
}