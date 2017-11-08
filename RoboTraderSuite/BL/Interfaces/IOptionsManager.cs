using System;
using System.Collections.Generic;
using Infra.Enum;
using TNS.API.ApiDataObjects;

namespace TNS.BL.Interfaces
{
    public interface IOptionsManager: IUnlBaseMemberManager
    {
        //Dictionary<string, OptionData> OptionDataDic { get; }
        OptionData GetOptionData(string optionKey);

        OptionData GetATMOptionData(DateTime expiry, EOptionType optionType);

        /// <summary>
        /// Check if there is any option that close enugh to the ATM option.
        /// </summary>
        /// <param name="optionType"></param>
        /// <param name="expiryDate"></param>
        /// <returns></returns>
        bool CheckForATMOption(EOptionType optionType, DateTime expiryDate);

        /// <summary>
        /// Get the Implied Volatility on the ATM option.
        /// </summary>
        /// <param name="optionType"></param>
        /// <param name="expiryDate"></param>
        /// <returns></returns>
        double GetImVolOnATMOption(EOptionType optionType, DateTime expiryDate);
        Dictionary<string, OptionData> OptionDataDic { get; }
    }
}