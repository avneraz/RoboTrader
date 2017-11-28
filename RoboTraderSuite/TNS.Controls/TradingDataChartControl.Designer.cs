namespace TNS.Controls
{
    partial class TradingDataChartControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY1 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView3 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView4 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.unlTradingDataBindingSource = new System.Windows.Forms.BindingSource();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDailyPnL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeltaTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIVWeightedAvg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarketValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImVolOnCallATM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImVolOnPutATM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.unlTradingDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // unlTradingDataBindingSource
            // 
            this.unlTradingDataBindingSource.DataSource = typeof(TNS.API.ApiDataObjects.UnlTradingData);
            // 
            // chartControl1
            // 
            this.chartControl1.DataBindings = null;
            this.chartControl1.DataSource = this.unlTradingDataBindingSource;
            xyDiagram1.AxisX.AutoScaleBreaks.Enabled = true;
            xyDiagram1.AxisX.DateTimeScaleOptions.AggregateFunction = DevExpress.XtraCharts.AggregateFunction.None;
            xyDiagram1.AxisX.DateTimeScaleOptions.MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Minute;
            xyDiagram1.AxisX.GridLines.Color = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(187)))), ((int)(((byte)(89)))));
            xyDiagram1.AxisX.GridLines.MinorColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            xyDiagram1.AxisX.GridLines.MinorVisible = true;
            xyDiagram1.AxisX.GridLines.Visible = true;
            xyDiagram1.AxisX.MinorCount = 10;
            xyDiagram1.AxisX.StickToEnd = true;
            xyDiagram1.AxisX.Title.Text = "Last Update";
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.EnableAxisXScrolling = true;
            xyDiagram1.EnableAxisXZooming = true;
            xyDiagram1.EnableAxisYScrolling = true;
            xyDiagram1.EnableAxisYZooming = true;
            secondaryAxisY1.AxisID = 0;
            secondaryAxisY1.Name = "Secondary AxisY 1";
            secondaryAxisY1.Visibility = DevExpress.Utils.DefaultBoolean.True;
            secondaryAxisY1.VisibleInPanesSerializable = "-1";
            secondaryAxisY1.WholeRange.Auto = false;
            secondaryAxisY1.WholeRange.MaxValueSerializable = "1";
            secondaryAxisY1.WholeRange.MinValueSerializable = "0";
            xyDiagram1.SecondaryAxesY.AddRange(new DevExpress.XtraCharts.SecondaryAxisY[] {
            secondaryAxisY1});
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            series1.ArgumentDataMember = "LastUpdate";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
            series1.DataSource = this.unlTradingDataBindingSource;
            series1.Name = "Price";
            series1.ValueDataMembersSerializable = "LastPrice";
            series1.View = lineSeriesView1;
            series2.ArgumentDataMember = "LastUpdate";
            series2.Name = "PnL";
            series2.ValueDataMembersSerializable = "PnLTotal";
            series2.View = lineSeriesView2;
            series3.ArgumentDataMember = "LastUpdate";
            series3.Name = "Call IV";
            series3.ValueDataMembersSerializable = "ImVolOnCallATM";
            lineSeriesView3.AxisYName = "Secondary AxisY 1";
            series3.View = lineSeriesView3;
            series4.ArgumentDataMember = "LastUpdate";
            series4.Name = "Put IV";
            series4.ValueDataMembersSerializable = "ImVolOnPutATM";
            lineSeriesView4.AxisYName = "Secondary AxisY 1";
            series4.View = lineSeriesView4;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2,
        series3,
        series4};
            this.chartControl1.Size = new System.Drawing.Size(656, 299);
            this.chartControl1.TabIndex = 0;
            chartTitle1.Text = "FB Trading Data";
            this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.unlTradingDataBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(656, 243);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colLastUpdate,
            this.colLastPrice,
            this.colDailyPnL,
            this.colCostTotal,
            this.colDeltaTotal,
            this.colMarketValue,
            this.colIVWeightedAvg,
            this.colImVolOnCallATM,
            this.colImVolOnPutATM});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.ReadOnly = true;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 70;
            // 
            // colDailyPnL
            // 
            this.colDailyPnL.DisplayFormat.FormatString = "#,###";
            this.colDailyPnL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDailyPnL.FieldName = "DailyPnL";
            this.colDailyPnL.Name = "colDailyPnL";
            this.colDailyPnL.Visible = true;
            this.colDailyPnL.VisibleIndex = 3;
            this.colDailyPnL.Width = 47;
            // 
            // colLastUpdate
            // 
            this.colLastUpdate.DisplayFormat.FormatString = "G";
            this.colLastUpdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLastUpdate.FieldName = "LastUpdate";
            this.colLastUpdate.Name = "colLastUpdate";
            this.colLastUpdate.Visible = true;
            this.colLastUpdate.VisibleIndex = 1;
            this.colLastUpdate.Width = 92;
            // 
            // colLastPrice
            // 
            this.colLastPrice.DisplayFormat.FormatString = "#,###.00";
            this.colLastPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLastPrice.FieldName = "LastPrice";
            this.colLastPrice.Name = "colLastPrice";
            this.colLastPrice.Visible = true;
            this.colLastPrice.VisibleIndex = 2;
            this.colLastPrice.Width = 79;
            // 
            // colCostTotal
            // 
            this.colCostTotal.DisplayFormat.FormatString = "#,###";
            this.colCostTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCostTotal.FieldName = "CostTotal";
            this.colCostTotal.Name = "colCostTotal";
            this.colCostTotal.Visible = true;
            this.colCostTotal.VisibleIndex = 4;
            this.colCostTotal.Width = 54;
            // 
            // colDeltaTotal
            // 
            this.colDeltaTotal.DisplayFormat.FormatString = "#,###";
            this.colDeltaTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDeltaTotal.FieldName = "DeltaTotal";
            this.colDeltaTotal.Name = "colDeltaTotal";
            this.colDeltaTotal.Visible = true;
            this.colDeltaTotal.VisibleIndex = 5;
            this.colDeltaTotal.Width = 54;
            // 
            // colIVWeightedAvg
            // 
            this.colIVWeightedAvg.DisplayFormat.FormatString = "#0.00%";
            this.colIVWeightedAvg.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIVWeightedAvg.FieldName = "IVWeightedAvg";
            this.colIVWeightedAvg.Name = "colIVWeightedAvg";
            this.colIVWeightedAvg.Visible = true;
            this.colIVWeightedAvg.VisibleIndex = 7;
            this.colIVWeightedAvg.Width = 54;
            // 
            // colMarketValue
            // 
            this.colMarketValue.DisplayFormat.FormatString = "#,###";
            this.colMarketValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMarketValue.FieldName = "MarketValue";
            this.colMarketValue.Name = "colMarketValue";
            this.colMarketValue.Visible = true;
            this.colMarketValue.VisibleIndex = 6;
            this.colMarketValue.Width = 54;
            // 
            // colImVolOnCallATM
            // 
            this.colImVolOnCallATM.DisplayFormat.FormatString = "#0.00%";
            this.colImVolOnCallATM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImVolOnCallATM.FieldName = "ImVolOnCallATM";
            this.colImVolOnCallATM.Name = "colImVolOnCallATM";
            this.colImVolOnCallATM.Visible = true;
            this.colImVolOnCallATM.VisibleIndex = 8;
            this.colImVolOnCallATM.Width = 54;
            // 
            // colImVolOnPutATM
            // 
            this.colImVolOnPutATM.DisplayFormat.FormatString = "#0.00%";
            this.colImVolOnPutATM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImVolOnPutATM.FieldName = "ImVolOnPutATM";
            this.colImVolOnPutATM.Name = "colImVolOnPutATM";
            this.colImVolOnPutATM.Visible = true;
            this.colImVolOnPutATM.VisibleIndex = 9;
            this.colImVolOnPutATM.Width = 67;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chartControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(656, 546);
            this.splitContainer1.SplitterDistance = 299;
            this.splitContainer1.TabIndex = 2;
            // 
            // TradingDataChartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TradingDataChartControl";
            this.Size = new System.Drawing.Size(656, 546);
            this.Load += new System.EventHandler(this.TradingDataChartControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.unlTradingDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource unlTradingDataBindingSource;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colDailyPnL;
        private DevExpress.XtraGrid.Columns.GridColumn colCostTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colDeltaTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colMarketValue;
        private DevExpress.XtraGrid.Columns.GridColumn colIVWeightedAvg;
        private DevExpress.XtraGrid.Columns.GridColumn colImVolOnCallATM;
        private DevExpress.XtraGrid.Columns.GridColumn colImVolOnPutATM;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
