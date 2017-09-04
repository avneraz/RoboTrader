using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Infra.Enum;
using log4net;
using NHibernate;
using NHibernate.Linq;
using Remotion.Linq.Parsing;
using TNS.API.ApiDataObjects;
using TNS.BL.UnlManagers;

namespace TNS.BL
{
    public class OptionTradingDataFactory
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(OptionTradingDataFactory));
        public static List<OptionTradingData> GetOptionTradingDataList(string symbol, DateTime expiryDate)
        {
            
            List<OptionTradingData> optionTradingDataList = new List<OptionTradingData>();
            List<OptionData> optionDataList = GetOptionDataList( symbol,  expiryDate);

            List<UnlOptions> unlOptionsList = GetUnlOptions(symbol,expiryDate);

            foreach (var uo in unlOptionsList)
            {
                var option = optionDataList.FirstOrDefault(od => od.OptionKey == uo.OptionKey);
                if(option == null) continue;
                optionTradingDataList.Add(new OptionTradingData(option, uo));
            }
            var x = optionTradingDataList[0].DiffDays;
            var b = optionTradingDataList[0].UnlOptions.OpenTransaction.OrderStatus.LastFillPrice;
            return optionTradingDataList;
        }

        private static List<OptionData> GetOptionDataList(string symbol, DateTime expiryDate)
        {
            var unlManager = AppManager.AppManagerSingleTonObject.UNLManagerDic[symbol] as UNLManager;
            
                
            if (unlManager == null)
            {
                Logger.Error($"{symbol} UNLManager is null!!");
                throw new Exception($"{symbol} UNLManager is null!!");
            }
            
            var optionsManager = unlManager.OptionsManager as OptionsManager;
            var account = AppManager.AppManagerSingleTonObject.AccountManager.MainAccount;// "DU15174";
            if (optionsManager != null)
                return optionsManager.OptionDataDic.Values
                    .Where(od => od.Account.Equals(account) && od.Expiry.Equals(expiryDate)).ToList();

            Logger.Error($"{symbol} OptionsManager is null!!");
            throw new Exception($"{symbol} OptionsManager is null!!");
        }

        private static List<UnlOptions> GetUnlOptions(string symbol, DateTime expiryDate)
        {
            var account = AppManager.AppManagerSingleTonObject.AccountManager.MainAccount;// "DU15174";
            using (ISession session = DBSessionFactory.Instance.OpenSession())
            {
                string expiryStr = $"{expiryDate}";

                var unlOptionsList = session.Query<UnlOptions>()
                    .Where(uo => uo.Status == EStatus.Open && uo.Account.Equals(account) && uo.Symbol == symbol && uo.OptionKey.Contains(expiryStr))
                    .ToList();

                return unlOptionsList;
            }


        }
    }
}
