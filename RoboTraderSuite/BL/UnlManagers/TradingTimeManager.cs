using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Infra.Bus;
using Infra.Enum;
using Infra.Extensions;
using log4net;
using TNS.API;
using TNS.API.ApiDataObjects;
using TNS.BL.Interfaces;
using TNS.DbDAL;

namespace TNS.BL.UnlManagers
{
    /// <summary>
    /// Determines the trading time, start and end trading time, and also if the current day is working day.
    /// </summary>
    public class TradingTimeManager : UnlMemberBaseManager, ITradingTimeManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(TradingTimeManager));
        

        public TradingTimeManager(ITradingApi apiWrapper, MainSecurity mainSecurity, UNLManager unlManager) :
            base(apiWrapper, mainSecurity, unlManager)
        {

        }

        private bool _requestContractDetailsDataDone;
        public override bool HandleMessage(IMessage message)
        {
            bool result = base.HandleMessage(message);
            if (result)
                return true;

            if (_requestContractDetailsDataDone == false && 
                message.APIDataType == EapiDataTypes.SecurityData)
            {
                Debug.WriteLine(MainSecurityData.GetContract());
                APIWrapper.RequestContractDetailsData(MainSecurityData);
                _requestContractDetailsDataDone = true;
            }
            
            if (message.APIDataType != EapiDataTypes.ContractDetailsData) return false;

            ContractDetailsData = (ContractDetailsData) message;
            if (_cancellationTokenSource == null)
                _cancellationTokenSource = new CancellationTokenSource();
            else
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = new CancellationTokenSource();
            }
            ScheduleTradingStartWorkingEventAsync();
            ScheduleTradingEndWorkingEventAsync();
            return true;
        }

        public override void DoWorkAfterConnection()
        {
           
        }
        // ***Declare a System.Threading.CancellationTokenSource.
        private CancellationTokenSource _cancellationTokenSource;

        public async void ScheduleTradingEndWorkingEventAsync()
        {
            try
            {
                //We are after trading!
                if (EndTradingTimeLocal <= DateTime.Now)
                    return;
                //Raise event 1 minutes before trading end:
                var ms = (int)Math.Abs(EndTradingTimeLocal.Subtract(DateTime.Now).TotalMilliseconds) - 60000;

                await Task.Delay(ms, _cancellationTokenSource.Token);
                Trading60SecondsToEnd?.Invoke();

                await Task.Delay(30000, _cancellationTokenSource.Token);
                Trading30SecondsToEnd?.Invoke();

                //Raise event 2 secs before the end time to catch the trading in the middle!
                await Task.Delay(28000, _cancellationTokenSource.Token);
                TradingEnd?.Invoke();

            }
            // *** If cancellation is requested, an OperationCanceledException results. 
            catch (OperationCanceledException)
            {
                Logger.Notice("ScheduleTradingEndWorkingEventAsync was canceled!!!");
            }
            catch (Exception ex1)
            {
                Logger.Error(ex1.Message, ex1);
            }

        }

        public async void ScheduleTradingStartWorkingEventAsync()
        {
            try
            {
                //Working begin already, still in working time, raise event
                if ((StartTradingTimeLocal <= DateTime.Now) && (EndTradingTimeLocal > DateTime.Now))
                {
                    //Wait 30 SECONDS , let application setup and load everything
                    await Task.Delay(30000, _cancellationTokenSource.Token);

                    TradingStart?.Invoke();
                    return;
                }
                //After working time ==> exit!
                if ((EndTradingTimeLocal <= DateTime.Now))
                {
                    return;
                }

                await Task.Delay((int)StartTradingTimeLocal.Subtract(DateTime.Now).TotalMilliseconds,
                    _cancellationTokenSource.Token);

                TradingStart?.Invoke();

            }
            // *** If cancellation is requested, an OperationCanceledException results. 
            catch (OperationCanceledException)
            {
                Logger.Notice("ScheduleTradingStartWorkingEventAsync was canceled!!!");
            }
            catch (Exception ex1)
            {
                Logger.Error(ex1.Message, ex1);
            }

        }
       

        #region Events

        public event Action Trading30SecondsToEnd;
        public event Action Trading60SecondsToEnd;
        public event Action TradingEnd;
        public event Action TradingStart;

        #endregion

        public ContractDetailsData ContractDetailsData { get; set; }

        /// <summary>
        /// Get indication if today is working day for AAPL security.
        /// </summary>
        public bool IsWorkingDay => ContractDetailsData.IsWorkingDay;
        /// <summary>
        /// Check if the time on local is working time for AAPL trading
        /// </summary>
        public bool IsNowWorkingTime => ContractDetailsData.IsNowWorkingTime;
        public DateTime EndTradingTime => ContractDetailsData.EndTradingTime;
        public DateTime EndTradingTimeLocal => ContractDetailsData.EndTradingTimeLocal;
        public DateTime NextWorkingDay => ContractDetailsData.NextWorkingDay;
        public DateTime StartTradingTimeLocal => ContractDetailsData.StartTradingTimeLocal;
    }

}