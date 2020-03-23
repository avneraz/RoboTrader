namespace TNS.Controls
{
    partial class OptionsView
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.optionDataBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.optionDataBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(5, 49);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(5);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Padding = new System.Windows.Forms.Padding(5);
            this.gridControl1.Size = new System.Drawing.Size(1392, 624);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // optionDataBindingSource
            // 
            this.optionDataBindingSource.DataSource = typeof(TNS.API.ApiDataObjects.OptionData);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 2;
            this.gridView1.Name = "gridView1";
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colOptionContract_Symbol, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colOptionContract_Expiry, DevExpress.Data.ColumnSortOrder.Ascending),
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
            this.colOptionContract_Symbol.Width = 130;
            // 
            // colOptionContract_Expiry
            // 
            this.colOptionContract_Expiry.Caption = "Expiry";
            this.colOptionContract_Expiry.FieldName = "OptionContract.Expiry";
            this.colOptionContract_Expiry.Name = "colOptionContract_Expiry";
            this.colOptionContract_Expiry.Visible = true;
            this.colOptionContract_Expiry.VisibleIndex = 0;
            this.colOptionContract_Expiry.Width = 100;
            // 
            // colOptionContract_OptionType
            // 
            this.colOptionContract_OptionType.Caption = "Type";
            this.colOptionContract_OptionType.FieldName = "OptionContract.OptionType";
            this.colOptionContract_OptionType.Name = "colOptionContract_OptionType";
            this.colOptionContract_OptionType.Visible = true;
            this.colOptionContract_OptionType.VisibleIndex = 0;
            // 
            // colOptionContract_Strike
            // 
            this.colOptionContract_Strike.Caption = "Strike";
            this.colOptionContract_Strike.FieldName = "OptionContract.Strike";
            this.colOptionContract_Strike.Name = "colOptionContract_Strike";
            this.colOptionContract_Strike.Visible = true;
            this.colOptionContract_Strike.VisibleIndex = 1;
            this.colOptionContract_Strike.Width = 86;
            // 
            // colBasePrice
            // 
            this.colBasePrice.DisplayFormat.FormatString = "#0.00";
            this.colBasePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBasePrice.FieldName = "PriorClosePrice";
            this.colBasePrice.Name = "colBasePrice";
            this.colBasePrice.Visible = true;
            this.colBasePrice.VisibleIndex = 2;
            this.colBasePrice.Width = 59;
            // 
            // colLastPrice
            // 
            this.colLastPrice.DisplayFormat.FormatString = "#0.00";
            this.colLastPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLastPrice.FieldName = "LastPrice";
            this.colLastPrice.Name = "colLastPrice";
            this.colLastPrice.Visible = true;
            this.colLastPrice.VisibleIndex = 3;
            this.colLastPrice.Width = 51;
            // 
            // colAskPrice
            // 
            this.colAskPrice.DisplayFormat.FormatString = "#0.00";
            this.colAskPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAskPrice.FieldName = "Ask";
            this.colAskPrice.Name = "colAskPrice";
            this.colAskPrice.Visible = true;
            this.colAskPrice.VisibleIndex = 4;
            this.colAskPrice.Width = 51;
            // 
            // colBidPrice
            // 
            this.colBidPrice.DisplayFormat.FormatString = "#0.00";
            this.colBidPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBidPrice.FieldName = "Bid";
            this.colBidPrice.Name = "colBidPrice";
            this.colBidPrice.Visible = true;
            this.colBidPrice.VisibleIndex = 5;
            this.colBidPrice.Width = 51;
            // 
            // colDelta
            // 
            this.colDelta.DisplayFormat.FormatString = "#0.000";
            this.colDelta.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDelta.FieldName = "Delta";
            this.colDelta.Name = "colDelta";
            this.colDelta.Visible = true;
            this.colDelta.VisibleIndex = 6;
            this.colDelta.Width = 51;
            // 
            // colGamma
            // 
            this.colGamma.DisplayFormat.FormatString = "#0.000";
            this.colGamma.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGamma.FieldName = "Gamma";
            this.colGamma.Name = "colGamma";
            this.colGamma.Visible = true;
            this.colGamma.VisibleIndex = 7;
            this.colGamma.Width = 51;
            // 
            // colVega
            // 
            this.colVega.DisplayFormat.FormatString = "#0.000";
            this.colVega.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVega.FieldName = "Vega";
            this.colVega.Name = "colVega";
            this.colVega.Visible = true;
            this.colVega.VisibleIndex = 8;
            this.colVega.Width = 51;
            // 
            // colTheta
            // 
            this.colTheta.DisplayFormat.FormatString = "#0.000";
            this.colTheta.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTheta.FieldName = "Theta";
            this.colTheta.Name = "colTheta";
            this.colTheta.Visible = true;
            this.colTheta.VisibleIndex = 9;
            this.colTheta.Width = 51;
            // 
            // colImpliedVolatility
            // 
            this.colImpliedVolatility.DisplayFormat.FormatString = "#0.00%";
            this.colImpliedVolatility.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImpliedVolatility.FieldName = "ImpliedVolatility";
            this.colImpliedVolatility.Name = "colImpliedVolatility";
            this.colImpliedVolatility.Visible = true;
            this.colImpliedVolatility.VisibleIndex = 10;
            this.colImpliedVolatility.Width = 51;
            // 
            // colModelPrice
            // 
            this.colModelPrice.DisplayFormat.FormatString = "#0.000";
            this.colModelPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colModelPrice.FieldName = "ModelPrice";
            this.colModelPrice.Name = "colModelPrice";
            this.colModelPrice.Visible = true;
            this.colModelPrice.VisibleIndex = 11;
            this.colModelPrice.Width = 51;
            // 
            // colUnderlinePrice
            // 
            this.colUnderlinePrice.DisplayFormat.FormatString = "#0.00";
            this.colUnderlinePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnderlinePrice.FieldName = "LastPrice";
            this.colUnderlinePrice.Name = "colUnderlinePrice";
            this.colUnderlinePrice.Visible = true;
            this.colUnderlinePrice.VisibleIndex = 12;
            this.colUnderlinePrice.Width = 51;
            // 
            // colHighestPrice
            // 
            this.colHighestPrice.DisplayFormat.FormatString = "#0.00";
            this.colHighestPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHighestPrice.FieldName = "HighestPrice";
            this.colHighestPrice.Name = "colHighestPrice";
            this.colHighestPrice.Visible = true;
            this.colHighestPrice.VisibleIndex = 13;
            this.colHighestPrice.Width = 51;
            // 
            // colLowestPrice
            // 
            this.colLowestPrice.DisplayFormat.FormatString = "#0.00";
            this.colLowestPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLowestPrice.FieldName = "LowestPrice";
            this.colLowestPrice.Name = "colLowestPrice";
            this.colLowestPrice.Visible = true;
            this.colLowestPrice.VisibleIndex = 14;
            this.colLowestPrice.Width = 51;
            // 
            // colOpeningPrice
            // 
            this.colOpeningPrice.DisplayFormat.FormatString = "#0.00";
            this.colOpeningPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOpeningPrice.FieldName = "OpeningPrice";
            this.colOpeningPrice.Name = "colOpeningPrice";
            this.colOpeningPrice.Visible = true;
            this.colOpeningPrice.VisibleIndex = 15;
            this.colOpeningPrice.Width = 51;
            // 
            // colAskSize
            // 
            this.colAskSize.FieldName = "AskSize";
            this.colAskSize.Name = "colAskSize";
            this.colAskSize.Visible = true;
            this.colAskSize.VisibleIndex = 16;
            this.colAskSize.Width = 51;
            // 
            // colBidSize
            // 
            this.colBidSize.FieldName = "BidSize";
            this.colBidSize.Name = "colBidSize";
            this.colBidSize.Visible = true;
            this.colBidSize.VisibleIndex = 17;
            this.colBidSize.Width = 51;
            // 
            // colVolume
            // 
            this.colVolume.FieldName = "Volume";
            this.colVolume.Name = "colVolume";
            this.colVolume.Visible = true;
            this.colVolume.VisibleIndex = 18;
            this.colVolume.Width = 51;
            // 
            // colMultiplier
            // 
            this.colMultiplier.FieldName = "Multiplier";
            this.colMultiplier.Name = "colMultiplier";
            this.colMultiplier.Visible = true;
            this.colMultiplier.VisibleIndex = 19;
            this.colMultiplier.Width = 51;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.ReadOnly = true;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 20;
            this.colId.Width = 76;
            // 
            // colLastUpdate
            // 
            this.colLastUpdate.DisplayFormat.FormatString = "g";
            this.colLastUpdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLastUpdate.FieldName = "LastUpdate";
            this.colLastUpdate.Name = "colLastUpdate";
            this.colLastUpdate.Visible = true;
            this.colLastUpdate.VisibleIndex = 21;
            this.colLastUpdate.Width = 123;
            // 
            // OptionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.gridControl1);
            this.Name = "OptionsView";
            this.Size = new System.Drawing.Size(1368, 678);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource optionDataBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionContractOptionKey;
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
        private DevExpress.XtraGrid.Columns.GridColumn colOptionContract_OptionType;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionContract_Strike;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionContract_Expiry;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionContract_Symbol;
    }
}
