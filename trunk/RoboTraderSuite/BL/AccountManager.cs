using System;
using Infra.Bus;
using Infra.Enum;
using TNS.API.ApiDataObjects;

namespace TNS.BL
{
    public class AccountManager : SimpleBaseLogic
    {
        protected override string ThreadName => "AccountManager_Work";

        protected override void HandleMessage(IMessage message)
        {
            switch (message.APIDataType)
            {
                case EapiDataTypes.AccountSummaryData:
                    var accountData = message as AccountSummaryData;

                    EquityWithLoanValue = accountData.EquityWithLoanValue;
                    FullMaintMarginReq = accountData.FullMaintMarginReq;
                    NetLiquidation = accountData.NetLiquidation;
                    break;
            }
        }


        /// <summary>
        /// Current money plus option market value
        /// </summary>
        public double EquityWithLoanValue { get; set; }

        /// <summary>
        /// Margin maintenance required 
        /// </summary>
        public double FullMaintMarginReq { get; set; }

        /// <summary>
        /// Invested money plus PnL
        /// </summary>
        public double NetLiquidation { get; set; }
    }
}