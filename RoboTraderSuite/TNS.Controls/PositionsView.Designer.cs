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
            this.btnLoadData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdPositionData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsPositionDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdPositionData
            // 
            this.grdPositionData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPositionData.DataSource = this.optionsPositionDataBindingSource;
            this.grdPositionData.Location = new System.Drawing.Point(5, 65);
            this.grdPositionData.MainView = this.gridView1;
            this.grdPositionData.Name = "grdPositionData";
            this.grdPositionData.Padding = new System.Windows.Forms.Padding(10);
            this.grdPositionData.Size = new System.Drawing.Size(1120, 210);
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
            this.colAvgPrice});
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
            this.colBidPrice.VisibleIndex = 9;
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
            this.colAskPrice.VisibleIndex = 10;
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
            this.colOptionDelta.VisibleIndex = 18;
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
            this.colDeltaTotal.VisibleIndex = 14;
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
            this.colLastPrice.VisibleIndex = 12;
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
            this.colGammaTotal.VisibleIndex = 15;
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
            this.colOptionData_ModelPrice.VisibleIndex = 11;
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
            this.colThetaTotal.VisibleIndex = 16;
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
            this.colVegaTotal.VisibleIndex = 17;
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
            this.colOptionData_Gamma.VisibleIndex = 19;
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
            this.colOptionData_ImpliedVolatility.VisibleIndex = 13;
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
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(5, 19);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(94, 25);
            this.btnLoadData.TabIndex = 2;
            this.btnLoadData.Text = "Start Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // PositionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.grdPositionData);
            this.Name = "PositionsView";
            this.Size = new System.Drawing.Size(1130, 653);
            this.Resize += new System.EventHandler(this.PositionsView_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grdPositionData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsPositionDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
    }
}
