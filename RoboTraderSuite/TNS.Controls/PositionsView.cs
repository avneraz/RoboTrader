using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Infra;
using Infra.Enum;
using Infra.Extensions;
using Infra.Global;
using log4net;
using TNS.API.ApiDataObjects;
using TNS.BL;
using TNS.BL.Interfaces;
using TNS.BL.UnlManagers;
using DAL;

namespace TNS.Controls
{
    public partial class PositionsView : UserControl, IPositionView
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(PositionsView));
        public PositionsView()
        {
            InitializeComponent();
        }

        public void SetAppManager(AppManager appManager)
        {
            AppManager = appManager;
        }
        public void SetOptionDataList(List<OptionData> optionsDataList)
        {
            OptionsDataList = optionsDataList;
        }
        public List<OptionData> OptionsDataList { get; set; }
        private AppManager AppManager { get; set; }
        public List<AccountSummaryData> AccountSummaryDataList { get; set; }
        //public AccountSummaryData AccountSummaryData { get; set; }

        /// <summary>
        /// Current money plus option market value
        /// </summary>
        public double EquityWithLoanValue => AccountSummaryDataList[0].EquityWithLoanValue;

        /// <summary>
        /// Margin maintenance required 
        /// </summary>
        public double FullMaintMarginReq => AccountSummaryDataList[0].FullMaintMarginReq;

        /// <summary>
        /// Invested money plus PnL
        /// </summary>
        public double NetLiquidation => AccountSummaryDataList[0].NetLiquidation;

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            SetAndUpdate();
           
        }
        private void SetAndUpdate()
        {
            if (_dataloaded)
                return;
            _dataloaded = true;
            GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(1),
                () =>
                {
                    grdPositionData.InvokeIfRequired(() =>
                    {
                        optionsPositionDataBindingSource.ResetBindings(false);
                            //grdPositionData.Height = 208 + (gridView1.RowHeight + 1) * (optionsPositionDataBindingSource.Count);

                    });
                    grpAccountSummary.InvokeIfRequired(() =>
                    {
                        accountSummaryDataBindingSource.ResetBindings(false);
                        var accountSummaryData = (accountSummaryDataBindingSource.Current) as AccountSummaryData;
                        lblDailyPnL.ForeColor =
                            accountSummaryData != null && accountSummaryData.DailyPnL < 0
                                ? Color.Red
                                : Color.ForestGreen;
                    });
                    grdUnLTradingData.InvokeIfRequired(() =>
                    {
                        unlTradingDataBindingSource.ResetBindings(false);

                    });
                    //grdMainSecurities.InvokeIfRequired(() =>
                    //{
                    //    securityDataBindingSource.ResetBindings(false);
                    //});
                 
                },
                true);
        }

        private bool _dataloaded;
      

        public void SetPositionDataList(List<OptionsPositionData> positionDataList)
        {

            grdPositionData.InvokeIfRequired(() =>
            {
                optionsPositionDataBindingSource.DataSource = positionDataList;
                optionsPositionDataBindingSource.ResetBindings(false);
                //grdPositionData.Height = 208 + (gridView1.RowHeight + 1) * (optionsPositionDataBindingSource.Count);
                SetAndUpdate();
            });
        }

        public void SetUnlTradingDataList(List<UnlTradingData> unlTradingDataList)
        {
            grdUnLTradingData.InvokeIfRequired(() =>
            {
                unlTradingDataBindingSource.DataSource = unlTradingDataList;
                unlTradingDataBindingSource.ResetBindings(false);

            });

        }

        //public void SetSecurityDataList(List<SecurityData> securityDataList)
        //{
        //    grdMainSecurities.InvokeIfRequired(() =>
        //    {
        //        securityDataBindingSource.DataSource = securityDataList;
        //        securityDataBindingSource.ResetBindings(false);
        //    });
        //}
        //public Dictionary<string, UnlTradingData> UnlTradingDataDic { get; private set; }
        public void SetAccountSummaryData(List<AccountSummaryData> accountSummaryDataList)
        {
            AccountSummaryDataList = accountSummaryDataList;
            grpAccountSummary.InvokeIfRequired(() =>
            {
                accountSummaryDataBindingSource.DataSource = AccountSummaryDataList;
                accountSummaryDataBindingSource.ResetBindings(false);
                grpAccountSummary.ResetBindings();
            });
           
        }

        
        //private Dictionary<string, OptionsPositionData> PositionDataDic { get;  set; }

        private void PositionsView_Resize(object sender, EventArgs e)
        {
            
            grdPositionData.Height = 208 + (grdViewPositionData.RowHeight + 1) * (optionsPositionDataBindingSource.Count);
        }

        private void grdPositionData_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            //return;
            var view = sender as GridView;
            if ((view == null) || (e.RowHandle < 0)) return;

            

            try
            {
                bool isCellValueNegative;
                switch (e.Column.FieldName)
                {
                    case "ChangeFromCost":
                        isCellValueNegative = Convert.ToDouble(e.CellValue) < 0;
                        e.Appearance.ForeColor = isCellValueNegative ? Color.Green : Color.Red;
                        return;
                    case "PnL":
                        isCellValueNegative = Convert.ToDouble(e.CellValue) < 0;
                        e.Appearance.ForeColor = isCellValueNegative ? Color.Red : Color.Green;
                        return;
                    case "OptionContract.Strike":
                    case "OffsetUnl":
                        var pData = (OptionsPositionData)grdViewPositionData.GetRow(e.RowHandle);
                        
                        bool bold = false;
                        if (pData.OptionData != null)
                            e.Appearance.ForeColor = GetCellColor(pData, out bold);
                        
                        var font = e.Appearance.GetFont();
                        var style = FontStyle.Bold + (bold ? (int)FontStyle.Underline : (int)FontStyle.Regular);
                        //style = font.Style + (int) FontStyle.Underline;
                        e.Appearance.Font = new Font(font.FontFamily,font.Size +1, style);
                        return;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
        }

        private Color GetCellColor(OptionsPositionData pData, out bool bold)
        {
            //the offset factor from unl for trading, to accomplished the algorithm of "Out of the money" (OTM)
            const double offsetFromUnl = 0.1;
            var unlPrice = pData.OptionData.UnderlinePrice;
            //We divide the offset to 3 step in order to paint the cell accordingly.
            var step = unlPrice*offsetFromUnl/3;
            
            var isCall = pData.OptionType == EOptionType.Call;
            var strike = pData.OptionContract.Strike;

            //The offset (in points) from the underline. if the strike exceed this number => 
            //turn the color to color that symbol the difference size.
            var diff = isCall? strike - unlPrice : unlPrice - strike;
            bold = false;
            Color foreColor;
            if (diff <= step)
            {
                foreColor = Color.Red;
                bold = true;
            }
            else if (diff <= 1.5*step)
            {
                foreColor = Color.Brown;
            }
            else if (diff <= 2.5*step)
            {
                foreColor = Color.Blue;
            }
            else
            {
                foreColor = Color.DarkGreen;
            }
            return foreColor;
        }
        private void grdViewPositionData_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            //return;
            try
            {
                var view = sender as GridView;
                if ((view == null)) return;
                //Add additional info about the underline on the group header:
                var pData = (OptionsPositionData)grdViewPositionData.GetRow(e.RowHandle);
                double unlPrice = 0;
                if (pData.OptionData != null)
                    unlPrice = pData.OptionData.UnderlinePrice;
                var groupInfo = (GridGroupRowInfo)(e.Info);
                //var mainInfo = GetSecurityMainInfo(pData.Symbol);
                string mainInfo;
                e.Appearance.ForeColor = IsUnderlineRaising(pData.Symbol, out mainInfo) ? Color.Green : Color.Red;
                var unlInfo = GetUnlInfo(pData.Symbol);
                groupInfo.GroupText = $"{pData.Symbol}:{unlPrice:N}           {mainInfo}   {unlInfo}";
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }

        }

        //private bool IsUnderlineRaising(string symbol)
        //{
        //   var secData = ((IEnumerable<SecurityData>) securityDataBindingSource.DataSource).FirstOrDefault(sd=>sd.Symbol == symbol);
        //    return secData != null && (secData.Change > 0);
        //}

        private bool IsUnderlineRaising(string symbol, out string mainInfo)
        {
            var secData = ((IEnumerable<SecurityData>)securityDataBindingSource.DataSource).FirstOrDefault(sd => sd.Symbol == symbol);
            mainInfo = secData != null ? secData.MainInfo : string.Empty;
            return secData != null && (secData.Change > 0);
        }


        private string GetSecurityMainInfo(string symbol)
        {
            var secData = ((IEnumerable<SecurityData>)securityDataBindingSource.DataSource).FirstOrDefault(sd => sd.Symbol == symbol);
            return secData != null ? secData.MainInfo : string.Empty;
        }
        private string GetUnlInfo(string symbol)
        {
            var unlTradingData = ((IEnumerable<UnlTradingData>) unlTradingDataBindingSource.DataSource).
                FirstOrDefault(sd => sd.Symbol == symbol);

            var unlInfo = unlTradingData != null ? $"VIX: {unlTradingData.VIX}  IV.W.Avg={unlTradingData.IVWeightedAvg:P}" : string.Empty; 

            return unlInfo;
        }
        public OptionsPositionData GetSelectedPositionData()
        {
            if ((optionsPositionDataBindingSource == null) || optionsPositionDataBindingSource.Count == 0)
                return null;

            var pos = grdViewPositionData.GetSelectedRows()[0];
            var positionData = grdViewPositionData.GetRow(pos) as OptionsPositionData;

            return positionData;
        }

        private UnlTradingData GetSelectedUnlTradingData()
        {
            if ((unlTradingDataBindingSource == null) || unlTradingDataBindingSource.Count == 0)
                return null;
            var pos = gridViewUnLTradingData.GetSelectedRows()[0];
            var unlTradingData = gridViewUnLTradingData.GetRow(pos) as UnlTradingData;

            return unlTradingData;
        }
        private void grdViewPositionData_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                popupMenu1.ShowPopup(grdPositionData.PointToScreen(e.Point));
            }
        }

        private void iSellOption_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var positionData = GetSelectedPositionData();
                if (positionData == null) return;
                SendSellOrder(positionData.OptionData);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                MessageBox.Show(ex.Message);
            }
        }
        private void iBuyOption_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var positionData = GetSelectedPositionData();
                if (positionData == null) return;
                SendBuyOrder(positionData.OptionData);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                MessageBox.Show(ex.Message);
            }
        }
        public void SendSellOrder(OptionData optionData, int quantity = 1)
        {
            var unlManager = (UNLManager) (AppManager.UNLManagerDic[optionData.Symbol]);
            IOrdersManager orderManager = unlManager.OrdersManager;
            orderManager.SellOption(optionData, quantity);
        }

        public void SendBuyOrder(OptionData optionData, int quantity = 1)
        {
            var unlManager = (UNLManager)(AppManager.UNLManagerDic[optionData.Symbol]);
            IOrdersManager orderManager = unlManager.OrdersManager;
            orderManager.BuyOption(optionData, quantity);
        }

        private void iOptionPicker_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var positionData = GetSelectedPositionData();
                if (positionData == null) throw new Exception("There is no Position Data!!!");

                var control = new OptionTradingControl {PositionView = this};
                control.SetDataSource(positionData);
                control.ShowControl(this.ParentForm, true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                MessageBox.Show(ex.Message);
            }
        }

      
        //private void grdViewMainSecurities_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        //{
        //    if (e.HitInfo.InRow)
        //    {
        //        popupMenu1.ShowPopup(grdMainSecurities.PointToScreen(e.Point));
        //    }
        //}

        private void iShowUnlOption_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var positionData = GetSelectedPositionData();
                if (positionData == null) throw new Exception("There is no Position Data!!!");
                
                string unl = positionData.Symbol;
                DateTime expiryDate = positionData.Expiry;

                var list = OptionTradingDataFactory.GetOptionTradingDataList(unl, expiryDate);

                var control = new UNLOptionsControl();

                control.SetDataSource(list);
                control.ShowControl(this.ParentForm, true);

                //MessageBox.Show($"The UNL: '{unl}' Expiry={expiryDate} has {list.Count} items.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void iMargin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var positionData = GetSelectedPositionData();
                if (positionData == null) throw new Exception("There is no Position Data!!!");

               MessageBox.Show($" the Margin for sell 1 option is: {AppManager.MarginManager.OnePositionSellMargin(positionData):C0}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridViewUnLTradingData_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                popupMenuUNL.ShowPopup(grdUnLTradingData.PointToScreen(e.Point));
            }
        }

        private void iUNLMargin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var unlTradingData = GetSelectedUnlTradingData();
                if (unlTradingData == null) throw new Exception("There is no UNL Data!!!");
                var symbol = unlTradingData.Symbol;

                //var result = AppManager.MarginManager.CalculateUNLRequierdMargin(unlTradingData.Symbol);
                var result = AppManager.MarginManager.MarginDataDic[unlTradingData.Symbol];
                MessageBox.Show($" The Margin requierd for '{symbol}' options is: {result.Margin:C0}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void iUNLOptionPicker_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var unlTradingData = GetSelectedUnlTradingData();
                if (unlTradingData == null) throw new Exception("There is no UNL Data!!!");
                var symbol = unlTradingData.Symbol;

                var control = new OptionTradingControl { PositionView = this };
                control.SetDataSource(symbol);

                var form = control.ShowControl(this.ParentForm, true);
                form.TopMost = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void iCloseUNLPositions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var unlTradingData = GetSelectedUnlTradingData();
                if (unlTradingData == null) throw new Exception("There is no UNL Data!!!");
                var symbol = unlTradingData.Symbol;

                var control = new PositionClosingSelector {Symbol = symbol};
                var form = control.ShowControl(this.ParentForm, true);
                form.TopMost = true;

                //var unlManager = AppManager.UNLManagerDic[symbol] as UNLManager;
                //if (unlManager == null)
                //    throw new Exception($"The symbol: '{symbol}' doesn't exist in the UNLManager list!");

                //unlManager.CloseEntireShortPositions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdUnLTradingData_Click(object sender, EventArgs e)
        {

        }
    }
}
