using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TNS.API.ApiDataObjects;

namespace TNS.Controls
{
    public partial class TradingControl : UserControl
    {
        public TradingControl()
        {
            InitializeComponent();
            TradingInfo = new TradingInfo();
            this.rgpSellOrBuy.EditValue = 1;            
        }

      

        //public void SetTradeCaption(string value)
        //{
        //    lblCaption.Text = value;
        //}

        public void SetTradingData( OptionData optionData)
        {
            lblCaption.Text = $"{optionData.Symbol} ==> {optionData.OptionContract.OptionType} {optionData.OptionContract.Strike}. {optionData.Expiry.ToShortDateString()}";

            OptionData = optionData;

            SetTradingDescription();
        }
        private OptionData OptionData { get; set; }
        private void rgpSellOrBuy_Properties_PropertiesChanged(object sender, EventArgs e)
        {
           if((int) rgpSellOrBuy.EditValue == 1)
            {
                //Sell:
                this.TradingInfo.OrderAction = OrderAction.SELL;
            }
            else
            {
                //Buy:
                this.TradingInfo.OrderAction = OrderAction.BUY;
            }
        }

        public TradingInfo TradingInfo { get; private set; }

        private void btnSubmitTrading_Click(object sender, EventArgs e)
        {
            TradingInfo.OptionCount = (int)numOptionsCount.Value;
            if ((int)rgpSellOrBuy.EditValue == 1)
            {
                //Sell:
                TradingInfo.OrderAction = OrderAction.SELL;
            }
            else
            {
                //Buy:
                TradingInfo.OrderAction = OrderAction.BUY;
            }
            ParentForm.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Set to null to indicate no operation.
            TradingInfo = null;
            ParentForm.Close();
        }

        private void rgpSellOrBuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTradingDescription();
        }

        private string TradingDescription { get; set; }
        private void SetTradingDescription()
        {
            var buyOrSell = "Sell";
            if ((int)rgpSellOrBuy.EditValue == 1)
            {
                //Sell:
                lblTradingDescription.ForeColor = Color.Red;
                btnSubmitTrading.BackColor = Color.Red;
            }
            else
            {
                //Buy:
                buyOrSell = "Buy";                
                lblTradingDescription.ForeColor = Color.Green;
                btnSubmitTrading.BackColor = Color.Green;
            }
            //lblTradingDescription.BackColor = Color.Salmon;
            lblTradingDescription.Text = $"{buyOrSell} ({OptionData.Symbol} {OptionData.OptionContract.OptionType} {OptionData.OptionContract.Strike}) X{numOptionsCount.Value}.";
            btnSubmitTrading.Text = $"{buyOrSell} {numOptionsCount.Value}";
        }

        private void numOptionsCount_ValueChanged(object sender, EventArgs e)
        {
            SetTradingDescription();
        }
    }


    public class TradingInfo
    {

       public OrderAction OrderAction { get; set; }

        public int OptionCount { get; set; }
    }
}
