using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using Infra.Bus;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    public class APIMessageData : IMessage
    {
        public string Message { get; set; }
        public int ErrorCode { get; set; }
        public object AdditionalInfo { get; set; }

        public DateTime UpdateTime { get; set; }
        public EapiDataTypes APIDataType => EapiDataTypes.APIMessageData;
        public override string ToString()
        {
            return $"{UpdateTime} : {Message}. Code={ErrorCode}. AdditionalInfo={AdditionalInfo}.";
        }
    }
}
