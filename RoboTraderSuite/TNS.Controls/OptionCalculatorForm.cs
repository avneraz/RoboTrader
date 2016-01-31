using System;
using System.Globalization;
using System.Windows.Forms;
using Infra.BnS;
using Infra.Enum;
using Infra.Extensions;

namespace TNS.Controls
{
    public partial class OptionCalculatorForm : Form
    {
        public OptionCalculatorForm()
        {
            InitializeComponent();
            //grpOptionType.EditValue = 0;
            OptionType = EOptionType.Call;
        }

        private double StockPrice => double.Parse(txtStockPrice.Text);

        private double StrikePrice => double.Parse(txtStrikePrice.Text);

        private double OptionPrice => double.Parse(txtOptionPrice.Text);

        /// <summary>
        /// Get the all  left until expired.
        /// </summary>
        private int DayLefts => int.Parse(txtExpireDays.Text);

        private double ImpliedVolatilities => (double.Parse(txtSigma.Text)) / 100.0d;

        private double RiskFreeInterestRate => (double.Parse(txtRiskFreeInterestRate.Text) / 100.0d);

        private void btnCalculate_Click(object sender, EventArgs e)
        {

            try
            {
                BlackNScholesCaculator blackNScholesCaculator = new BlackNScholesCaculator()
                   {
                       DayLefts = DayLefts,
                       ImpliedVolatilities = this.ImpliedVolatilities,
                       //OptionType = EOptionTypes.Put,
                       RiskFreeInterestRate = this.RiskFreeInterestRate,
                       StockPrice = this.StockPrice,
                       StrikePrice = this.StrikePrice
                   };
                blackNScholesCaculator.CalculateAll();
                double resValue = blackNScholesCaculator.CallValue;
                lblCallB_SValue.Text = resValue.ToString("#0.00");
                resValue = blackNScholesCaculator.PutValue;
                lblPutB_SValue.Text = resValue.ToString("#0.00");


                lblPutDelta.Text = blackNScholesCaculator.DeltaPut.ToString("#0.00");

                lblCallDelta.Text = blackNScholesCaculator.DeltaCall.ToString("#0.00");

                lblCallGama.Text = blackNScholesCaculator.GamaCall.ToString("#0.0000");
                lblPutGama.Text = blackNScholesCaculator.GamaPut.ToString("#0.0000");

                lblCallTheta.Text = blackNScholesCaculator.ThetaCall.ToString("#0.00");
                lblPutTheta.Text = blackNScholesCaculator.ThetaPut.ToString("#0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCalculateIV_Click(object sender, EventArgs e)
        {
            try
            {
                var blackNScholesCaculator = new BlackNScholesCaculator()
                   {
                       DayLefts = DayLefts,

                       RiskFreeInterestRate = this.RiskFreeInterestRate,
                       StockPrice = this.StockPrice,
                       StrikePrice = this.StrikePrice
                   };

                var iv = OptionType == EOptionType.Call
                    ? blackNScholesCaculator.GetCallIVBisections(OptionPrice)
                    : blackNScholesCaculator.GetPutIVBisections(OptionPrice);

                txtBNSBisections.Text = iv.ToString(CultureInfo.InvariantCulture);

                txtIterationCounter.Text = blackNScholesCaculator.IterationCounter.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public EOptionType OptionType { get; set; }

        private void grpOptionType_EditValueChanged(object sender, EventArgs e)
        {
            OptionType = (int)grpOptionType.EditValue == 1 ? EOptionType.Put : EOptionType.Call;
        }

        private void OptionCalc_Load(object sender, EventArgs e)
        {
            this.SetLocationAtExtendScreen();
        }
     
    }
}
