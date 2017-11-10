namespace TNS.Controls
{
    partial class OrdersView
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdOrders = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iCancelOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.orderStatusDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdViewOrders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAPIDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMargin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommission = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSymbol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrder_LimitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrder_Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptionKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrike = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderStatusDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdOrders);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Size = new System.Drawing.Size(1027, 588);
            this.splitContainer1.SplitterDistance = 167;
            this.splitContainer1.TabIndex = 0;
            // 
            // grdOrders
            // 
            this.grdOrders.ContextMenuStrip = this.contextMenuStrip1;
            this.grdOrders.DataSource = this.orderStatusDataBindingSource;
            this.grdOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOrders.Location = new System.Drawing.Point(5, 5);
            this.grdOrders.MainView = this.grdViewOrders;
            this.grdOrders.Name = "grdOrders";
            this.grdOrders.Size = new System.Drawing.Size(846, 578);
            this.grdOrders.TabIndex = 1;
            this.grdOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewOrders});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iCancelOrder});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 26);
            // 
            // iCancelOrder
            // 
            this.iCancelOrder.Name = "iCancelOrder";
            this.iCancelOrder.Size = new System.Drawing.Size(143, 22);
            this.iCancelOrder.Text = "Cancel Order";
            this.iCancelOrder.Click += new System.EventHandler(this.iCancelOrder_Click);
            // 
            // orderStatusDataBindingSource
            // 
            this.orderStatusDataBindingSource.DataSource = typeof(TNS.API.ApiDataObjects.OrderStatusData);
            // 
            // grdViewOrders
            // 
            this.grdViewOrders.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOrder,
            this.colAPIDataType,
            this.colOrderStatus,
            this.colOrderId,
            this.colMargin,
            this.colLastUpdateTime,
            this.colCommission,
            this.colSymbol,
            this.colOrder_LimitPrice,
            this.colOrder_Quantity,
            this.colOptionKey,
            this.colStrike});
            this.grdViewOrders.GridControl = this.grdOrders;
            this.grdViewOrders.Name = "grdViewOrders";
            // 
            // colOrder
            // 
            this.colOrder.FieldName = "Order";
            this.colOrder.Name = "colOrder";
            this.colOrder.OptionsColumn.ReadOnly = true;
            // 
            // colAPIDataType
            // 
            this.colAPIDataType.FieldName = "APIDataType";
            this.colAPIDataType.Name = "colAPIDataType";
            this.colAPIDataType.OptionsColumn.ReadOnly = true;
            this.colAPIDataType.Width = 164;
            // 
            // colOrderStatus
            // 
            this.colOrderStatus.FieldName = "OrderStatus";
            this.colOrderStatus.Name = "colOrderStatus";
            this.colOrderStatus.Visible = true;
            this.colOrderStatus.VisibleIndex = 3;
            this.colOrderStatus.Width = 93;
            // 
            // colOrderId
            // 
            this.colOrderId.FieldName = "OrderId";
            this.colOrderId.Name = "colOrderId";
            this.colOrderId.OptionsColumn.ReadOnly = true;
            this.colOrderId.Visible = true;
            this.colOrderId.VisibleIndex = 0;
            this.colOrderId.Width = 66;
            // 
            // colMargin
            // 
            this.colMargin.Caption = "Margin";
            this.colMargin.DisplayFormat.FormatString = "#,##0";
            this.colMargin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMargin.FieldName = "Margin";
            this.colMargin.Name = "colMargin";
            this.colMargin.Visible = true;
            this.colMargin.VisibleIndex = 4;
            this.colMargin.Width = 82;
            // 
            // colLastUpdateTime
            // 
            this.colLastUpdateTime.DisplayFormat.FormatString = "g";
            this.colLastUpdateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLastUpdateTime.FieldName = "LastUpdateTime";
            this.colLastUpdateTime.Name = "colLastUpdateTime";
            this.colLastUpdateTime.Visible = true;
            this.colLastUpdateTime.VisibleIndex = 5;
            this.colLastUpdateTime.Width = 135;
            // 
            // colCommission
            // 
            this.colCommission.DisplayFormat.FormatString = "#,##0.00";
            this.colCommission.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCommission.FieldName = "Commission";
            this.colCommission.Name = "colCommission";
            this.colCommission.Visible = true;
            this.colCommission.VisibleIndex = 6;
            this.colCommission.Width = 142;
            // 
            // colSymbol
            // 
            this.colSymbol.Caption = "Symbol";
            this.colSymbol.FieldName = "Order.Contract.Symbol";
            this.colSymbol.Name = "colSymbol";
            this.colSymbol.Visible = true;
            this.colSymbol.VisibleIndex = 7;
            this.colSymbol.Width = 62;
            // 
            // colOrder_LimitPrice
            // 
            this.colOrder_LimitPrice.Caption = "Limit LastPrice";
            this.colOrder_LimitPrice.DisplayFormat.FormatString = "0.00";
            this.colOrder_LimitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOrder_LimitPrice.FieldName = "Order.LimitPrice";
            this.colOrder_LimitPrice.Name = "colOrder_LimitPrice";
            this.colOrder_LimitPrice.Visible = true;
            this.colOrder_LimitPrice.VisibleIndex = 8;
            this.colOrder_LimitPrice.Width = 62;
            // 
            // colOrder_Quantity
            // 
            this.colOrder_Quantity.Caption = "Quantity";
            this.colOrder_Quantity.FieldName = "Order.Quantity";
            this.colOrder_Quantity.Name = "colOrder_Quantity";
            this.colOrder_Quantity.Visible = true;
            this.colOrder_Quantity.VisibleIndex = 9;
            this.colOrder_Quantity.Width = 72;
            // 
            // colOptionKey
            // 
            this.colOptionKey.Caption = "Option Key";
            this.colOptionKey.FieldName = "OptionKey";
            this.colOptionKey.Name = "colOptionKey";
            this.colOptionKey.Visible = true;
            this.colOptionKey.VisibleIndex = 1;
            this.colOptionKey.Width = 62;
            // 
            // colStrike
            // 
            this.colStrike.Caption = "Strike";
            this.colStrike.FieldName = "Strike";
            this.colStrike.Name = "colStrike";
            this.colStrike.Visible = true;
            this.colStrike.VisibleIndex = 2;
            this.colStrike.Width = 52;
            // 
            // OrdersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.splitContainer1);
            this.Name = "OrdersView";
            this.Size = new System.Drawing.Size(1027, 588);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderStatusDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl grdOrders;
        private System.Windows.Forms.BindingSource orderStatusDataBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewOrders;
        private DevExpress.XtraGrid.Columns.GridColumn colOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colAPIDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderId;
        private DevExpress.XtraGrid.Columns.GridColumn colMargin;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colCommission;
        private DevExpress.XtraGrid.Columns.GridColumn colSymbol;
        private DevExpress.XtraGrid.Columns.GridColumn colOrder_LimitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colOrder_Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionKey;
        private DevExpress.XtraGrid.Columns.GridColumn colStrike;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iCancelOrder;
    }
}
