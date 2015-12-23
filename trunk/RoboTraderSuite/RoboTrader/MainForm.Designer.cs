namespace TNS.RoboTrader
{
    partial class MainForm
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
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xPageAPIMessages = new DevExpress.XtraTab.XtraTabPage();
            this.apiMesagesView = new TNS.Controls.APIMesagesView();
            this.xPageAccontSummary = new DevExpress.XtraTab.XtraTabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xPageAPIMessages.SuspendLayout();
            this.xPageAccontSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMessages
            // 
            this.txtMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessages.Location = new System.Drawing.Point(0, 0);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.Size = new System.Drawing.Size(742, 515);
            this.txtMessages.TabIndex = 0;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xPageAPIMessages;
            this.xtraTabControl1.Size = new System.Drawing.Size(748, 543);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xPageAPIMessages,
            this.xPageAccontSummary});
            // 
            // xPageAPIMessages
            // 
            this.xPageAPIMessages.Controls.Add(this.apiMesagesView);
            this.xPageAPIMessages.Name = "xPageAPIMessages";
            this.xPageAPIMessages.Size = new System.Drawing.Size(716, 515);
            this.xPageAPIMessages.Text = "API Messages";
            // 
            // apiMesagesView
            // 
            this.apiMesagesView.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.apiMesagesView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.apiMesagesView.Location = new System.Drawing.Point(0, 0);
            this.apiMesagesView.Name = "apiMesagesView";
            this.apiMesagesView.Size = new System.Drawing.Size(716, 515);
            this.apiMesagesView.TabIndex = 0;
            // 
            // xPageAccontSummary
            // 
            this.xPageAccontSummary.Controls.Add(this.textBox1);
            this.xPageAccontSummary.Controls.Add(this.label1);
            this.xPageAccontSummary.Controls.Add(this.txtMessages);
            this.xPageAccontSummary.Name = "xPageAccontSummary";
            this.xPageAccontSummary.Size = new System.Drawing.Size(742, 515);
            this.xPageAccontSummary.Text = "Accont Summary";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 21);
            this.textBox1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 543);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xPageAPIMessages.ResumeLayout(false);
            this.xPageAccontSummary.ResumeLayout(false);
            this.xPageAccontSummary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessages;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xPageAPIMessages;
        private Controls.APIMesagesView apiMesagesView;
        private DevExpress.XtraTab.XtraTabPage xPageAccontSummary;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

