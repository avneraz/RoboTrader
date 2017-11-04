using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Bus;
using Infra.Enum;
using TNS.BL.UnlManagers;

namespace TNS.BL.Interfaces
{
    public interface ISubscibeMessage
    {
        bool HandleMessage(IMessage message);

        UNLManager UnlManager { get; }
        EapiDataTypes DataType { get; }
        void RegisterForMessage();

        void UnRegisterForMessage();

    } 
    
}
