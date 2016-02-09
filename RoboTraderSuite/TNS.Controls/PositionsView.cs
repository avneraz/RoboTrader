using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Infra;
using Infra.Extensions;
using TNS.API.ApiDataObjects;

namespace TNS.Controls
{
    public partial class PositionsView : UserControl
    {
        public PositionsView()
        {
            InitializeComponent();
        }
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
                            grdPositionData.Height = 208 + (gridView1.RowHeight + 1) * (optionsPositionDataBindingSource.Count);

                    });
                    grpAccountSummary.InvokeIfRequired(() =>
                    {
                        accountSummaryDataBindingSource.ResetBindings(false);
                    });
                    grdUnLTradingData.InvokeIfRequired(() =>
                    {
                        unlTradingDataBindingSource.ResetBindings(false);

                    });
                },
                true);
        }

        private bool _dataloaded;
        //private List<OptionsPositionData> OptionsPositionDataList { get; set; }
        //public void SetPositionDataDicTBD(Dictionary<string, OptionsPositionData> positionDataDic)
        //{
        //    //PositionDataDic = positionDataDic;
        //    GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(15), () => grdPositionData.InvokeIfRequired(SetAndUpdate), false);
        //}

        public void SetPositionDataList(List<OptionsPositionData> positionDataList)
        {

            grdPositionData.InvokeIfRequired(() =>
            {
                optionsPositionDataBindingSource.DataSource = positionDataList;
                optionsPositionDataBindingSource.ResetBindings(false);
                grdPositionData.Height = 208 + (gridView1.RowHeight + 1) * (optionsPositionDataBindingSource.Count);
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
            
            grdPositionData.Height = 208 + (gridView1.RowHeight + 1) * (optionsPositionDataBindingSource.Count);
        }
    }
}
