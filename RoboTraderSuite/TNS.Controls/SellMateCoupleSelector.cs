using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using Infra.Extensions;
using TNS.API.ApiDataObjects;
using TNS.BL;
using TNS.BL.UnlManagers;
// ReSharper disable LocalizableElement

namespace TNS.Controls
{
    public partial class SellMateCoupleSelector : UserControl
    {

     

        public SellMateCoupleSelector()
        {
            InitializeComponent();
            _appManager = AppManager.AppManagerSingleTonObject;
        }

        public EOperationType OperationType { get; set; }
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

                this.InvokeIfRequired(() =>
                {
                    unlTradingDataBindingSource.DataSource = UnlManager.UnlTradingData;
                    unlTradingDataBindingSource.ResetBindings(false);
                    _marginData = _appManager.MarginManager.MarginDataDic[_symbol];
                    marginDataBindingSource.DataSource = _marginData;
                    marginDataBindingSource.ResetBindings(false);

                    IEnumerable expiryDateEnumerable = OperationType == EOperationType.SellMateCouples
                        ? UnlManager.OptionsManager.OptionDataDic.Values
                            .DistinctBy(p => p.Expiry).Select(p => p.Expiry)
                        : UnlManager.PositionsDataBuilder.PositionDataDic.Values.DistinctBy(p => p.Expiry)
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

        private void SellMateCoupleSelector_Load(object sender, EventArgs e)
        {
            switch (OperationType)
            {
                case EOperationType.SellMateCouples:
                    SetGUI(btnSellMateCouples, " => Sell Mate Couple");
                    break;
                case EOperationType.OptimizePartlyPosition:
                    SetGUI(btnOptimizePartlyPosition, " => Optimize Partly Position");
                    break;
                case EOperationType.OptimizePosition:
                    SetGUI(btnOptimizePosition, " => Optimize Position");
                    lblComboBoxLabel.Location = lblCouplesCountLabel.Location;
                    lblCouplesCountLabel.Visible = false;
                    comBoxExpiries.Top = lblComboBoxLabel.Top;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            if (ParentForm == null) return;

            ParentForm.CancelButton = btnCancel;
        }

        private void SetGUI(Control control, string header)
        {
            UnlTradingData unlTradingData = UnlManager.UnlTradingData;

            lblHeader.Text = $"{_symbol} - {unlTradingData.Price} Margin =" +
                         $" {unlTradingData.Margin:C0} Max Margin = {unlTradingData.MaxAllowedMargin:C0}" + header;

            btnOptimizePosition.Visible = false;
            btnOptimizePartlyPosition.Visible = false;
            btnSellMateCouples.Visible = false;
               
            control.Location = btnSellMateCouples.Location;
            control.Visible = true; //btnSellMateCouples.Visible = true;
            if (comBoxExpiries.Items.Count < 1)
            {
                btnOptimizePosition.Enabled = false;
                btnOptimizePartlyPosition.Enabled = false;
                btnSellMateCouples.Enabled = false;
            }
           
        }

        private void btnSubmitCloseCouples_Click(object sender, EventArgs e)
        {
            try
            {
                ParentForm?.Close();
                UnlManager.TradingManager.SellMateCouples((int) numCouplesToSell.Value,
                    (DateTime) comBoxExpiries.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOptimizePosition_Click(object sender, EventArgs e)
        {
            try
            {
                ParentForm?.Close();
                UnlManager.TradingManager.OptimizePositions((DateTime) comBoxExpiries.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOptimizePartlyPosition_Click(object sender, EventArgs e)
        {
            try
            {
                ParentForm?.Close();
                UnlManager.TradingManager.PerformPartialOptimization((DateTime)comBoxExpiries.SelectedItem, (int)numCouplesToSell.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ParentForm?.Close();
        }

    }
    public enum EOperationType
    {
        UnKnown,
        SellMateCouples,
        OptimizePosition,
        OptimizePartlyPosition
    }
}
