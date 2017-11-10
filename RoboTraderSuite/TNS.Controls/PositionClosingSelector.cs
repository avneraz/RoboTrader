using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using Infra.Extensions;
using TNS.API.ApiDataObjects;
using TNS.BL;
using TNS.BL.UnlManagers;

namespace TNS.Controls
{
    public partial class PositionClosingSelector : DevExpress.XtraEditors.XtraUserControl
    {
        public PositionClosingSelector()
        {
            InitializeComponent();
            _appManager = AppManager.AppManagerSingleTonObject;
        }

        private MarginData _marginData;
        private readonly AppManager _appManager;
        private UNLManager UnlManager { get; set; }
        private string _symbol;

        public string Symbol
        {
            get => _symbol;
            set
            {
                _symbol = value;
                UnlManager = _appManager.UNLManagerDic[_symbol] as UNLManager;
                if (UnlManager == null) throw new Exception("The symbol is not exist!!");

                this.InvokeIfRequired (() =>
                {
                    unlTradingDataBindingSource.DataSource = UnlManager.UnlTradingData;
                    unlTradingDataBindingSource.ResetBindings(false);
                    _marginData = _appManager.MarginManager.MarginDataDic[_symbol];
                    marginDataBindingSource.DataSource = _marginData;
                    marginDataBindingSource.ResetBindings(false);

                    IEnumerable expiryDateEnumerable = UnlManager.PositionsDataBuilder.PositionDataDic.Values
                        .DistinctBy(p => p.Expiry)
                        .Select(p => p.Expiry);


                    foreach (var expiryDate in expiryDateEnumerable)
                    {
                        comBoxExpiries.Items.Add(expiryDate);
                    }
                    if (comBoxExpiries.Items.Count > 0)
                        comBoxExpiries.SelectedIndex = 0;
                });
             
            }
        }

        private void PositionClosingSelector_Load(object sender, EventArgs e)
        {
            UnlTradingData unlTradingData = UnlManager.UnlTradingData;
            lblMarginGain.Text = (_marginData.MarginPerCouple * (double)numCouplesToClose.Value).ToString("C0");
            lblHeader.Text = $"{_symbol} - {unlTradingData.LastPrice} Margin = {unlTradingData.Margin:C0}";
            btnSubmitCloseCouples.Text = $"Close {numCouplesToClose.Value:##} Mate Couple";
            numCouplesToClose.Maximum = _marginData.MateCouplesCount;
            numCouplesToClose.Minimum = 1;
        }

        private void numCouplesToClose_ValueChanged(object sender, EventArgs e)
        {
            lblMarginGain.Text = (_marginData.MarginPerCouple * (double)numCouplesToClose.Value).ToString("C0");
            btnSubmitCloseCouples.Text = $"Close {numCouplesToClose.Value:##} Mate Couple";
        }

        private void btnSubmitCloseCouples_Click(object sender, EventArgs e)
        {
            try
            {
                UnlManager.TradingManager.CloseMateCouples((int)numCouplesToClose.Value, (DateTime)comBoxExpiries.SelectedItem);
                ParentForm?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCloseAllPositions_Click(object sender, EventArgs e)
        {
            try
            {
                UnlManager.TradingManager.CloseEntireShortPositions();
                ParentForm?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
