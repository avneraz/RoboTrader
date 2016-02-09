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

        public void SetOptionDataList(List<OptionData> optionsDataList)
        {
            gridControl1.InvokeIfRequired(() =>
            {
                optionDataBindingSource.DataSource = optionsDataList;
                optionDataBindingSource.ResetBindings(false);

            });

            GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(1),
               () =>
               {
                   gridControl1.InvokeIfRequired(() =>
                   {
                       optionDataBindingSource.ResetBindings(false);

                   });
               },
               true);

        }
    }
}
