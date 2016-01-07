using System;
using System.Windows.Forms;
using Infra.Extensions;
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
            try
            {
                _appManager = new AppManager(this);
                //_appManager.AppManagerUp += AppManagerOnAppManagerUp;
                _appManager.Distributer.APIMessageArrive += DistributerOnAPIMessageArrive;

                _appManager.ConnectToBroker();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                MessageBox.Show(ex.Message);
            }
            

        }


        private void DistributerOnAPIMessageArrive(APIMessageData apiMessageData)
        {
            apiMesagesView.InvokeIfRequired(() => apiMesagesView.AddMessage(apiMessageData));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _appManager?.ShutDownApplication();
        }

        private void btnSendOrder_Click(object sender, EventArgs e)
        {
            _appManager.SendOneOrderTest("AAPL",true);
        }

        private void btnRegisterForData_Click(object sender, EventArgs e)
        {
            try
            {
                mainSecuritiesView1.SetUIDataManager(_appManager.UIDataManager);
                ordersView1.SetUIDataManager(_appManager.UIDataManager);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
