using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Infra;
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
        public double FullExcessLiquidity { get; set; }

        public double PnL => NetLiquidation - AllConfigurations.AllConfigurationsObject.Trading.InitNetLiquidation;

        public EapiDataTypes APIDataType => EapiDataTypes.AccountSummaryData;

        public List<string> ManagedAccounts { get; set; }

        /// <summary>
        /// Gets the main account. The first one
        /// </summary>
        /// <value>
        /// The main account.
        /// </value>
        public string MainAccount
        {
            get
            {
                if (ManagedAccounts != null && ManagedAccounts.Count > 0)
                    return ManagedAccounts[0];
                return null;
            }
        }
        /// <summary>
        /// Get indication if this account is the real account or simulator.
        /// </summary>
        public bool SimulatorAccount => AllConfigurations.AllConfigurationsObject.Application.MainAccount != MainAccount;
            

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
