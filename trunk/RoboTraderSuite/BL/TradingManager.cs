using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TNS.API.ApiDataObjects;
using TNS.DbDAL;
using Infra.Bus;
using Infra.Enum;

namespace TNS.BL
{
    public class TradingManager : UnlMemberBaseManager
    {
        public TradingManager(ITradingApi apiWrapper, MainSecurity mainSecurity, UNLManager unlManager) : base(apiWrapper, mainSecurity, unlManager)
        {
        }

        private AccountSummaryData AccountSummaryData { get; set; }
        public override void HandleMessage(IMessage message)
        {
            base.HandleMessage(message);
            switch (message.APIDataType)
            {
                case EapiDataTypes.AccountSummaryData:
                    AccountSummaryData = message as AccountSummaryData;
                    break;
            }

        }
        protected override void DoWorkAfterConnection()
        {
        }

      
    }
}