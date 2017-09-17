using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Infra.Extensions;
using TNS.API.ApiDataObjects;

namespace TNS.Controls
{
    public partial class UNLOptionsControl : UserControl
    {
        public UNLOptionsControl()
        {
            InitializeComponent();
           
        }

       
        public void SetDataSource(List<OptionTradingData> list)
        {
            grdUnlOptions.InvokeIfRequired(() =>
                {
                    optionTradingDataBindingSource.DataSource = list;
                    optionTradingDataBindingSource.ResetBindings(false);
                    gridViewUnlOptions.ViewCaption = list[0].Symbol;
                }
            );
        }

        private void UNLOptionsControl_Load(object sender, EventArgs e)
        {
            gridViewUnlOptions.ExpandAllGroups();

            if (ParentForm == null) return;

            ParentForm.TopMost = true;
            ParentForm.Height = 300 + optionTradingDataBindingSource.Count * gridViewUnlOptions.RowHeight;
        }


    }
}
