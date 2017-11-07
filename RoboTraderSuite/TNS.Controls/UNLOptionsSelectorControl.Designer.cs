namespace TNS.Controls
{
    partial class UNLOptionsSelectorControl
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
            this.comBoxExpiries = new System.Windows.Forms.ComboBox();
            this.lblComboBoxLabel = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comBoxExpiries
            // 
            this.comBoxExpiries.FormattingEnabled = true;
            this.comBoxExpiries.Location = new System.Drawing.Point(122, 34);
            this.comBoxExpiries.Name = "comBoxExpiries";
            this.comBoxExpiries.Size = new System.Drawing.Size(75, 21);
            this.comBoxExpiries.TabIndex = 17;
            // 
            // lblComboBoxLabel
            // 
            this.lblComboBoxLabel.AutoSize = true;
            this.lblComboBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComboBoxLabel.ForeColor = System.Drawing.Color.Red;
            this.lblComboBoxLabel.Location = new System.Drawing.Point(38, 34);
            this.lblComboBoxLabel.Name = "lblComboBoxLabel";
            this.lblComboBoxLabel.Size = new System.Drawing.Size(63, 15);
            this.lblComboBoxLabel.TabIndex = 16;
            this.lblComboBoxLabel.Text = "Expiries:";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(294, 215);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Location = new System.Drawing.Point(203, 215);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 18;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // UNLOptionsSelectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.comBoxExpiries);
            this.Controls.Add(this.lblComboBoxLabel);
            this.Name = "UNLOptionsSelectorControl";
            this.Size = new System.Drawing.Size(392, 252);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comBoxExpiries;
        private System.Windows.Forms.Label lblComboBoxLabel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnShow;
    }
}
