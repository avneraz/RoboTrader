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
        protected override void HandleMessage(IMessage message)
        {
            switch (message.APIDataType)
            {
                case EapiDataTypes.SecurityData:
                    var securityData = message as SecurityData;

                    securities_[securityData.Contract] = securityData;
                    break;
            }
        }

        private Dictionary<ContractBase, SecurityData> securities_;

    }

}