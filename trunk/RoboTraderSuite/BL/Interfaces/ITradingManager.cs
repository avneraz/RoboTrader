using TNS.API.ApiDataObjects;

namespace TNS.BL.Interfaces
{
    public interface ITradingManager : IUnlBaseMemberManager
    {
        AccountSummaryData AccountSummaryData { get; set; }
    }
}