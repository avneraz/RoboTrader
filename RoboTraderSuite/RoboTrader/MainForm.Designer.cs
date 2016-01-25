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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.xtraPageMainSecurities = new DevExpress.XtraTab.XtraTabPage();
            this.mainSecuritiesView1 = new TNS.Controls.MainSecuritiesView();
            this.xtraPageOrders = new DevExpress.XtraTab.XtraTabPage();
            this.ordersView1 = new TNS.Controls.OrdersView();
            this.btnRegisterForData = new System.Windows.Forms.Button();
            this.btnSendOrder = new System.Windows.Forms.Button();
            this.xtraPageOptions = new DevExpress.XtraTab.XtraTabPage();
            this.optionsView1 = new TNS.Controls.OptionsView();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xPageAPIMessages.SuspendLayout();
            this.xPageAccontSummary.SuspendLayout();
            this.xtraPageMainSecurities.SuspendLayout();
            this.xtraPageOrders.SuspendLayout();
            this.xtraPageOptions.SuspendLayout();
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
            this.xPageAccontSummary,
            this.xtraPageMainSecurities,
            this.xtraPageOrders,
            this.xtraPageOptions});
            // 
            // xPageAPIMessages
            // 
            this.xPageAPIMessages.Controls.Add(this.apiMesagesView);
            this.xPageAPIMessages.Name = "xPageAPIMessages";
            this.xPageAPIMessages.Size = new System.Drawing.Size(742, 515);
            this.xPageAPIMessages.Text = "API Messages";
            // 
            // apiMesagesView
            // 
            this.apiMesagesView.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.apiMesagesView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.apiMesagesView.Location = new System.Drawing.Point(0, 0);
            this.apiMesagesView.Name = "apiMesagesView";
            this.apiMesagesView.Size = new System.Drawing.Size(742, 515);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 21);
            this.textBox1.TabIndex = 2;
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
            // xtraPageMainSecurities
            // 
            this.xtraPageMainSecurities.Controls.Add(this.mainSecuritiesView1);
            this.xtraPageMainSecurities.Name = "xtraPageMainSecurities";
            this.xtraPageMainSecurities.Size = new System.Drawing.Size(742, 515);
            this.xtraPageMainSecurities.Text = "Main Securities";
            // 
            // mainSecuritiesView1
            // 
            this.mainSecuritiesView1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mainSecuritiesView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSecuritiesView1.Location = new System.Drawing.Point(0, 0);
            this.mainSecuritiesView1.Name = "mainSecuritiesView1";
            this.mainSecuritiesView1.Size = new System.Drawing.Size(742, 515);
            this.mainSecuritiesView1.TabIndex = 0;
            //this.mainSecuritiesView1.UIDataManager = null;
            // 
            // xtraPageOrders
            // 
            this.xtraPageOrders.Controls.Add(this.ordersView1);
            this.xtraPageOrders.Controls.Add(this.btnRegisterForData);
            this.xtraPageOrders.Controls.Add(this.btnSendOrder);
            this.xtraPageOrders.Name = "xtraPageOrders";
            this.xtraPageOrders.Size = new System.Drawing.Size(742, 515);
            this.xtraPageOrders.Text = "Orders";
            // 
            // ordersView1
            // 
            this.ordersView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ordersView1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ordersView1.Location = new System.Drawing.Point(11, 43);
            this.ordersView1.Name = "ordersView1";
            this.ordersView1.Size = new System.Drawing.Size(724, 465);
            this.ordersView1.TabIndex = 1;
            //this.ordersView1.UIDataManager = null;
            // 
            // btnRegisterForData
            // 
            this.btnRegisterForData.Location = new System.Drawing.Point(11, 14);
            this.btnRegisterForData.Name = "btnRegisterForData";
            this.btnRegisterForData.Size = new System.Drawing.Size(102, 23);
            this.btnRegisterForData.TabIndex = 0;
            this.btnRegisterForData.Text = "Register For Data";
            this.btnRegisterForData.UseVisualStyleBackColor = true;
            this.btnRegisterForData.Click += new System.EventHandler(this.btnRegisterForData_Click);
            // 
            // btnSendOrder
            // 
            this.btnSendOrder.Location = new System.Drawing.Point(217, 14);
            this.btnSendOrder.Name = "btnSendOrder";
            this.btnSendOrder.Size = new System.Drawing.Size(75, 23);
            this.btnSendOrder.TabIndex = 0;
            this.btnSendOrder.Text = "Send Order";
            this.btnSendOrder.UseVisualStyleBackColor = true;
            this.btnSendOrder.Click += new System.EventHandler(this.btnSendOrder_Click);
            // 
            // xtraPageOptions
            // 
            this.xtraPageOptions.Controls.Add(this.optionsView1);
            this.xtraPageOptions.Name = "xtraPageOptions";
            this.xtraPageOptions.Size = new System.Drawing.Size(742, 515);
            this.xtraPageOptions.Text = "Options";
            // 
            // optionsView1
            // 
            this.optionsView1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.optionsView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsView1.Location = new System.Drawing.Point(0, 0);
            this.optionsView1.Name = "optionsView1";
            this.optionsView1.Size = new System.Drawing.Size(742, 515);
            this.optionsView1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 543);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xPageAPIMessages.ResumeLayout(false);
            this.xPageAccontSummary.ResumeLayout(false);
            this.xPageAccontSummary.PerformLayout();
            this.xtraPageMainSecurities.ResumeLayout(false);
            this.xtraPageOrders.ResumeLayout(false);
            this.xtraPageOptions.ResumeLayout(false);
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
        private DevExpress.XtraTab.XtraTabPage xtraPageMainSecurities;
        private Controls.MainSecuritiesView mainSecuritiesView1;
        private DevExpress.XtraTab.XtraTabPage xtraPageOrders;
        private System.Windows.Forms.Button btnSendOrder;
        private Controls.OrdersView ordersView1;
        private System.Windows.Forms.Button btnRegisterForData;
        private DevExpress.XtraTab.XtraTabPage xtraPageOptions;
        private Controls.OptionsView optionsView1;
    }
}

