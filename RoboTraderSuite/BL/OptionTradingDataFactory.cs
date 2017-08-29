using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.API.ApiDataObjects;

namespace TNS.BL
{
    public class OptionTradingDataFactory
    {
        public static List<OptionTradingData> GetOptionTradingDataList(string symbol, DateTime expiryDate)
        {
            List<OptionTradingData> optionTradingDataList = new List<OptionTradingData>();
            List<OptionData> optionDataList = null;
            List<UnlOptions> unlOptionsList = null;

            

            foreach (var uo in unlOptionsList)
            {
                var option = optionDataList.FirstOrDefault(od => od.OptionKey == uo.OptionKey);
                optionTradingDataList.Add(new OptionTradingData(option, uo));
            }

            return optionTradingDataList;
        }

        private static List<OptionData> GetOptionDataList()
        {
            
        }
    }
}
