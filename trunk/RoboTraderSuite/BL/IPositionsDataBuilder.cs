using System.Collections.Generic;
using TNS.API.ApiDataObjects;

namespace TNS.BL
{
    public interface IPositionsDataBuilder: IUnlBaseMemberManager
    {
        Dictionary<string, PositionData> PositionDataDic { get; }
        IOptionsManager OptionsManager { get; }
        void AddOptionDataToPosition();
    }
}