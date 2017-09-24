using TNS.API.ApiDataObjects;
using TNS.BL.UnlManagers;

namespace TNS.Trading
{
    /// <summary>
    /// Responsible and manage UNL trading and coordinates the activities between all.
    /// </summary>
    public class TradingGeneralManager
    {
        public void CloseAllUnlPositions(UNLManager unlManager)
        {
            var positionList = unlManager.PositionsDataBuilder.PositionDataDic.Values;

            foreach (OptionsPositionData positionData in positionList)
            {
                unlManager.OrdersManager.BuyOption(positionData.OptionData, positionData.Position);
            }
        }
    }
}
