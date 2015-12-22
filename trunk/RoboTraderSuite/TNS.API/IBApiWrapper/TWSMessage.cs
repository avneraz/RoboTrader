using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.API.IBApiWrapper
{
    public class TWSMessage
    {
        public TWSMessage(string message, int errorCode, int requestId)
        {
            Message = message;
            ErrorCode = errorCode;
            RequestId = requestId;
        }

        public string Message { get; set; }
        public int ErrorCode { get; set; }
        public int RequestId { get; set; }

        public EtwsErrorCode TWSErrorCode
        {
            get { return (EtwsErrorCode)ErrorCode; }
            set { ErrorCode = (int)value; }
        }
    }
}
