using System;
using System.Collections.Generic;
using System.Linq;
using Infra.Bus;
using Infra.Enum;
using TNS.API;
using TNS.API.ApiDataObjects;
using TNS.BL.Interfaces;

namespace TNS.BL.UnlManagers
{
    public class OrdersManager : UnlMemberBaseManager, IOrdersManager
    {
        public event Action<OrderStatusData> OrderStatusDataUpdated;
        public OrdersManager(ITradingApi apiWrapper, ManagedSecurities managedSecurity, UNLManager unlManager) : base(apiWrapper, managedSecurity, unlManager)
        {
            OrderStatusDataDic = new Dictionary<string, OrderStatusData>();
        }
        /// <summary>
        ///  = OrderType.LMT, used for testing
        /// </summary>
        private OrderType DefaultOrderType { get; set; } = OrderType.LMT;

        //private bool _doSellOneOrderTesting;
        public override bool HandleMessage(IMessage message)
        {
            bool result = base.HandleMessage(message);
             
            //if (Symbol == "AAPL" && _doSellOneOrderTesting)
            //{
            //    DefaultOrderType = OrderType.MKT;
            //    TestTrading(sell: true);
            //    DefaultOrderType = OrderType.LMT;
            //    _doSellOneOrderTesting = false;
            //}
            if (result)
                return true;

            switch (message.APIDataType)
            {
                case EapiDataTypes.OrderStatus:
                var order = (OrderStatusData) message;
                OrderStatusDataDic[order.OrderId] = order;
                    OrderStatusDataUpdated?.Invoke(order);
                        result = true;
                    break;
                case EapiDataTypes.OrderData:

                    //OrderStatusDataUpdated?.Invoke(order);
                    result = true;
                    break;
            }
            //SellOption(UNLManager.OptionsManager.OptionDataDic.Values.ToList()[0], 1, 1);
            return result;
        }

        public override void DoWorkAfterConnection()
        {
            //_doSellOneOrderTesting = false;
        }
        public Dictionary<string, OrderStatusData> OrderStatusDataDic { get; }
        public OrderData SellOption(OptionData optionData, double limitPrice, int quantity)
        {
            OrderData orderData = new OrderData()
            {
                OrderType = DefaultOrderType,
                OrderAction = OrderAction.SELL,
                LimitPrice = limitPrice,
                Quantity = quantity,
                Contract = optionData.OptionContract
            };

            orderData.OrderId = APIWrapper.CreateOrder(orderData);

            return orderData;
        }

        public OrderData BuyOption(OptionData optionData, double limitPrice, int quantity)
        {
            OrderData orderData = new OrderData()
            {
                OrderType = DefaultOrderType,
                OrderAction = OrderAction.BUY,
                LimitPrice = limitPrice,
                Quantity = quantity,
                Contract = optionData.OptionContract
            };
            orderData.OrderId = APIWrapper.CreateOrder(orderData);

            return orderData;
        }

        public OrderData TestTrading(bool sell)
        {
            DefaultOrderType = OrderType.MKT;
            OrderData orderData = sell ? 
                SellOption(UNLManager.OptionsManager.OptionDataDic.Values.ToList()[0], 1, 1) : 
                BuyOption(UNLManager.OptionsManager.OptionDataDic.Values.ToList()[0], 1, 1);
            DefaultOrderType = OrderType.LMT;
            return orderData;

        }
    }
}
