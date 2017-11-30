using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Infra.Extensions;
using TNS.BL;
using TNS.BL.UnlManagers;

namespace TNS.Controls
{
    public partial class WhatIfControl : UserControl
    {
        public WhatIfControl()
        {
            InitializeComponent();
        }

        public WhatIfControl(string symbol)
        {
            InitializeComponent();
            _symbol = symbol;
            InitializeMembers();
        }

        private  AppManager AppManager => AppManager.AppManagerSingleTonObject;
        private readonly string _symbol;
        private UNLManager UnlManager { get; set; }
       
        private void InitializeMembers()
        {
            UnlManager = AppManager.UNLManagerDic[_symbol] as UNLManager;
            if (UnlManager == null) throw new Exception("The symbol is not exist!!");

            this.InvokeIfRequired(() =>
            {
                unlTradingDataBindingSource.DataSource = UnlManager.UnlTradingData;
                unlTradingDataBindingSource.ResetBindings(false);
            });
            IEnumerable expiryDateEnumerable = UnlManager.PositionsDataBuilder.PositionDataDic.Values
                .DistinctBy(p => p.Expiry).Select(p => p.Expiry);
            UnlManager.UnlTradingData.Title = "Current Data:";

            foreach (var expiryDate in expiryDateEnumerable)
            {
                comBoxExpiries.Items.Add(expiryDate);
            }
            if (comBoxExpiries.Items.Count > 0)
                comBoxExpiries.SelectedIndex = 0;
        }

        private void WhatIfControl_Load(object sender, EventArgs e)
        {
            var unlTradingData = UnlManager.UnlTradingData;
            lblHeader.Text = $"{_symbol} - {unlTradingData.LastPrice} Margin =" +
                             $" {unlTradingData.Margin:C0} Max Margin = {unlTradingData.MaxAllowedMargin:C0}" + "=> What If Analysis.";
            gridViewUTD.BestFitColumns();

            if (ParentForm == null) return;
            ParentForm.CancelButton = btnCancel;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //Visible = false;
                //Parent.Controls.Remove(this);
                //Dispose();

                ParentForm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
