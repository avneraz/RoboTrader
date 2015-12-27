using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TNS.API.ApiDataObjects;
using TNS.BL;

namespace TNS.Controls
{
    public partial class MainSecuritiesView : UserControl,IUIData
    {
        public MainSecuritiesView()
        {
            InitializeComponent();
        }

        public MainSecuritiesView(UIDataManager uiDataManager):this()
        {
            UIDataManager = uiDataManager;
        }

        public void SetUIDataManager(UIDataManager uiDataManager)
        {
            UIDataManager = uiDataManager;
            Action action = () => {
                                      securityDataBindingSource.DataSource = UIDataManager.GetSecurityDataList();
                securityDataBindingSource.ResetBindings(false);
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action.Invoke();

            UIDataManager.SecuritiesUpdated+= UIDataManagerOnSecuritiesUpdated;
        }

        private void UIDataManagerOnSecuritiesUpdated(SecurityData securityData)
        {
            Action action = () => {
                securityDataBindingSource.DataSource = UIDataManager.GetSecurityDataList();
                securityDataBindingSource.ResetBindings(false);
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action.Invoke();
        }

        public UIDataManager UIDataManager { get; set; }
    }
}
