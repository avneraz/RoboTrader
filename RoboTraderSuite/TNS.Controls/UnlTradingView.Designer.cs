namespace TNS.Controls
{
    partial class UnlTradingView
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
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.unlTradingDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAPIDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSymbol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTradingState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeltaTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGammaTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThetaTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVegaTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarginTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIVWeightedAvg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVIX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnderlinePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarketValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPnLTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommisionTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastDayPnL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDailyPnL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaxAbsoluteDelta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMargin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.colShorts = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unlTradingDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.unlTradingDataBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(5, 63);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1200, 512);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // unlTradingDataBindingSource
            // 
            this.unlTradingDataBindingSource.DataSource = typeof(TNS.API.ApiDataObjects.UnlTradingData);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAPIDataType,
            this.colSymbol,
            this.colLastUpdate,
            this.colShorts,
            this.colTradingState,
            this.colDeltaTotal,
            this.colGammaTotal,
            this.colThetaTotal,
            this.colVegaTotal,
            this.colMarginTotal,
            this.colIVWeightedAvg,
            this.colVIX,
            this.colUnderlinePrice,
            this.colMarketValue,
            this.colCostTotal,
            this.colPnLTotal,
            this.colCommisionTotal,
            this.colLastDayPnL,
            this.colDailyPnL,
            this.colMaxAbsoluteDelta,
            this.colMargin});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colAPIDataType
            // 
            this.colAPIDataType.FieldName = "APIDataType";
            this.colAPIDataType.Name = "colAPIDataType";
            this.colAPIDataType.OptionsColumn.ReadOnly = true;
            // 
            // colSymbol
            // 
            this.colSymbol.FieldName = "Symbol";
            this.colSymbol.Name = "colSymbol";
            this.colSymbol.Visible = true;
            this.colSymbol.VisibleIndex = 0;
            this.colSymbol.Width = 61;
            // 
            // colLastUpdate
            // 
            this.colLastUpdate.DisplayFormat.FormatString = "G";
            this.colLastUpdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLastUpdate.FieldName = "LastUpdate";
            this.colLastUpdate.Name = "colLastUpdate";
            this.colLastUpdate.Visible = true;
            this.colLastUpdate.VisibleIndex = 19;
            this.colLastUpdate.Width = 121;
            // 
            // colTradingState
            // 
            this.colTradingState.Caption = "State";
            this.colTradingState.FieldName = "TradingState";
            this.colTradingState.Name = "colTradingState";
            this.colTradingState.Visible = true;
            this.colTradingState.VisibleIndex = 1;
            this.colTradingState.Width = 73;
            // 
            // colDeltaTotal
            // 
            this.colDeltaTotal.Caption = "Σ δ";
            this.colDeltaTotal.DisplayFormat.FormatString = "#0";
            this.colDeltaTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDeltaTotal.FieldName = "DeltaTotal";
            this.colDeltaTotal.Name = "colDeltaTotal";
            this.colDeltaTotal.Visible = true;
            this.colDeltaTotal.VisibleIndex = 6;
            this.colDeltaTotal.Width = 56;
            // 
            // colGammaTotal
            // 
            this.colGammaTotal.Caption = "Σ γ";
            this.colGammaTotal.DisplayFormat.FormatString = "#0";
            this.colGammaTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGammaTotal.FieldName = "GammaTotal";
            this.colGammaTotal.Name = "colGammaTotal";
            this.colGammaTotal.Visible = true;
            this.colGammaTotal.VisibleIndex = 7;
            this.colGammaTotal.Width = 49;
            // 
            // colThetaTotal
            // 
            this.colThetaTotal.Caption = "Σ Θ";
            this.colThetaTotal.DisplayFormat.FormatString = "#0";
            this.colThetaTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThetaTotal.FieldName = "ThetaTotal";
            this.colThetaTotal.Name = "colThetaTotal";
            this.colThetaTotal.Visible = true;
            this.colThetaTotal.VisibleIndex = 8;
            this.colThetaTotal.Width = 49;
            // 
            // colVegaTotal
            // 
            this.colVegaTotal.Caption = "Σ V";
            this.colVegaTotal.DisplayFormat.FormatString = "#0";
            this.colVegaTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVegaTotal.FieldName = "VegaTotal";
            this.colVegaTotal.Name = "colVegaTotal";
            this.colVegaTotal.Visible = true;
            this.colVegaTotal.VisibleIndex = 9;
            this.colVegaTotal.Width = 49;
            // 
            // colMarginTotal
            // 
            this.colMarginTotal.Caption = "Margin Max ";
            this.colMarginTotal.DisplayFormat.FormatString = "#,##0";
            this.colMarginTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMarginTotal.FieldName = "MaxAllowedMargin";
            this.colMarginTotal.Name = "colMarginTotal";
            this.colMarginTotal.Visible = true;
            this.colMarginTotal.VisibleIndex = 2;
            this.colMarginTotal.Width = 72;
            // 
            // colIVWeightedAvg
            // 
            this.colIVWeightedAvg.Caption = "IV W Avg";
            this.colIVWeightedAvg.DisplayFormat.FormatString = "#0.00%";
            this.colIVWeightedAvg.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIVWeightedAvg.FieldName = "IVWeightedAvg";
            this.colIVWeightedAvg.Name = "colIVWeightedAvg";
            this.colIVWeightedAvg.Visible = true;
            this.colIVWeightedAvg.VisibleIndex = 10;
            this.colIVWeightedAvg.Width = 54;
            // 
            // colVIX
            // 
            this.colVIX.DisplayFormat.FormatString = "#0.00";
            this.colVIX.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVIX.FieldName = "VIX";
            this.colVIX.Name = "colVIX";
            this.colVIX.Visible = true;
            this.colVIX.VisibleIndex = 11;
            this.colVIX.Width = 48;
            // 
            // colUnderlinePrice
            // 
            this.colUnderlinePrice.Caption = "Unl. P";
            this.colUnderlinePrice.DisplayFormat.FormatString = "#0.00";
            this.colUnderlinePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnderlinePrice.FieldName = "UnderlinePrice";
            this.colUnderlinePrice.Name = "colUnderlinePrice";
            this.colUnderlinePrice.Visible = true;
            this.colUnderlinePrice.VisibleIndex = 12;
            this.colUnderlinePrice.Width = 48;
            // 
            // colMarketValue
            // 
            this.colMarketValue.Caption = "Market";
            this.colMarketValue.DisplayFormat.FormatString = "#,##0";
            this.colMarketValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMarketValue.FieldName = "MarketValue";
            this.colMarketValue.Name = "colMarketValue";
            this.colMarketValue.Visible = true;
            this.colMarketValue.VisibleIndex = 13;
            this.colMarketValue.Width = 48;
            // 
            // colCostTotal
            // 
            this.colCostTotal.Caption = "Cost";
            this.colCostTotal.DisplayFormat.FormatString = "#,##0";
            this.colCostTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCostTotal.FieldName = "CostTotal";
            this.colCostTotal.Name = "colCostTotal";
            this.colCostTotal.Visible = true;
            this.colCostTotal.VisibleIndex = 14;
            this.colCostTotal.Width = 48;
            // 
            // colPnLTotal
            // 
            this.colPnLTotal.Caption = "PnL";
            this.colPnLTotal.DisplayFormat.FormatString = "#,##0";
            this.colPnLTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPnLTotal.FieldName = "PnLTotal";
            this.colPnLTotal.Name = "colPnLTotal";
            this.colPnLTotal.OptionsColumn.ReadOnly = true;
            this.colPnLTotal.Visible = true;
            this.colPnLTotal.VisibleIndex = 15;
            this.colPnLTotal.Width = 48;
            // 
            // colCommisionTotal
            // 
            this.colCommisionTotal.Caption = "Commision";
            this.colCommisionTotal.FieldName = "CommisionTotal";
            this.colCommisionTotal.Name = "colCommisionTotal";
            this.colCommisionTotal.Visible = true;
            this.colCommisionTotal.VisibleIndex = 16;
            this.colCommisionTotal.Width = 62;
            // 
            // colLastDayPnL
            // 
            this.colLastDayPnL.Caption = "Prr PnL";
            this.colLastDayPnL.DisplayFormat.FormatString = "#,##0";
            this.colLastDayPnL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLastDayPnL.FieldName = "LastDayPnL";
            this.colLastDayPnL.Name = "colLastDayPnL";
            this.colLastDayPnL.Visible = true;
            this.colLastDayPnL.VisibleIndex = 17;
            this.colLastDayPnL.Width = 45;
            // 
            // colDailyPnL
            // 
            this.colDailyPnL.Caption = "Daily PnL";
            this.colDailyPnL.DisplayFormat.FormatString = "#,##0";
            this.colDailyPnL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDailyPnL.FieldName = "DailyPnL";
            this.colDailyPnL.Name = "colDailyPnL";
            this.colDailyPnL.OptionsColumn.ReadOnly = true;
            this.colDailyPnL.Visible = true;
            this.colDailyPnL.VisibleIndex = 18;
            this.colDailyPnL.Width = 58;
            // 
            // colMaxAbsoluteDelta
            // 
            this.colMaxAbsoluteDelta.Caption = "Max |δ|";
            this.colMaxAbsoluteDelta.FieldName = "MaxAbsoluteDelta";
            this.colMaxAbsoluteDelta.Name = "colMaxAbsoluteDelta";
            this.colMaxAbsoluteDelta.OptionsColumn.ReadOnly = true;
            this.colMaxAbsoluteDelta.Visible = true;
            this.colMaxAbsoluteDelta.VisibleIndex = 5;
            this.colMaxAbsoluteDelta.Width = 61;
            // 
            // colMargin
            // 
            this.colMargin.Caption = "Margin";
            this.colMargin.DisplayFormat.FormatString = "#,##0";
            this.colMargin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMargin.FieldName = "Margin";
            this.colMargin.Name = "colMargin";
            this.colMargin.Visible = true;
            this.colMargin.VisibleIndex = 4;
            this.colMargin.Width = 49;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(5, 20);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(94, 25);
            this.btnLoadData.TabIndex = 1;
            this.btnLoadData.Text = "Start Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // colShorts
            // 
            this.colShorts.Caption = "Shorts #";
            this.colShorts.FieldName = "Shorts";
            this.colShorts.Name = "colShorts";
            this.colShorts.Visible = true;
            this.colShorts.VisibleIndex = 3;
            // 
            // UnlTradingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.gridControl1);
            this.Name = "UnlTradingView";
            this.Size = new System.Drawing.Size(1210, 580);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unlTradingDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.BindingSource unlTradingDataBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colAPIDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colSymbol;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colTradingState;
        private DevExpress.XtraGrid.Columns.GridColumn colDeltaTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colGammaTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colThetaTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colVegaTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colMarginTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colIVWeightedAvg;
        private DevExpress.XtraGrid.Columns.GridColumn colVIX;
        private DevExpress.XtraGrid.Columns.GridColumn colUnderlinePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colMarketValue;
        private DevExpress.XtraGrid.Columns.GridColumn colCostTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colPnLTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colCommisionTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colLastDayPnL;
        private DevExpress.XtraGrid.Columns.GridColumn colDailyPnL;
        private DevExpress.XtraGrid.Columns.GridColumn colMaxAbsoluteDelta;
        private DevExpress.XtraGrid.Columns.GridColumn colMargin;
        private DevExpress.XtraGrid.Columns.GridColumn colShorts;
    }
}
