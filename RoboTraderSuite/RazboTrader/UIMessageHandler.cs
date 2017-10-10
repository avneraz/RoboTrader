using System;
using Infra.Bus;
using TNS.API.ApiDataObjects;

namespace RazboTrader
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
