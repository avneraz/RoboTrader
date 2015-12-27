using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.API.ApiDataObjects;

namespace TNS.BL
{
    public class UIDataManager
    {
        public UIDataManager(AppManager appManager)
        {
            _appManager = appManager;
            InitializeItems();
        }

        public Dictionary<string, SecurityData> Securities { get; set; }

        public List<SecurityData> GetSecurityDataList()
        {
            return Securities.Values.ToList();
        }
        public event Action<SecurityData> SecuritiesUpdated;

        private readonly AppManager _appManager;

        private void InitializeItems()
        {
            //Get Securities:
            Securities = _appManager.MainSecuritiesManager.Securities;
            _appManager.MainSecuritiesManager.SecuritiesUpdated += 
                                MainSecuritiesManagerOnSecuritiesUpdated;
        }

        private void MainSecuritiesManagerOnSecuritiesUpdated(SecurityData securityData)
        {
            SecuritiesUpdated?.Invoke(securityData);
        }
    }
}
