using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Infra;
using Infra.Extensions;
using TNS.API.ApiDataObjects;

namespace TNS.Controls
{
    public partial class OptionTradingControl : UserControl
    {
        public OptionTradingControl()
        {
            InitializeComponent();
        }
        private string _taskId;

        private IPositionView _positionView;

        public IPositionView PositionView
        {
            get => _positionView;
            set
            {
                _positionView = value ?? throw new ArgumentNullException(nameof(value));
                OptionsDataList = PositionView.OptionsDataList;
            }
        }

        public void SetDataSource(OptionsPositionData positionData)
        {
            var symbol = positionData.Symbol;
            var expired = positionData.Expiry;

            SetDataSource(symbol, expired);
        }

        public void SetDataSource(string symbol) => SetDataSource(symbol, null);

        private void SetDataSource(string symbol, DateTime? expired)
        {
            var options = expired.HasValue
                ? OptionsDataList.Where(op => op.Symbol == symbol && op.OptionContract.Expiry == expired).ToList()
                : OptionsDataList.Where(op => op.Symbol == symbol).ToList();

            if (options.Count == 0)
                throw new Exception("No option elements were found!");

            grdOption.InvokeIfRequired(() =>
            {
                optionDataBindingSource.DataSource = options;
                optionDataBindingSource.ResetBindings(false);
            });
            grdViewOption.ExpandGroupLevel(0);
            grdViewOption.ExpandGroupLevel(1);

            _taskId = GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(1),
                () => { grdOption.InvokeIfRequired(() => { optionDataBindingSource.ResetBindings(false); }); }, true);
        }

        private List<OptionData> OptionsDataList { get; set; }

   
      

        private void btnSendOrder_Click(object sender, EventArgs e)
        {
            //OpenOrderDialog();

        }

        private void OpenOrderDialog()
        {
            try
            {
                OptionData optionData = GetSelectedOptionData();
                _tradingControl = new TradingControl();
                
                _tradingControl.SetTradingData(optionData);
                var containerForm = _tradingControl.ShowControl(ParentForm, true);

                containerForm.ControlBox = false;
                containerForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                containerForm.ShowIcon = false;
                containerForm.ShowInTaskbar = false;
                containerForm.TopMost = true;
                //containerForm.Text = caption;
                //containerForm.
                containerForm.FormClosing += ContainerForm_FormClosing;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private TradingControl _tradingControl;
        private void ContainerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_tradingControl == null) return;

            if (_tradingControl.TradingInfo == null) return;

            //Do trading:
            OptionData optionData = GetSelectedOptionData();
            if (_tradingControl.TradingInfo.OrderAction == OrderAction.BUY)
            {
                PositionView.SendBuyOrder(optionData, _tradingControl.TradingInfo.OptionCount);
            }
            else
            {
                PositionView.SendSellOrder(optionData, _tradingControl.TradingInfo.OptionCount);
            }
        }     



        private OptionData GetSelectedOptionData()
        {
            if ((optionDataBindingSource == null) || optionDataBindingSource.Count == 0)
                return null;

            var pos = grdViewOption.GetSelectedRows()[0];
            var optionData = (OptionData)grdViewOption.GetRow(pos);

            return optionData;
        }

      
           

        private void ParentFormOnClosed(object sender, EventArgs eventArgs)
        {
            GeneralTimer.GeneralTimerInstance.RemoveTask(_taskId);
        }

        private void OptionTradingControl_Load(object sender, EventArgs e)
        {
            if (ParentForm != null) ParentForm.Closed += ParentFormOnClosed;
        }

        private void grdViewOption_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                popupMenu1.ShowPopup(grdOption.PointToScreen(e.Point));
            }
        }

    
        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenOrderDialog();
        }
    }
}
