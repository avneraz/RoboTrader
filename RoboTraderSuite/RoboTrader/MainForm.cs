using System;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraPrinting.HtmlExport;
using Infra;
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
        private UIDataBroker UIDataBroker { get; set; }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            Logger.Info("Start RoboTrader - Main Form");
            GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromMilliseconds(1), StartApplication, false);
            GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(30),
                () =>
                {
                    if (_startApplicationMethodDone == false)
                    {
                        this.InvokeIfRequired(() =>
                        {
                            PopupMessageForm.ShowMessage("Start Application Method fail, Time out 30 sec!!!!!!",
                                Color.Red, ParentForm, 5, withSiren: true);
                        });
                    }
                }, false);

        }

        private void StartApplication()
        {
            try
            {
                _appManager = new AppManager();
                _uiMessageHandler = new UIMessageHandler();
                _uiMessageHandler.Start();
                _uiMessageHandler.APIMessageArrive += DistributerOnAPIMessageArrive;
                _uiMessageHandler.ExceptionThrown += DistributerOnExceptionThrown;

                _appManager.Distributer.AddUIMessageHandler(_uiMessageHandler);

                UIDataBroker = new UIDataBroker();
                UIDataBroker.Start();
                _appManager.Distributer.AddUIDataBroker(UIDataBroker);

                _appManager.ConnectToBroker();
                //For Test: Thread.Sleep(30000);
                _startApplicationMethodDone = true;
                this.InvokeIfRequired(() =>
                {
                    PopupMessageForm.ShowMessage("Start Application Method finish successfully!!!", Color.Green,
                        ParentForm, 5, withSiren: false);
                    UpdateGuiComponents();
                });
                
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                this.InvokeIfRequired(() => { MessageBox.Show(ex.Message); });
                
            }
        }

        private void UpdateGuiComponents()
        {
            unlTradingView1.SetUnlTradingDataDic(UIDataBroker.UnlTradingDataDic);
            positionsView1.SetUnlTradingDataDic(UIDataBroker.PositionDataDic);
        }

        private bool _startApplicationMethodDone;

        private void DistributerOnExceptionThrown(ExceptionData exceptionData)
        {
            if (!(exceptionData.ThrownException is SocketException)) return;
            this.InvokeIfRequired(() =>
            {
                PopupMessageForm.ShowMessage(exceptionData.ToString(), Color.Red, ParentForm, 5, withSiren: true);
            });

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
        /// <summary>
        /// Indicate if the Greek  values of the options will be calculated locally, 
        /// usually it's activated by the user when the broker don't send Greek values.
        /// </summary>
        public bool CalculateGreekLocally { get; set; }
        private void btnBnsLocal_Click(object sender, EventArgs e)
        {
            CalculateGreekLocally = !CalculateGreekLocally;
            if (CalculateGreekLocally)
            {
                btnBnsLocal.Text = "TWS BnS";
                _appManager.Distributer.CalculateGreekLocally = true;
            }
            else
            {
                btnBnsLocal.Text = "Local BnS";
                _appManager.Distributer.CalculateGreekLocally = false;
            }

        }
    }
}
