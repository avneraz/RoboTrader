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

        private OptionsPositionData _positionData;
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

       public OptionsPositionData PositionData
        {
            get => _positionData;
            set
            {
                _positionData = value;
                SetDataSource();
            }
        }
        private List<OptionData> OptionsDataList { get; set; }

        private void SetDataSource()
        {
            var symbol = PositionData.Symbol;
            var expired = PositionData.Expiry;

            var list = OptionsDataList.Where(op => op.Symbol == symbol && op.OptionContract.Expiry == expired).ToList();
            if (list.Count == 0)
                throw new Exception("No option elements were found!");

            grdOption.InvokeIfRequired(() =>
            {
                optionDataBindingSource.DataSource = list;
                optionDataBindingSource.ResetBindings(false);
            });
            grdViewOption.ExpandGroupLevel(0);

            _taskId = GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(1),
                () =>
                {
                    grdOption.InvokeIfRequired(() =>
                    {
                        optionDataBindingSource.ResetBindings(false);
                    });
                }, true);
        }

      

        private void btnSendOrder_Click(object sender, EventArgs e)
        {
            try
            {
                OptionData optionData = GetSelectedOptionData();
                if (rbtSell.Checked)
                    PositionView.SendSellOrder(optionData, Convert.ToInt32(txtQuantity.Text));
                else
                    PositionView.SendBuyOrder(optionData, Convert.ToInt32(txtQuantity.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
    
    }
}
