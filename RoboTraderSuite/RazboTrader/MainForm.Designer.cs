namespace RazboTrader
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
            this.xPagePositions = new DevExpress.XtraTab.XtraTabPage();
            this.positionsView1 = new TNS.Controls.PositionsView();
            this.xtraPageMainSecurities = new DevExpress.XtraTab.XtraTabPage();
            this.mainSecuritiesView1 = new TNS.Controls.MainSecuritiesView();
            this.xtraPageOrders = new DevExpress.XtraTab.XtraTabPage();
            this.cbxSell = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtStrike = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.ordersView1 = new TNS.Controls.OrdersView();
            this.btnRegisterForData = new System.Windows.Forms.Button();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.btnSendOrder = new System.Windows.Forms.Button();
            this.xtraPageOptions = new DevExpress.XtraTab.XtraTabPage();
            this.optionsView1 = new TNS.Controls.OptionsView();
            this.xtraPageUnlDataTrading = new DevExpress.XtraTab.XtraTabPage();
            this.unlTradingView1 = new TNS.Controls.UnlTradingView();
            this.btnBnsLocal = new System.Windows.Forms.Button();
            this.btnTestDiluter = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xPageAPIMessages.SuspendLayout();
            this.xPagePositions.SuspendLayout();
            this.xtraPageMainSecurities.SuspendLayout();
            this.xtraPageOrders.SuspendLayout();
            this.xtraPageOptions.SuspendLayout();
            this.xtraPageUnlDataTrading.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMessages
            // 
            this.txtMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessages.Location = new System.Drawing.Point(0, 0);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.Size = new System.Drawing.Size(1061, 492);
            this.txtMessages.TabIndex = 0;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(-1, 65);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xPagePositions;
            this.xtraTabControl1.Size = new System.Drawing.Size(1067, 520);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xPageAPIMessages,
            this.xPagePositions,
            this.xtraPageMainSecurities,
            this.xtraPageOrders,
            this.xtraPageOptions,
            this.xtraPageUnlDataTrading});
            // 
            // xPageAPIMessages
            // 
            this.xPageAPIMessages.Controls.Add(this.apiMesagesView);
            this.xPageAPIMessages.Name = "xPageAPIMessages";
            this.xPageAPIMessages.Size = new System.Drawing.Size(1061, 492);
            this.xPageAPIMessages.Text = "API Messages";
            // 
            // apiMesagesView
            // 
            this.apiMesagesView.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.apiMesagesView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.apiMesagesView.Location = new System.Drawing.Point(0, 0);
            this.apiMesagesView.Name = "apiMesagesView";
            this.apiMesagesView.Size = new System.Drawing.Size(1061, 492);
            this.apiMesagesView.TabIndex = 0;
            // 
            // xPagePositions
            // 
            this.xPagePositions.Controls.Add(this.positionsView1);
            this.xPagePositions.Controls.Add(this.txtMessages);
            this.xPagePositions.Name = "xPagePositions";
            this.xPagePositions.Size = new System.Drawing.Size(1061, 492);
            this.xPagePositions.Text = "Positions";
            // 
            // positionsView1
            // 
            this.positionsView1.AccountSummaryDataList = null;
            this.positionsView1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.positionsView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionsView1.Location = new System.Drawing.Point(0, 0);
            this.positionsView1.Name = "positionsView1";
            this.positionsView1.OptionsDataList = null;
            this.positionsView1.Size = new System.Drawing.Size(1061, 492);
            this.positionsView1.TabIndex = 1;
            // 
            // xtraPageMainSecurities
            // 
            this.xtraPageMainSecurities.Controls.Add(this.mainSecuritiesView1);
            this.xtraPageMainSecurities.Name = "xtraPageMainSecurities";
            this.xtraPageMainSecurities.Size = new System.Drawing.Size(1061, 492);
            this.xtraPageMainSecurities.Text = "Main Securities";
            // 
            // mainSecuritiesView1
            // 
            this.mainSecuritiesView1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mainSecuritiesView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSecuritiesView1.Location = new System.Drawing.Point(0, 0);
            this.mainSecuritiesView1.Name = "mainSecuritiesView1";
            this.mainSecuritiesView1.Size = new System.Drawing.Size(1061, 492);
            this.mainSecuritiesView1.TabIndex = 0;
            // 
            // xtraPageOrders
            // 
            this.xtraPageOrders.Controls.Add(this.cbxSell);
            this.xtraPageOrders.Controls.Add(this.dateTimePicker1);
            this.xtraPageOrders.Controls.Add(this.label4);
            this.xtraPageOrders.Controls.Add(this.label3);
            this.xtraPageOrders.Controls.Add(this.txtType);
            this.xtraPageOrders.Controls.Add(this.txtStrike);
            this.xtraPageOrders.Controls.Add(this.label1);
            this.xtraPageOrders.Controls.Add(this.txtSymbol);
            this.xtraPageOrders.Controls.Add(this.ordersView1);
            this.xtraPageOrders.Controls.Add(this.btnRegisterForData);
            this.xtraPageOrders.Controls.Add(this.btnCancelOrder);
            this.xtraPageOrders.Controls.Add(this.btnSendOrder);
            this.xtraPageOrders.Name = "xtraPageOrders";
            this.xtraPageOrders.Size = new System.Drawing.Size(1061, 492);
            this.xtraPageOrders.Text = "Orders";
            // 
            // cbxSell
            // 
            this.cbxSell.AutoSize = true;
            this.cbxSell.Checked = true;
            this.cbxSell.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSell.Location = new System.Drawing.Point(629, 18);
            this.cbxSell.Name = "cbxSell";
            this.cbxSell.Size = new System.Drawing.Size(42, 17);
            this.cbxSell.TabIndex = 5;
            this.cbxSell.Text = "Sell";
            this.cbxSell.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(712, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.Value = new System.DateTime(2017, 12, 15, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(534, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(390, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Strike:";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(578, 14);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(35, 21);
            this.txtType.TabIndex = 2;
            this.txtType.Text = "CALL";
            // 
            // txtStrike
            // 
            this.txtStrike.Location = new System.Drawing.Point(425, 16);
            this.txtStrike.Name = "txtStrike";
            this.txtStrike.Size = new System.Drawing.Size(100, 21);
            this.txtStrike.TabIndex = 2;
            this.txtStrike.Text = "160";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Symbol:";
            // 
            // txtSymbol
            // 
            this.txtSymbol.Location = new System.Drawing.Point(271, 15);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(100, 21);
            this.txtSymbol.TabIndex = 2;
            this.txtSymbol.Text = "AAPL";
            // 
            // ordersView1
            // 
            this.ordersView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ordersView1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ordersView1.Location = new System.Drawing.Point(3, 43);
            this.ordersView1.Name = "ordersView1";
            this.ordersView1.Size = new System.Drawing.Size(1055, 465);
            this.ordersView1.TabIndex = 1;
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
            // btnCancelOrder
            // 
            this.btnCancelOrder.Location = new System.Drawing.Point(918, 14);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(136, 23);
            this.btnCancelOrder.TabIndex = 0;
            this.btnCancelOrder.Text = "Cancel Selected Order";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnSendOrder
            // 
            this.btnSendOrder.Location = new System.Drawing.Point(119, 14);
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
            this.xtraPageOptions.Size = new System.Drawing.Size(1061, 492);
            this.xtraPageOptions.Text = "Options";
            // 
            // optionsView1
            // 
            this.optionsView1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.optionsView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsView1.Location = new System.Drawing.Point(0, 0);
            this.optionsView1.Name = "optionsView1";
            this.optionsView1.Size = new System.Drawing.Size(1061, 492);
            this.optionsView1.TabIndex = 0;
            // 
            // xtraPageUnlDataTrading
            // 
            this.xtraPageUnlDataTrading.Controls.Add(this.unlTradingView1);
            this.xtraPageUnlDataTrading.Name = "xtraPageUnlDataTrading";
            this.xtraPageUnlDataTrading.Size = new System.Drawing.Size(1061, 492);
            this.xtraPageUnlDataTrading.Text = "Unl. Trading Data";
            // 
            // unlTradingView1
            // 
            this.unlTradingView1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.unlTradingView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unlTradingView1.Location = new System.Drawing.Point(0, 0);
            this.unlTradingView1.Name = "unlTradingView1";
            this.unlTradingView1.Size = new System.Drawing.Size(1061, 492);
            this.unlTradingView1.TabIndex = 0;
            // 
            // btnBnsLocal
            // 
            this.btnBnsLocal.Location = new System.Drawing.Point(13, 13);
            this.btnBnsLocal.Name = "btnBnsLocal";
            this.btnBnsLocal.Size = new System.Drawing.Size(75, 23);
            this.btnBnsLocal.TabIndex = 2;
            this.btnBnsLocal.Text = "B n S Local ";
            this.btnBnsLocal.UseVisualStyleBackColor = true;
            this.btnBnsLocal.Click += new System.EventHandler(this.btnBnsLocal_Click);
            // 
            // btnTestDiluter
            // 
            this.btnTestDiluter.Location = new System.Drawing.Point(132, 12);
            this.btnTestDiluter.Name = "btnTestDiluter";
            this.btnTestDiluter.Size = new System.Drawing.Size(75, 23);
            this.btnTestDiluter.TabIndex = 3;
            this.btnTestDiluter.Text = "Test Diluter";
            this.btnTestDiluter.UseVisualStyleBackColor = true;
            this.btnTestDiluter.Click += new System.EventHandler(this.btnTestDiluter_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(244, 13);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 585);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnTestDiluter);
            this.Controls.Add(this.btnBnsLocal);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xPageAPIMessages.ResumeLayout(false);
            this.xPagePositions.ResumeLayout(false);
            this.xPagePositions.PerformLayout();
            this.xtraPageMainSecurities.ResumeLayout(false);
            this.xtraPageOrders.ResumeLayout(false);
            this.xtraPageOrders.PerformLayout();
            this.xtraPageOptions.ResumeLayout(false);
            this.xtraPageUnlDataTrading.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessages;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xPageAPIMessages;
        private TNS.Controls.APIMesagesView apiMesagesView;
        private DevExpress.XtraTab.XtraTabPage xPagePositions;
        private DevExpress.XtraTab.XtraTabPage xtraPageMainSecurities;
        private TNS.Controls.MainSecuritiesView mainSecuritiesView1;
        private DevExpress.XtraTab.XtraTabPage xtraPageOrders;
        private System.Windows.Forms.Button btnSendOrder;
        private TNS.Controls.OrdersView ordersView1;
        private System.Windows.Forms.Button btnRegisterForData;
        private DevExpress.XtraTab.XtraTabPage xtraPageOptions;
        private TNS.Controls.OptionsView optionsView1;
        private DevExpress.XtraTab.XtraTabPage xtraPageUnlDataTrading;
        private TNS.Controls.UnlTradingView unlTradingView1;
        private TNS.Controls.PositionsView positionsView1;
        private System.Windows.Forms.Button btnBnsLocal;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtStrike;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.CheckBox cbxSell;
        private System.Windows.Forms.Button btnTestDiluter;
        private System.Windows.Forms.Button btnTest;
    }
}

