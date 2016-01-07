using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra;
using TNS.API.ApiDataObjects;
using TNS.BL.Interfaces;
using TNS.BL.UnlManagers;

namespace TNS.BL
{
    public class UIDataManager
    {
        public UIDataManager(AppManager appManager)
        {
            _appManager = appManager;
            GeneralTimer.GeneralTimerInstance.AddTask(TimeSpan.FromSeconds(10), InitializeItems, false);
        }

        public Dictionary<string, BaseSecurityData> Securities { get; set; }

        public Dictionary<string, OrderStatusData> OrderStatusDataDic { get; set; }

        public List<OrderStatusData> GetOrderStatusDataList()
        {
            return OrderStatusDataDic.Values.ToList();
        }
        public List<BaseSecurityData> GetSecurityDataList()
        {
            return Securities.Values.ToList();
        }
        public event Action<BaseSecurityData> SecuritiesUpdated;

        public event Action<OrderStatusData> OrderStatusDataUpdated;

        private readonly AppManager _appManager;

        private void InitializeItems()
        {
            //Get Securities:
            Securities = _appManager.MainSecuritiesManager.Securities;
            _appManager.MainSecuritiesManager.SecuritiesUpdated += 
                                MainSecuritiesManagerOnSecuritiesUpdated;
            IOrdersManager ordersManager = ((UNLManager) (_appManager.UNLManagerDic["AAPL"])).OrdersManager;
            OrderStatusDataDic = ordersManager.OrderStatusDataDic;
            ordersManager.OrderStatusDataUpdated += OrderManagerOnOrderStatusDataUpdated;

        }

        private void OrderManagerOnOrderStatusDataUpdated(OrderStatusData orderStatusData)
        {
            OrderStatusDataUpdated?.Invoke(orderStatusData);
        }

        private void MainSecuritiesManagerOnSecuritiesUpdated(BaseSecurityData securityData)
        {
            SecuritiesUpdated?.Invoke(securityData);
        }
    }
}
