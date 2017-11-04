using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
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
            gridViewUnlOptions.BestFitColumns();
            if (ParentForm == null) return;

            ParentForm.TopMost = true;
            ParentForm.Height = 300 + optionTradingDataBindingSource.Count * gridViewUnlOptions.RowHeight;
        }

        private void gridViewUnlOptions_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var view = sender as GridView;
            if ((view == null) || (e.RowHandle < 0)) return;


            try
            {
                bool isCellValueNegative;
                switch (e.Column.FieldName)
                {
                    case "IVChange":
                        isCellValueNegative = Convert.ToDouble(e.CellValue) < 0;
                        e.Appearance.ForeColor = isCellValueNegative ? Color.Green : Color.Red;
                        return;
                    case "PNL":
                        isCellValueNegative = Convert.ToDouble(e.CellValue) < 0;
                        e.Appearance.ForeColor = isCellValueNegative ? Color.Red : Color.Green;
                        return;
                    //case "OptionContract.Strike":
                    //case "OffsetUnl":
                    //    var pData = (OptionsPositionData)grdViewPositionData.GetRow(e.RowHandle);

                    //    bool bold = false;
                    //    if (pData.OptionData != null)
                    //        e.Appearance.ForeColor = GetCellColor(pData, out bold);

                    //    var font = e.Appearance.GetFont();
                    //    var style = FontStyle.Bold + (bold ? (int)FontStyle.Underline : (int)FontStyle.Regular);
                    //    //style = font.Style + (int) FontStyle.Underline;
                    //    e.Appearance.Font = new Font(font.FontFamily, font.Size + 1, style);
                    //    return;
                }
            }
            catch (Exception ex)
            {
                //Logger.Error(ex.Message, ex);
            }
        }
    }
}
