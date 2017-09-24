using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;
using DAL;
using Infra;
using Infra.Enum;
using Infra.Extensions;
using Infra.PopUpMessages;
using log4net;
using TNS.API.ApiDataObjects;
using TNS.BL;
using TNS.BL.DataObjects;
using TNS.RoboTrader;
using UILogic;

namespace RazboTrader
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
            this.Size = new Size(1600, 1000);
            this.SetLocationAtExtendScreen();
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
            positionsView1.SetPositionDataList(UIDataBroker.PositionDataList);
            positionsView1.SetAccountSummaryData(UIDataBroker.AccountSummaryDataList);
            positionsView1.SetUnlTradingDataList(UIDataBroker.UnlTradingDataList);
            positionsView1.SetSecurityDataList(UIDataBroker.SecurityDataList);
            positionsView1.SetAppManager(_appManager);
            positionsView1.SetOptionDataList(UIDataBroker.OptionsDataList);
            ordersView1.SetOrderStatusDataList(UIDataBroker.OrderStatusDataList);
            optionsView1.SetOptionDataList(UIDataBroker.OptionsDataList);
            mainSecuritiesView1.SetManagedSecuritiesData(UIDataBroker.SecurityDataList);
        }

        public List<OptionData> OptionsDataList { get; set; }
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
            try
            {
                //Create the object:
                TradeOrderData tradeOrderData = new TradeOrderData()
                {
                    OrderType = OrderType.MKT,
                    OptionTypeText = txtType.Text,
                    ExpiryDate = dateTimePicker1.Value,
                    OrderAction = cbxSell.Checked ? OrderAction.SELL : OrderAction.BUY,
                    Strike = Convert.ToDouble(txtStrike.Text),
                    Symbol = txtSymbol.Text
                };
                
                _appManager.SendOneOrderTest(tradeOrderData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelOrderTest(string orderId)
        {
            _appManager.CancelOrderTest("AAPL", orderId);
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

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            try
            {
                CancelOrderTest(ordersView1.SelectedOrderStatusData.OrderId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTestDiluter_Click(object sender, EventArgs e)
        {
            try
            {
                DBDiluter dbDiluter = new DBDiluter();
                DateTime startDate = new DateTime(2017, 8, 21);
                DateTime endDate = new DateTime(2017, 8, 22);

                var count = dbDiluter.DiluteOptionsFromAllUnLs(startDate, endDate);
                MessageBox.Show($"{count} rows were deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                var strike = Convert.ToDouble(txtStrike.Text);
                var unlRate = Convert.ToDouble(txtUNLRate.Text);
                EOptionType type;
                if(Enum.TryParse(txtType.Text, true,out type) == false) throw new Exception("Wrong option type!");
                bool mate = cbxSell.Checked;
                var result = _appManager.CalculateMarginTest(unlRate, strike, mate, type);
                MessageBox.Show($"The margin is {result}");

                // string unl = "AMZN";
                // DateTime expiryDate = new DateTime(2017, 12, 15);
                //var list = OptionTradingDataFactory.GetOptionTradingDataList(unl, expiryDate);

                // MessageBox.Show($"The UNL: '{unl}' Expiry={expiryDate} has {list.Count} items.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTestClosePositions_Click(object sender, EventArgs e)
        {
            try
            {
                var symbol = txtSymbol.Text;
                _appManager.CloseEntireShortPositions(symbol);
                //var expiryDate = dateTimePicker1.Value;

                //var symbol = txtSymbol.Text;
                //_appManager.CloseShortPositions(symbol,expiryDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
