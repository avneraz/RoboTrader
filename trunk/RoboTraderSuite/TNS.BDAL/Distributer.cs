using System;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using log4net;
using TNS.API.ApiDataObjects;
using TNS.API.IBApiWrapper;
using TNS.API.Infra.Bus;
using TNS.Global.PopUpMessages;

namespace TNS.BrokerDAL
{
    public class Distributer : SimpleBaseLogic
    {
        public event Action<ExceptionData> ExceptionThrown;
        public event Action<APIMessageData> APIMessageArrive;
        public Distributer()
        {
        }

        private static readonly ILog Logger = LogManager.GetLogger(typeof(Distributer));
        protected override void HandleMessage(IMessage meesage)
        {
            
            
            switch (meesage.GetType().Name)
            {
                case "APIMessageData":
                    APIMessageData apiMessageData = meesage as APIMessageData;
                    if (apiMessageData == null)
                        break;
                    APIMessageArrive?.Invoke(apiMessageData);
                    Logger.Debug(apiMessageData.ToString());
                    break;
                case "AccountSummaryData":
                    
                    
                    break;
                case "ExceptionData":
                    HandleException(meesage);
                    break;
                case "OptionData":
                    break;
                case "OrderData":
                    break;
                case "PositionData":
                    break;
            }


        }

        private  void HandleException(IMessage meesage)
        {
            ExceptionData exceptionData = meesage as ExceptionData;
            if (exceptionData == null) return;
            ExceptionThrown?.Invoke(exceptionData);
            
            Logger.Error(exceptionData.ThrownException);
        }
    }
}