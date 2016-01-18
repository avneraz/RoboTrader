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
            UIDal uiDal = new UIDal();
            OptionDataList = uiDal.GetLastOptionData();
            optionDataBindingSource.DataSource = OptionDataList;
            optionDataBindingSource.ResetBindings(false);
        }

        private IList<OptionData> OptionDataList { get; set; }
        void UpdateData()
        {
            try
            {
                UIDal uiDal = new UIDal();
                //var list = uiDal.GetOptionsBySymbol("AAPL");
                OptionDataList = uiDal.GetLastOptionData();
                this.InvokeIfRequired(() =>
                {
                    //optionDataBindingSource.DataSource = OptionDataList;
                    optionDataBindingSource.ResetBindings(false);
                    //gridControl1.RefreshDataSource();
                    //gridView1.ExpandAllGroups();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
