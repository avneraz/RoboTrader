using System.Collections.Generic;

namespace TNS.API.ApiDataObjects
{
    public interface ITradingApi
    {
        void RequestContinousOptionChainData(List<OptionContract> contracts);
        void RequestContinousPositionsData();
        string CreateOrder(OptionContract contract, OrderData order);
        void UpdateOrder(string orderId, OptionContract contract, OrderData order);

        void CancelOrder(string orderId);
    }
}
