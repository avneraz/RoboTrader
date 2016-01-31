using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Infra;
using Infra.Extensions;
using TNS.API.ApiDataObjects;

namespace TNS.Controls
{
    public partial class PositionsView : UserControl
    {
        public PositionsView()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            SetAndUpdate();
           
        }
        private void SetAndUpdate()
        {
            //optionsPositionDataBindingSource.DataSource = PositionDataDic.Values.ToList();
            optionsPositionDataBindingSource.DataSource = OptionsPositionDataList;
            grdPositionData.Refresh();
            if (_dataloaded)
                return;
            if (PositionDataDic.Count > 0)
            {
                _dataloaded = true;
                GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(1),
                    () =>
                    {
                        grdPositionData.InvokeIfRequired(() =>
                        {
                            optionsPositionDataBindingSource.DataSource = PositionDataDic.Values.ToList();
                            optionsPositionDataBindingSource.ResetBindings(false);
                            //OptionsPositionDataList = PositionDataDic.Values.ToList();
                            grdPositionData.Height = 208 + (gridView1.RowHeight + 1) * (optionsPositionDataBindingSource.Count);

                        });
                    },
                    true);
            }
        }

        private bool _dataloaded;
        private List<OptionsPositionData> OptionsPositionDataList { get; set; }
        public void SetUnlTradingDataDic(Dictionary<string, OptionsPositionData> positionDataDic)
        {
            PositionDataDic = positionDataDic;
            OptionsPositionDataList = positionDataDic.Values.ToList();
            GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(30), () => grdPositionData.InvokeIfRequired(SetAndUpdate), false);
         
        }

        private Dictionary<string, OptionsPositionData> PositionDataDic { get;  set; }

        private void PositionsView_Resize(object sender, EventArgs e)
        {
            
            grdPositionData.Height = 208 + (gridView1.RowHeight + 1) * (optionsPositionDataBindingSource.Count);
        }
    }
}
