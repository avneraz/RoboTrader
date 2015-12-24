namespace Infra.PopUpMessages
{
    partial class PopupMessageForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblClosePopupMessage = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblClosePopupMessage
            // 
            this.lblClosePopupMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClosePopupMessage.BackColor = System.Drawing.Color.Green;
            this.lblClosePopupMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblClosePopupMessage.ForeColor = System.Drawing.Color.White;
            this.lblClosePopupMessage.Location = new System.Drawing.Point(722, 0);
            this.lblClosePopupMessage.Name = "lblClosePopupMessage";
            this.lblClosePopupMessage.Size = new System.Drawing.Size(26, 23);
            this.lblClosePopupMessage.TabIndex = 4;
            this.lblClosePopupMessage.Text = "X";
            this.lblClosePopupMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClosePopupMessage.Click += new System.EventHandler(this.lblClosePopupMessage_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Red;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Image = global::Infra.Properties.Resources.Exclamation;
            this.lblMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(748, 73);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "1100\tConnectivity between IB and TWS has been lost.";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.DoubleClick += new System.EventHandler(this.lblMessage_DoubleClick);
            // 
            // PopupMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(748, 73);
            this.ControlBox = false;
            this.Controls.Add(this.lblClosePopupMessage);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopupMessageForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PopupMessageForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblClosePopupMessage;
        protected System.Windows.Forms.Label lblMessage;

    }
}