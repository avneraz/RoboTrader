namespace TNS.Controls
{
    partial class UNLOptionsControl
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
            this.grdUnlOptions = new DevExpress.XtraGrid.GridControl();
            this.optionTradingDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewUnlOptions = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOptionType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrike = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIvOnSell = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentIV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIVChange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSellPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPNL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeltaChange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThetaChange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGammaChange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVegaChange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiffDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSellDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnlID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnlOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionTradingDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUnlOptions)).BeginInit();
            this.SuspendLayout();
            // 
            // grdUnlOptions
            // 
            this.grdUnlOptions.DataSource = this.optionTradingDataBindingSource;
            this.grdUnlOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUnlOptions.Location = new System.Drawing.Point(0, 0);
            this.grdUnlOptions.MainView = this.gridViewUnlOptions;
            this.grdUnlOptions.Name = "grdUnlOptions";
            this.grdUnlOptions.Size = new System.Drawing.Size(979, 549);
            this.grdUnlOptions.TabIndex = 0;
            this.grdUnlOptions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewUnlOptions});
            // 
            // optionTradingDataBindingSource
            // 
            this.optionTradingDataBindingSource.DataSource = typeof(TNS.API.ApiDataObjects.OptionTradingData);
            // 
            // gridViewUnlOptions
            // 
            this.gridViewUnlOptions.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOptionType,
            this.colStrike,
            this.colUnlID,
            this.colIvOnSell,
            this.colCurrentIV,
            this.colIVChange,
            this.colCurrentPrice,
            this.colSellPrice,
            this.colPNL,
            this.colDeltaChange,
            this.colThetaChange,
            this.colGammaChange,
            this.colVegaChange,
            this.colDiffDays,
            this.colSellDateTime});
            this.gridViewUnlOptions.GridControl = this.grdUnlOptions;
            this.gridViewUnlOptions.GroupCount = 2;
            this.gridViewUnlOptions.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PNL", null, "(PNL: SUM={0:#,###.0})")});
            this.gridViewUnlOptions.Name = "gridViewUnlOptions";
            this.gridViewUnlOptions.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewUnlOptions.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewUnlOptions.OptionsBehavior.Editable = false;
            this.gridViewUnlOptions.OptionsBehavior.ReadOnly = true;
            this.gridViewUnlOptions.OptionsView.ShowViewCaption = true;
            this.gridViewUnlOptions.RowHeight = 25;
            this.gridViewUnlOptions.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colOptionType, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colStrike, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPNL, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colIvOnSell, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gridViewUnlOptions.ViewCaptionHeight = 30;
            this.gridViewUnlOptions.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewUnlOptions_RowCellStyle);
            // 
            // colOptionType
            // 
            this.colOptionType.Caption = "Type";
            this.colOptionType.FieldName = "OptionType";
            this.colOptionType.Name = "colOptionType";
            this.colOptionType.Visible = true;
            this.colOptionType.VisibleIndex = 0;
            this.colOptionType.Width = 51;
            // 
            // colStrike
            // 
            this.colStrike.Caption = "Strike";
            this.colStrike.DisplayFormat.FormatString = "#.0";
            this.colStrike.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStrike.FieldName = "Strike";
            this.colStrike.Name = "colStrike";
            this.colStrike.Visible = true;
            this.colStrike.VisibleIndex = 0;
            this.colStrike.Width = 54;
            // 
            // colIvOnSell
            // 
            this.colIvOnSell.Caption = "IvOnSell";
            this.colIvOnSell.DisplayFormat.FormatString = "#0.00%";
            this.colIvOnSell.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIvOnSell.FieldName = "IvOnSell";
            this.colIvOnSell.Name = "colIvOnSell";
            this.colIvOnSell.Visible = true;
            this.colIvOnSell.VisibleIndex = 4;
            this.colIvOnSell.Width = 56;
            // 
            // colCurrentIV
            // 
            this.colCurrentIV.Caption = "IV";
            this.colCurrentIV.DisplayFormat.FormatString = "#0.00%";
            this.colCurrentIV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCurrentIV.FieldName = "CurrentIV";
            this.colCurrentIV.Name = "colCurrentIV";
            this.colCurrentIV.Visible = true;
            this.colCurrentIV.VisibleIndex = 5;
            this.colCurrentIV.Width = 37;
            // 
            // colIVChange
            // 
            this.colIVChange.DisplayFormat.FormatString = "#0.00%";
            this.colIVChange.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIVChange.FieldName = "IVChange";
            this.colIVChange.Name = "colIVChange";
            this.colIVChange.OptionsColumn.ReadOnly = true;
            this.colIVChange.Visible = true;
            this.colIVChange.VisibleIndex = 6;
            this.colIVChange.Width = 58;
            // 
            // colCurrentPrice
            // 
            this.colCurrentPrice.DisplayFormat.FormatString = "#.00";
            this.colCurrentPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCurrentPrice.FieldName = "CurrentPrice";
            this.colCurrentPrice.Name = "colCurrentPrice";
            this.colCurrentPrice.OptionsColumn.ReadOnly = true;
            this.colCurrentPrice.Visible = true;
            this.colCurrentPrice.VisibleIndex = 1;
            this.colCurrentPrice.Width = 80;
            // 
            // colSellPrice
            // 
            this.colSellPrice.DisplayFormat.FormatString = "#.00";
            this.colSellPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSellPrice.FieldName = "SellPrice";
            this.colSellPrice.Name = "colSellPrice";
            this.colSellPrice.OptionsColumn.ReadOnly = true;
            this.colSellPrice.Visible = true;
            this.colSellPrice.VisibleIndex = 2;
            this.colSellPrice.Width = 67;
            // 
            // colPNL
            // 
            this.colPNL.DisplayFormat.FormatString = "#,###.0";
            this.colPNL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPNL.FieldName = "PNL";
            this.colPNL.Name = "colPNL";
            this.colPNL.OptionsColumn.ReadOnly = true;
            this.colPNL.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PNL", "SUM={0:#,###.0}")});
            this.colPNL.Visible = true;
            this.colPNL.VisibleIndex = 7;
            this.colPNL.Width = 58;
            // 
            // colDeltaChange
            // 
            this.colDeltaChange.Caption = "δ Change";
            this.colDeltaChange.DisplayFormat.FormatString = "#.000";
            this.colDeltaChange.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDeltaChange.FieldName = "DeltaChange";
            this.colDeltaChange.Name = "colDeltaChange";
            this.colDeltaChange.OptionsColumn.ReadOnly = true;
            this.colDeltaChange.Visible = true;
            this.colDeltaChange.VisibleIndex = 8;
            this.colDeltaChange.Width = 63;
            // 
            // colThetaChange
            // 
            this.colThetaChange.Caption = "Θ Change";
            this.colThetaChange.DisplayFormat.FormatString = "#.000";
            this.colThetaChange.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThetaChange.FieldName = "ThetaChange";
            this.colThetaChange.Name = "colThetaChange";
            this.colThetaChange.OptionsColumn.ReadOnly = true;
            this.colThetaChange.Visible = true;
            this.colThetaChange.VisibleIndex = 9;
            this.colThetaChange.Width = 41;
            // 
            // colGammaChange
            // 
            this.colGammaChange.Caption = "γ Change";
            this.colGammaChange.DisplayFormat.FormatString = "#.000";
            this.colGammaChange.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGammaChange.FieldName = "GammaChange";
            this.colGammaChange.Name = "colGammaChange";
            this.colGammaChange.OptionsColumn.ReadOnly = true;
            this.colGammaChange.Visible = true;
            this.colGammaChange.VisibleIndex = 10;
            this.colGammaChange.Width = 69;
            // 
            // colVegaChange
            // 
            this.colVegaChange.Caption = "V Change";
            this.colVegaChange.DisplayFormat.FormatString = "#.000";
            this.colVegaChange.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVegaChange.FieldName = "VegaChange";
            this.colVegaChange.Name = "colVegaChange";
            this.colVegaChange.OptionsColumn.ReadOnly = true;
            this.colVegaChange.Visible = true;
            this.colVegaChange.VisibleIndex = 11;
            this.colVegaChange.Width = 65;
            // 
            // colDiffDays
            // 
            this.colDiffDays.FieldName = "DiffDays";
            this.colDiffDays.Name = "colDiffDays";
            this.colDiffDays.OptionsColumn.ReadOnly = true;
            this.colDiffDays.Visible = true;
            this.colDiffDays.VisibleIndex = 12;
            this.colDiffDays.Width = 63;
            // 
            // colSellDateTime
            // 
            this.colSellDateTime.Caption = "Sell D/T";
            this.colSellDateTime.DisplayFormat.FormatString = "g";
            this.colSellDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colSellDateTime.FieldName = "SellDateTime";
            this.colSellDateTime.Name = "colSellDateTime";
            this.colSellDateTime.Visible = true;
            this.colSellDateTime.VisibleIndex = 3;
            this.colSellDateTime.Width = 86;
            // 
            // colUnlID
            // 
            this.colUnlID.FieldName = "UnlID";
            this.colUnlID.Name = "colUnlID";
            this.colUnlID.Visible = true;
            this.colUnlID.VisibleIndex = 0;
            this.colUnlID.Width = 62;
            // 
            // UNLOptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdUnlOptions);
            this.Name = "UNLOptionsControl";
            this.Size = new System.Drawing.Size(979, 549);
            this.Load += new System.EventHandler(this.UNLOptionsControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdUnlOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionTradingDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUnlOptions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdUnlOptions;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUnlOptions;
        private System.Windows.Forms.BindingSource optionTradingDataBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colSellPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPNL;
        private DevExpress.XtraGrid.Columns.GridColumn colIVChange;
        private DevExpress.XtraGrid.Columns.GridColumn colDeltaChange;
        private DevExpress.XtraGrid.Columns.GridColumn colThetaChange;
        private DevExpress.XtraGrid.Columns.GridColumn colGammaChange;
        private DevExpress.XtraGrid.Columns.GridColumn colVegaChange;
        private DevExpress.XtraGrid.Columns.GridColumn colDiffDays;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionType;
        private DevExpress.XtraGrid.Columns.GridColumn colStrike;
        private DevExpress.XtraGrid.Columns.GridColumn colIvOnSell;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentIV;
        private DevExpress.XtraGrid.Columns.GridColumn colSellDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colUnlID;
    }
}
