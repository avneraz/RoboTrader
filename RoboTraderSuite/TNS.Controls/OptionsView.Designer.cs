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
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.optionDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colDelta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGamma = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTheta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImpliedVolatility = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModelPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnderlinePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHighestPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLowestPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBasePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOpeningPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAskPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBidPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAskSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBidSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMultiplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptionContractOptionKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnLoadOptions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.optionDataBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(5, 49);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(5);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Padding = new System.Windows.Forms.Padding(5);
            this.gridControl1.Size = new System.Drawing.Size(949, 596);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOptionContractOptionKey,
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
            this.gridView1.Name = "gridView1";
            // 
            // optionDataBindingSource
            // 
            this.optionDataBindingSource.DataSource = typeof(TNS.API.ApiDataObjects.OptionData);
            // 
            // colDelta
            // 
            this.colDelta.FieldName = "Delta";
            this.colDelta.Name = "colDelta";
            this.colDelta.Visible = true;
            this.colDelta.VisibleIndex = 5;
            this.colDelta.Width = 43;
            // 
            // colGamma
            // 
            this.colGamma.FieldName = "Gamma";
            this.colGamma.Name = "colGamma";
            this.colGamma.Visible = true;
            this.colGamma.VisibleIndex = 6;
            this.colGamma.Width = 43;
            // 
            // colVega
            // 
            this.colVega.FieldName = "Vega";
            this.colVega.Name = "colVega";
            this.colVega.Visible = true;
            this.colVega.VisibleIndex = 7;
            this.colVega.Width = 43;
            // 
            // colTheta
            // 
            this.colTheta.FieldName = "Theta";
            this.colTheta.Name = "colTheta";
            this.colTheta.Visible = true;
            this.colTheta.VisibleIndex = 8;
            this.colTheta.Width = 43;
            // 
            // colImpliedVolatility
            // 
            this.colImpliedVolatility.FieldName = "ImpliedVolatility";
            this.colImpliedVolatility.Name = "colImpliedVolatility";
            this.colImpliedVolatility.Visible = true;
            this.colImpliedVolatility.VisibleIndex = 4;
            this.colImpliedVolatility.Width = 43;
            // 
            // colModelPrice
            // 
            this.colModelPrice.FieldName = "ModelPrice";
            this.colModelPrice.Name = "colModelPrice";
            this.colModelPrice.Visible = true;
            this.colModelPrice.VisibleIndex = 3;
            this.colModelPrice.Width = 43;
            // 
            // colUnderlinePrice
            // 
            this.colUnderlinePrice.FieldName = "UnderlinePrice";
            this.colUnderlinePrice.Name = "colUnderlinePrice";
            this.colUnderlinePrice.Visible = true;
            this.colUnderlinePrice.VisibleIndex = 9;
            this.colUnderlinePrice.Width = 43;
            // 
            // colLastPrice
            // 
            this.colLastPrice.FieldName = "LastPrice";
            this.colLastPrice.Name = "colLastPrice";
            this.colLastPrice.Visible = true;
            this.colLastPrice.VisibleIndex = 2;
            this.colLastPrice.Width = 43;
            // 
            // colHighestPrice
            // 
            this.colHighestPrice.FieldName = "HighestPrice";
            this.colHighestPrice.Name = "colHighestPrice";
            this.colHighestPrice.Visible = true;
            this.colHighestPrice.VisibleIndex = 10;
            this.colHighestPrice.Width = 43;
            // 
            // colLowestPrice
            // 
            this.colLowestPrice.FieldName = "LowestPrice";
            this.colLowestPrice.Name = "colLowestPrice";
            this.colLowestPrice.Visible = true;
            this.colLowestPrice.VisibleIndex = 11;
            this.colLowestPrice.Width = 43;
            // 
            // colBasePrice
            // 
            this.colBasePrice.FieldName = "BasePrice";
            this.colBasePrice.Name = "colBasePrice";
            this.colBasePrice.Visible = true;
            this.colBasePrice.VisibleIndex = 1;
            this.colBasePrice.Width = 43;
            // 
            // colOpeningPrice
            // 
            this.colOpeningPrice.FieldName = "OpeningPrice";
            this.colOpeningPrice.Name = "colOpeningPrice";
            this.colOpeningPrice.Visible = true;
            this.colOpeningPrice.VisibleIndex = 12;
            this.colOpeningPrice.Width = 43;
            // 
            // colAskPrice
            // 
            this.colAskPrice.FieldName = "AskPrice";
            this.colAskPrice.Name = "colAskPrice";
            this.colAskPrice.Visible = true;
            this.colAskPrice.VisibleIndex = 13;
            this.colAskPrice.Width = 43;
            // 
            // colBidPrice
            // 
            this.colBidPrice.FieldName = "BidPrice";
            this.colBidPrice.Name = "colBidPrice";
            this.colBidPrice.Visible = true;
            this.colBidPrice.VisibleIndex = 14;
            this.colBidPrice.Width = 43;
            // 
            // colAskSize
            // 
            this.colAskSize.FieldName = "AskSize";
            this.colAskSize.Name = "colAskSize";
            this.colAskSize.Visible = true;
            this.colAskSize.VisibleIndex = 15;
            this.colAskSize.Width = 43;
            // 
            // colBidSize
            // 
            this.colBidSize.FieldName = "BidSize";
            this.colBidSize.Name = "colBidSize";
            this.colBidSize.Visible = true;
            this.colBidSize.VisibleIndex = 16;
            this.colBidSize.Width = 43;
            // 
            // colVolume
            // 
            this.colVolume.FieldName = "Volume";
            this.colVolume.Name = "colVolume";
            this.colVolume.Visible = true;
            this.colVolume.VisibleIndex = 17;
            this.colVolume.Width = 43;
            // 
            // colMultiplier
            // 
            this.colMultiplier.FieldName = "Multiplier";
            this.colMultiplier.Name = "colMultiplier";
            this.colMultiplier.Visible = true;
            this.colMultiplier.VisibleIndex = 18;
            this.colMultiplier.Width = 43;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.ReadOnly = true;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 19;
            this.colId.Width = 43;
            // 
            // colLastUpdate
            // 
            this.colLastUpdate.FieldName = "LastUpdate";
            this.colLastUpdate.Name = "colLastUpdate";
            this.colLastUpdate.Visible = true;
            this.colLastUpdate.VisibleIndex = 20;
            this.colLastUpdate.Width = 68;
            // 
            // colOptionContractOptionKey
            // 
            this.colOptionContractOptionKey.Caption = "Op. Key";
            this.colOptionContractOptionKey.FieldName = "OptionContract.OptionKey";
            this.colOptionContractOptionKey.Name = "colOptionContractOptionKey";
            this.colOptionContractOptionKey.Visible = true;
            this.colOptionContractOptionKey.VisibleIndex = 0;
            this.colOptionContractOptionKey.Width = 56;
            // 
            // btnLoadOptions
            // 
            this.btnLoadOptions.Location = new System.Drawing.Point(5, 13);
            this.btnLoadOptions.Name = "btnLoadOptions";
            this.btnLoadOptions.Size = new System.Drawing.Size(88, 23);
            this.btnLoadOptions.TabIndex = 1;
            this.btnLoadOptions.Text = "Load Options";
            this.btnLoadOptions.UseVisualStyleBackColor = true;
            this.btnLoadOptions.Click += new System.EventHandler(this.btnLoadOptions_Click);
            // 
            // OptionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.btnLoadOptions);
            this.Controls.Add(this.gridControl1);
            this.Name = "OptionsView";
            this.Size = new System.Drawing.Size(959, 650);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionDataBindingSource)).EndInit();
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
        private System.Windows.Forms.Button btnLoadOptions;
    }
}
