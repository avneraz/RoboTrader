using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TNS.API.Infra.Bus;

namespace TNS.API.ApiDataObjects
{
    public class AccountSummaryData: IMessage
    {

        //tags = NetLiquidation,EquityWithLoanValue,BuyingPower,ExcessLiquidity,FullMaintMarginReq,FullInitMarginReq"
        public double BuyingPower { get; set; }
        public double EquityWithLoanValue { get; set; }
        public double ExcessLiquidity { get; set; }
        public double FullInitMarginReq { get; set; }
        public double FullMaintMarginReq { get; set; }
        public double NetLiquidation { get; set; }

        #region Static Stuff

       
        private static AccountSummaryData _accountSummaryDataObject;

        public static AccountSummaryData AccountSummaryDataObject =>
            _accountSummaryDataObject ?? (_accountSummaryDataObject = new AccountSummaryData());

        #endregion

        public override string ToString()
        {
            string toString = $"BuyingPower={BuyingPower}, EquityWithLoanValue={EquityWithLoanValue}, ExcessLiquidity={ExcessLiquidity}, FullInitMarginReq={FullInitMarginReq}, FullMaintMarginReq={FullMaintMarginReq}, NetLiquidation={NetLiquidation}";
            return toString;
        }
    }
}
