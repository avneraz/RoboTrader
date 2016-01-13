using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using TNS.API.ApiDataObjects;
using TNS.API.IBApiWrapper;
using Infra;
using Infra.Bus;
using Infra.Configuration;
using Infra.PopUpMessages;
using NHibernate;
using NHibernate.Linq;
using TNS.API;
using TNS.BL.Interfaces;
using TNS.BL.UnlManagers;

namespace TNS.BL
{
    public class AppManager
    {
        public AppManager(Form mainForm)
        {
            InitializeAppManager(mainForm);
        }

        public event Action AppManagerUp;
        /// <summary>
        /// Must be called once application is up by the main GUI object
        /// </summary>
        private void InitializeAppManager(Form mainForm)
        {
            ParentForm = mainForm;

            ConfigHandler configHandler = new ConfigHandler();
            //Do the following just in case you want to create the configuration from scratch:
            //WriteConfigurationFromScratch(configHandler);

            Configurations = configHandler.ReadConfig();
            //var a = Configurations.Trading.UNLSymbolsListForTrading();
            Infra.AllConfigurations.AllConfigurationsObject = Configurations;
            
            Distributer = new Distributer();
            Distributer.ExceptionThrown += DistributerOnExceptionThrown;
            Distributer.ConnectionChanged += DistributerOnConnectionChanged;

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

            APIWrapper.ConnectToBroker();
            if (APIWrapper.IsConnected)
                DoWorkAfterConnectionToBroker();

        }
        public void ShutDownApplication()
        {
            GeneralTimer.GeneralTimerInstance.StopGeneralTimer();
            APIWrapper.DisconnectFromBroker();
            //TOADO add another shutdown actions:
        }
        private void BuildManagers()
        {

            AccountManager = new AccountManager(APIWrapper);
            ManagedSecuritiesManager = new ManagedSecuritiesManager(APIWrapper);

            UNLManagerDic = new Dictionary<string, SimpleBaseLogic>();
            ISession session = DBSessionFactory.Instance.OpenSession();
            List<ManagedSecurity> activeUNLList = session.Query<ManagedSecurity>().Where(contract => contract.IsActive && contract.OptionChain).ToList();

            //List<MainSecurity> activeUNLList = DbDalManager.GetActiveUNLList();
            foreach (var managedSecurity in activeUNLList)
            {
                //if (mainSecurity.Symbol == "AAPL")//For testing
                //    continue;
                var unlManager = new UNLManager(managedSecurity, APIWrapper);
                UNLManagerDic.Add(managedSecurity.Symbol, unlManager);
            }
           
            DbWriter = new DBWriter();
            DbWriter.Connect();
            Distributer.SetManagers(UNLManagerDic,AccountManager,ManagedSecuritiesManager, DbWriter);
        }
        private bool _doWorkAfterConnectionDone;
        public Dictionary<string, SimpleBaseLogic> UNLManagerDic { get; private set; }

        private Form ParentForm { get; set; }

        public bool IsConnected { get; set; }

        public ITradingApi APIWrapper { get; private set; }



        private void DistributerOnConnectionChanged(BrokerConnectionStatusMessage brokerConnectionStatusMessage)
        {
            IsConnected = (brokerConnectionStatusMessage.Status == ConnectionStatus.Connected);
            if (_doWorkAfterConnectionDone == false)
                DoWorkAfterConnectionToBroker();
        }
       

        private void DoWorkAfterConnectionToBroker()
        {
            _doWorkAfterConnectionDone = true;

            var connectionStatus = new BrokerConnectionStatusMessage(
                ConnectionStatus.Connected, null) {AfterConnectionToApiWrapper = true};

            Distributer.Enqueue(connectionStatus);
            
            
            AppManagerUp?.Invoke();
        }

        private void DistributerOnExceptionThrown(ExceptionData exceptionData)
        {
            if (!(exceptionData.ThrownException is SocketException)) return;

            if (ParentForm.InvokeRequired)
            {
                Action action = () =>
                {
                    PopupMessageForm.ShowMessage(exceptionData.ToString(), Color.Red, ParentForm, 5, withSiren: true);
                };
                ParentForm.Invoke(action);
            }
        }

        #region Managers Properties

        public Distributer Distributer { get; set; }
        public AccountManager AccountManager { get; private set; }
        public DBWriter DbWriter { get; set; }
        public AllConfigurations Configurations { get; private set; }
        public ManagedSecuritiesManager ManagedSecuritiesManager { get; private set; }

        #endregion

        #region Testing
        private static void WriteConfigurationFromScratch(ConfigHandler configHandler)
        {
            AllConfigurations allConfigurations = new AllConfigurations
            {
                Application =
                {
                    DefaultHost = "127.0.0.1",
                    AppClientId = 11,
                    AppPort = 7496,
                    MainAccount = "U1450837",
                    WDAppClientId = 12
                },
                Session =
                {
                    AAPLHighLoadingStrike = 100,
                    AAPLLowLoadingStrike = 200,
                    AAPLSessionsToLoad = "20150821;20151016;20160115",
                    HighStrikePercentage = 10,
                    LowStrikePercentage = 20,
                    MinimumDaysToExpiration = 20,
                    MaxmumDaysToExpiration = 60,
                },
                Trading =
                {
                    USAInterestPercentage = 0.25,
                    StatisticsSaveIntervalSec = 300,
                    PolicyID = 3,
                    AlgorithmType = 2,
                    OTMOffsetPut = 12,
                    OTMOffsetCall = 10,
                    UNLSymbolsList = "AAPL;MSFT"
                }
            };


            configHandler.SaveConfig(allConfigurations);

        }
       
        public void SendOneOrderTest(string symbol,bool sell)
        {
            IOrdersManager ordersManager = ((UNLManager) UNLManagerDic[symbol]).OrdersManager;
            ordersManager.TestTrading(true);
        }

        #endregion


    }
}
