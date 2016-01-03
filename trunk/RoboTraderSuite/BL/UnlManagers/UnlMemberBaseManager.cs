using Infra.Bus;
using Infra.Enum;
using TNS.API;
using TNS.API.ApiDataObjects;
using TNS.BL.Interfaces;
using TNS.DbDAL;

namespace TNS.BL.UnlManagers
{
   

    public class UnlMemberBaseManager : IUnlBaseMemberManager
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
        public SecurityData MainSecurityData { get; private set; }
        public bool IsConnected => ConnectionStatus == ConnectionStatus.Connected;
        public ConnectionStatus ConnectionStatus { get; private set; }
        public virtual bool HandleMessage(IMessage message)
        {
            bool result = false;
            switch (message.APIDataType)
            {
                case EapiDataTypes.SecurityData:
                    var securityData = message as SecurityData;
                    MainSecurityData = securityData;
                    result = true;
                    break;
                case EapiDataTypes.BrokerConnectionStatus:

                    var connectionStatusMessage = (BrokerConnectionStatusMessage)message;
                    ConnectionStatus = connectionStatusMessage.Status;
                    if (connectionStatusMessage.AfterConnectionToApiWrapper)
                        DoWorkAfterConnection();
                    result = true;
                    break;
            }
            return result;
        }

        public virtual void DoWorkAfterConnection()
        {
        }
    }
}
