using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.BrokerDAL;

namespace TNS.BL
{
    public class AppManager
    {
        private void InitializeMembers()
        {
            throw new System.NotImplementedException();
        }
        #region Managers Properties

        public PositionsDataBuilder PositionsDataBuilder { get; private set; }

        public AccountManager AccountManager { get; private set; }

        //public ContractManager ContractManager { get; private set; }

        public OptionsManager OptionsManager { get; private set; }


        #endregion


    }
}
