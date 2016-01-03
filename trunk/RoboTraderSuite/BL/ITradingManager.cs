using TNS.API.ApiDataObjects;

namespace TNS.BL
{
    public interface ITradingManager : IUnlBaseMemberManager
    {
        AccountSummaryData AccountSummaryData { get; set; }
    }
}