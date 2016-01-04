using Infra.Bus;
using TNS.API.ApiDataObjects;

namespace TNS.BL.Interfaces
{
    public interface IUnlBaseMemberManager
    {
        BaseSecurityData MainSecurityData { get; }
        bool IsConnected { get; }
        ConnectionStatus ConnectionStatus { get; }
        bool HandleMessage(IMessage message);
        void DoWorkAfterConnection();
    }
}