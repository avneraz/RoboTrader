using System.Collections.Generic;
using TNS.API.ApiDataObjects;

namespace TNS.BL.Interfaces
{
    public interface IPositionsDataBuilder: IUnlBaseMemberManager
    {
        //Dictionary<string, PositionData> PositionDataDic { get; }
       
        void AddOptionDataToPosition();
    }
}