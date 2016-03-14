using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infra;
using Infra.Extensions;
using TNS.API.ApiDataObjects;
using TNS.BL;
using UILogic;

namespace TNS.Controls
{
    public partial class OrdersView : UserControl
    {
        public OrdersView()
        {
            InitializeComponent();
        }


      

        private bool _dataloaded;
        private void SetAndUpdate()
        {
            //optionsPositionDataBindingSource.DataSource = PositionDataDic.Values.ToList();
            //optionsPositionDataBindingSource.DataSource = OptionsPositionDataList;
            grdOrders.Refresh();
            if (_dataloaded)
                return;
            if (OrderStatusDataDic.Count > 0)
            {
                _dataloaded = true;
                GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(1),
                    () =>
                    {
                        grdOrders.InvokeIfRequired(() =>
                        {
                            orderStatusDataBindingSource.DataSource = OrderStatusDataDic.Values.ToList();
                            orderStatusDataBindingSource.ResetBindings(false);
                           
                        });
                    },
                    true);
            }
        }

        public OrderStatusData SelectedOrderStatusData
        {
            get
            {
                if (OrderStatusDataDic.Count == 0)
                    return null;
                var pos = grdViewOrders.GetSelectedRows()[0];
                var orderStatusData = grdViewOrders.GetRow(pos) as OrderStatusData;
                return orderStatusData;
            }
        }


        private Dictionary<string, OrderStatusData> OrderStatusDataDic { get; set; }

        //public void SetOrderStatusDataDic(Dictionary<string, OrderStatusData> orderStatusDataDic)
        //{
        //    OrderStatusDataDic = orderStatusDataDic;
        //    //OptionsPositionDataList = positionDataDic.Values.ToList();
        //    GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(30), () => grdOrders.InvokeIfRequired(SetAndUpdate), false);
        //}

        private void iCancelOrder_Click(object sender, EventArgs e)
        {

        }

        public void SetOrderStatusDataList(List<OrderStatusData> orderStatusDataList)
        {
            grdOrders.InvokeIfRequired(() =>
            {
                orderStatusDataBindingSource.DataSource = orderStatusDataList;
                orderStatusDataBindingSource.ResetBindings(false);

            });

            GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(1),
               () =>
               {
                   grdOrders.InvokeIfRequired(() =>
                   {
                       orderStatusDataBindingSource.ResetBindings(false);

                   });
               },
               true);

        }
    }
}
