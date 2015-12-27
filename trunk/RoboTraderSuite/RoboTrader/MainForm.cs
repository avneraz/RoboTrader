using System;
using System.Windows.Forms;
using log4net;
using log4net.Repository.Hierarchy;
using TNS.API.ApiDataObjects;
using TNS.BL;

namespace TNS.RoboTrader
{
    /// <summary>
    /// The main GUI Form
    /// </summary>
    public partial class MainForm : Form
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(MainForm));
        /// <summary>
        /// The Main GUI Form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        private AppManager _appManager;
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            Logger.Info("Start Program - Tester");
            _appManager = new AppManager();
            _appManager.AppManagerUp += AppManagerOnAppManagerUp;
            _appManager.InitializeAppManager(this);
            _appManager.ConnectToBroker();
            _appManager.Distributer.APIMessageArrive += DistributerOnAPIMessageArrive;

        }

        private void AppManagerOnAppManagerUp()
        {
            mainSecuritiesView1.SetUIDataManager(_appManager.UIDataManager);
        }

        private void DistributerOnAPIMessageArrive(APIMessageData apiMessageData)
        {
            Action action = () => apiMesagesView.AddMessage(apiMessageData);
           
            if (InvokeRequired)
                Invoke(action);
            else
                action.Invoke();
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _appManager.ShutDownApplication();
        }
    }
}
