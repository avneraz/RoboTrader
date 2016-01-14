using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infra.Extensions;
using TNS.API.ApiDataObjects;
using TNS.BL;
using UILogic;

namespace TNS.Controls
{
    public partial class OrdersView : UserControl, IUIData
    {
        public OrdersView()
        {
            InitializeComponent();
        }
        public UIDataManager UIDataManager { get; set; }
        public void SetUIDataManager(UIDataManager uiDataManager)
        {
            
            UIDataManager = uiDataManager;
            this.InvokeIfRequired(() => {
                orderStatusDataBindingSource.DataSource = UIDataManager.GetOrderStatusDataList();
                orderStatusDataBindingSource.ResetBindings(false);
            });
            UIDataManager.OrderStatusDataUpdated += UIDataManagerOnOrderStatusDataUpdated;
        }

        private void UIDataManagerOnOrderStatusDataUpdated(OrderStatusData orderStatusData)
        {
            this.InvokeIfRequired(() =>
            {
                orderStatusDataBindingSource.DataSource = UIDataManager.GetOrderStatusDataList();
                orderStatusDataBindingSource.ResetBindings(false);
            });
        }



    }
}
