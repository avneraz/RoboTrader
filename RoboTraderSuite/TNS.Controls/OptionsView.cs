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
            GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(5), UpdateData, true);
            btnLoadOptions.Enabled = false;
        }

        void UpdateData()
        {
            try
            {
                UIDal uiDal = new UIDal();
                //var list = uiDal.GetOptionsBySymbol("AAPL");
                var list = uiDal.GetLastOptionData();
                this.InvokeIfRequired(() =>
                {
                    optionDataBindingSource.DataSource = list;
                    optionDataBindingSource.ResetBindings(false);
                    gridControl1.RefreshDataSource();
                    gridView1.ExpandAllGroups();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
