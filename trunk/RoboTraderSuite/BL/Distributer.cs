using System;
using System.Collections.Generic;
using log4net;
using TNS.API.ApiDataObjects;
using TNS.Global.Bus;
using TNS.Global.Enum;

namespace TNS.BL
{
    public class Distributer : SimpleBaseLogic
    {
        public Distributer(Dictionary<string, UNLManager> unlManagerDic)
        {
            UNLManagerDic = unlManagerDic;
        }

        public event Action<ExceptionData> ExceptionThrown;
        public event Action<APIMessageData> APIMessageArrive;
        
        private Dictionary<string, UNLManager> UNLManagerDic { get; set; }
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
                
                case EapiDataTypes.APIMessageData:
                    var apiMessageData = meesage as APIMessageData;
                    if (apiMessageData == null)
                        break;
                    APIMessageArrive?.Invoke(apiMessageData);
                    Logger.Debug(apiMessageData.ToString());
                    break;
                case EapiDataTypes.AccountMemberData:
                    break;
                case EapiDataTypes.OptionData:
                    //var optionData = meesage as OptionData;


                    break;
                case EapiDataTypes.PositionData:
                case EapiDataTypes.OrderData:

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