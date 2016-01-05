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
using TNS.DbDAL;
using Infra;
using Infra.Bus;
using Infra.PopUpMessages;
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

            ConfigurationBuilder.BuildAndInitializeConfiguration();
            Configurations = AllConfigurations.AllConfigurationsObject;

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
            MainSecuritiesManager = new MainSecuritiesManager(APIWrapper);

            UNLManagerDic = new Dictionary<string, SimpleBaseLogic>();

            List<MainSecurity> activeUNLList = DbDalManager.GetActiveUNLList();
            foreach (MainSecurity mainSecurity in activeUNLList)
            {
                var unlManager = new UNLManager(mainSecurity, APIWrapper);
                UNLManagerDic.Add(mainSecurity.Symbol, unlManager);
            }

            DbWriter = new DBWriter();
            DbWriter.Connect();
            Distributer.SetManagers(UNLManagerDic,AccountManager,MainSecuritiesManager, DbWriter);
            UIDataManager = new UIDataManager(this);
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

        public UIDataManager UIDataManager { get; set; }
        public Distributer Distributer { get; set; }
        public AccountManager AccountManager { get; private set; }
        public DBWriter DbWriter { get; set; }
        public AllConfigurations Configurations { get; private set; }
        public MainSecuritiesManager MainSecuritiesManager { get; private set; }

        #endregion

        #region Testing

        public void SendOneOrderTest(string symbol,bool sell)
        {
            IOrdersManager ordersManager = ((UNLManager) UNLManagerDic[symbol]).OrdersManager;
            ordersManager.TestTrading(true);
        }

        #endregion


    }
}
