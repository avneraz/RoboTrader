using System;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using log4net;
using TNS.API.ApiDataObjects;
using TNS.API.IBApiWrapper;
using TNS.Global.Bus;
using TNS.Global.Enum;
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

            switch (meesage.APIDataType)
            {
                case EapiDataTypes.Unknown:
                    break;
                case EapiDataTypes.ExceptionData:
                    HandleException(meesage);
                    break;
                case EapiDataTypes.AccountSummaryData:
                    break;
                case EapiDataTypes.OptionData:
                    break;
                case EapiDataTypes.PositionData:
                    break;
                case EapiDataTypes.OrderData:
                    break;
                case EapiDataTypes.APIMessageData:
                    var apiMessageData = meesage as APIMessageData;
                    if (apiMessageData == null)
                        break;
                    APIMessageArrive?.Invoke(apiMessageData);
                    Logger.Debug(apiMessageData.ToString());
                    break;
                case EapiDataTypes.AccountMemberData:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
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