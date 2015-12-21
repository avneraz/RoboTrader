using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net.Util.TypeConverters;
using TNS.API.ApiDataObjects;

namespace TNS.BrokerDAL.DataObjects
{
    public class AccountSummaryData
    {

        //tags = NetLiquidation,EquityWithLoanValue,BuyingPower,ExcessLiquidity,FullMaintMarginReq,FullInitMarginReq"
        public double BuyingPower { get; set; }
        public double EquityWithLoanValue { get; set; }
        public double ExcessLiquidity { get; set; }
        public double FullInitMarginReq { get; set; }
        public double FullMaintMarginReq { get; set; }
        public double NetLiquidation { get; set; }

        #region Static Stuff

        private static List<PropertyInfo> _propertiesInfoList;

        public static void UpdateAccountSummaryData(AccountMemberData accountMemberData)
        {
            var propInfo = PropertiesInfoList.FirstOrDefault(pi => pi.Name == accountMemberData.Tag);
            propInfo?.SetValue(AccountSummaryDataObject, Convert.ToDouble(accountMemberData.Values));
        }

        private static AccountSummaryData _accountSummaryDataObject;

        public static AccountSummaryData AccountSummaryDataObject =>
            _accountSummaryDataObject ?? (_accountSummaryDataObject = new AccountSummaryData());

        private static IEnumerable<PropertyInfo> PropertiesInfoList
        {
            get
            {
                if (_propertiesInfoList != null) return _propertiesInfoList;

                var type = typeof(AccountSummaryData);
                _propertiesInfoList = type.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
                return _propertiesInfoList;
            }
        } 
        #endregion

        public override string ToString()
        {
            string toString = $"BuyingPower={BuyingPower}, EquityWithLoanValue={EquityWithLoanValue}, ExcessLiquidity={ExcessLiquidity}, FullInitMarginReq={FullInitMarginReq}, FullMaintMarginReq={FullMaintMarginReq}, NetLiquidation={NetLiquidation}";
            return toString;
        }
    }
}
