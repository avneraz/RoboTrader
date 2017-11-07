using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infra.Enum;
using Infra.Extensions;
using TNS.BL;

namespace TNS.Controls
{
    public partial class UNLOptionsSelectorControl : UserControl
    {
        public UNLOptionsSelectorControl()
        {
            InitializeComponent();
        }

        private string _symbol;

        public string Symbol
        {
            get => _symbol;
            set
            {
                _symbol = value;
                var expiryDateEnumerable = OptionTradingDataFactory.GetUNLExpiryList(_symbol, true);
                foreach (var expiryDate in expiryDateEnumerable)
                {
                    comBoxExpiries.Items.Add(expiryDate);
                }
                if (comBoxExpiries.Items.Count > 0)
                    comBoxExpiries.SelectedIndex = 0;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var control = new UNLOptionsControl();
            try
            {
                var list = OptionTradingDataFactory.GetOptionTradingDataList(_symbol,
                    (DateTime) comBoxExpiries.SelectedItem, EStatus.AllStatus);
                if(list.Count == 0) throw new Exception("There is no results, or Options still loading!");
                

                control.SetDataSource(list);
                control.ShowControl(this.ParentForm, true);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                this.Parent.Controls.Remove(this);
            }
        }
    }
}
