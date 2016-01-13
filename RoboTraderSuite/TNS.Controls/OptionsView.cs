using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infra.Extensions;
using UILogic;

namespace TNS.Controls
{
    public partial class OptionsView : UserControl
    {
        public OptionsView()
        {
            InitializeComponent();
        }

        private void btnLoadOptions_Click(object sender, EventArgs e)
        {
            try
            {
                UIDal uiDal = new UIDal();
                var list = uiDal.GetOptionsBySymbol("AAPL");
                this.InvokeIfRequired(() =>
                {
                    optionDataBindingSource.DataSource = list;
                    optionDataBindingSource.ResetBindings(false);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
