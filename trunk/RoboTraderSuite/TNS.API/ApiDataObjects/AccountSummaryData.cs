using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Infra.Bus;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    public class AccountSummaryData : IMessage
    {

        //tags = NetLiquidation,EquityWithLoanValue,BuyingPower,ExcessLiquidity,FullMaintMarginReq,FullInitMarginReq"
        public double BuyingPower { get; set; }
        public double EquityWithLoanValue { get; set; }
        public double ExcessLiquidity { get; set; }
        public double FullInitMarginReq { get; set; }
        public double FullMaintMarginReq { get; set; }
        public double NetLiquidation { get; set; }

        public EapiDataTypes APIDataType => EapiDataTypes.AccountSummaryData;

        public override string ToString()
        {
            string toString = $"AccountSummaryData: [BuyingPower={BuyingPower}," +
                              $" EquityWithLoanValue={EquityWithLoanValue}," +
                              $" ExcessLiquidity={ExcessLiquidity}, FullInitMarginReq={FullInitMarginReq}," +
                              $" FullMaintMarginReq={FullMaintMarginReq}, NetLiquidation={NetLiquidation}]";
            return toString;
        }
    }
}
