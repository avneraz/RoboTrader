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
            ((System.ComponentModel.ISupportInitialize)(this.numOptionsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgpSellOrBuy.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // numOptionsCount
            // 
            this.numOptionsCount.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.numOptionsCount.Location = new System.Drawing.Point(135, 62);
            this.numOptionsCount.Name = "numOptionsCount";
            this.numOptionsCount.Size = new System.Drawing.Size(53, 20);
            this.numOptionsCount.TabIndex = 12;
            this.numOptionsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCouplesToCloseLabel
            // 
            this.lblCouplesToCloseLabel.AutoSize = true;
            this.lblCouplesToCloseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCouplesToCloseLabel.ForeColor = System.Drawing.Color.Red;
            this.lblCouplesToCloseLabel.Location = new System.Drawing.Point(13, 62);
            this.lblCouplesToCloseLabel.Name = "lblCouplesToCloseLabel";
            this.lblCouplesToCloseLabel.Size = new System.Drawing.Size(94, 15);
            this.lblCouplesToCloseLabel.TabIndex = 11;
            this.lblCouplesToCloseLabel.Text = "Option Count:";
            // 
            // btnSubmitTrading
            // 
            this.btnSubmitTrading.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSubmitTrading.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSubmitTrading.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSubmitTrading.ForeColor = System.Drawing.Color.White;
            this.btnSubmitTrading.Location = new System.Drawing.Point(300, 126);
            this.btnSubmitTrading.Name = "btnSubmitTrading";
            this.btnSubmitTrading.Size = new System.Drawing.Size(67, 23);
            this.btnSubmitTrading.TabIndex = 13;
            this.btnSubmitTrading.Text = "Submit";
            this.btnSubmitTrading.UseVisualStyleBackColor = false;
            this.btnSubmitTrading.Click += new System.EventHandler(this.btnSubmitTrading_Click);
            // 
            // rgpSellOrBuy
            // 
            this.rgpSellOrBuy.Location = new System.Drawing.Point(16, 103);
            this.rgpSellOrBuy.Name = "rgpSellOrBuy";
            this.rgpSellOrBuy.Properties.Appearance.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rgpSellOrBuy.Properties.Appearance.Options.UseBackColor = true;
            this.rgpSellOrBuy.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.rgpSellOrBuy.Properties.Columns = 2;
            this.rgpSellOrBuy.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Sell"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Buy")});
            this.rgpSellOrBuy.Properties.PropertiesChanged += new System.EventHandler(this.rgpSellOrBuy_Properties_PropertiesChanged);
            this.rgpSellOrBuy.Size = new System.Drawing.Size(172, 46);
            this.rgpSellOrBuy.TabIndex = 14;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(208, 126);
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
            this.lblCaption.Location = new System.Drawing.Point(13, 12);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(354, 26);
            this.lblCaption.TabIndex = 11;
            this.lblCaption.Text = "Option Count:";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCaption.Visible = false;
            // 
            // TradingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.rgpSellOrBuy);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmitTrading);
            this.Controls.Add(this.numOptionsCount);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.lblCouplesToCloseLabel);
            this.Name = "TradingControl";
            this.Size = new System.Drawing.Size(402, 212);
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
    }
}
