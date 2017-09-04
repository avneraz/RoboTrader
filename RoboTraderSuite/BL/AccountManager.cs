using System;
using Infra.Bus;
using Infra.Enum;
using TNS.API;
using TNS.API.ApiDataObjects;

namespace TNS.BL
{
    public class AccountManager : SimpleBaseLogic
    {
        private readonly ITradingApi _apiWrapper;

        public AccountManager(ITradingApi apiWrapper)
        {
            _apiWrapper = apiWrapper;
        }
        public void SubscribeAccountUpdates()
        {
            //bool subscribe, string acctCode
            //_ibClient.ClientSocket.reqAccountUpdates(subscribe, acctCode);
        }
        protected override string ThreadName => "AccountManager_Work";

        protected override void HandleMessage(IMessage message)
        {
            switch (message.APIDataType)
            {
                case EapiDataTypes.AccountSummaryData:
                    var accountData = (AccountSummaryData)message;
                    if(MainAccount == null)
                        MainAccount = accountData.MainAccount;
                    EquityWithLoanValue = accountData.EquityWithLoanValue;
                    FullMaintMarginReq = accountData.FullMaintMarginReq;
                    NetLiquidation = accountData.NetLiquidation;
                    break;
                case EapiDataTypes.BrokerConnectionStatus:
                    var connectionStatusMessage = (BrokerConnectionStatusMessage)message;
                    if (connectionStatusMessage.AfterConnectionToApiWrapper)
                        DoWorkAfterConnection();
                    break;
            }
        }

        public string MainAccount { get; set; }
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

        protected void DoWorkAfterConnection()
        {
            _apiWrapper.RequestAccountData();
        }
    }
}