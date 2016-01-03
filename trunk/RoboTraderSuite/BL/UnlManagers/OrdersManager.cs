using System;
using Infra.Bus;
using Infra.Enum;
using TNS.API;
using TNS.API.ApiDataObjects;
using TNS.BL.Interfaces;
using TNS.DbDAL;

namespace TNS.BL.UnlManagers
{
    public class OrdersManager : UnlMemberBaseManager, IOrdersManager
    {
        public OrdersManager(ITradingApi apiWrapper, MainSecurity mainSecurity, UNLManager unlManager) : base(apiWrapper, mainSecurity, unlManager)
        {
        }

        public override bool HandleMessage(IMessage message)
        {
            bool result = base.HandleMessage(message);
            if (result)
                return true;

            switch (message.APIDataType)
            {
                case EapiDataTypes.OrderStatus:
                case EapiDataTypes.OrderData:
                    result = true;
                    break;
            }
            return result;
        }

        public override void DoWorkAfterConnection()
        {
            ContractBase contractBase = new OptionContract("AAPL", 110, new DateTime(2015, 2, 19),OptionType.Call);
            OrderData orderData = new OrderData(OrderType.MKT, OrderAction.SELL, 1.18, 1, contractBase);
            string orderIdStr = APIWrapper.CreateOrder(orderData);

        }

    }
}
