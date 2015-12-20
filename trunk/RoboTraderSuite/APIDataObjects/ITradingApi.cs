using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDataObjects
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
