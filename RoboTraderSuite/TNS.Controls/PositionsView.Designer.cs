namespace TNS.Controls
{
    partial class PositionsView
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
            this.grdPositionData = new DevExpress.XtraGrid.GridControl();
            this.optionsPositionDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpiry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptionContract_OptionType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCalculatedOptionPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAverageCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrike = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMultiplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExchange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocalSymbol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBidPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAskPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptionDelta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContract_ExpiryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptionData_OptionType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeltaTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarketValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPNL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGammaTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptionData_ModelPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptionData_UnderlinePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThetaTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVegaTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptionData_Gamma = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptionData_ImpliedVolatility = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContract_Symbol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAvgPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChangeFromCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNetLiquidation = new System.Windows.Forms.Label();
            this.accountSummaryDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblMargin = new System.Windows.Forms.Label();
            this.grpAccountSummary = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPnL = new System.Windows.Forms.Label();
            this.grdUnLTradingData = new DevExpress.XtraGrid.GridControl();
            this.unlTradingDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewUnLTradingData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAPIDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSymbol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnlBid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnlAsk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnlChange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnlOpen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShorts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTradingState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeltaTotal2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGammaTotal2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThetaTotal2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVegaTotal2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarginTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIVWeightedAvg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVIX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnderlinePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPnLTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommisionTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastDayPnL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDailyPnL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaxAbsoluteDelta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMargin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdPositionData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsPositionDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountSummaryDataBindingSource)).BeginInit();
            this.grpAccountSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnLTradingData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unlTradingDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUnLTradingData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdPositionData
            // 
            this.grdPositionData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPositionData.DataSource = this.optionsPositionDataBindingSource;
            this.grdPositionData.Location = new System.Drawing.Point(0, 1);
            this.grdPositionData.MainView = this.gridView1;
            this.grdPositionData.Name = "grdPositionData";
            this.grdPositionData.Padding = new System.Windows.Forms.Padding(10);
            this.grdPositionData.Size = new System.Drawing.Size(1225, 330);
            this.grdPositionData.TabIndex = 1;
            this.grdPositionData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // optionsPositionDataBindingSource
            // 
            this.optionsPositionDataBindingSource.DataSource = typeof(TNS.API.ApiDataObjects.OptionsPositionData);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.GroupFooter.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.Red;
            this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Red;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
            this.gridView1.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.LightYellow;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDescription,
            this.colExpiry,
            this.colOptionContract_OptionType,
            this.colPosition,
            this.colCalculatedOptionPrice,
            this.colAverageCost,
            this.colConId,
            this.colStrike,
            this.colMultiplier,
            this.colExchange,
            this.colCurrency,
            this.colLocalSymbol,
            this.colBidPrice,
            this.colAskPrice,
            this.colOptionDelta,
            this.colContract_ExpiryDate,
            this.colOptionData_OptionType,
            this.colDeltaTotal,
            this.colTotalCost,
            this.colLastPrice,
            this.colMarketValue,
            this.colPNL,
            this.colGammaTotal,
            this.colOptionData_ModelPrice,
            this.colOptionData_UnderlinePrice,
            this.colThetaTotal,
            this.colVegaTotal,
            this.colOptionData_Gamma,
            this.colOptionData_ImpliedVolatility,
            this.colContract_Symbol,
            this.colAvgPrice,
            this.colChangeFromCost});
            this.gridView1.GridControl = this.grdPositionData;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PnL", this.colPNL, "{0:#,##0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCost", this.colTotalCost, "{0:#,##0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MarketValue", this.colMarketValue, "{0:#,##0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DeltaTotal", this.colDeltaTotal, "{0:#,##0.0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GammaTotal", this.colGammaTotal, "{0:#,##0.0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThetaTotal", this.colThetaTotal, "{0:#,##0.0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VegaTotal", this.colVegaTotal, "{0:#,##0.0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Position", this.colPosition, "{0:#,##0}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.RowHeight = 22;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDescription, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colOptionContract_OptionType, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colStrike, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Symbol";
            this.colDescription.MaxWidth = 120;
            this.colDescription.MinWidth = 50;
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 0;
            this.colDescription.Width = 100;
            // 
            // colExpiry
            // 
            this.colExpiry.Caption = "Expiry";
            this.colExpiry.DisplayFormat.FormatString = "dd-MMM-yyyy";
            this.colExpiry.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colExpiry.FieldName = "Expiry";
            this.colExpiry.MaxWidth = 140;
            this.colExpiry.MinWidth = 70;
            this.colExpiry.Name = "colExpiry";
            this.colExpiry.Visible = true;
            this.colExpiry.VisibleIndex = 0;
            this.colExpiry.Width = 91;
            // 
            // colOptionContract_OptionType
            // 
            this.colOptionContract_OptionType.Caption = "C/P";
            this.colOptionContract_OptionType.FieldName = "OptionContract.OptionType";
            this.colOptionContract_OptionType.MaxWidth = 100;
            this.colOptionContract_OptionType.MinWidth = 35;
            this.colOptionContract_OptionType.Name = "colOptionContract_OptionType";
            this.colOptionContract_OptionType.Visible = true;
            this.colOptionContract_OptionType.VisibleIndex = 1;
            this.colOptionContract_OptionType.Width = 40;
            // 
            // colPosition
            // 
            this.colPosition.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon;
            this.colPosition.AppearanceCell.Options.UseBackColor = true;
            this.colPosition.AppearanceHeader.BackColor = System.Drawing.Color.LemonChiffon;
            this.colPosition.AppearanceHeader.Options.UseBackColor = true;
            this.colPosition.Caption = "Pos #";
            this.colPosition.FieldName = "Position";
            this.colPosition.MaxWidth = 100;
            this.colPosition.MinWidth = 36;
            this.colPosition.Name = "colPosition";
            this.colPosition.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Position", "{0:#,##0}")});
            this.colPosition.Visible = true;
            this.colPosition.VisibleIndex = 3;
            this.colPosition.Width = 36;
            // 
            // colCalculatedOptionPrice
            // 
            this.colCalculatedOptionPrice.Caption = "Calc. Price";
            this.colCalculatedOptionPrice.DisplayFormat.FormatString = "#,##0.00";
            this.colCalculatedOptionPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCalculatedOptionPrice.FieldName = "CalculatedOptionPrice";
            this.colCalculatedOptionPrice.Name = "colCalculatedOptionPrice";
            this.colCalculatedOptionPrice.Visible = true;
            this.colCalculatedOptionPrice.VisibleIndex = 8;
            // 
            // colAverageCost
            // 
            this.colAverageCost.AppearanceCell.ForeColor = System.Drawing.Color.MediumOrchid;
            this.colAverageCost.AppearanceCell.Options.UseForeColor = true;
            this.colAverageCost.AppearanceHeader.ForeColor = System.Drawing.Color.MediumOrchid;
            this.colAverageCost.AppearanceHeader.Options.UseForeColor = true;
            this.colAverageCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAverageCost.FieldName = "AverageCost";
            this.colAverageCost.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAverageCost.Name = "colAverageCost";
            // 
            // colConId
            // 
            this.colConId.FieldName = "ConId";
            this.colConId.MaxWidth = 100;
            this.colConId.Name = "colConId";
            // 
            // colStrike
            // 
            this.colStrike.FieldName = "OptionContract.Strike";
            this.colStrike.MaxWidth = 60;
            this.colStrike.MinWidth = 50;
            this.colStrike.Name = "colStrike";
            this.colStrike.Visible = true;
            this.colStrike.VisibleIndex = 2;
            this.colStrike.Width = 54;
            // 
            // colMultiplier
            // 
            this.colMultiplier.FieldName = "Multiplier";
            this.colMultiplier.Name = "colMultiplier";
            // 
            // colExchange
            // 
            this.colExchange.FieldName = "Multiplier";
            this.colExchange.MaxWidth = 100;
            this.colExchange.Name = "colExchange";
            // 
            // colCurrency
            // 
            this.colCurrency.FieldName = "Currency";
            this.colCurrency.MaxWidth = 65;
            this.colCurrency.Name = "colCurrency";
            this.colCurrency.Width = 65;
            // 
            // colLocalSymbol
            // 
            this.colLocalSymbol.FieldName = "LocalSymbol";
            this.colLocalSymbol.MaxWidth = 100;
            this.colLocalSymbol.Name = "colLocalSymbol";
            // 
            // colBidPrice
            // 
            this.colBidPrice.AppearanceCell.BackColor = System.Drawing.Color.LightBlue;
            this.colBidPrice.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.colBidPrice.AppearanceCell.Options.UseBackColor = true;
            this.colBidPrice.AppearanceCell.Options.UseForeColor = true;
            this.colBidPrice.AppearanceHeader.BackColor = System.Drawing.Color.LightBlue;
            this.colBidPrice.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.colBidPrice.AppearanceHeader.Options.UseBackColor = true;
            this.colBidPrice.AppearanceHeader.Options.UseForeColor = true;
            this.colBidPrice.Caption = "Bid";
            this.colBidPrice.DisplayFormat.FormatString = "#,##0.000";
            this.colBidPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBidPrice.FieldName = "OptionData.BidPrice";
            this.colBidPrice.MaxWidth = 100;
            this.colBidPrice.MinWidth = 50;
            this.colBidPrice.Name = "colBidPrice";
            this.colBidPrice.Visible = true;
            this.colBidPrice.VisibleIndex = 10;
            this.colBidPrice.Width = 51;
            // 
            // colAskPrice
            // 
            this.colAskPrice.AppearanceCell.BackColor = System.Drawing.Color.LightBlue;
            this.colAskPrice.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.colAskPrice.AppearanceCell.Options.UseBackColor = true;
            this.colAskPrice.AppearanceCell.Options.UseForeColor = true;
            this.colAskPrice.AppearanceHeader.BackColor = System.Drawing.Color.LightBlue;
            this.colAskPrice.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
            this.colAskPrice.AppearanceHeader.Options.UseBackColor = true;
            this.colAskPrice.AppearanceHeader.Options.UseForeColor = true;
            this.colAskPrice.Caption = "Ask";
            this.colAskPrice.DisplayFormat.FormatString = "#,##0.000";
            this.colAskPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAskPrice.FieldName = "OptionData.AskPrice";
            this.colAskPrice.MaxWidth = 100;
            this.colAskPrice.MinWidth = 50;
            this.colAskPrice.Name = "colAskPrice";
            this.colAskPrice.Visible = true;
            this.colAskPrice.VisibleIndex = 11;
            this.colAskPrice.Width = 51;
            // 
            // colOptionDelta
            // 
            this.colOptionDelta.AppearanceCell.BackColor = System.Drawing.Color.AliceBlue;
            this.colOptionDelta.AppearanceCell.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colOptionDelta.AppearanceCell.Options.UseBackColor = true;
            this.colOptionDelta.AppearanceCell.Options.UseForeColor = true;
            this.colOptionDelta.AppearanceHeader.BackColor = System.Drawing.Color.AliceBlue;
            this.colOptionDelta.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.colOptionDelta.AppearanceHeader.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colOptionDelta.AppearanceHeader.Options.UseBackColor = true;
            this.colOptionDelta.AppearanceHeader.Options.UseFont = true;
            this.colOptionDelta.AppearanceHeader.Options.UseForeColor = true;
            this.colOptionDelta.Caption = " δ";
            this.colOptionDelta.DisplayFormat.FormatString = "#0.000";
            this.colOptionDelta.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOptionDelta.FieldName = "OptionData.Delta";
            this.colOptionDelta.MaxWidth = 70;
            this.colOptionDelta.Name = "colOptionDelta";
            this.colOptionDelta.Visible = true;
            this.colOptionDelta.VisibleIndex = 19;
            this.colOptionDelta.Width = 33;
            // 
            // colContract_ExpiryDate
            // 
            this.colContract_ExpiryDate.Caption = "Session";
            this.colContract_ExpiryDate.FieldName = "OptionData.Contract.ExpiryDate";
            this.colContract_ExpiryDate.MaxWidth = 100;
            this.colContract_ExpiryDate.Name = "colContract_ExpiryDate";
            this.colContract_ExpiryDate.Width = 90;
            // 
            // colOptionData_OptionType
            // 
            this.colOptionData_OptionType.FieldName = "OptionData.EOptionType";
            this.colOptionData_OptionType.MaxWidth = 50;
            this.colOptionData_OptionType.Name = "colOptionData_OptionType";
            this.colOptionData_OptionType.Width = 50;
            // 
            // colDeltaTotal
            // 
            this.colDeltaTotal.AppearanceCell.BackColor = System.Drawing.Color.LightCyan;
            this.colDeltaTotal.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDeltaTotal.AppearanceCell.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colDeltaTotal.AppearanceCell.Options.UseBackColor = true;
            this.colDeltaTotal.AppearanceCell.Options.UseFont = true;
            this.colDeltaTotal.AppearanceCell.Options.UseForeColor = true;
            this.colDeltaTotal.AppearanceHeader.BackColor = System.Drawing.Color.LightCyan;
            this.colDeltaTotal.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colDeltaTotal.AppearanceHeader.Options.UseBackColor = true;
            this.colDeltaTotal.AppearanceHeader.Options.UseForeColor = true;
            this.colDeltaTotal.Caption = "Σ δ";
            this.colDeltaTotal.DisplayFormat.FormatString = "#,##0.0";
            this.colDeltaTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDeltaTotal.FieldName = "DeltaTotal";
            this.colDeltaTotal.MaxWidth = 120;
            this.colDeltaTotal.MinWidth = 45;
            this.colDeltaTotal.Name = "colDeltaTotal";
            this.colDeltaTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DeltaTotal", "{0:#,##0}")});
            this.colDeltaTotal.Visible = true;
            this.colDeltaTotal.VisibleIndex = 15;
            this.colDeltaTotal.Width = 45;
            // 
            // colTotalCost
            // 
            this.colTotalCost.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon;
            this.colTotalCost.AppearanceCell.ForeColor = System.Drawing.Color.Magenta;
            this.colTotalCost.AppearanceCell.Options.UseBackColor = true;
            this.colTotalCost.AppearanceCell.Options.UseForeColor = true;
            this.colTotalCost.AppearanceHeader.BackColor = System.Drawing.Color.LemonChiffon;
            this.colTotalCost.AppearanceHeader.ForeColor = System.Drawing.Color.Magenta;
            this.colTotalCost.AppearanceHeader.Options.UseBackColor = true;
            this.colTotalCost.AppearanceHeader.Options.UseForeColor = true;
            this.colTotalCost.Caption = "Cost";
            this.colTotalCost.DisplayFormat.FormatString = "#,##0";
            this.colTotalCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalCost.FieldName = "TotalCost";
            this.colTotalCost.MaxWidth = 120;
            this.colTotalCost.MinWidth = 70;
            this.colTotalCost.Name = "colTotalCost";
            this.colTotalCost.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCost", "{0:#,##0}")});
            this.colTotalCost.Visible = true;
            this.colTotalCost.VisibleIndex = 4;
            this.colTotalCost.Width = 71;
            // 
            // colLastPrice
            // 
            this.colLastPrice.AppearanceCell.BackColor = System.Drawing.Color.LightBlue;
            this.colLastPrice.AppearanceCell.Options.UseBackColor = true;
            this.colLastPrice.AppearanceHeader.BackColor = System.Drawing.Color.LightBlue;
            this.colLastPrice.AppearanceHeader.Options.UseBackColor = true;
            this.colLastPrice.Caption = "Last P";
            this.colLastPrice.DisplayFormat.FormatString = "#,##0.000";
            this.colLastPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLastPrice.FieldName = "OptionData.LastPrice";
            this.colLastPrice.MaxWidth = 100;
            this.colLastPrice.MinWidth = 50;
            this.colLastPrice.Name = "colLastPrice";
            this.colLastPrice.Visible = true;
            this.colLastPrice.VisibleIndex = 13;
            this.colLastPrice.Width = 51;
            // 
            // colMarketValue
            // 
            this.colMarketValue.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon;
            this.colMarketValue.AppearanceCell.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.colMarketValue.AppearanceCell.Options.UseBackColor = true;
            this.colMarketValue.AppearanceCell.Options.UseForeColor = true;
            this.colMarketValue.AppearanceHeader.BackColor = System.Drawing.Color.LemonChiffon;
            this.colMarketValue.AppearanceHeader.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.colMarketValue.AppearanceHeader.Options.UseBackColor = true;
            this.colMarketValue.AppearanceHeader.Options.UseForeColor = true;
            this.colMarketValue.Caption = "Market Val.";
            this.colMarketValue.DisplayFormat.FormatString = "#,##0";
            this.colMarketValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMarketValue.FieldName = "MarketValue";
            this.colMarketValue.MaxWidth = 120;
            this.colMarketValue.MinWidth = 70;
            this.colMarketValue.Name = "colMarketValue";
            this.colMarketValue.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MarketValue", "{0:#,##0}")});
            this.colMarketValue.Visible = true;
            this.colMarketValue.VisibleIndex = 5;
            this.colMarketValue.Width = 71;
            // 
            // colPNL
            // 
            this.colPNL.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon;
            this.colPNL.AppearanceCell.ForeColor = System.Drawing.Color.DarkMagenta;
            this.colPNL.AppearanceCell.Options.UseBackColor = true;
            this.colPNL.AppearanceCell.Options.UseForeColor = true;
            this.colPNL.AppearanceHeader.BackColor = System.Drawing.Color.LemonChiffon;
            this.colPNL.AppearanceHeader.ForeColor = System.Drawing.Color.DarkMagenta;
            this.colPNL.AppearanceHeader.Options.UseBackColor = true;
            this.colPNL.AppearanceHeader.Options.UseForeColor = true;
            this.colPNL.Caption = "PnL";
            this.colPNL.DisplayFormat.FormatString = "#,##0";
            this.colPNL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPNL.FieldName = "PnL";
            this.colPNL.MaxWidth = 120;
            this.colPNL.MinWidth = 70;
            this.colPNL.Name = "colPNL";
            this.colPNL.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PnL", "{0:#,##0}")});
            this.colPNL.Visible = true;
            this.colPNL.VisibleIndex = 6;
            this.colPNL.Width = 71;
            // 
            // colGammaTotal
            // 
            this.colGammaTotal.AppearanceCell.BackColor = System.Drawing.Color.LightCyan;
            this.colGammaTotal.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colGammaTotal.AppearanceCell.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colGammaTotal.AppearanceCell.Options.UseBackColor = true;
            this.colGammaTotal.AppearanceCell.Options.UseFont = true;
            this.colGammaTotal.AppearanceCell.Options.UseForeColor = true;
            this.colGammaTotal.AppearanceHeader.BackColor = System.Drawing.Color.LightCyan;
            this.colGammaTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colGammaTotal.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.colGammaTotal.AppearanceHeader.Options.UseBackColor = true;
            this.colGammaTotal.AppearanceHeader.Options.UseFont = true;
            this.colGammaTotal.AppearanceHeader.Options.UseForeColor = true;
            this.colGammaTotal.Caption = "Σ γ";
            this.colGammaTotal.DisplayFormat.FormatString = "#,##0.0";
            this.colGammaTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGammaTotal.FieldName = "GammaTotal";
            this.colGammaTotal.MaxWidth = 120;
            this.colGammaTotal.MinWidth = 45;
            this.colGammaTotal.Name = "colGammaTotal";
            this.colGammaTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GammaTotal", "{0:#,##0}")});
            this.colGammaTotal.Visible = true;
            this.colGammaTotal.VisibleIndex = 16;
            this.colGammaTotal.Width = 45;
            // 
            // colOptionData_ModelPrice
            // 
            this.colOptionData_ModelPrice.AppearanceCell.BackColor = System.Drawing.Color.LightBlue;
            this.colOptionData_ModelPrice.AppearanceCell.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.colOptionData_ModelPrice.AppearanceCell.Options.UseBackColor = true;
            this.colOptionData_ModelPrice.AppearanceCell.Options.UseForeColor = true;
            this.colOptionData_ModelPrice.AppearanceHeader.BackColor = System.Drawing.Color.LightBlue;
            this.colOptionData_ModelPrice.AppearanceHeader.Options.UseBackColor = true;
            this.colOptionData_ModelPrice.Caption = "BnS P.";
            this.colOptionData_ModelPrice.DisplayFormat.FormatString = "#,##0.000";
            this.colOptionData_ModelPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOptionData_ModelPrice.FieldName = "OptionData.ModelPrice";
            this.colOptionData_ModelPrice.MaxWidth = 100;
            this.colOptionData_ModelPrice.MinWidth = 50;
            this.colOptionData_ModelPrice.Name = "colOptionData_ModelPrice";
            this.colOptionData_ModelPrice.Visible = true;
            this.colOptionData_ModelPrice.VisibleIndex = 12;
            this.colOptionData_ModelPrice.Width = 51;
            // 
            // colOptionData_UnderlinePrice
            // 
            this.colOptionData_UnderlinePrice.FieldName = "OptionData.UnderlinePrice";
            this.colOptionData_UnderlinePrice.MaxWidth = 100;
            this.colOptionData_UnderlinePrice.Name = "colOptionData_UnderlinePrice";
            // 
            // colThetaTotal
            // 
            this.colThetaTotal.AppearanceCell.BackColor = System.Drawing.Color.LightCyan;
            this.colThetaTotal.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colThetaTotal.AppearanceCell.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colThetaTotal.AppearanceCell.Options.UseBackColor = true;
            this.colThetaTotal.AppearanceCell.Options.UseFont = true;
            this.colThetaTotal.AppearanceCell.Options.UseForeColor = true;
            this.colThetaTotal.AppearanceHeader.BackColor = System.Drawing.Color.LightCyan;
            this.colThetaTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colThetaTotal.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.colThetaTotal.AppearanceHeader.Options.UseBackColor = true;
            this.colThetaTotal.AppearanceHeader.Options.UseFont = true;
            this.colThetaTotal.AppearanceHeader.Options.UseForeColor = true;
            this.colThetaTotal.Caption = "Σ Θ";
            this.colThetaTotal.DisplayFormat.FormatString = "#,##0.0";
            this.colThetaTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThetaTotal.FieldName = "ThetaTotal";
            this.colThetaTotal.MaxWidth = 120;
            this.colThetaTotal.MinWidth = 45;
            this.colThetaTotal.Name = "colThetaTotal";
            this.colThetaTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThetaTotal", "{0:#,##0}")});
            this.colThetaTotal.Visible = true;
            this.colThetaTotal.VisibleIndex = 17;
            this.colThetaTotal.Width = 45;
            // 
            // colVegaTotal
            // 
            this.colVegaTotal.AppearanceCell.BackColor = System.Drawing.Color.LightCyan;
            this.colVegaTotal.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colVegaTotal.AppearanceCell.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colVegaTotal.AppearanceCell.Options.UseBackColor = true;
            this.colVegaTotal.AppearanceCell.Options.UseFont = true;
            this.colVegaTotal.AppearanceCell.Options.UseForeColor = true;
            this.colVegaTotal.AppearanceHeader.BackColor = System.Drawing.Color.LightCyan;
            this.colVegaTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colVegaTotal.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.colVegaTotal.AppearanceHeader.Options.UseBackColor = true;
            this.colVegaTotal.AppearanceHeader.Options.UseFont = true;
            this.colVegaTotal.AppearanceHeader.Options.UseForeColor = true;
            this.colVegaTotal.Caption = "Σ V";
            this.colVegaTotal.DisplayFormat.FormatString = "#,##0.0";
            this.colVegaTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVegaTotal.FieldName = "VegaTotal";
            this.colVegaTotal.FieldNameSortGroup = "VegaTotal";
            this.colVegaTotal.MaxWidth = 120;
            this.colVegaTotal.MinWidth = 45;
            this.colVegaTotal.Name = "colVegaTotal";
            this.colVegaTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VegaTotal", "{0:#,##0}")});
            this.colVegaTotal.Visible = true;
            this.colVegaTotal.VisibleIndex = 18;
            this.colVegaTotal.Width = 45;
            // 
            // colOptionData_Gamma
            // 
            this.colOptionData_Gamma.AppearanceCell.BackColor = System.Drawing.Color.AliceBlue;
            this.colOptionData_Gamma.AppearanceCell.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colOptionData_Gamma.AppearanceCell.Options.UseBackColor = true;
            this.colOptionData_Gamma.AppearanceCell.Options.UseForeColor = true;
            this.colOptionData_Gamma.AppearanceHeader.BackColor = System.Drawing.Color.AliceBlue;
            this.colOptionData_Gamma.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.colOptionData_Gamma.AppearanceHeader.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colOptionData_Gamma.AppearanceHeader.Options.UseBackColor = true;
            this.colOptionData_Gamma.AppearanceHeader.Options.UseFont = true;
            this.colOptionData_Gamma.AppearanceHeader.Options.UseForeColor = true;
            this.colOptionData_Gamma.Caption = "γ";
            this.colOptionData_Gamma.DisplayFormat.FormatString = "#0.000";
            this.colOptionData_Gamma.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOptionData_Gamma.FieldName = "OptionData.Gamma";
            this.colOptionData_Gamma.MaxWidth = 70;
            this.colOptionData_Gamma.MinWidth = 45;
            this.colOptionData_Gamma.Name = "colOptionData_Gamma";
            this.colOptionData_Gamma.Visible = true;
            this.colOptionData_Gamma.VisibleIndex = 20;
            this.colOptionData_Gamma.Width = 70;
            // 
            // colOptionData_ImpliedVolatility
            // 
            this.colOptionData_ImpliedVolatility.AppearanceCell.BackColor = System.Drawing.Color.AliceBlue;
            this.colOptionData_ImpliedVolatility.AppearanceCell.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colOptionData_ImpliedVolatility.AppearanceCell.Options.UseBackColor = true;
            this.colOptionData_ImpliedVolatility.AppearanceCell.Options.UseForeColor = true;
            this.colOptionData_ImpliedVolatility.AppearanceHeader.BackColor = System.Drawing.Color.AliceBlue;
            this.colOptionData_ImpliedVolatility.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.colOptionData_ImpliedVolatility.AppearanceHeader.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colOptionData_ImpliedVolatility.AppearanceHeader.Options.UseBackColor = true;
            this.colOptionData_ImpliedVolatility.AppearanceHeader.Options.UseFont = true;
            this.colOptionData_ImpliedVolatility.AppearanceHeader.Options.UseForeColor = true;
            this.colOptionData_ImpliedVolatility.Caption = "IV";
            this.colOptionData_ImpliedVolatility.DisplayFormat.FormatString = "#0.00%";
            this.colOptionData_ImpliedVolatility.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOptionData_ImpliedVolatility.FieldName = "OptionData.ImpliedVolatility";
            this.colOptionData_ImpliedVolatility.MaxWidth = 100;
            this.colOptionData_ImpliedVolatility.MinWidth = 50;
            this.colOptionData_ImpliedVolatility.Name = "colOptionData_ImpliedVolatility";
            this.colOptionData_ImpliedVolatility.Visible = true;
            this.colOptionData_ImpliedVolatility.VisibleIndex = 14;
            this.colOptionData_ImpliedVolatility.Width = 51;
            // 
            // colContract_Symbol
            // 
            this.colContract_Symbol.FieldName = "OptionData.Contract.Symbol";
            this.colContract_Symbol.Name = "colContract_Symbol";
            // 
            // colAvgPrice
            // 
            this.colAvgPrice.Caption = "Avg Price";
            this.colAvgPrice.DisplayFormat.FormatString = "#,##0.00";
            this.colAvgPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAvgPrice.FieldName = "AverageCost";
            this.colAvgPrice.MinWidth = 70;
            this.colAvgPrice.Name = "colAvgPrice";
            this.colAvgPrice.UnboundExpression = "[TotalCostUSD] / [Position]";
            this.colAvgPrice.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colAvgPrice.Visible = true;
            this.colAvgPrice.VisibleIndex = 7;
            this.colAvgPrice.Width = 71;
            // 
            // colChangeFromCost
            // 
            this.colChangeFromCost.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.colChangeFromCost.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.colChangeFromCost.AppearanceCell.Options.UseBackColor = true;
            this.colChangeFromCost.AppearanceCell.Options.UseForeColor = true;
            this.colChangeFromCost.Caption = "% Cost";
            this.colChangeFromCost.DisplayFormat.FormatString = "#0.00%";
            this.colChangeFromCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colChangeFromCost.FieldName = "gridColumn1";
            this.colChangeFromCost.Name = "colChangeFromCost";
            this.colChangeFromCost.UnboundExpression = "(100 * [CalculatedOptionPrice] - [AverageCost]) / [AverageCost]";
            this.colChangeFromCost.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colChangeFromCost.Visible = true;
            this.colChangeFromCost.VisibleIndex = 9;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(90, 12);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(94, 25);
            this.btnLoadData.TabIndex = 2;
            this.btnLoadData.Text = "Start Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Net Liquidation:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Margin:";
            // 
            // lblNetLiquidation
            // 
            this.lblNetLiquidation.AutoSize = true;
            this.lblNetLiquidation.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblNetLiquidation.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.accountSummaryDataBindingSource, "NetLiquidation", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.lblNetLiquidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetLiquidation.ForeColor = System.Drawing.Color.Green;
            this.lblNetLiquidation.Location = new System.Drawing.Point(120, 18);
            this.lblNetLiquidation.Name = "lblNetLiquidation";
            this.lblNetLiquidation.Size = new System.Drawing.Size(59, 15);
            this.lblNetLiquidation.TabIndex = 3;
            this.lblNetLiquidation.Text = "159,300";
            // 
            // accountSummaryDataBindingSource
            // 
            this.accountSummaryDataBindingSource.DataSource = typeof(TNS.API.ApiDataObjects.AccountSummaryData);
            // 
            // lblMargin
            // 
            this.lblMargin.AutoSize = true;
            this.lblMargin.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblMargin.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.accountSummaryDataBindingSource, "FullMaintMarginReq", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.lblMargin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMargin.ForeColor = System.Drawing.Color.Green;
            this.lblMargin.Location = new System.Drawing.Point(120, 51);
            this.lblMargin.Name = "lblMargin";
            this.lblMargin.Size = new System.Drawing.Size(59, 15);
            this.lblMargin.TabIndex = 3;
            this.lblMargin.Text = "125,000";
            // 
            // grpAccountSummary
            // 
            this.grpAccountSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAccountSummary.Controls.Add(this.label4);
            this.grpAccountSummary.Controls.Add(this.label1);
            this.grpAccountSummary.Controls.Add(this.lblMargin);
            this.grpAccountSummary.Controls.Add(this.lblPnL);
            this.grpAccountSummary.Controls.Add(this.lblNetLiquidation);
            this.grpAccountSummary.Controls.Add(this.label2);
            this.grpAccountSummary.Location = new System.Drawing.Point(1015, 0);
            this.grpAccountSummary.Name = "grpAccountSummary";
            this.grpAccountSummary.Size = new System.Drawing.Size(209, 126);
            this.grpAccountSummary.TabIndex = 4;
            this.grpAccountSummary.TabStop = false;
            this.grpAccountSummary.Text = "Account Summary";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(6, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "PnL:";
            // 
            // lblPnL
            // 
            this.lblPnL.AutoSize = true;
            this.lblPnL.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblPnL.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.accountSummaryDataBindingSource, "PnL", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.lblPnL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPnL.ForeColor = System.Drawing.Color.Green;
            this.lblPnL.Location = new System.Drawing.Point(120, 84);
            this.lblPnL.Name = "lblPnL";
            this.lblPnL.Size = new System.Drawing.Size(39, 15);
            this.lblPnL.TabIndex = 3;
            this.lblPnL.Text = "9999";
            // 
            // grdUnLTradingData
            // 
            this.grdUnLTradingData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUnLTradingData.DataSource = this.unlTradingDataBindingSource;
            this.grdUnLTradingData.Location = new System.Drawing.Point(3, 3);
            this.grdUnLTradingData.MainView = this.gridViewUnLTradingData;
            this.grdUnLTradingData.Name = "grdUnLTradingData";
            this.grdUnLTradingData.Size = new System.Drawing.Size(1010, 127);
            this.grdUnLTradingData.TabIndex = 5;
            this.grdUnLTradingData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewUnLTradingData});
            // 
            // unlTradingDataBindingSource
            // 
            this.unlTradingDataBindingSource.DataSource = typeof(TNS.API.ApiDataObjects.UnlTradingData);
            // 
            // gridViewUnLTradingData
            // 
            this.gridViewUnLTradingData.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridViewUnLTradingData.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewUnLTradingData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAPIDataType,
            this.colSymbol,
            this.colUnlBid,
            this.colUnlAsk,
            this.colUnlChange,
            this.colUnlOpen,
            this.colLastUpdate,
            this.colShorts,
            this.colTradingState,
            this.colDeltaTotal2,
            this.colGammaTotal2,
            this.colThetaTotal2,
            this.colVegaTotal2,
            this.colMarginTotal,
            this.colIVWeightedAvg,
            this.colVIX,
            this.colUnderlinePrice,
            this.gridColumn5,
            this.colCostTotal,
            this.colPnLTotal,
            this.colCommisionTotal,
            this.colLastDayPnL,
            this.colDailyPnL,
            this.colMaxAbsoluteDelta,
            this.colMargin});
            this.gridViewUnLTradingData.GridControl = this.grdUnLTradingData;
            this.gridViewUnLTradingData.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MarketValue", this.colThetaTotal2, "(Market: SUM={0:#,##0})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThetaTotal", this.colThetaTotal2, "{0:#,##0}")});
            this.gridViewUnLTradingData.Name = "gridViewUnLTradingData";
            this.gridViewUnLTradingData.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewUnLTradingData.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewUnLTradingData.OptionsBehavior.Editable = false;
            this.gridViewUnLTradingData.OptionsBehavior.ReadOnly = true;
            this.gridViewUnLTradingData.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewUnLTradingData.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewUnLTradingData.OptionsView.ShowFooter = true;
            this.gridViewUnLTradingData.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSymbol, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            // colUnlBid
            // 
            this.colUnlBid.Caption = "Un lBid";
            this.colUnlBid.FieldName = "UnlBid";
            this.colUnlBid.Name = "colUnlBid";
            this.colUnlBid.Visible = true;
            this.colUnlBid.VisibleIndex = 2;
            // 
            // colUnlAsk
            // 
            this.colUnlAsk.Caption = "Unl Ask";
            this.colUnlAsk.FieldName = "UnlAsk";
            this.colUnlAsk.Name = "colUnlAsk";
            this.colUnlAsk.Visible = true;
            this.colUnlAsk.VisibleIndex = 3;
            // 
            // colUnlChange
            // 
            this.colUnlChange.Caption = "Unl Change";
            this.colUnlChange.DisplayFormat.FormatString = "#0.00%";
            this.colUnlChange.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnlChange.FieldName = "UnlChange";
            this.colUnlChange.Name = "colUnlChange";
            this.colUnlChange.Visible = true;
            this.colUnlChange.VisibleIndex = 6;
            // 
            // colUnlOpen
            // 
            this.colUnlOpen.Caption = "Unl Open";
            this.colUnlOpen.DisplayFormat.FormatString = "#0.00";
            this.colUnlOpen.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnlOpen.FieldName = "UnlBasePrice";
            this.colUnlOpen.Name = "colUnlOpen";
            this.colUnlOpen.Visible = true;
            this.colUnlOpen.VisibleIndex = 4;
            // 
            // colLastUpdate
            // 
            this.colLastUpdate.DisplayFormat.FormatString = "G";
            this.colLastUpdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLastUpdate.FieldName = "LastUpdate";
            this.colLastUpdate.Name = "colLastUpdate";
            this.colLastUpdate.Visible = true;
            this.colLastUpdate.VisibleIndex = 23;
            this.colLastUpdate.Width = 121;
            // 
            // colShorts
            // 
            this.colShorts.Caption = "Shorts #";
            this.colShorts.FieldName = "Shorts";
            this.colShorts.Name = "colShorts";
            this.colShorts.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Shorts", "{0:#,##0}")});
            this.colShorts.Visible = true;
            this.colShorts.VisibleIndex = 8;
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
            // colDeltaTotal2
            // 
            this.colDeltaTotal2.AppearanceCell.BackColor = System.Drawing.Color.LightCyan;
            this.colDeltaTotal2.AppearanceCell.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colDeltaTotal2.AppearanceCell.Options.UseBackColor = true;
            this.colDeltaTotal2.AppearanceCell.Options.UseForeColor = true;
            this.colDeltaTotal2.Caption = "Σ δ";
            this.colDeltaTotal2.DisplayFormat.FormatString = "#,##0";
            this.colDeltaTotal2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDeltaTotal2.FieldName = "DeltaTotal";
            this.colDeltaTotal2.Name = "colDeltaTotal2";
            this.colDeltaTotal2.Visible = true;
            this.colDeltaTotal2.VisibleIndex = 11;
            this.colDeltaTotal2.Width = 56;
            // 
            // colGammaTotal2
            // 
            this.colGammaTotal2.AppearanceCell.BackColor = System.Drawing.Color.LightCyan;
            this.colGammaTotal2.AppearanceCell.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colGammaTotal2.AppearanceCell.Options.UseBackColor = true;
            this.colGammaTotal2.AppearanceCell.Options.UseForeColor = true;
            this.colGammaTotal2.Caption = "Σ γ";
            this.colGammaTotal2.DisplayFormat.FormatString = "#,##0";
            this.colGammaTotal2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGammaTotal2.FieldName = "GammaTotal";
            this.colGammaTotal2.Name = "colGammaTotal2";
            this.colGammaTotal2.Visible = true;
            this.colGammaTotal2.VisibleIndex = 12;
            this.colGammaTotal2.Width = 49;
            // 
            // colThetaTotal2
            // 
            this.colThetaTotal2.AppearanceCell.BackColor = System.Drawing.Color.LightCyan;
            this.colThetaTotal2.AppearanceCell.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colThetaTotal2.AppearanceCell.Options.UseBackColor = true;
            this.colThetaTotal2.AppearanceCell.Options.UseForeColor = true;
            this.colThetaTotal2.Caption = "Σ Θ";
            this.colThetaTotal2.DisplayFormat.FormatString = "#,##0";
            this.colThetaTotal2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThetaTotal2.FieldName = "ThetaTotal";
            this.colThetaTotal2.Name = "colThetaTotal2";
            this.colThetaTotal2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThetaTotal", "{0:#,##0}")});
            this.colThetaTotal2.Visible = true;
            this.colThetaTotal2.VisibleIndex = 13;
            this.colThetaTotal2.Width = 49;
            // 
            // colVegaTotal2
            // 
            this.colVegaTotal2.AppearanceCell.BackColor = System.Drawing.Color.LightCyan;
            this.colVegaTotal2.AppearanceCell.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colVegaTotal2.AppearanceCell.Options.UseBackColor = true;
            this.colVegaTotal2.AppearanceCell.Options.UseForeColor = true;
            this.colVegaTotal2.Caption = "Σ V";
            this.colVegaTotal2.DisplayFormat.FormatString = "#,##0";
            this.colVegaTotal2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVegaTotal2.FieldName = "VegaTotal";
            this.colVegaTotal2.Name = "colVegaTotal2";
            this.colVegaTotal2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VegaTotal", "{0:#,##0}")});
            this.colVegaTotal2.Visible = true;
            this.colVegaTotal2.VisibleIndex = 14;
            this.colVegaTotal2.Width = 49;
            // 
            // colMarginTotal
            // 
            this.colMarginTotal.Caption = "Margin Max ";
            this.colMarginTotal.DisplayFormat.FormatString = "#,##0";
            this.colMarginTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMarginTotal.FieldName = "MaxAllowedMargin";
            this.colMarginTotal.Name = "colMarginTotal";
            this.colMarginTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MaxAllowedMargin", "{0:#,##0}")});
            this.colMarginTotal.Visible = true;
            this.colMarginTotal.VisibleIndex = 7;
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
            this.colIVWeightedAvg.VisibleIndex = 15;
            this.colIVWeightedAvg.Width = 54;
            // 
            // colVIX
            // 
            this.colVIX.DisplayFormat.FormatString = "#0.00";
            this.colVIX.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVIX.FieldName = "VIX";
            this.colVIX.Name = "colVIX";
            this.colVIX.Visible = true;
            this.colVIX.VisibleIndex = 16;
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
            this.colUnderlinePrice.VisibleIndex = 5;
            this.colUnderlinePrice.Width = 48;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon;
            this.gridColumn5.AppearanceCell.ForeColor = System.Drawing.Color.Magenta;
            this.gridColumn5.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn5.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn5.Caption = "Market";
            this.gridColumn5.DisplayFormat.FormatString = "#,##0";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "MarketValue";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MarketValue", "{0:#,##0}")});
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 17;
            this.gridColumn5.Width = 48;
            // 
            // colCostTotal
            // 
            this.colCostTotal.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon;
            this.colCostTotal.AppearanceCell.ForeColor = System.Drawing.Color.Magenta;
            this.colCostTotal.AppearanceCell.Options.UseBackColor = true;
            this.colCostTotal.AppearanceCell.Options.UseForeColor = true;
            this.colCostTotal.Caption = "Cost";
            this.colCostTotal.DisplayFormat.FormatString = "#,##0";
            this.colCostTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCostTotal.FieldName = "CostTotal";
            this.colCostTotal.Name = "colCostTotal";
            this.colCostTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CostTotal", "{0:#,##0}")});
            this.colCostTotal.Visible = true;
            this.colCostTotal.VisibleIndex = 18;
            this.colCostTotal.Width = 48;
            // 
            // colPnLTotal
            // 
            this.colPnLTotal.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon;
            this.colPnLTotal.AppearanceCell.ForeColor = System.Drawing.Color.Magenta;
            this.colPnLTotal.AppearanceCell.Options.UseBackColor = true;
            this.colPnLTotal.AppearanceCell.Options.UseForeColor = true;
            this.colPnLTotal.Caption = "PnL";
            this.colPnLTotal.DisplayFormat.FormatString = "#,##0";
            this.colPnLTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPnLTotal.FieldName = "PnLTotal";
            this.colPnLTotal.Name = "colPnLTotal";
            this.colPnLTotal.OptionsColumn.ReadOnly = true;
            this.colPnLTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PnLTotal", "{0:#,##0}")});
            this.colPnLTotal.Visible = true;
            this.colPnLTotal.VisibleIndex = 19;
            this.colPnLTotal.Width = 48;
            // 
            // colCommisionTotal
            // 
            this.colCommisionTotal.Caption = "Commision";
            this.colCommisionTotal.FieldName = "CommisionTotal";
            this.colCommisionTotal.Name = "colCommisionTotal";
            this.colCommisionTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CommisionTotal", "{0:#,##0}")});
            this.colCommisionTotal.Visible = true;
            this.colCommisionTotal.VisibleIndex = 20;
            this.colCommisionTotal.Width = 62;
            // 
            // colLastDayPnL
            // 
            this.colLastDayPnL.Caption = "Prr PnL";
            this.colLastDayPnL.DisplayFormat.FormatString = "#,##0";
            this.colLastDayPnL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLastDayPnL.FieldName = "LastDayPnL";
            this.colLastDayPnL.Name = "colLastDayPnL";
            this.colLastDayPnL.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LastDayPnL", "{0:#,##0}")});
            this.colLastDayPnL.Visible = true;
            this.colLastDayPnL.VisibleIndex = 21;
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
            this.colDailyPnL.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DailyPnL", "{0:#,##0}")});
            this.colDailyPnL.Visible = true;
            this.colDailyPnL.VisibleIndex = 22;
            this.colDailyPnL.Width = 58;
            // 
            // colMaxAbsoluteDelta
            // 
            this.colMaxAbsoluteDelta.Caption = "Max |δ|";
            this.colMaxAbsoluteDelta.FieldName = "MaxAbsoluteDelta";
            this.colMaxAbsoluteDelta.Name = "colMaxAbsoluteDelta";
            this.colMaxAbsoluteDelta.OptionsColumn.ReadOnly = true;
            this.colMaxAbsoluteDelta.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MaxAbsoluteDelta", "{0:#,##0}")});
            this.colMaxAbsoluteDelta.Visible = true;
            this.colMaxAbsoluteDelta.VisibleIndex = 10;
            this.colMaxAbsoluteDelta.Width = 61;
            // 
            // colMargin
            // 
            this.colMargin.Caption = "Margin";
            this.colMargin.DisplayFormat.FormatString = "#,##0";
            this.colMargin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMargin.FieldName = "Margin";
            this.colMargin.Name = "colMargin";
            this.colMargin.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Margin", "{0:#,##0}")});
            this.colMargin.Visible = true;
            this.colMargin.VisibleIndex = 9;
            this.colMargin.Width = 49;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grdUnLTradingData);
            this.splitContainerControl1.Panel1.Controls.Add(this.grpAccountSummary);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.btnLoadData);
            this.splitContainerControl1.Panel2.Controls.Add(this.grdPositionData);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1231, 657);
            this.splitContainerControl1.SplitterPosition = 132;
            this.splitContainerControl1.TabIndex = 6;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // PositionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "PositionsView";
            this.Size = new System.Drawing.Size(1231, 657);
            this.Resize += new System.EventHandler(this.PositionsView_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grdPositionData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsPositionDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountSummaryDataBindingSource)).EndInit();
            this.grpAccountSummary.ResumeLayout(false);
            this.grpAccountSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnLTradingData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unlTradingDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUnLTradingData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdPositionData;
        private System.Windows.Forms.BindingSource optionsPositionDataBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionContract_OptionType;
        private DevExpress.XtraGrid.Columns.GridColumn colPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colAverageCost;
        private DevExpress.XtraGrid.Columns.GridColumn colConId;
        private DevExpress.XtraGrid.Columns.GridColumn colStrike;
        private DevExpress.XtraGrid.Columns.GridColumn colMultiplier;
        private DevExpress.XtraGrid.Columns.GridColumn colExchange;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn colLocalSymbol;
        private DevExpress.XtraGrid.Columns.GridColumn colBidPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colAskPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionDelta;
        private DevExpress.XtraGrid.Columns.GridColumn colContract_ExpiryDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionData_OptionType;
        private DevExpress.XtraGrid.Columns.GridColumn colDeltaTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalCost;
        private DevExpress.XtraGrid.Columns.GridColumn colLastPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colMarketValue;
        private DevExpress.XtraGrid.Columns.GridColumn colPNL;
        private DevExpress.XtraGrid.Columns.GridColumn colGammaTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionData_ModelPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionData_UnderlinePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colThetaTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colVegaTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionData_Gamma;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionData_ImpliedVolatility;
        private DevExpress.XtraGrid.Columns.GridColumn colContract_Symbol;
        private DevExpress.XtraGrid.Columns.GridColumn colAvgPrice;
        private System.Windows.Forms.Button btnLoadData;
        private DevExpress.XtraGrid.Columns.GridColumn colExpiry;
        private DevExpress.XtraGrid.Columns.GridColumn colCalculatedOptionPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNetLiquidation;
        private System.Windows.Forms.BindingSource accountSummaryDataBindingSource;
        private System.Windows.Forms.Label lblMargin;
        private System.Windows.Forms.GroupBox grpAccountSummary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPnL;
        private DevExpress.XtraGrid.GridControl grdUnLTradingData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUnLTradingData;
        private DevExpress.XtraGrid.Columns.GridColumn colAPIDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colSymbol;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colShorts;
        private DevExpress.XtraGrid.Columns.GridColumn colTradingState;
        private DevExpress.XtraGrid.Columns.GridColumn colDeltaTotal2;
        private DevExpress.XtraGrid.Columns.GridColumn colGammaTotal2;
        private DevExpress.XtraGrid.Columns.GridColumn colThetaTotal2;
        private DevExpress.XtraGrid.Columns.GridColumn colVegaTotal2;
        private DevExpress.XtraGrid.Columns.GridColumn colMarginTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colIVWeightedAvg;
        private DevExpress.XtraGrid.Columns.GridColumn colVIX;
        private DevExpress.XtraGrid.Columns.GridColumn colUnderlinePrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn colCostTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colPnLTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colCommisionTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colLastDayPnL;
        private DevExpress.XtraGrid.Columns.GridColumn colDailyPnL;
        private DevExpress.XtraGrid.Columns.GridColumn colMaxAbsoluteDelta;
        private DevExpress.XtraGrid.Columns.GridColumn colMargin;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.BindingSource unlTradingDataBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colChangeFromCost;
        private DevExpress.XtraGrid.Columns.GridColumn colUnlBid;
        private DevExpress.XtraGrid.Columns.GridColumn colUnlAsk;
        private DevExpress.XtraGrid.Columns.GridColumn colUnlChange;
        private DevExpress.XtraGrid.Columns.GridColumn colUnlOpen;
    }
}
