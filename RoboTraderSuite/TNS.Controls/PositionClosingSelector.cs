using System;
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
                });
             
            }
        }

        private void PositionClosingSelector_Load(object sender, EventArgs e)
        {
            UnlTradingData unlTradingData = UnlManager.UnlTradingData;
            lblMarginGain.Text = (_marginData.MarginPerCouple * (double)numCouplesToClose.Value).ToString("C0");
            lblHeader.Text = $"{_symbol} - {unlTradingData.UnderlinePrice} Margin = {unlTradingData.Margin:C0}";
        }

        private void numCouplesToClose_ValueChanged(object sender, EventArgs e)
        {
            lblMarginGain.Text = (_marginData.MarginPerCouple * (double)numCouplesToClose.Value).ToString("C0");
        }

        private void btnSubmitCloseCouples_Click(object sender, EventArgs e)
        {
            try
            {
               UnlManager.TradingManager.CloseMateCouples((int)numCouplesToClose.Value, DateTime.Parse(txtExpireDate.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
