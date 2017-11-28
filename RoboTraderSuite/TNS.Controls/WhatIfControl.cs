using System;
using System.Windows.Forms;
using Infra.Extensions;
using TNS.BL;
using TNS.BL.UnlManagers;

namespace TNS.Controls
{
    public partial class WhatIfControl : UserControl
    {
        public WhatIfControl()
        {
            InitializeComponent();
        }

        public WhatIfControl(string symbol)
        {
            InitializeComponent();
            _symbol = symbol;
            InitializeMembers();
        }

        private  AppManager AppManager => AppManager.AppManagerSingleTonObject;
        private readonly string _symbol;
        private UNLManager UnlManager { get; set; }
       
        private void InitializeMembers()
        {
            UnlManager = AppManager.UNLManagerDic[_symbol] as UNLManager;
            if (UnlManager == null) throw new Exception("The symbol is not exist!!");

            this.InvokeIfRequired(() =>
            {
                unlTradingDataBindingSource.DataSource = UnlManager.UnlTradingData;
                unlTradingDataBindingSource.ResetBindings(false);
            });
        }
    }
}
