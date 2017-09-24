using System.Collections.Generic;
using TNS.API.ApiDataObjects;

namespace TNS.BL.Interfaces
{
    public interface IPositionsDataBuilder: IUnlBaseMemberManager
    {
        Dictionary<string, OptionsPositionData> PositionDataDic { get; }
       
        void AddOrUpdateDataToPosition();
    }
}