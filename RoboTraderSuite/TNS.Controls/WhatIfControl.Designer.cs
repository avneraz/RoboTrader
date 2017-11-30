namespace TNS.Controls
{
    partial class WhatIfControl
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCalculate = new DevExpress.XtraEditors.SimpleButton();
            this.lblHeader = new System.Windows.Forms.Label();
            this.unlTradingDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comBoxExpiries = new System.Windows.Forms.ComboBox();
            this.lblComboBoxLabel = new System.Windows.Forms.Label();
            this.gridUTD = new DevExpress.XtraGrid.GridControl();
            this.gridViewUTD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIVWeightedAvg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeltaTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGammaTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThetaTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVegaTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarketValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPnLTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaxAllowedMargin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMargin = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.unlTradingDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUTD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUTD)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(742, 444);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 31);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculate.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnCalculate.Appearance.BackColor2 = System.Drawing.Color.Red;
            this.btnCalculate.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCalculate.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnCalculate.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.Appearance.Options.UseBackColor = true;
            this.btnCalculate.Appearance.Options.UseBorderColor = true;
            this.btnCalculate.Appearance.Options.UseFont = true;
            this.btnCalculate.Appearance.Options.UseForeColor = true;
            this.btnCalculate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnCalculate.Location = new System.Drawing.Point(635, 444);
            this.btnCalculate.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(84, 31);
            this.btnCalculate.TabIndex = 19;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.ToolTip = "יוסף";
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Blue;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(847, 28);
            this.lblHeader.TabIndex = 20;
            this.lblHeader.Text = "AMZN - 971.25 Margin = 112,205";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // unlTradingDataBindingSource
            // 
            this.unlTradingDataBindingSource.DataSource = typeof(TNS.API.ApiDataObjects.UnlTradingData);
            // 
            // comBoxExpiries
            // 
            this.comBoxExpiries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comBoxExpiries.FormattingEnabled = true;
            this.comBoxExpiries.Location = new System.Drawing.Point(751, 56);
            this.comBoxExpiries.Name = "comBoxExpiries";
            this.comBoxExpiries.Size = new System.Drawing.Size(75, 21);
            this.comBoxExpiries.TabIndex = 22;
            // 
            // lblComboBoxLabel
            // 
            this.lblComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComboBoxLabel.AutoSize = true;
            this.lblComboBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComboBoxLabel.ForeColor = System.Drawing.Color.Red;
            this.lblComboBoxLabel.Location = new System.Drawing.Point(675, 59);
            this.lblComboBoxLabel.Name = "lblComboBoxLabel";
            this.lblComboBoxLabel.Size = new System.Drawing.Size(63, 15);
            this.lblComboBoxLabel.TabIndex = 21;
            this.lblComboBoxLabel.Text = "Expiries:";
            // 
            // gridUTD
            // 
            this.gridUTD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUTD.DataSource = this.unlTradingDataBindingSource;
            this.gridUTD.Location = new System.Drawing.Point(3, 96);
            this.gridUTD.MainView = this.gridViewUTD;
            this.gridUTD.Name = "gridUTD";
            this.gridUTD.Size = new System.Drawing.Size(841, 264);
            this.gridUTD.TabIndex = 23;
            this.gridUTD.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewUTD});
            // 
            // gridViewUTD
            // 
            this.gridViewUTD.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTitle,
            this.colLastPrice,
            this.colIVWeightedAvg,
            this.colDeltaTotal,
            this.colGammaTotal,
            this.colThetaTotal,
            this.colVegaTotal,
            this.colMarketValue,
            this.colCostTotal,
            this.colPnLTotal,
            this.colMaxAllowedMargin,
            this.colMargin});
            this.gridViewUTD.GridControl = this.gridUTD;
            this.gridViewUTD.Name = "gridViewUTD";
            this.gridViewUTD.ViewCaptionHeight = 50;
            // 
            // colTitle
            // 
            this.colTitle.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTitle.AppearanceHeader.FontSizeDelta = 1;
            this.colTitle.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colTitle.AppearanceHeader.Options.UseFont = true;
            this.colTitle.AppearanceHeader.Options.UseForeColor = true;
            this.colTitle.Caption = "Title";
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 0;
            this.colTitle.Width = 121;
            // 
            // colLastPrice
            // 
            this.colLastPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colLastPrice.AppearanceHeader.FontSizeDelta = 1;
            this.colLastPrice.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colLastPrice.AppearanceHeader.Options.UseFont = true;
            this.colLastPrice.AppearanceHeader.Options.UseForeColor = true;
            this.colLastPrice.Caption = "Price";
            this.colLastPrice.FieldName = "LastPrice";
            this.colLastPrice.MaxWidth = 60;
            this.colLastPrice.MinWidth = 40;
            this.colLastPrice.Name = "colLastPrice";
            this.colLastPrice.Visible = true;
            this.colLastPrice.VisibleIndex = 1;
            this.colLastPrice.Width = 60;
            // 
            // colIVWeightedAvg
            // 
            this.colIVWeightedAvg.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colIVWeightedAvg.AppearanceHeader.FontSizeDelta = 1;
            this.colIVWeightedAvg.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colIVWeightedAvg.AppearanceHeader.Options.UseFont = true;
            this.colIVWeightedAvg.AppearanceHeader.Options.UseForeColor = true;
            this.colIVWeightedAvg.Caption = "IV W Avg";
            this.colIVWeightedAvg.DisplayFormat.FormatString = "#0.00%";
            this.colIVWeightedAvg.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIVWeightedAvg.FieldName = "IVWeightedAvg";
            this.colIVWeightedAvg.MaxWidth = 70;
            this.colIVWeightedAvg.MinWidth = 40;
            this.colIVWeightedAvg.Name = "colIVWeightedAvg";
            this.colIVWeightedAvg.Visible = true;
            this.colIVWeightedAvg.VisibleIndex = 2;
            this.colIVWeightedAvg.Width = 70;
            // 
            // colDeltaTotal
            // 
            this.colDeltaTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDeltaTotal.AppearanceHeader.FontSizeDelta = 1;
            this.colDeltaTotal.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colDeltaTotal.AppearanceHeader.Options.UseFont = true;
            this.colDeltaTotal.AppearanceHeader.Options.UseForeColor = true;
            this.colDeltaTotal.Caption = "Σ δ";
            this.colDeltaTotal.DisplayFormat.FormatString = "#,###";
            this.colDeltaTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDeltaTotal.FieldName = "DeltaTotal";
            this.colDeltaTotal.MaxWidth = 60;
            this.colDeltaTotal.MinWidth = 30;
            this.colDeltaTotal.Name = "colDeltaTotal";
            this.colDeltaTotal.OptionsColumn.ReadOnly = true;
            this.colDeltaTotal.Visible = true;
            this.colDeltaTotal.VisibleIndex = 3;
            this.colDeltaTotal.Width = 50;
            // 
            // colGammaTotal
            // 
            this.colGammaTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colGammaTotal.AppearanceHeader.FontSizeDelta = 1;
            this.colGammaTotal.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colGammaTotal.AppearanceHeader.Options.UseFont = true;
            this.colGammaTotal.AppearanceHeader.Options.UseForeColor = true;
            this.colGammaTotal.Caption = "Σ γ";
            this.colGammaTotal.DisplayFormat.FormatString = "#,###";
            this.colGammaTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGammaTotal.FieldName = "GammaTotal";
            this.colGammaTotal.MaxWidth = 60;
            this.colGammaTotal.MinWidth = 30;
            this.colGammaTotal.Name = "colGammaTotal";
            this.colGammaTotal.OptionsColumn.ReadOnly = true;
            this.colGammaTotal.Visible = true;
            this.colGammaTotal.VisibleIndex = 4;
            this.colGammaTotal.Width = 50;
            // 
            // colThetaTotal
            // 
            this.colThetaTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colThetaTotal.AppearanceHeader.FontSizeDelta = 1;
            this.colThetaTotal.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colThetaTotal.AppearanceHeader.Options.UseFont = true;
            this.colThetaTotal.AppearanceHeader.Options.UseForeColor = true;
            this.colThetaTotal.Caption = "Σ Θ";
            this.colThetaTotal.DisplayFormat.FormatString = "#,###";
            this.colThetaTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThetaTotal.FieldName = "ThetaTotal";
            this.colThetaTotal.MaxWidth = 60;
            this.colThetaTotal.MinWidth = 30;
            this.colThetaTotal.Name = "colThetaTotal";
            this.colThetaTotal.OptionsColumn.ReadOnly = true;
            this.colThetaTotal.Visible = true;
            this.colThetaTotal.VisibleIndex = 5;
            this.colThetaTotal.Width = 50;
            // 
            // colVegaTotal
            // 
            this.colVegaTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colVegaTotal.AppearanceHeader.FontSizeDelta = 1;
            this.colVegaTotal.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colVegaTotal.AppearanceHeader.Options.UseFont = true;
            this.colVegaTotal.AppearanceHeader.Options.UseForeColor = true;
            this.colVegaTotal.Caption = "Σ V";
            this.colVegaTotal.DisplayFormat.FormatString = "#,###";
            this.colVegaTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVegaTotal.FieldName = "VegaTotal";
            this.colVegaTotal.MaxWidth = 60;
            this.colVegaTotal.MinWidth = 30;
            this.colVegaTotal.Name = "colVegaTotal";
            this.colVegaTotal.OptionsColumn.ReadOnly = true;
            this.colVegaTotal.Visible = true;
            this.colVegaTotal.VisibleIndex = 6;
            this.colVegaTotal.Width = 50;
            // 
            // colMarketValue
            // 
            this.colMarketValue.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMarketValue.AppearanceHeader.FontSizeDelta = 1;
            this.colMarketValue.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colMarketValue.AppearanceHeader.Options.UseFont = true;
            this.colMarketValue.AppearanceHeader.Options.UseForeColor = true;
            this.colMarketValue.Caption = "Market";
            this.colMarketValue.DisplayFormat.FormatString = "#,###";
            this.colMarketValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMarketValue.FieldName = "MarketValue";
            this.colMarketValue.MaxWidth = 70;
            this.colMarketValue.MinWidth = 50;
            this.colMarketValue.Name = "colMarketValue";
            this.colMarketValue.OptionsColumn.ReadOnly = true;
            this.colMarketValue.Visible = true;
            this.colMarketValue.VisibleIndex = 7;
            this.colMarketValue.Width = 64;
            // 
            // colCostTotal
            // 
            this.colCostTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCostTotal.AppearanceHeader.FontSizeDelta = 1;
            this.colCostTotal.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colCostTotal.AppearanceHeader.Options.UseFont = true;
            this.colCostTotal.AppearanceHeader.Options.UseForeColor = true;
            this.colCostTotal.Caption = "Cost";
            this.colCostTotal.DisplayFormat.FormatString = "#,###";
            this.colCostTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCostTotal.FieldName = "CostTotal";
            this.colCostTotal.MaxWidth = 70;
            this.colCostTotal.MinWidth = 50;
            this.colCostTotal.Name = "colCostTotal";
            this.colCostTotal.OptionsColumn.ReadOnly = true;
            this.colCostTotal.Visible = true;
            this.colCostTotal.VisibleIndex = 8;
            this.colCostTotal.Width = 64;
            // 
            // colPnLTotal
            // 
            this.colPnLTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPnLTotal.AppearanceHeader.FontSizeDelta = 1;
            this.colPnLTotal.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colPnLTotal.AppearanceHeader.Options.UseFont = true;
            this.colPnLTotal.AppearanceHeader.Options.UseForeColor = true;
            this.colPnLTotal.Caption = "PnL";
            this.colPnLTotal.DisplayFormat.FormatString = "#,###";
            this.colPnLTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPnLTotal.FieldName = "PnLTotal";
            this.colPnLTotal.MaxWidth = 70;
            this.colPnLTotal.MinWidth = 50;
            this.colPnLTotal.Name = "colPnLTotal";
            this.colPnLTotal.OptionsColumn.ReadOnly = true;
            this.colPnLTotal.Visible = true;
            this.colPnLTotal.VisibleIndex = 9;
            this.colPnLTotal.Width = 65;
            // 
            // colMaxAllowedMargin
            // 
            this.colMaxAllowedMargin.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMaxAllowedMargin.AppearanceHeader.FontSizeDelta = 1;
            this.colMaxAllowedMargin.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colMaxAllowedMargin.AppearanceHeader.Options.UseFont = true;
            this.colMaxAllowedMargin.AppearanceHeader.Options.UseForeColor = true;
            this.colMaxAllowedMargin.Caption = "Alwd Margin";
            this.colMaxAllowedMargin.DisplayFormat.FormatString = "#,###";
            this.colMaxAllowedMargin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMaxAllowedMargin.FieldName = "MaxAllowedMargin";
            this.colMaxAllowedMargin.MaxWidth = 70;
            this.colMaxAllowedMargin.MinWidth = 50;
            this.colMaxAllowedMargin.Name = "colMaxAllowedMargin";
            this.colMaxAllowedMargin.OptionsColumn.ReadOnly = true;
            this.colMaxAllowedMargin.Visible = true;
            this.colMaxAllowedMargin.VisibleIndex = 10;
            this.colMaxAllowedMargin.Width = 67;
            // 
            // colMargin
            // 
            this.colMargin.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMargin.AppearanceHeader.FontSizeDelta = 1;
            this.colMargin.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colMargin.AppearanceHeader.Options.UseFont = true;
            this.colMargin.AppearanceHeader.Options.UseForeColor = true;
            this.colMargin.DisplayFormat.FormatString = "#,###";
            this.colMargin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMargin.FieldName = "Margin";
            this.colMargin.MaxWidth = 70;
            this.colMargin.MinWidth = 50;
            this.colMargin.Name = "colMargin";
            this.colMargin.Visible = true;
            this.colMargin.VisibleIndex = 11;
            this.colMargin.Width = 70;
            // 
            // WhatIfControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.gridUTD);
            this.Controls.Add(this.comBoxExpiries);
            this.Controls.Add(this.lblComboBoxLabel);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnCancel);
            this.MaximumSize = new System.Drawing.Size(1000, 500);
            this.MinimumSize = new System.Drawing.Size(745, 333);
            this.Name = "WhatIfControl";
            this.Size = new System.Drawing.Size(847, 497);
            this.Load += new System.EventHandler(this.WhatIfControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.unlTradingDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUTD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUTD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnCalculate;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.BindingSource unlTradingDataBindingSource;
        private System.Windows.Forms.ComboBox comBoxExpiries;
        private System.Windows.Forms.Label lblComboBoxLabel;
        private DevExpress.XtraGrid.GridControl gridUTD;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUTD;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colLastPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colIVWeightedAvg;
        private DevExpress.XtraGrid.Columns.GridColumn colDeltaTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colGammaTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colThetaTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colVegaTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colMarketValue;
        private DevExpress.XtraGrid.Columns.GridColumn colCostTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colPnLTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colMaxAllowedMargin;
        private DevExpress.XtraGrid.Columns.GridColumn colMargin;
    }
}
