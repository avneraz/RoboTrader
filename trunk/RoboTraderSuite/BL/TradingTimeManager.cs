using TNS.API.ApiDataObjects;
using TNS.DbDAL;

namespace TNS.BL
{
    /// <summary>
    /// Determines the trading time, start and end trading time, and also if the current day is working day.
    /// </summary>
    public class TradingTimeManager: UnlMemberBaseManager
    {
       
        protected override void DoWorkAfterConnection()
        {
        }

        public TradingTimeManager(ITradingApi apiWrapper, MainSecurity mainSecurity, UNLManager unlManager) : base(apiWrapper, mainSecurity, unlManager)
        {
        }
    }
}