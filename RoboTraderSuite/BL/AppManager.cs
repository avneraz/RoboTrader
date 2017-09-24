using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DAL;
using TNS.API.ApiDataObjects;
using TNS.API.IBApiWrapper;
using Infra;
using Infra.Bus;
using Infra.Configuration;
using Infra.Enum;
using Infra.Extensions.ArrayExtensions;
using log4net;
using NHibernate;
using NHibernate.Linq;
using TNS.API;
using TNS.BL.DataObjects;
using TNS.BL.Interfaces;
using TNS.BL.UnlManagers;

namespace TNS.BL
{
    public class AppManager
    {

        public static AppManager AppManagerSingleTonObject { get; private set; }
        private static readonly ILog Logger = LogManager.GetLogger(typeof(AppManager));
        private void InitalizeUnhandledExceptionHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                var exception = (Exception)e.ExceptionObject;
                Logger.Error("Unhandled exception caught", exception);
            };
        }
        /// <summary>
        /// Should be called only once from the GUI main form.
        /// </summary>
        public AppManager()
        {
            InitalizeUnhandledExceptionHandler();
            InitializeAppManager();
            AppManagerSingleTonObject = this;
        }

        /// <summary>
        /// Must be called once application is up by the main GUI object
        /// </summary>
        private void InitializeAppManager()
        {

            ConfigHandler configHandler = new ConfigHandler();
            //Do the following just in case you want to create the configuration from scratch:
            WriteConfigurationFromScratch(configHandler);

            Configurations = configHandler.ReadConfig();
            //var a = Configurations.Trading.UNLSymbolsListForTrading();
            Infra.AllConfigurations.AllConfigurationsObject = Configurations;
            
            Distributer = new Distributer();

            //Change the wrapper object according to the actual broker, 
            //for now it's Interactive Broker.
            APIWrapper = new IBApiWrapper(
                Configurations.Application.DefaultHost, Configurations.Application.AppPort,
                Configurations.Application.AppClientId, Distributer,
                Configurations.Application.MainAccount);
        }
        /// <summary>
        /// Called when the application ready for connect to the broker.<para></para>
        /// The broker server must be up (TWS or other.)
        /// </summary>
        public void ConnectToBroker()
        {
            BuildManagers();
            StartManagers();
            APIWrapper.ConnectToBroker();
            UNLManager unlM = UNLManagerDic.Values.FirstOrDefault() as UNLManager;
            Debug.Assert(unlM != null, "UNLManager is null");
            unlM.SendTradingTimeEvent += TradingManager_SendTradingTimeEvent;
            Logger.InfoFormat( "AppManager up! ");
        }

        private void TradingManager_SendTradingTimeEvent(TradingTimeEvent tradingTimeEvent)
        {
            var eventType = tradingTimeEvent.TradingTimeEventType;
            switch (eventType)
            {
                case ETradingTimeEventType.StartTrading:
                    break;
                case ETradingTimeEventType.EndTradingIn30Seconds:
                    break;
                case ETradingTimeEventType.EndTradingIn60Seconds:
                    break;
                case ETradingTimeEventType.EndTrading:
                    DBDiluter dbDiluter = new DBDiluter();
                    dbDiluter.DiluteFromAllUnLs();
                    //Save the parameter in one minute from now, and then 'Net Liquidition' will be stable!
                    GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromMinutes(1), () =>
                    {
                        SavedPatametersManager.SaveLastNetLiquiditionParameter(AccountManager.NetLiquidation);
                    }, false);
                    break;
            }
        }

        private void StartManagers()
        {
            AccountManager.Start();
            ManagedSecuritiesManager.Start();
            UNLManagerDic.Values.ForEach(mgr => mgr.Start());
            DbWriter.Start();
            Distributer.Start();
        }

        public void CloseShortPositions(string symbol, DateTime expiry)
        {
            var unlManager = UNLManagerDic[symbol] as UNLManager;
            if(unlManager == null)
                throw new Exception($"The symbol: '{symbol}' doesn't exist in the UNLManager list!");
            unlManager.CloseShortPositions(expiry);
        }
        public void CloseEntireShortPositions(string symbol)
        {
            var unlManager = UNLManagerDic[symbol] as UNLManager;
            if (unlManager == null)
                throw new Exception($"The symbol: '{symbol}' doesn't exist in the UNLManager list!");
            unlManager.CloseEntireShortPositions();
        }
        public void ShutDownApplication()
        {
            GeneralTimer.GeneralTimerInstance.StopGeneralTimer();
            APIWrapper.DisconnectFromBroker();
            Logger.InfoFormat("ShutDown Application! ");
            //TOADO add another shutdown actions:
        }
        private void BuildManagers()
        {

            AccountManager = new AccountManager(APIWrapper);
            
            ManagedSecuritiesManager = new ManagedSecuritiesManager(APIWrapper);

            UNLManagerDic = new Dictionary<string, SimpleBaseLogic>();
            ISession session = DBSessionFactory.Instance.OpenSession();
            List<ManagedSecurity> activeUNLList = session.Query<ManagedSecurity>().Where(contract => contract.IsActive && contract.OptionChain).ToList();

            foreach (var managedSecurity in activeUNLList)
            {
                var unlManager = new UNLManager(managedSecurity, APIWrapper, Distributer);
                UNLManagerDic.Add(managedSecurity.Symbol, unlManager);
            }
            MarginManager = new MarginManager();

            DbWriter = new DBWriter(Configurations.Application.DBWritePeriod);
            Distributer.SetManagers(UNLManagerDic,AccountManager,ManagedSecuritiesManager, DbWriter,MarginManager);
            //UIDataManager = new UIDataManager();
        }
        public Dictionary<string, SimpleBaseLogic> UNLManagerDic { get; private set; }
        public ITradingApi APIWrapper { get; private set; }

        #region Managers Properties
        //public UIDataManager UIDataManager { get; set; }
        public Distributer Distributer { get; set; }
        public AccountManager AccountManager { get; private set; }
        public DBWriter DbWriter { get; set; }
        public AllConfigurations Configurations { get; private set; }
        public ManagedSecuritiesManager ManagedSecuritiesManager { get; private set; }
        public MarginManager MarginManager { get; set; }
        public SimpleBaseLogic UIDataBroker { get; set; }

        #endregion

        #region Testing
        public static void WriteConfigurationFromScratch(ConfigHandler configHandler)
        {
            AllConfigurations allConfigurations = new AllConfigurations
            {
                Application =
                {
                    DefaultHost = "127.0.0.1",
                    AppClientId = 11,
                    AppPort = 7496,//7496,4001,
                    MainAccount = "U1450837",
                    WDAppClientId = 12,
                    DBWritePeriod = TimeSpan.FromSeconds(10)
                },
                Session =
                {
                    AAPLHighLoadingStrike = 100,
                    AAPLLowLoadingStrike = 200,
                    AAPLSessionsToLoad = "20170817;20151016;20160115",
                    HighStrikePercentage = 15,
                    LowStrikePercentage = 15,
                    MinimumDaysToExpiration = 61,
                    MaxmumDaysToExpiration = 119,
                },
                Trading =
                {
                    AllowedDeltaOffset = 20,
                    USAInterestPercentage = 0.25,
                    StatisticsSaveIntervalSec = 300,
                    DeltaLossThreshold = 0.25,
                    PolicyID = 3,
                    AlgorithmType = 2,
                    OTMOffsetPut = 12,
                    OTMOffsetCall = 10,
                    UNLSymbolsList = "AAPL;MSFT",
                    RiskFreeInterestRate = 0.01,
                    InitNetLiquidation = 210300,
                    OrderInterval = 1500,
                    MinPriceStep = 0.01,

                }
            };


            configHandler.SaveConfig(allConfigurations);

        }

        //public void SendOneOrderTest(string symbol,bool sell)
        //{
        //    IOrdersManager ordersManager = ((UNLManager) UNLManagerDic[symbol]).OrdersManager;
        //    ordersManager.TestTrading(true);
        //}
        public void SendOneOrderTest(TradeOrderData tradeOrderData)
        {
            //IOrdersManager ordersManager = ((UNLManager)UNLManagerDic[tradeOrderData.Symbol]).OrdersManager;
            //ordersManager.TestTrading(tradeOrderData);
            ITradingManager tradeManager = ((UNLManager)UNLManagerDic[tradeOrderData.Symbol]).TradingManager;
            tradeManager.TestTrading(tradeOrderData);
        }
        public void CancelOrderTest(string symbol, string orderId)
        {
            IOrdersManager ordersManager = ((UNLManager)UNLManagerDic[symbol]).OrdersManager;
            ordersManager.CancelOrder(orderId);
        }

        public void DiluteOptionsTest()
        {
            TradingManager_SendTradingTimeEvent(new TradingTimeEvent(ETradingTimeEventType.EndTrading));
        }

        public double CalculateMarginTest(double unlRate, double strike, bool mate, EOptionType type = EOptionType.Call)
        {
           var result = MarginManager.CalculateMargin(unlRate, strike, mate, type);
            return result;
        }
        #endregion


    }
}
