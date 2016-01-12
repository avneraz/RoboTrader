using Infra.Bus;
using Infra.Enum;
using TNS.API;
using TNS.API.ApiDataObjects;
using TNS.BL.Interfaces;

namespace TNS.BL.UnlManagers
{
   

    public class UnlMemberBaseManager : IUnlBaseMemberManager
    {
        public UnlMemberBaseManager(ITradingApi apiWrapper, ManagedSecurities managedSecurity, UNLManager unlManager)
        {
            ManagedSecurity = managedSecurity;
            APIWrapper = apiWrapper;
            UNLManager = unlManager;
            ConnectionStatus = ConnectionStatus.Disconnected;
            Symbol = managedSecurity.Symbol;
            
        }
        protected const double EPSILON = 0.000000001;
        protected readonly string Symbol;
        protected readonly ManagedSecurities ManagedSecurity;
        protected readonly ITradingApi APIWrapper;
        protected readonly UNLManager UNLManager;
        // ReSharper disable once InconsistentNaming
        protected BaseSecurityData _mainSecurityData;

        public virtual BaseSecurityData MainSecurityData
        {
            get { return _mainSecurityData; }
            protected set { _mainSecurityData = value; }
        }

        public bool IsConnected => ConnectionStatus == ConnectionStatus.Connected;
        public ConnectionStatus ConnectionStatus { get; private set; }
        public virtual bool HandleMessage(IMessage message)
        {
            bool result = false;
            switch (message.APIDataType)
            {
                case EapiDataTypes.SecurityData:
                    var securityData = message as BaseSecurityData;
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
