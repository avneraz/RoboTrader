using Infra.Bus;
using Infra.Enum;
using TNS.API;
using TNS.API.ApiDataObjects;
using TNS.BL.Interfaces;

namespace TNS.BL.UnlManagers
{
    public class TradingManager : UnlMemberBaseManager, ITradingManager
    {
        public TradingManager(ITradingApi apiWrapper, ManagedSecurities managedSecurity, UNLManager unlManager) : base(apiWrapper, managedSecurity, unlManager)
        {
        }

        public AccountSummaryData AccountSummaryData { get; set; }
        public override bool HandleMessage(IMessage message)
        {
            bool result = base.HandleMessage(message);
            if (result)
                return true;

            switch (message.APIDataType)
            {
                case EapiDataTypes.AccountSummaryData:
                    AccountSummaryData = message as AccountSummaryData;
                    return true;
            }
            return false;

        }

        public override void DoWorkAfterConnection()
        {
        }

      
    }
}