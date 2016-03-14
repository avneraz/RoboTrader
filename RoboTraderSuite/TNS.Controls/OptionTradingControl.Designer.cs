namespace TNS.Controls
{
    partial class OptionTradingControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdOption = new DevExpress.XtraGrid.GridControl();
            this.optionDataBindingSource = new System.Windows.Forms.BindingSource();
            this.grdViewOption = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOptionContractOptionKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptionContract_Symbol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptionContract_Expiry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptionContract_OptionType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptionContract_Strike = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBasePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAskPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBidPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDelta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGamma = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTheta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImpliedVolatility = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModelPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnderlinePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHighestPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLowestPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOpeningPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAskSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBidSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMultiplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnSendOrder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.rbtbuy = new System.Windows.Forms.RadioButton();
            this.rbtSell = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.grdOption);
            this.panel1.Location = new System.Drawing.Point(5, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1090, 576);
            this.panel1.TabIndex = 0;
            // 
            // grdOption
            // 
            this.grdOption.DataSource = this.optionDataBindingSource;
            this.grdOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOption.Location = new System.Drawing.Point(0, 0);
            this.grdOption.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdOption.MainView = this.grdViewOption;
            this.grdOption.Margin = new System.Windows.Forms.Padding(5);
            this.grdOption.Name = "grdOption";
            this.grdOption.Padding = new System.Windows.Forms.Padding(5);
            this.grdOption.Size = new System.Drawing.Size(1090, 576);
            this.grdOption.TabIndex = 1;
            this.grdOption.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewOption});
            // 
            // optionDataBindingSource
            // 
            this.optionDataBindingSource.DataSource = typeof(TNS.API.ApiDataObjects.OptionData);
            // 
            // grdViewOption
            // 
            this.grdViewOption.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdViewOption.Appearance.EvenRow.Options.UseBackColor = true;
            this.grdViewOption.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdViewOption.Appearance.OddRow.Options.UseBackColor = true;
            this.grdViewOption.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOptionContractOptionKey,
            this.colOptionContract_Symbol,
            this.colOptionContract_Expiry,
            this.colOptionContract_OptionType,
            this.colOptionContract_Strike,
            this.colBasePrice,
            this.colLastPrice,
            this.colAskPrice,
            this.colBidPrice,
            this.colDelta,
            this.colGamma,
            this.colVega,
            this.colTheta,
            this.colImpliedVolatility,
            this.colModelPrice,
            this.colUnderlinePrice,
            this.colHighestPrice,
            this.colLowestPrice,
            this.colOpeningPrice,
            this.colAskSize,
            this.colBidSize,
            this.colVolume,
            this.colMultiplier,
            this.colId,
            this.colLastUpdate});
            this.grdViewOption.GridControl = this.grdOption;
            this.grdViewOption.GroupCount = 1;
            this.grdViewOption.Name = "grdViewOption";
            this.grdViewOption.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colOptionContract_OptionType, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colOptionContract_Strike, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colOptionContractOptionKey
            // 
            this.colOptionContractOptionKey.Caption = "Op. Key";
            this.colOptionContractOptionKey.FieldName = "OptionContract.OptionKey";
            this.colOptionContractOptionKey.Name = "colOptionContractOptionKey";
            this.colOptionContractOptionKey.Width = 88;
            // 
            // colOptionContract_Symbol
            // 
            this.colOptionContract_Symbol.Caption = "Symbol";
            this.colOptionContract_Symbol.FieldName = "OptionContract.Symbol";
            this.colOptionContract_Symbol.Name = "colOptionContract_Symbol";
            this.colOptionContract_Symbol.Visible = true;
            this.colOptionContract_Symbol.VisibleIndex = 0;
            this.colOptionContract_Symbol.Width = 77;
            // 
            // colOptionContract_Expiry
            // 
            this.colOptionContract_Expiry.Caption = "Expiry";
            this.colOptionContract_Expiry.FieldName = "OptionContract.Expiry";
            this.colOptionContract_Expiry.Name = "colOptionContract_Expiry";
            this.colOptionContract_Expiry.Visible = true;
            this.colOptionContract_Expiry.VisibleIndex = 1;
            this.colOptionContract_Expiry.Width = 80;
            // 
            // colOptionContract_OptionType
            // 
            this.colOptionContract_OptionType.Caption = "Type";
            this.colOptionContract_OptionType.FieldName = "OptionContract.OptionType";
            this.colOptionContract_OptionType.Name = "colOptionContract_OptionType";
            this.colOptionContract_OptionType.Visible = true;
            this.colOptionContract_OptionType.VisibleIndex = 2;
            this.colOptionContract_OptionType.Width = 41;
            // 
            // colOptionContract_Strike
            // 
            this.colOptionContract_Strike.Caption = "Strike";
            this.colOptionContract_Strike.FieldName = "OptionContract.Strike";
            this.colOptionContract_Strike.Name = "colOptionContract_Strike";
            this.colOptionContract_Strike.Visible = true;
            this.colOptionContract_Strike.VisibleIndex = 2;
            this.colOptionContract_Strike.Width = 74;
            // 
            // colBasePrice
            // 
            this.colBasePrice.Caption = "Base P.";
            this.colBasePrice.DisplayFormat.FormatString = "#0.00";
            this.colBasePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBasePrice.FieldName = "BasePrice";
            this.colBasePrice.Name = "colBasePrice";
            this.colBasePrice.Visible = true;
            this.colBasePrice.VisibleIndex = 3;
            this.colBasePrice.Width = 70;
            // 
            // colLastPrice
            // 
            this.colLastPrice.Caption = "Last P.";
            this.colLastPrice.DisplayFormat.FormatString = "#0.00";
            this.colLastPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLastPrice.FieldName = "LastPrice";
            this.colLastPrice.Name = "colLastPrice";
            this.colLastPrice.Visible = true;
            this.colLastPrice.VisibleIndex = 4;
            this.colLastPrice.Width = 67;
            // 
            // colAskPrice
            // 
            this.colAskPrice.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            this.colAskPrice.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.colAskPrice.AppearanceCell.Options.UseBackColor = true;
            this.colAskPrice.AppearanceCell.Options.UseForeColor = true;
            this.colAskPrice.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
            this.colAskPrice.AppearanceHeader.Options.UseForeColor = true;
            this.colAskPrice.Caption = "Ask";
            this.colAskPrice.DisplayFormat.FormatString = "#0.00";
            this.colAskPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAskPrice.FieldName = "AskPrice";
            this.colAskPrice.Name = "colAskPrice";
            this.colAskPrice.Visible = true;
            this.colAskPrice.VisibleIndex = 6;
            this.colAskPrice.Width = 42;
            // 
            // colBidPrice
            // 
            this.colBidPrice.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            this.colBidPrice.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.colBidPrice.AppearanceCell.Options.UseBackColor = true;
            this.colBidPrice.AppearanceCell.Options.UseForeColor = true;
            this.colBidPrice.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.colBidPrice.AppearanceHeader.Options.UseForeColor = true;
            this.colBidPrice.Caption = "Bid";
            this.colBidPrice.DisplayFormat.FormatString = "#0.00";
            this.colBidPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBidPrice.FieldName = "BidPrice";
            this.colBidPrice.Name = "colBidPrice";
            this.colBidPrice.Visible = true;
            this.colBidPrice.VisibleIndex = 7;
            this.colBidPrice.Width = 38;
            // 
            // colDelta
            // 
            this.colDelta.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colDelta.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.colDelta.AppearanceCell.Options.UseBackColor = true;
            this.colDelta.AppearanceCell.Options.UseForeColor = true;
            this.colDelta.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colDelta.AppearanceHeader.Options.UseForeColor = true;
            this.colDelta.AppearanceHeader.Options.UseTextOptions = true;
            this.colDelta.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDelta.Caption = " δ";
            this.colDelta.DisplayFormat.FormatString = "#0.000";
            this.colDelta.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDelta.FieldName = "Delta";
            this.colDelta.Name = "colDelta";
            this.colDelta.Visible = true;
            this.colDelta.VisibleIndex = 8;
            this.colDelta.Width = 65;
            // 
            // colGamma
            // 
            this.colGamma.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colGamma.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.colGamma.AppearanceCell.Options.UseBackColor = true;
            this.colGamma.AppearanceCell.Options.UseForeColor = true;
            this.colGamma.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colGamma.AppearanceHeader.Options.UseForeColor = true;
            this.colGamma.AppearanceHeader.Options.UseTextOptions = true;
            this.colGamma.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGamma.Caption = "γ";
            this.colGamma.DisplayFormat.FormatString = "#0.000";
            this.colGamma.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGamma.FieldName = "Gamma";
            this.colGamma.Name = "colGamma";
            this.colGamma.Visible = true;
            this.colGamma.VisibleIndex = 9;
            this.colGamma.Width = 55;
            // 
            // colVega
            // 
            this.colVega.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colVega.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.colVega.AppearanceCell.Options.UseBackColor = true;
            this.colVega.AppearanceCell.Options.UseForeColor = true;
            this.colVega.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colVega.AppearanceHeader.Options.UseForeColor = true;
            this.colVega.AppearanceHeader.Options.UseTextOptions = true;
            this.colVega.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVega.Caption = "Vega";
            this.colVega.DisplayFormat.FormatString = "#0.000";
            this.colVega.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVega.FieldName = "Vega";
            this.colVega.Name = "colVega";
            this.colVega.Visible = true;
            this.colVega.VisibleIndex = 10;
            this.colVega.Width = 53;
            // 
            // colTheta
            // 
            this.colTheta.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colTheta.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.colTheta.AppearanceCell.Options.UseBackColor = true;
            this.colTheta.AppearanceCell.Options.UseForeColor = true;
            this.colTheta.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colTheta.AppearanceHeader.Options.UseForeColor = true;
            this.colTheta.AppearanceHeader.Options.UseTextOptions = true;
            this.colTheta.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTheta.Caption = "Θ";
            this.colTheta.DisplayFormat.FormatString = "#0.000";
            this.colTheta.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTheta.FieldName = "Theta";
            this.colTheta.Name = "colTheta";
            this.colTheta.Visible = true;
            this.colTheta.VisibleIndex = 11;
            this.colTheta.Width = 73;
            // 
            // colImpliedVolatility
            // 
            this.colImpliedVolatility.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.colImpliedVolatility.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.colImpliedVolatility.AppearanceCell.Options.UseBackColor = true;
            this.colImpliedVolatility.AppearanceCell.Options.UseForeColor = true;
            this.colImpliedVolatility.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colImpliedVolatility.AppearanceHeader.Options.UseForeColor = true;
            this.colImpliedVolatility.Caption = "IV";
            this.colImpliedVolatility.DisplayFormat.FormatString = "#0.00%";
            this.colImpliedVolatility.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImpliedVolatility.FieldName = "ImpliedVolatility";
            this.colImpliedVolatility.Name = "colImpliedVolatility";
            this.colImpliedVolatility.Visible = true;
            this.colImpliedVolatility.VisibleIndex = 12;
            this.colImpliedVolatility.Width = 73;
            // 
            // colModelPrice
            // 
            this.colModelPrice.Caption = "BnS P.";
            this.colModelPrice.DisplayFormat.FormatString = "#0.000";
            this.colModelPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colModelPrice.FieldName = "ModelPrice";
            this.colModelPrice.Name = "colModelPrice";
            this.colModelPrice.Visible = true;
            this.colModelPrice.VisibleIndex = 5;
            this.colModelPrice.Width = 58;
            // 
            // colUnderlinePrice
            // 
            this.colUnderlinePrice.DisplayFormat.FormatString = "#0.00";
            this.colUnderlinePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnderlinePrice.FieldName = "UnderlinePrice";
            this.colUnderlinePrice.Name = "colUnderlinePrice";
            this.colUnderlinePrice.Width = 41;
            // 
            // colHighestPrice
            // 
            this.colHighestPrice.Caption = "Highest P.";
            this.colHighestPrice.DisplayFormat.FormatString = "#0.00";
            this.colHighestPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHighestPrice.FieldName = "HighestPrice";
            this.colHighestPrice.Name = "colHighestPrice";
            this.colHighestPrice.Visible = true;
            this.colHighestPrice.VisibleIndex = 13;
            this.colHighestPrice.Width = 81;
            // 
            // colLowestPrice
            // 
            this.colLowestPrice.Caption = "Lowest P.";
            this.colLowestPrice.DisplayFormat.FormatString = "#0.00";
            this.colLowestPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLowestPrice.FieldName = "LowestPrice";
            this.colLowestPrice.Name = "colLowestPrice";
            this.colLowestPrice.Visible = true;
            this.colLowestPrice.VisibleIndex = 14;
            this.colLowestPrice.Width = 79;
            // 
            // colOpeningPrice
            // 
            this.colOpeningPrice.Caption = "Opening P.";
            this.colOpeningPrice.DisplayFormat.FormatString = "#0.00";
            this.colOpeningPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOpeningPrice.FieldName = "OpeningPrice";
            this.colOpeningPrice.Name = "colOpeningPrice";
            this.colOpeningPrice.Visible = true;
            this.colOpeningPrice.VisibleIndex = 15;
            this.colOpeningPrice.Width = 87;
            // 
            // colAskSize
            // 
            this.colAskSize.FieldName = "AskSize";
            this.colAskSize.Name = "colAskSize";
            this.colAskSize.Width = 20;
            // 
            // colBidSize
            // 
            this.colBidSize.FieldName = "BidSize";
            this.colBidSize.Name = "colBidSize";
            this.colBidSize.Width = 20;
            // 
            // colVolume
            // 
            this.colVolume.FieldName = "Volume";
            this.colVolume.Name = "colVolume";
            this.colVolume.Width = 20;
            // 
            // colMultiplier
            // 
            this.colMultiplier.FieldName = "Multiplier";
            this.colMultiplier.Name = "colMultiplier";
            this.colMultiplier.Width = 20;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.ReadOnly = true;
            this.colId.Width = 20;
            // 
            // colLastUpdate
            // 
            this.colLastUpdate.DisplayFormat.FormatString = "g";
            this.colLastUpdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLastUpdate.FieldName = "LastUpdate";
            this.colLastUpdate.Name = "colLastUpdate";
            this.colLastUpdate.Width = 49;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnSendOrder);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.txtQuantity);
            this.groupControl1.Controls.Add(this.rbtbuy);
            this.groupControl1.Controls.Add(this.rbtSell);
            this.groupControl1.Location = new System.Drawing.Point(5, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(480, 59);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Trading";
            // 
            // btnSendOrder
            // 
            this.btnSendOrder.Location = new System.Drawing.Point(385, 29);
            this.btnSendOrder.Name = "btnSendOrder";
            this.btnSendOrder.Size = new System.Drawing.Size(75, 23);
            this.btnSendOrder.TabIndex = 3;
            this.btnSendOrder.Text = "Send Order...";
            this.btnSendOrder.UseVisualStyleBackColor = true;
            this.btnSendOrder.Click += new System.EventHandler(this.btnSendOrder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(291, 29);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(37, 21);
            this.txtQuantity.TabIndex = 1;
            this.txtQuantity.Text = "1";
            // 
            // rbtbuy
            // 
            this.rbtbuy.AutoSize = true;
            this.rbtbuy.ForeColor = System.Drawing.Color.Green;
            this.rbtbuy.Location = new System.Drawing.Point(107, 28);
            this.rbtbuy.Name = "rbtbuy";
            this.rbtbuy.Size = new System.Drawing.Size(43, 17);
            this.rbtbuy.TabIndex = 0;
            this.rbtbuy.Text = "Buy";
            this.rbtbuy.UseVisualStyleBackColor = true;
            // 
            // rbtSell
            // 
            this.rbtSell.AutoSize = true;
            this.rbtSell.Checked = true;
            this.rbtSell.ForeColor = System.Drawing.Color.Red;
            this.rbtSell.Location = new System.Drawing.Point(20, 28);
            this.rbtSell.Name = "rbtSell";
            this.rbtSell.Size = new System.Drawing.Size(41, 17);
            this.rbtSell.TabIndex = 0;
            this.rbtSell.TabStop = true;
            this.rbtSell.Text = "Sell";
            this.rbtSell.UseVisualStyleBackColor = true;
            // 
            // OptionTradingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panel1);
            this.Name = "OptionTradingControl";
            this.Size = new System.Drawing.Size(1100, 650);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl grdOption;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewOption;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionContractOptionKey;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionContract_Symbol;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionContract_Expiry;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionContract_OptionType;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionContract_Strike;
        private DevExpress.XtraGrid.Columns.GridColumn colBasePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colLastPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colAskPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colBidPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colDelta;
        private DevExpress.XtraGrid.Columns.GridColumn colGamma;
        private DevExpress.XtraGrid.Columns.GridColumn colVega;
        private DevExpress.XtraGrid.Columns.GridColumn colTheta;
        private DevExpress.XtraGrid.Columns.GridColumn colImpliedVolatility;
        private DevExpress.XtraGrid.Columns.GridColumn colModelPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colUnderlinePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colHighestPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colLowestPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colOpeningPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colAskSize;
        private DevExpress.XtraGrid.Columns.GridColumn colBidSize;
        private DevExpress.XtraGrid.Columns.GridColumn colVolume;
        private DevExpress.XtraGrid.Columns.GridColumn colMultiplier;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdate;
        private System.Windows.Forms.BindingSource optionDataBindingSource;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Button btnSendOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.RadioButton rbtbuy;
        private System.Windows.Forms.RadioButton rbtSell;
    }
}
