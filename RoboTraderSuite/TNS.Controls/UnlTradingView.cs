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

namespace TNS.Controls
{
    public partial class UnlTradingView : UserControl
    {
        public UnlTradingView()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            SetAndUpdate();
        }

        private void SetAndUpdate()
        {
            unlTradingDataBindingSource.DataSource = UnlTradingDataDic.Values.ToList();
            grdUnLTradingData.Refresh();
            if(_dataloaded)
                return;
            if (UnlTradingDataDic.Count > 0)
            {
                _dataloaded = true;
                GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(1),
                    () =>
                    {
                        grdUnLTradingData.InvokeIfRequired(() =>
                        {
                            unlTradingDataBindingSource.DataSource = UnlTradingDataDic.Values.ToList();
                            unlTradingDataBindingSource.ResetBindings(false);

                        });
                    },
                    true);
            }
        }

        private bool _dataloaded;
        public void SetUnlTradingDataDic(Dictionary<string, UnlTradingData> unlTradingDataDic)
        {
            UnlTradingDataDic = unlTradingDataDic;
            GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(30), () => grdUnLTradingData.InvokeIfRequired(SetAndUpdate), false);
            //unlTradingDataBindingSource.DataSource = UnlTradingDataDic.Values.ToList();
            //GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(1),
            //    () => { gridControl1.InvokeIfRequired(() => { unlTradingDataBindingSource.ResetBindings(false); }); }, true);
        }
        public Dictionary<string, UnlTradingData> UnlTradingDataDic { get; private set; }
    }
}
