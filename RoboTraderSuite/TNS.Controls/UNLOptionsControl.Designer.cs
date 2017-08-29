namespace TNS.Controls
{
    partial class UNLOptionsControl
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.grdUnlOptions = new DevExpress.XtraGrid.GridControl();
            this.gridViewUnlOptions = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.unlOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colAPIDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptionData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOptionKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOpenTransaction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCloseTransaction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSymbol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPnL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHighestPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLowestPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBasePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOpeningPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAskPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBidPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAskSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBidSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMultiplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnlOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUnlOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unlOptionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grdUnlOptions
            // 
            this.grdUnlOptions.DataSource = this.unlOptionsBindingSource;
            this.grdUnlOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.grdUnlOptions.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdUnlOptions.Location = new System.Drawing.Point(0, 0);
            this.grdUnlOptions.MainView = this.gridViewUnlOptions;
            this.grdUnlOptions.Name = "grdUnlOptions";
            this.grdUnlOptions.Size = new System.Drawing.Size(1114, 549);
            this.grdUnlOptions.TabIndex = 0;
            this.grdUnlOptions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewUnlOptions});
            // 
            // gridViewUnlOptions
            // 
            this.gridViewUnlOptions.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAPIDataType,
            this.colId,
            this.colOptionData,
            this.colOptionKey,
            this.colOpenTransaction,
            this.colCloseTransaction,
            this.colSymbol,
            this.colStatus,
            this.colPnL,
            this.colAccount,
            this.colLastPrice,
            this.colHighestPrice,
            this.colLowestPrice,
            this.colBasePrice,
            this.colOpeningPrice,
            this.colChange,
            this.colAskPrice,
            this.colBidPrice,
            this.colAskSize,
            this.colBidSize,
            this.colVolume,
            this.colMultiplier,
            this.colLastUpdate});
            this.gridViewUnlOptions.GridControl = this.grdUnlOptions;
            this.gridViewUnlOptions.Name = "gridViewUnlOptions";
            // 
            // unlOptionsBindingSource
            // 
            this.unlOptionsBindingSource.DataSource = typeof(TNS.API.ApiDataObjects.UnlOptions);
            // 
            // colAPIDataType
            // 
            this.colAPIDataType.FieldName = "APIDataType";
            this.colAPIDataType.Name = "colAPIDataType";
            this.colAPIDataType.OptionsColumn.ReadOnly = true;
            this.colAPIDataType.Visible = true;
            this.colAPIDataType.VisibleIndex = 0;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.ReadOnly = true;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 1;
            // 
            // colOptionData
            // 
            this.colOptionData.FieldName = "OptionData";
            this.colOptionData.Name = "colOptionData";
            this.colOptionData.Visible = true;
            this.colOptionData.VisibleIndex = 2;
            // 
            // colOptionKey
            // 
            this.colOptionKey.FieldName = "OptionKey";
            this.colOptionKey.Name = "colOptionKey";
            this.colOptionKey.Visible = true;
            this.colOptionKey.VisibleIndex = 3;
            // 
            // colOpenTransaction
            // 
            this.colOpenTransaction.FieldName = "OpenTransaction";
            this.colOpenTransaction.Name = "colOpenTransaction";
            this.colOpenTransaction.Visible = true;
            this.colOpenTransaction.VisibleIndex = 4;
            // 
            // colCloseTransaction
            // 
            this.colCloseTransaction.FieldName = "CloseTransaction";
            this.colCloseTransaction.Name = "colCloseTransaction";
            this.colCloseTransaction.Visible = true;
            this.colCloseTransaction.VisibleIndex = 5;
            // 
            // colSymbol
            // 
            this.colSymbol.FieldName = "Symbol";
            this.colSymbol.Name = "colSymbol";
            this.colSymbol.Visible = true;
            this.colSymbol.VisibleIndex = 6;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 7;
            // 
            // colPnL
            // 
            this.colPnL.FieldName = "PnL";
            this.colPnL.Name = "colPnL";
            this.colPnL.Visible = true;
            this.colPnL.VisibleIndex = 8;
            // 
            // colAccount
            // 
            this.colAccount.FieldName = "Account";
            this.colAccount.Name = "colAccount";
            this.colAccount.Visible = true;
            this.colAccount.VisibleIndex = 9;
            // 
            // colLastPrice
            // 
            this.colLastPrice.FieldName = "LastPrice";
            this.colLastPrice.Name = "colLastPrice";
            this.colLastPrice.Visible = true;
            this.colLastPrice.VisibleIndex = 10;
            // 
            // colHighestPrice
            // 
            this.colHighestPrice.FieldName = "HighestPrice";
            this.colHighestPrice.Name = "colHighestPrice";
            this.colHighestPrice.Visible = true;
            this.colHighestPrice.VisibleIndex = 11;
            // 
            // colLowestPrice
            // 
            this.colLowestPrice.FieldName = "LowestPrice";
            this.colLowestPrice.Name = "colLowestPrice";
            this.colLowestPrice.Visible = true;
            this.colLowestPrice.VisibleIndex = 12;
            // 
            // colBasePrice
            // 
            this.colBasePrice.FieldName = "BasePrice";
            this.colBasePrice.Name = "colBasePrice";
            this.colBasePrice.Visible = true;
            this.colBasePrice.VisibleIndex = 13;
            // 
            // colOpeningPrice
            // 
            this.colOpeningPrice.FieldName = "OpeningPrice";
            this.colOpeningPrice.Name = "colOpeningPrice";
            this.colOpeningPrice.Visible = true;
            this.colOpeningPrice.VisibleIndex = 14;
            // 
            // colChange
            // 
            this.colChange.FieldName = "Change";
            this.colChange.Name = "colChange";
            this.colChange.OptionsColumn.ReadOnly = true;
            this.colChange.Visible = true;
            this.colChange.VisibleIndex = 15;
            // 
            // colAskPrice
            // 
            this.colAskPrice.FieldName = "AskPrice";
            this.colAskPrice.Name = "colAskPrice";
            this.colAskPrice.Visible = true;
            this.colAskPrice.VisibleIndex = 16;
            // 
            // colBidPrice
            // 
            this.colBidPrice.FieldName = "BidPrice";
            this.colBidPrice.Name = "colBidPrice";
            this.colBidPrice.Visible = true;
            this.colBidPrice.VisibleIndex = 17;
            // 
            // colAskSize
            // 
            this.colAskSize.FieldName = "AskSize";
            this.colAskSize.Name = "colAskSize";
            this.colAskSize.Visible = true;
            this.colAskSize.VisibleIndex = 18;
            // 
            // colBidSize
            // 
            this.colBidSize.FieldName = "BidSize";
            this.colBidSize.Name = "colBidSize";
            this.colBidSize.Visible = true;
            this.colBidSize.VisibleIndex = 19;
            // 
            // colVolume
            // 
            this.colVolume.FieldName = "Volume";
            this.colVolume.Name = "colVolume";
            this.colVolume.Visible = true;
            this.colVolume.VisibleIndex = 20;
            // 
            // colMultiplier
            // 
            this.colMultiplier.FieldName = "Multiplier";
            this.colMultiplier.Name = "colMultiplier";
            this.colMultiplier.Visible = true;
            this.colMultiplier.VisibleIndex = 21;
            // 
            // colLastUpdate
            // 
            this.colLastUpdate.FieldName = "LastUpdate";
            this.colLastUpdate.Name = "colLastUpdate";
            this.colLastUpdate.Visible = true;
            this.colLastUpdate.VisibleIndex = 22;
            // 
            // UNLOptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdUnlOptions);
            this.Name = "UNLOptionsControl";
            this.Size = new System.Drawing.Size(1114, 549);
            ((System.ComponentModel.ISupportInitialize)(this.grdUnlOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUnlOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unlOptionsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdUnlOptions;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUnlOptions;
        private System.Windows.Forms.BindingSource unlOptionsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colAPIDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionData;
        private DevExpress.XtraGrid.Columns.GridColumn colOptionKey;
        private DevExpress.XtraGrid.Columns.GridColumn colOpenTransaction;
        private DevExpress.XtraGrid.Columns.GridColumn colCloseTransaction;
        private DevExpress.XtraGrid.Columns.GridColumn colSymbol;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colPnL;
        private DevExpress.XtraGrid.Columns.GridColumn colAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colLastPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colHighestPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colLowestPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colBasePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colOpeningPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colChange;
        private DevExpress.XtraGrid.Columns.GridColumn colAskPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colBidPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colAskSize;
        private DevExpress.XtraGrid.Columns.GridColumn colBidSize;
        private DevExpress.XtraGrid.Columns.GridColumn colVolume;
        private DevExpress.XtraGrid.Columns.GridColumn colMultiplier;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdate;
    }
}
