using Infra.Bus;
using TNS.API.ApiDataObjects;

namespace TNS.BL
{
    public interface IUnlBaseMemberManager
    {
        SecurityData MainSecurityData { get; }
        bool IsConnected { get; }
        ConnectionStatus ConnectionStatus { get; }
        bool HandleMessage(IMessage message);
        void DoWorkAfterConnection();
    }
}