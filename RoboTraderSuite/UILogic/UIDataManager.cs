using System;
using System.Collections.Generic;
using System.Linq;
using Infra;
using TNS.API.ApiDataObjects;

namespace UILogic
{
    public class UIDataManager
    {
        public UIDataManager()
        {
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


        private void InitializeItems()
        {
           

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
