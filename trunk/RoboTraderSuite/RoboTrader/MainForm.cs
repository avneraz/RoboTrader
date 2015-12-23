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

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            Logger.Info("Start Program - Tester");
            AppManager appManager = new AppManager();
            appManager.InitializeAppManager(this);
            appManager.ConnectToBroker();
            appManager.Distributer.APIMessageArrive += DistributerOnAPIMessageArrive;
        }

        private void DistributerOnAPIMessageArrive(APIMessageData apiMessageData)
        {
            Action action = () =>
            {
                //txtMessages.Text += apiMessageData.ToString();
                apiMesagesView.AddMessage(apiMessageData);
            };
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action.Invoke();
            }
        }
    }
}
