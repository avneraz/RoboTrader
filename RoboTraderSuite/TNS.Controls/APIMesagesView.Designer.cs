namespace TNS.Controls
{
    partial class APIMesagesView
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this._apiMessageDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdditionalInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._apiMessageDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this._apiMessageDataBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(5, 5);
            this.gridControl1.LookAndFeel.UseWindowsXPTheme = true;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(884, 488);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // _apiMessageDataBindingSource
            // 
            this._apiMessageDataBindingSource.DataSource = typeof(TNS.API.ApiDataObjects.APIMessageData);
            // 
            // gridView1
            // 
            this.gridView1.AppearancePrint.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.AppearancePrint.OddRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUpdateTime,
            this.colMessage,
            this.colErrorCode,
            this.colAdditionalInfo});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsPrint.EnableAppearanceOddRow = true;
            // 
            // colMessage
            // 
            this.colMessage.FieldName = "Message";
            this.colMessage.MinWidth = 200;
            this.colMessage.Name = "colMessage";
            this.colMessage.Visible = true;
            this.colMessage.VisibleIndex = 2;
            this.colMessage.Width = 788;
            // 
            // colErrorCode
            // 
            this.colErrorCode.FieldName = "ErrorCode";
            this.colErrorCode.MaxWidth = 100;
            this.colErrorCode.MinWidth = 40;
            this.colErrorCode.Name = "colErrorCode";
            this.colErrorCode.Visible = true;
            this.colErrorCode.VisibleIndex = 0;
            this.colErrorCode.Width = 78;
            // 
            // colAdditionalInfo
            // 
            this.colAdditionalInfo.FieldName = "AdditionalInfo";
            this.colAdditionalInfo.Name = "colAdditionalInfo";
            // 
            // colUpdateTime
            // 
            this.colUpdateTime.Caption = "UD Time";
            this.colUpdateTime.DisplayFormat.FormatString = "T";
            this.colUpdateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colUpdateTime.FieldName = "UpdateTime";
            this.colUpdateTime.Name = "colUpdateTime";
            this.colUpdateTime.Visible = true;
            this.colUpdateTime.VisibleIndex = 1;
            // 
            // APIMesagesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.gridControl1);
            this.Name = "APIMesagesView";
            this.Size = new System.Drawing.Size(894, 498);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._apiMessageDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource _apiMessageDataBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colMessage;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorCode;
        private DevExpress.XtraGrid.Columns.GridColumn colAdditionalInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateTime;
    }
}
