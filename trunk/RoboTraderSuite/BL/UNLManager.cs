using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Repository.Hierarchy;
using TNS.API.ApiDataObjects;
using TNS.DbDAL;
using Infra.Bus;
using Infra.Enum;
using log4net;

namespace TNS.BL
{
    public class UNLManager : SimpleBaseLogic
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(UNLManager));
        public UNLManager(MainSecurity mainSecurity, AppManager appManager)
        {
            MainSecurity = mainSecurity;
            _appManager = appManager;
            APIWrapper = _appManager.APIWrapper;
            Logger.InfoFormat("UNLManager({0}) was created!", mainSecurity.Symbol);
        }
        public ITradingApi APIWrapper { get; private set; }
        private readonly AppManager _appManager;
        public MainSecurity MainSecurity { get; private set; }

        public SecurityData MainSecurityData { get; set; }

        public string Symbol => MainSecurityData.Symbol;
        protected override string ThreadName => MainSecurity.Symbol + "_UNLManager_Work";

        protected override void HandleMessage(IMessage message)
        {

            switch (message.APIDataType)
            {
               
                case EapiDataTypes.OptionData:
                    OptionsManager.Enqueue(message);
                    break;
                case EapiDataTypes.PositionData:
                    break;
                case EapiDataTypes.OrderData:
                    break;
               
            }
        }

        public override void DoWorkAfterConnection()
        {
            MainSecurityData = _appManager.GetMainSecurityData(MainSecurity.Symbol);
            OptionsManager = new OptionsManager(this);
            OptionsManager.DoWorkAfterConnection();
        }

        public OptionsManager OptionsManager { get; private set; }
        //public PositionsDataBuilder PositionsDataBuilder { get; private set; }
        //public TradingTimeManager TradingTimeManager { get; private set; }
        //public TradingManager TradingManager { get; private set; }


    }
}