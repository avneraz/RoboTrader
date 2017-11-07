using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Infra.Enum;
using Infra.Extensions;
using log4net;
using NHibernate;
using NHibernate.Linq;
using TNS.API.ApiDataObjects;
using TNS.BL.UnlManagers;

namespace TNS.BL
{
    public class OptionTradingDataFactory
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(OptionTradingDataFactory));

        static OptionTradingDataFactory()
        {
            ExpiryDateListDic = new Dictionary<string, List<DateTime>>();
        }
        public static List<OptionTradingData> GetOptionTradingDataList(string symbol, DateTime expiryDate,
            EStatus status = EStatus.Open)
        {

            var optionTradingDataList = new List<OptionTradingData>();
            var optionDataList = GetOptionDataList(symbol, expiryDate);

            var unlOptionsList = GetUnlOptions(symbol, expiryDate, status);

            foreach (var uo in unlOptionsList)
            {
                var option = optionDataList.FirstOrDefault(od => od.OptionKey == uo.OptionKey);
                if (option == null) continue;
                optionTradingDataList.Add(new OptionTradingData(option, uo));
            }
            //var x = optionTradingDataList[0].DiffDays;
            //var b = optionTradingDataList[0].UnlOptions.OpenTransaction.OrderStatus.LastFillPrice;
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
            var account = AppManager.AppManagerSingleTonObject.AccountManager.MainAccount; // "DU15174";
            if (optionsManager != null)
                return optionsManager.OptionDataDic.Values
                    .Where(od => od.Account.Equals(account) && od.Expiry.Equals(expiryDate)).ToList();

            Logger.Error($"{symbol} OptionsManager is null!!");
            throw new Exception($"{symbol} OptionsManager is null!!");
        }

        private static List<UnlOptions> GetUnlOptions(string symbol, DateTime expiryDate, EStatus status)
        {
            var account = AppManager.AppManagerSingleTonObject.AccountManager.MainAccount; // "DU15174";
            using (ISession session = DBSessionFactory.Instance.OpenSession())
            {
                string expiryStr = $"{expiryDate}";

                var list = session.Query<UnlOptions>()
                    .Where(uo => uo.Account.Equals(account) && uo.Symbol == symbol && uo.OptionKey.Contains(expiryStr));
                return status == EStatus.AllStatus ? list.ToList() : list.Where(p=>p.Status == status).ToList();
            }
        }
        private static Dictionary<string, List<DateTime>> ExpiryDateListDic { get; }
        //private static List<DateTime> ExpiryDateList { get; set; }
        public static List<DateTime> GetUNLExpiryList(string symbol, bool withRefresh)
        {
            //Eliminate the need to access db if it's done already, unless you want to refresh the list.
            if (withRefresh) ExpiryDateListDic[symbol] = null;
            List<DateTime> expiryDateList = ExpiryDateListDic[symbol];

            if (expiryDateList != null) return expiryDateList;

            var account = AppManager.AppManagerSingleTonObject.AccountManager.MainAccount; // "DU15174";
            using (ISession session = DBSessionFactory.Instance.OpenSession())
            {
                IEnumerable<DateTime> expiryDateEnumerable =
                    session.Query<UnlOptions>().Where(p => p.Account == account).DistinctBy(p => p.Expiry)
                        .Select(p => p.Expiry);

                expiryDateList = expiryDateEnumerable.ToList();
                ExpiryDateListDic[symbol] = expiryDateList;
                return expiryDateList;
            }
        }
    }
}
