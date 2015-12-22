using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.API.Infra.Bus;

namespace TNS.API.ApiDataObjects
{
    public class ExceptionData : IMessage
    {
        public ExceptionData(Exception thrownException)
        {
            ThrownException = thrownException;
        }

        public Exception ThrownException { get; set; }

        public override string ToString()
        {
           string toString = $"AAA:{ThrownException.Message}";
            return toString;
        }
    }
}
