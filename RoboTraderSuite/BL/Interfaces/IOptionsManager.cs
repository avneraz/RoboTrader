using System.Collections.Generic;
using TNS.API.ApiDataObjects;

namespace TNS.BL.Interfaces
{
    public interface IOptionsManager: IUnlBaseMemberManager
    {
        //Dictionary<string, OptionData> OptionDataDic { get; }
        OptionData GetOptionData(string optionKey);
       
    }
}