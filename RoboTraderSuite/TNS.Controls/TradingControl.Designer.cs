namespace TNS.Controls
{
    partial class TradingControl
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
            this.numOptionsCount = new System.Windows.Forms.NumericUpDown();
            this.lblCouplesToCloseLabel = new System.Windows.Forms.Label();
            this.btnSubmitTrading = new System.Windows.Forms.Button();
            this.rgpSellOrBuy = new DevExpress.XtraEditors.RadioGroup();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblTradingDescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numOptionsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgpSellOrBuy.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // numOptionsCount
            // 
            this.numOptionsCount.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.numOptionsCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numOptionsCount.Location = new System.Drawing.Point(110, 76);
            this.numOptionsCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numOptionsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOptionsCount.Name = "numOptionsCount";
            this.numOptionsCount.Size = new System.Drawing.Size(46, 20);
            this.numOptionsCount.TabIndex = 12;
            this.numOptionsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOptionsCount.ValueChanged += new System.EventHandler(this.numOptionsCount_ValueChanged);
            // 
            // lblCouplesToCloseLabel
            // 
            this.lblCouplesToCloseLabel.AutoSize = true;
            this.lblCouplesToCloseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCouplesToCloseLabel.ForeColor = System.Drawing.Color.Red;
            this.lblCouplesToCloseLabel.Location = new System.Drawing.Point(13, 78);
            this.lblCouplesToCloseLabel.Name = "lblCouplesToCloseLabel";
            this.lblCouplesToCloseLabel.Size = new System.Drawing.Size(81, 15);
            this.lblCouplesToCloseLabel.TabIndex = 11;
            this.lblCouplesToCloseLabel.Text = "Option Count:";
            // 
            // btnSubmitTrading
            // 
            this.btnSubmitTrading.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSubmitTrading.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSubmitTrading.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSubmitTrading.ForeColor = System.Drawing.Color.White;
            this.btnSubmitTrading.Location = new System.Drawing.Point(349, 184);
            this.btnSubmitTrading.Name = "btnSubmitTrading";
            this.btnSubmitTrading.Size = new System.Drawing.Size(67, 23);
            this.btnSubmitTrading.TabIndex = 13;
            this.btnSubmitTrading.Text = "Submit";
            this.btnSubmitTrading.UseVisualStyleBackColor = false;
            this.btnSubmitTrading.Click += new System.EventHandler(this.btnSubmitTrading_Click);
            // 
            // rgpSellOrBuy
            // 
            this.rgpSellOrBuy.Location = new System.Drawing.Point(273, 62);
            this.rgpSellOrBuy.Name = "rgpSellOrBuy";
            this.rgpSellOrBuy.Properties.Appearance.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rgpSellOrBuy.Properties.Appearance.Options.UseBackColor = true;
            this.rgpSellOrBuy.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.rgpSellOrBuy.Properties.ColumnIndent = 6;
            this.rgpSellOrBuy.Properties.Columns = 2;
            this.rgpSellOrBuy.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Sell"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Buy")});
            this.rgpSellOrBuy.Properties.ItemsLayout = DevExpress.XtraEditors.RadioGroupItemsLayout.Column;
            this.rgpSellOrBuy.Properties.PropertiesChanged += new System.EventHandler(this.rgpSellOrBuy_Properties_PropertiesChanged);
            this.rgpSellOrBuy.Size = new System.Drawing.Size(143, 46);
            this.rgpSellOrBuy.TabIndex = 14;
            this.rgpSellOrBuy.SelectedIndexChanged += new System.EventHandler(this.rgpSellOrBuy_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(258, 184);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.Color.Navy;
            this.lblCaption.Location = new System.Drawing.Point(20, 15);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(396, 23);
            this.lblCaption.TabIndex = 11;
            this.lblCaption.Text = "Caption:";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTradingDescription
            // 
            this.lblTradingDescription.BackColor = System.Drawing.SystemColors.Info;
            this.lblTradingDescription.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTradingDescription.ForeColor = System.Drawing.Color.Red;
            this.lblTradingDescription.Location = new System.Drawing.Point(155, 143);
            this.lblTradingDescription.Name = "lblTradingDescription";
            this.lblTradingDescription.Size = new System.Drawing.Size(261, 23);
            this.lblTradingDescription.TabIndex = 11;
            this.lblTradingDescription.Text = "TradingDescription";
            this.lblTradingDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(13, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Trading Description:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(16, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 3);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(16, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 3);
            this.panel2.TabIndex = 15;
            // 
            // TradingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rgpSellOrBuy);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmitTrading);
            this.Controls.Add(this.numOptionsCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTradingDescription);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.lblCouplesToCloseLabel);
            this.Name = "TradingControl";
            this.Size = new System.Drawing.Size(450, 258);
            ((System.ComponentModel.ISupportInitialize)(this.numOptionsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgpSellOrBuy.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numOptionsCount;
        private System.Windows.Forms.Label lblCouplesToCloseLabel;
        private System.Windows.Forms.Button btnSubmitTrading;
        private DevExpress.XtraEditors.RadioGroup rgpSellOrBuy;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label lblTradingDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
