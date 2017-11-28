using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using Infra.Extensions;
using TNS.API.ApiDataObjects;

namespace TNS.Controls
{
    public partial class TradingDataChartControl : UserControl
    {
        public TradingDataChartControl()
        {
            InitializeComponent();
        }

        public void SetDataSource(List<UnlTradingData> list, DateTime startWholeRange)
        {
            chartControl1.InvokeIfRequired(() =>
                {
                    //unlTradingDataBindingSource.DataSource = null;
                    unlTradingDataBindingSource.DataSource = list;
                    unlTradingDataBindingSource.ResetBindings(false);
                    //chartControl1.DataSource = unlTradingDataBindingSource;
                    //chartControl1.RefreshData();
                    //SetAxisXScale(startWholeRange);
                }

            );
        }

        public void SetAxisXScale(DateTime startWholeRange)
        {
            //DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            //Diagram xyDiagram1 = this.chartControl1.Diagram;
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = this.chartControl1.Diagram as DevExpress.XtraCharts.XYDiagram;

            if (xyDiagram1 == null) return;

            xyDiagram1.AxisX.VisualRange.Auto = false;
            xyDiagram1.AxisX.VisualRange.MaxValueSerializable = $"{DateTime.Now.AddHours(1):G}";// "11/17/2017 18:00:00.000";
            xyDiagram1.AxisX.VisualRange.MinValueSerializable = $"{DateTime.Today.AddHours(16):G}";// "11/17/2017 16:00:00.000";
            xyDiagram1.AxisX.WholeRange.Auto = false;
            xyDiagram1.AxisX.WholeRange.MaxValueSerializable = $"{DateTime.Now.AddHours(1):G}";
            xyDiagram1.AxisX.WholeRange.MinValueSerializable = $"{startWholeRange:G}";
            this.chartControl1.Titles[0].Text = "FB Trading Data";

        }
        private void TradingDataChartControl_Load(object sender, EventArgs e)
        {
            unlTradingDataBindingSource.ResetBindings(false);
            chartControl1.RefreshData();
        }
    }
}
