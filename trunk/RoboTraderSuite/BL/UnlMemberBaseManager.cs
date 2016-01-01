using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.API.ApiDataObjects;
using TNS.DbDAL;
using Infra.Bus;
using Infra.Enum;

namespace TNS.BL
{
    public class UnlMemberBaseManager
    {
        public UnlMemberBaseManager(ITradingApi apiWrapper, MainSecurity mainSecurity, UNLManager unlManager)
        {
            MainSecurity = mainSecurity;
            APIWrapper = apiWrapper;
            UNLManager = unlManager;
            ConnectionStatus = ConnectionStatus.Disconnected;
            Symbol = mainSecurity.Symbol;
            
        }
        protected const double EPSILON = 0.000000001;
        protected readonly string Symbol;
        protected readonly MainSecurity MainSecurity;
        protected readonly ITradingApi APIWrapper;
        protected readonly UNLManager UNLManager;
        protected SecurityData MainSecurityData { get; private set; }
        public bool IsConnected => ConnectionStatus == ConnectionStatus.Connected;
        public ConnectionStatus ConnectionStatus { get; private set; }
        public virtual void HandleMessage(IMessage message)
        {
            switch (message.APIDataType)
            {
                case EapiDataTypes.SecurityData:
                    var securityData = message as SecurityData;
                    MainSecurityData = securityData;
                    break;
                case EapiDataTypes.BrokerConnectionStatus:

                    var connectionStatusMessage = (BrokerConnectionStatusMessage)message;
                    ConnectionStatus = connectionStatusMessage.Status;
                    if (connectionStatusMessage.AfterConnectionToApiWrapper)
                        DoWorkAfterConnection();

                    break;
            }
        }

        protected virtual void DoWorkAfterConnection()
        {
        }
    }
}
