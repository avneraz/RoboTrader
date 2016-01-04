using System;
using System.Collections.Generic;
using System.Linq;
using Infra.Bus;
using Infra.Enum;
using Infra.Extensions.ArrayExtensions;
using log4net;
using TNS.API;
using TNS.API.ApiDataObjects;
using TNS.DbDAL;

namespace TNS.BL
{
    /// <summary>
    /// Deal with all Main Securities data. Retrieves contract and market data.
    /// </summary>
    public class MainSecuritiesManager : SimpleBaseLogic
    {
        public event Action<BaseSecurityData> SecuritiesUpdated;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(MainSecuritiesManager));
        private readonly ITradingApi _apiWrapper;
        public MainSecuritiesManager(ITradingApi apiWrapper)
        {
            InitializeMainSecurities();
            _apiWrapper = apiWrapper;
        }

        private void InitializeMainSecurities()
        {
            List<MainSecurity> mainSecurityList = DbDalManager.GetMainSecurityList();
            Securities = new Dictionary<string, BaseSecurityData>();

            foreach (var security in mainSecurityList)
            {
                SecurityType securityType;
                try
                {
                    securityType = (SecurityType) Enum.Parse(typeof (SecurityType), security.SecType);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    continue;
                }

                var stockContract = new SecurityContract(security.Symbol, 
                    securityType, security.Exchange, security.Currency);

                Securities.Add(stockContract.Symbol, new SecurityData() {SecurityContract = stockContract});
            }
        }

        protected override void HandleMessage(IMessage message)
        {
            switch (message.APIDataType)
            {
                case EapiDataTypes.SecurityData:
                    var securityData = message as BaseSecurityData;

                    if (securityData != null)
                    {
                        Securities[securityData.GetSymbolName()] = securityData;
                        SecuritiesUpdated?.Invoke(securityData);
                    }
                    break;
                case EapiDataTypes.BrokerConnectionStatus:
                    var connectionStatusMessage = (BrokerConnectionStatusMessage)message;
                    if (connectionStatusMessage.AfterConnectionToApiWrapper)
                        DoWorkAfterConnection();
                    break;
            }
        }

        public Dictionary<string, BaseSecurityData> Securities { get; private set; }
        protected override void DoWorkAfterConnection()
        {
            var contractList = Securities.Values.Select(securityData => securityData.GetContract()).ToList();

            _apiWrapper.RequestContinousContractData(contractList);
        }
    }

}