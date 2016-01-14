using System;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;
using Infra.Extensions;
using Infra.PopUpMessages;
using log4net;
using log4net.Repository.Hierarchy;
using TNS.API.ApiDataObjects;
using TNS.BL;
using UILogic;

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
        private UIMessageHandler _uiMessageHandler;

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            Logger.Info("Start Program - Tester");
            try
            {
                _appManager = new AppManager();
                _uiMessageHandler = new UIMessageHandler();
                _uiMessageHandler.Start();
                _uiMessageHandler.APIMessageArrive += DistributerOnAPIMessageArrive;
                _uiMessageHandler.ExceptionThrown += DistributerOnExceptionThrown;

                _appManager.Distributer.AddUIMessageHandler(_uiMessageHandler);
                _appManager.ConnectToBroker();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                MessageBox.Show(ex.Message);
            }
            

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
            _appManager.SendOneOrderTest("AAPL",false);

        }

        private void btnRegisterForData_Click(object sender, EventArgs e)
        {
            try
            {
                UIDal uiDal = new UIDal();
                var list = uiDal.GetOptionsBySymbol("AAPL");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
