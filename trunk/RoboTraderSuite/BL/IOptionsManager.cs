using System.Collections.Generic;
using TNS.API.ApiDataObjects;

namespace TNS.BL
{
    public interface IOptionsManager: IUnlBaseMemberManager
    {
        Dictionary<string, OptionData> OptionDataDic { get; }
        OptionData GetOptionData(string optionKey);

        void RequestContinousContractData(List<ContractBase> contractList);
    }
}