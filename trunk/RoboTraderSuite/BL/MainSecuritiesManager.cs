using System;
using System.Collections.Generic;
using System.Linq;
using Infra.Bus;
using Infra.Enum;
using Infra.Extensions.ArrayExtensions;
using log4net;
using TNS.API.ApiDataObjects;
using TNS.DbDAL;

namespace TNS.BL
{
    /// <summary>
    /// Deal with all Main Securities data. Retrieves contract and market data.
    /// </summary>
    public class MainSecuritiesManager : SimpleBaseLogic
    {
        public event Action<SecurityData> SecuritiesUpdated;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(MainSecuritiesManager));
        private readonly ITradingApi _apiWrapper;
        public MainSecuritiesManager(ITradingApi apiWrapper)
        {
            List<MainSecurity> mainSecurityList = DbDalManager.GetMainSecurityList();
            Securities = new Dictionary<string, SecurityData>();
           
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

                StockContract stockContract = new StockContract(security.Symbol,securityType, security.Exchange, security.Currency);
                
                Securities.Add(stockContract.Symbol, new SecurityData() {Contract = stockContract });
            }
            _apiWrapper = apiWrapper;
        }

        protected override void HandleMessage(IMessage message)
        {
            switch (message.APIDataType)
            {
                case EapiDataTypes.SecurityData:
                    var securityData = message as SecurityData;

                    if (securityData != null)
                    {
                        if (securityData.Symbol == "SPX")
                        {
                        }
                        Securities[securityData.Contract.Symbol] = securityData;
                        SecuritiesUpdated?.Invoke(securityData);

                    }

                    break;
            }
        }

        public Dictionary<string, SecurityData> Securities { get; }
        public override void DoWorkAfterConnection()
        {
            var contractList = Securities.Values.Select(securityData => securityData.Contract).ToList();

            _apiWrapper.RequestContinousContractData(contractList);
        }
    }

}