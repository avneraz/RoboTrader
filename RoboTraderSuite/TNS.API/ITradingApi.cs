using System.Collections.Generic;
using TNS.API.ApiDataObjects;

namespace TNS.API
{
    public interface ITradingApi
    {
        void ConnectToBroker();
        void DisconnectFromBroker();
        void RequestAccountData();
        void RequestContinousContractData(List<ContractBase> contracts);

        /// <summary>
        ///  Request Options chain for specific UNL, the request applies for several months ahead!
        /// </summary>
        /// <param name="optionToLoadParameters"></param>
        void RequestOptionChain(OptionToLoadParameters optionToLoadParameters);
        /// <summary>
        /// Request detail data for all securities taking place in trading.
        /// </summary>
        void RequestContractDetailsData(BaseSecurityData securityData);
        void RequestContinousPositionsData();
        string CreateOrder(OrderData orderData);
        void UpdateOrder(string orderId, OrderData order);
        void CancelOrder(string orderId);
        bool IsConnected { get; }
    }
}
