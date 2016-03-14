using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private IPositionView PositionView { get; set; }
        public static Form ShowControlWithinForm(IPositionView positionView, OptionsPositionData positionData)
        {
            string symbol = positionData.GetSymbolName();
            DateTime expired = positionData.Expiry;

            Form containerForm = new Form();
            OptionTradingControl control = new OptionTradingControl();
            control.PositionView = positionView;
            containerForm.Size = control.Size;
            control.SetOptionDataList(positionView.OptionsDataList);
            control.SetDataSource(symbol, expired);
            control.Dock = DockStyle.Fill;
            containerForm.Controls.Add(control);
            return containerForm;

        }

        private List<OptionData> OptionsDataList { get; set; }

        public void SetDataSource(string symbol, DateTime expired)
        {

            var list = OptionsDataList.Where(op => op.GetSymbolName() == symbol && op.OptionContract.Expiry == expired).ToList();
            if(list.Count == 0)
                throw new Exception("No option elements were found!");
            var unlPrice = list.First().UnderlinePrice;
            if (unlPrice < 0.01)
                unlPrice = 100;
            var list2 =
                list.Where(
                    od => od.OptionContract.Strike > (unlPrice - 10) && od.OptionContract.Strike < (unlPrice + 10));


            grdOption.InvokeIfRequired(() =>
            {
                optionDataBindingSource.DataSource = list2;
                optionDataBindingSource.ResetBindings(false);
            });


            GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(1),
                () =>
                {
                    grdOption.InvokeIfRequired(() =>
                    {
                        optionDataBindingSource.ResetBindings(false);
                    });
                }, true);



        }

        public void SetOptionDataList(List<OptionData> optionsDataList)
        {
            OptionsDataList = optionsDataList;
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
        public OptionData GetSelectedOptionData()
        {
            if ((optionDataBindingSource == null) || optionDataBindingSource.Count == 0)
                return null;

            var pos = grdViewOption.GetSelectedRows()[0];
            var optionData = (OptionData)grdViewOption.GetRow(pos);

            return optionData;
        }
    }
}
