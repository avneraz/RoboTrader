using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Bus;

namespace TNS.API.ApiDataObjects
{
    public interface ISymbolMessage : IMessage
    {
        string GetSymbolName();
        ContractBase GetContract();
    }
}
