using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IBApi;

namespace TNS.API.IBApiWrapper
{
    class ContractDetailsWaiter
    {
        private readonly Task<List<ContractDetails>> _task;
        private readonly ManualResetEvent _event;
        private readonly List<ContractDetails> _contracts;


        public ContractDetailsWaiter()
        {
            _task = new Task<List<ContractDetails>>(WaitForContract);
            _event = new ManualResetEvent(false);
            _contracts = new List<ContractDetails>();
        }

        public Task<List<ContractDetails>> GetContracts()
        {
            _task.Start();
            return _task;
        }

        public void OnContractReceived(ContractDetails contract)
        {
            _contracts.Add(contract);
        }

        public void OnContractReceiveEnd()
        {
            _event.Set();
        }

        private List<ContractDetails> WaitForContract()
        {
            //TODO: add timeout
            _event.WaitOne();
            return _contracts;
        }
    }
}
