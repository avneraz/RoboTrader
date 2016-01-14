using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Bus;
using TNS.API.ApiDataObjects;

namespace TNS.RoboTrader
{
    class UIMessageHandler : SmartBaseLogic
    {

        [MessageHandler]
        private void HandleApiMessage(APIMessageData data)
        {
            APIMessageArrive?.Invoke(data);
        }


        [MessageHandler]
        private void HandleExceptionData(ExceptionData data)
        {
            ExceptionThrown?.Invoke(data);
        }
       

        public event Action<APIMessageData> APIMessageArrive;
        public event Action<ExceptionData> ExceptionThrown;
    }
}
