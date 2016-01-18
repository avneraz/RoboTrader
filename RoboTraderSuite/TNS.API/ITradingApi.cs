using System.Collections.Generic;
using TNS.API.ApiDataObjects;

namespace TNS.API
{
    public interface ITradingApi
    {
        void ConnectToBroker();
        void DisconnectFromBroker();
        void RequestAccountData();
        /// <summary>
        /// Request detail data for several securities taking place in trading.
        /// </summary>
        /// <param name="contracts"></param>
        void RequestContinousContractData(List<ContractBase> contracts);
        /// <summary>
        /// Request detail data for one security.
        /// The same like "RequestContinousContractData" but for 1 security.
        /// </summary>
        void RequestSecurityContractDetails(SecurityData securityData);
        /// <summary>
        ///  Request Options chain for specific UNL, the request applies for several months ahead!
        /// </summary>
        /// <param name="optionToLoadParameters"></param>
        void RequestOptionChain(OptionToLoadParameters optionToLoadParameters);
        
        
        void RequestContinousPositionsData();
        string CreateOrder(OrderData orderData);
        void UpdateOrder(string orderId, OrderData order);
        void CancelOrder(string orderId);
        bool IsConnected { get; }
    }
}
