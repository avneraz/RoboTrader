using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.API.ApiDataObjects;
using TNS.DbDAL;

namespace TNS.BL
{
    public class OrdersManager : UnlMemberBaseManager
    {
        public OrdersManager(ITradingApi apiWrapper, MainSecurity mainSecurity, UNLManager unlManager) : base(apiWrapper, mainSecurity, unlManager)
        {
        }
        protected override void DoWorkAfterConnection()
        {
        }

    }
}
