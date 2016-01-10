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
        /// Request Options chain for specific UNL, the request applies for several months ahead!
        /// </summary>
        /// <param name="securityData"></param>
        /// <param name="months">The max month ahead for loading option data</param>
        /// <param name="minDaysToExpired">The minimum days left of the loading options.</param>
        /// <param name="multiplier"></param>
        void RequestOptionChain(BaseSecurityData securityData, int months,
                                    int minDaysToExpired, int multiplier = 100);
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
