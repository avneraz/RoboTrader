using System;
using System.Threading;
using Infra.Bus;
using Infra.Enum;
using log4net;
using TNS.API;
using TNS.API.ApiDataObjects;
using TNS.BL.Interfaces;

namespace TNS.BL.UnlManagers
{
    public class WhatIfOrderBroker : ISubscibeMessage
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(WhatIfOrderBroker));
       
        private readonly string _symbol;
        private readonly AutoResetEvent _autoResetEvent = new AutoResetEvent(false);

        public WhatIfOrderBroker(string symbol)
        {
            _symbol = symbol;
            InitializeMembers();
        }

        public UNLManager UnlManager { get; set; }
        public EapiDataTypes DataType { get; set; }
        private AppManager AppManager => AppManager.AppManagerSingleTonObject;
        protected ITradingApi APIWrapper { get; set; }
        public OrderData OrderData { get; set; }
        private OrderStatusData OrderStatusData { get; set; }
        public double RequierdMargin { get; set; }
        public OptionData OptionData { get; set; }
        public string WhatIfOrderId { get; set; }

        private void InitializeMembers()
        {
            UnlManager = AppManager.UNLManagerDic[_symbol] as UNLManager;
            if (UnlManager == null) throw new Exception("The symbol is not exist!!");
            APIWrapper = UnlManager.APIWrapper;
            DataType = EapiDataTypes.OrderStatus;
        }

        public double SendWhatIfOrder(OptionData optionData, OrderAction orderAction, int quantity)
        {
            OptionData = optionData;
            try
            {
                UnlManager.RegisterForMessage(this, EapiDataTypes.OrderStatus);
                var orderData = new OrderData
                {
                    OrderType = OrderType.MKT,
                    OrderAction = orderAction,
                  
                    Quantity = quantity,
                    Contract = OptionData.OptionContract,
                    WhatIf = true,
                };
                WhatIfOrderId = APIWrapper.CreateOrder(orderData);
                orderData.OrderId = WhatIfOrderId;
                //Put the current thread into waiting state until it receives the signal
                var isSignaled = _autoResetEvent.WaitOne(TimeSpan.FromSeconds(5));
                //Thread.Sleep(5000);
                if (!isSignaled)
                {
                    var ex = new Exception("No Answer from TWS. 5 secondfs Timeout!!!");
                    Logger.Error("No Answer from TWS. 5 secondfs Timeout!!!", ex);
                    throw ex;
                }
                if(OrderStatusData.OrderStatus == OrderStatus.Filled)
                    return OrderStatusData.Margin;
                var ex1 = new Exception("Send WhatIf order failed!!!");
                Logger.Error("Send WhatIf order failed!!!", ex1);
                throw ex1;
            }
            finally
            {
                UnlManager.UnRegisterForMessage(this, EapiDataTypes.OrderStatus);
                try
                {
                    _autoResetEvent.Dispose();
                }
                catch (Exception ex)
                {
                  Logger.Error("AutoResetEvent faild on Dispose()", ex);
                }
            }
        }

        public bool HandleMessage(IMessage message)
        {
            if (message.APIDataType != EapiDataTypes.OrderStatus) return false;
            //Thread.Sleep(4000);
            OrderStatusData = (OrderStatusData) message;
            switch (OrderStatusData.OrderStatus)
            {
                
                case OrderStatus.Filled:
                case OrderStatus.WhatIf:
                case OrderStatus.Cancelled:
                case OrderStatus.Inactive:
                    _autoResetEvent.Set();
                    break;
            }
            
                
           
            return true;

        }

        public void RegisterForMessage()
        {
            UnlManager.RegisterForMessage(this, DataType);
        }

        public void UnRegisterForMessage()
        {
            UnlManager.UnRegisterForMessage(this, DataType);
        }

       
    }
}
