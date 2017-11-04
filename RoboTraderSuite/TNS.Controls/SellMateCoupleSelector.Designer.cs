namespace TNS.Controls
{
    partial class SellMateCoupleSelector
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
            this.numCouplesToSell = new System.Windows.Forms.NumericUpDown();
            this.lblCouplesCountLabel = new System.Windows.Forms.Label();
            this.grpUNLSummary = new System.Windows.Forms.GroupBox();
            this.lblTotalDeltaLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSingleCount = new System.Windows.Forms.Label();
            this.marginDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblMateCoupleCount = new System.Windows.Forms.Label();
            this.lblTotalDelta = new System.Windows.Forms.Label();
            this.unlTradingDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblMarginPerCouple = new System.Windows.Forms.Label();
            this.lblMargin = new System.Windows.Forms.Label();
            this.lblSingleType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comBoxExpiries = new System.Windows.Forms.ComboBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblComboBoxLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSellMateCouples = new DevExpress.XtraEditors.SimpleButton();
            this.btnOptimizePosition = new DevExpress.XtraEditors.SimpleButton();
            this.btnOptimizePartlyPosition = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.numCouplesToSell)).BeginInit();
            this.grpUNLSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marginDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unlTradingDataBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numCouplesToSell
            // 
            this.numCouplesToSell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numCouplesToSell.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.numCouplesToSell.Location = new System.Drawing.Point(179, 28);
            this.numCouplesToSell.Name = "numCouplesToSell";
            this.numCouplesToSell.Size = new System.Drawing.Size(53, 20);
            this.numCouplesToSell.TabIndex = 12;
            this.numCouplesToSell.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCouplesCountLabel
            // 
            this.lblCouplesCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCouplesCountLabel.AutoSize = true;
            this.lblCouplesCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCouplesCountLabel.ForeColor = System.Drawing.Color.Red;
            this.lblCouplesCountLabel.Location = new System.Drawing.Point(36, 28);
            this.lblCouplesCountLabel.Name = "lblCouplesCountLabel";
            this.lblCouplesCountLabel.Size = new System.Drawing.Size(104, 15);
            this.lblCouplesCountLabel.TabIndex = 11;
            this.lblCouplesCountLabel.Text = "Couples Count:";
            // 
            // grpUNLSummary
            // 
            this.grpUNLSummary.Controls.Add(this.lblTotalDeltaLabel);
            this.grpUNLSummary.Controls.Add(this.label6);
            this.grpUNLSummary.Controls.Add(this.label4);
            this.grpUNLSummary.Controls.Add(this.label2);
            this.grpUNLSummary.Controls.Add(this.lblSingleCount);
            this.grpUNLSummary.Controls.Add(this.lblMateCoupleCount);
            this.grpUNLSummary.Controls.Add(this.lblTotalDelta);
            this.grpUNLSummary.Controls.Add(this.lblMarginPerCouple);
            this.grpUNLSummary.Controls.Add(this.lblMargin);
            this.grpUNLSummary.Controls.Add(this.lblSingleType);
            this.grpUNLSummary.Controls.Add(this.label3);
            this.grpUNLSummary.Controls.Add(this.label5);
            this.grpUNLSummary.Location = new System.Drawing.Point(3, 37);
            this.grpUNLSummary.Name = "grpUNLSummary";
            this.grpUNLSummary.Size = new System.Drawing.Size(219, 163);
            this.grpUNLSummary.TabIndex = 13;
            this.grpUNLSummary.TabStop = false;
            this.grpUNLSummary.Text = "UNL Summary";
            // 
            // lblTotalDeltaLabel
            // 
            this.lblTotalDeltaLabel.AutoSize = true;
            this.lblTotalDeltaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDeltaLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotalDeltaLabel.Location = new System.Drawing.Point(6, 136);
            this.lblTotalDeltaLabel.Name = "lblTotalDeltaLabel";
            this.lblTotalDeltaLabel.Size = new System.Drawing.Size(31, 15);
            this.lblTotalDeltaLabel.TabIndex = 3;
            this.lblTotalDeltaLabel.Text = "Σ δ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(6, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Margin Per Couple:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(6, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Single Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mate Couple #:";
            // 
            // lblSingleCount
            // 
            this.lblSingleCount.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblSingleCount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.marginDataBindingSource, "SingleCount", true));
            this.lblSingleCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSingleCount.ForeColor = System.Drawing.Color.Green;
            this.lblSingleCount.Location = new System.Drawing.Point(150, 60);
            this.lblSingleCount.Name = "lblSingleCount";
            this.lblSingleCount.Size = new System.Drawing.Size(70, 15);
            this.lblSingleCount.TabIndex = 3;
            this.lblSingleCount.Text = "1";
            this.lblSingleCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // marginDataBindingSource
            // 
            this.marginDataBindingSource.DataSource = typeof(TNS.API.ApiDataObjects.MarginData);
            // 
            // lblMateCoupleCount
            // 
            this.lblMateCoupleCount.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblMateCoupleCount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.marginDataBindingSource, "MateCouplesCount", true));
            this.lblMateCoupleCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMateCoupleCount.ForeColor = System.Drawing.Color.Green;
            this.lblMateCoupleCount.Location = new System.Drawing.Point(150, 41);
            this.lblMateCoupleCount.Name = "lblMateCoupleCount";
            this.lblMateCoupleCount.Size = new System.Drawing.Size(70, 15);
            this.lblMateCoupleCount.TabIndex = 3;
            this.lblMateCoupleCount.Text = "15";
            this.lblMateCoupleCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalDelta
            // 
            this.lblTotalDelta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblTotalDelta.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.unlTradingDataBindingSource, "DeltaTotal", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "N0"));
            this.lblTotalDelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDelta.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotalDelta.Location = new System.Drawing.Point(150, 136);
            this.lblTotalDelta.Name = "lblTotalDelta";
            this.lblTotalDelta.Size = new System.Drawing.Size(70, 15);
            this.lblTotalDelta.TabIndex = 3;
            this.lblTotalDelta.Text = "-25";
            this.lblTotalDelta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // unlTradingDataBindingSource
            // 
            this.unlTradingDataBindingSource.DataSource = typeof(TNS.API.ApiDataObjects.UnlTradingData);
            // 
            // lblMarginPerCouple
            // 
            this.lblMarginPerCouple.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblMarginPerCouple.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.marginDataBindingSource, "MarginPerCouple", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.lblMarginPerCouple.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarginPerCouple.ForeColor = System.Drawing.Color.Green;
            this.lblMarginPerCouple.Location = new System.Drawing.Point(150, 102);
            this.lblMarginPerCouple.Name = "lblMarginPerCouple";
            this.lblMarginPerCouple.Size = new System.Drawing.Size(70, 15);
            this.lblMarginPerCouple.TabIndex = 3;
            this.lblMarginPerCouple.Text = "35,140";
            this.lblMarginPerCouple.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMargin
            // 
            this.lblMargin.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblMargin.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.unlTradingDataBindingSource, "Margin", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "C0"));
            this.lblMargin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMargin.ForeColor = System.Drawing.Color.Green;
            this.lblMargin.Location = new System.Drawing.Point(150, 19);
            this.lblMargin.Name = "lblMargin";
            this.lblMargin.Size = new System.Drawing.Size(70, 15);
            this.lblMargin.TabIndex = 3;
            this.lblMargin.Text = "112,205";
            this.lblMargin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSingleType
            // 
            this.lblSingleType.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblSingleType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.marginDataBindingSource, "SingleOptionType", true));
            this.lblSingleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSingleType.ForeColor = System.Drawing.Color.Green;
            this.lblSingleType.Location = new System.Drawing.Point(150, 81);
            this.lblSingleType.Name = "lblSingleType";
            this.lblSingleType.Size = new System.Drawing.Size(70, 15);
            this.lblSingleType.TabIndex = 3;
            this.lblSingleType.Text = "Call";
            this.lblSingleType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Single #:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Margin:";
            // 
            // comBoxExpiries
            // 
            this.comBoxExpiries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comBoxExpiries.FormattingEnabled = true;
            this.comBoxExpiries.Location = new System.Drawing.Point(157, 62);
            this.comBoxExpiries.Name = "comBoxExpiries";
            this.comBoxExpiries.Size = new System.Drawing.Size(75, 21);
            this.comBoxExpiries.TabIndex = 15;
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Blue;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(596, 28);
            this.lblHeader.TabIndex = 16;
            this.lblHeader.Text = "AMZN - 971.25 Margin = 112,205";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblComboBoxLabel
            // 
            this.lblComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComboBoxLabel.AutoSize = true;
            this.lblComboBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComboBoxLabel.ForeColor = System.Drawing.Color.Red;
            this.lblComboBoxLabel.Location = new System.Drawing.Point(36, 62);
            this.lblComboBoxLabel.Name = "lblComboBoxLabel";
            this.lblComboBoxLabel.Size = new System.Drawing.Size(63, 15);
            this.lblComboBoxLabel.TabIndex = 11;
            this.lblComboBoxLabel.Text = "Expiries:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comBoxExpiries);
            this.groupBox1.Controls.Add(this.lblCouplesCountLabel);
            this.groupBox1.Controls.Add(this.lblComboBoxLabel);
            this.groupBox1.Controls.Add(this.numCouplesToSell);
            this.groupBox1.Location = new System.Drawing.Point(334, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 163);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Activities";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(442, 304);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 35);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSellMateCouples
            // 
            this.btnSellMateCouples.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSellMateCouples.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSellMateCouples.Appearance.BackColor2 = System.Drawing.Color.Red;
            this.btnSellMateCouples.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSellMateCouples.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnSellMateCouples.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSellMateCouples.Appearance.Options.UseBackColor = true;
            this.btnSellMateCouples.Appearance.Options.UseBorderColor = true;
            this.btnSellMateCouples.Appearance.Options.UseFont = true;
            this.btnSellMateCouples.Appearance.Options.UseForeColor = true;
            this.btnSellMateCouples.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnSellMateCouples.Location = new System.Drawing.Point(290, 304);
            this.btnSellMateCouples.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnSellMateCouples.Name = "btnSellMateCouples";
            this.btnSellMateCouples.Size = new System.Drawing.Size(124, 35);
            this.btnSellMateCouples.TabIndex = 18;
            this.btnSellMateCouples.Text = "Sell Mate Couple";
            this.btnSellMateCouples.ToolTip = "יוסף";
            this.btnSellMateCouples.Click += new System.EventHandler(this.btnSubmitCloseCouples_Click);
            // 
            // btnOptimizePosition
            // 
            this.btnOptimizePosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptimizePosition.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnOptimizePosition.Appearance.BackColor2 = System.Drawing.Color.Red;
            this.btnOptimizePosition.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnOptimizePosition.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnOptimizePosition.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnOptimizePosition.Appearance.Options.UseBackColor = true;
            this.btnOptimizePosition.Appearance.Options.UseBorderColor = true;
            this.btnOptimizePosition.Appearance.Options.UseFont = true;
            this.btnOptimizePosition.Appearance.Options.UseForeColor = true;
            this.btnOptimizePosition.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnOptimizePosition.Location = new System.Drawing.Point(27, 225);
            this.btnOptimizePosition.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnOptimizePosition.Name = "btnOptimizePosition";
            this.btnOptimizePosition.Size = new System.Drawing.Size(124, 35);
            this.btnOptimizePosition.TabIndex = 18;
            this.btnOptimizePosition.Text = "Optimize Position";
            this.btnOptimizePosition.ToolTip = "יוסף";
            this.btnOptimizePosition.Click += new System.EventHandler(this.btnOptimizePosition_Click);
            // 
            // btnOptimizePartlyPosition
            // 
            this.btnOptimizePartlyPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptimizePartlyPosition.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnOptimizePartlyPosition.Appearance.BackColor2 = System.Drawing.Color.Red;
            this.btnOptimizePartlyPosition.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnOptimizePartlyPosition.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnOptimizePartlyPosition.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnOptimizePartlyPosition.Appearance.Options.UseBackColor = true;
            this.btnOptimizePartlyPosition.Appearance.Options.UseBorderColor = true;
            this.btnOptimizePartlyPosition.Appearance.Options.UseFont = true;
            this.btnOptimizePartlyPosition.Appearance.Options.UseForeColor = true;
            this.btnOptimizePartlyPosition.Appearance.Options.UseTextOptions = true;
            this.btnOptimizePartlyPosition.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnOptimizePartlyPosition.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnOptimizePartlyPosition.Location = new System.Drawing.Point(178, 225);
            this.btnOptimizePartlyPosition.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnOptimizePartlyPosition.Name = "btnOptimizePartlyPosition";
            this.btnOptimizePartlyPosition.Size = new System.Drawing.Size(124, 35);
            this.btnOptimizePartlyPosition.TabIndex = 18;
            this.btnOptimizePartlyPosition.Text = "Optimize Partly Position";
            this.btnOptimizePartlyPosition.ToolTip = "יוסף";
            this.btnOptimizePartlyPosition.Click += new System.EventHandler(this.btnOptimizePartlyPosition_Click);
            // 
            // SellMateCoupleSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOptimizePartlyPosition);
            this.Controls.Add(this.btnOptimizePosition);
            this.Controls.Add(this.btnSellMateCouples);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpUNLSummary);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblHeader);
            this.MinimumSize = new System.Drawing.Size(438, 168);
            this.Name = "SellMateCoupleSelector";
            this.Size = new System.Drawing.Size(596, 366);
            this.Load += new System.EventHandler(this.SellMateCoupleSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCouplesToSell)).EndInit();
            this.grpUNLSummary.ResumeLayout(false);
            this.grpUNLSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marginDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unlTradingDataBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numCouplesToSell;
        private System.Windows.Forms.Label lblCouplesCountLabel;
        private System.Windows.Forms.BindingSource marginDataBindingSource;
        private System.Windows.Forms.BindingSource unlTradingDataBindingSource;
        private System.Windows.Forms.GroupBox grpUNLSummary;
        private System.Windows.Forms.Label lblTotalDeltaLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSingleCount;
        private System.Windows.Forms.Label lblMateCoupleCount;
        private System.Windows.Forms.Label lblTotalDelta;
        private System.Windows.Forms.Label lblMarginPerCouple;
        private System.Windows.Forms.Label lblMargin;
        private System.Windows.Forms.Label lblSingleType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comBoxExpiries;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblComboBoxLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSellMateCouples;
        private DevExpress.XtraEditors.SimpleButton btnOptimizePosition;
        private DevExpress.XtraEditors.SimpleButton btnOptimizePartlyPosition;
    }
}
