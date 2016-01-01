using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Enum;
using Infra.Bus;

namespace TNS.API.ApiDataObjects
{


    public class RequestDataReceived : IMessage
    {
        public RequestDataReceived(EapiDataTypes receivedApiDataType)
        {
            ReceivedApiDataType = receivedApiDataType;
        }

        public EapiDataTypes APIDataType => EapiDataTypes.RequestDataReceived;
        public EapiDataTypes ReceivedApiDataType { get; set; }
       
    }
}
