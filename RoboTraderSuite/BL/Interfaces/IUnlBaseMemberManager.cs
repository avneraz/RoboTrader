using Infra.Bus;
using TNS.API.ApiDataObjects;

namespace TNS.BL.Interfaces
{
    public interface IUnlBaseMemberManager
    {
        SecurityData MainSecurityData { get; }
        bool IsConnected { get; }
        ConnectionStatus ConnectionStatus { get; }
        bool HandleMessage(IMessage message);
        void DoWorkAfterConnection();
        bool RequestOptionChainDone { get; set; }
        UnlTradingData UnlTradingData { get;  }
    }
}