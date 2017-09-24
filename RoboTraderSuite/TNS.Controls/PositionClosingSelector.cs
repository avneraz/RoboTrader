using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Infra.Extensions;
using TNS.BL;
using TNS.BL.UnlManagers;

namespace TNS.Controls
{
    public partial class PositionClosingSelector : DevExpress.XtraEditors.XtraUserControl
    {
        public PositionClosingSelector()
        {
            InitializeComponent();
            _appManager = AppManager.AppManagerSingleTonObject;
        }
        private readonly AppManager _appManager;
        private UNLManager UnlManager { get; set; }
        private string _symbol;

        public string Symbol
        {
            get => _symbol;
            set
            {
                _symbol = value;
                UnlManager = _appManager.UNLManagerDic[_symbol] as UNLManager;
                if (UnlManager == null) throw new Exception("The symbol is not exist!!");

                this.InvokeIfRequired (() =>
                {
                    unlTradingDataBindingSource.DataSource = UnlManager.UnlTradingData;
                    unlTradingDataBindingSource.ResetBindings(false);

                });
             
            }
        }
    }
}
