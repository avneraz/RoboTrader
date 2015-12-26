using System.Collections.Generic;
using Infra.Bus;
using Infra.Enum;
using TNS.API.ApiDataObjects;

namespace TNS.BL
{
    /// <summary>
    /// Deal with all Main Securities data. Retrieves contract and market data.
    /// </summary>
    public class MainSecuritiesManager : SimpleBaseLogic
    {
        public MainSecuritiesManager()
        {
            Securities = new Dictionary<string, SecurityData>();
        }

        protected override void HandleMessage(IMessage message)
        {
            switch (message.APIDataType)
            {
                case EapiDataTypes.SecurityData:
                    var securityData = message as SecurityData;

                    if (securityData != null) Securities[securityData.Contract.Symbol] = securityData;
                    break;
            }
        }

        public Dictionary<string, SecurityData> Securities { get; }
    }

}