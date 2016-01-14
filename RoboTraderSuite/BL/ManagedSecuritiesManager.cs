using System;
using System.Collections.Generic;
using System.Linq;
using Infra.Bus;
using Infra.Enum;
using log4net;
using TNS.API;
using TNS.API.ApiDataObjects;
using DAL;
using NHibernate;
using NHibernate.Linq;

namespace TNS.BL
{
    /// <summary>
    /// Deal with all Main Securities data. Retrieves contract and market data.
    /// </summary>
    public class ManagedSecuritiesManager : SimpleBaseLogic
    {
        public event Action<BaseSecurityData> SecuritiesUpdated;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ManagedSecuritiesManager));
        private readonly ITradingApi _apiWrapper;
        public ManagedSecuritiesManager(ITradingApi apiWrapper)
        {
            InitializeMainSecurities();
            _apiWrapper = apiWrapper;
        }

        private void InitializeMainSecurities()
        {
            ISession session = DBSessionFactory.Instance.OpenSession();
            List<ManagedSecurity> managedSecuritiesList = session.Query<ManagedSecurity>().ToList();

            Securities = new Dictionary<string, BaseSecurityData>();

            foreach (var security in managedSecuritiesList)
            {
             
                var stockContract = new SecurityContract(security.Symbol,
                    security.SecurityType, security.Exchange, security.Currency);

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
        protected void DoWorkAfterConnection()
        {
            var contractList = Securities.Values.Select(securityData => securityData.GetContract()).ToList();

            _apiWrapper.RequestContinousContractData(contractList);
        }
    }

}