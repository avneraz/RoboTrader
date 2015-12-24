using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Repository.Hierarchy;
using TNS.API.ApiDataObjects;
using TNS.DbDAL;
using TNS.Global.Bus;
using TNS.Global.Enum;

namespace TNS.BL
{
    public class UNLManager : SimpleBaseLogic
    {
        public UNLManager(MainSecurity mainSecurity)
        {
            MainSecurity = mainSecurity;
        }

        MainSecurity MainSecurity { get; set; }
        protected override string ThreadName => "UNLManager_Work";

        protected override void HandleMessage(IMessage meesage)
        {

            switch (meesage.APIDataType)
            {
               
                case EapiDataTypes.OptionData:
                    break;
                case EapiDataTypes.PositionData:
                    break;
                case EapiDataTypes.OrderData:
                    break;
               
            }
        }

        public OptionsManager OptionsManager { get; private set; }
        public PositionsDataBuilder PositionsDataBuilder { get; private set; }
        public TradingTimeManager TradingTimeManager { get; private set; }
        public TradingManager TradingManager { get; private set; }


    }
}