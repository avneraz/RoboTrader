using System;
using System.Threading;
using log4net;
using TNS.API.ApiDataObjects;
using TNS.API.IBApiWrapper;
using TNS.API.Infra.Bus;

namespace TNS.BrokerDAL
{
    public class Distributer : SimpleBaseLogic
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Distributer));
        protected override void HandleMessage(IMessage meesage)
        {
            Console.WriteLine(meesage);
            var optionData = meesage as OptionData;
            if (optionData != null)
            {
                var msg = (optionData.Contract);
            }
        }

        internal void InitializeAPIBroker()
        {
            Logger.Info("Start Program - Tester");
            var c = this;
            IBApiWrapper wrapper = new IBApiWrapper("127.0.0.1", 7496, 4, c, "U1450837");
            wrapper.Connect();
            wrapper.RequestAccountData();
            //wrapper.RequestContinousOptionChainData(new List<OptionContract>()
            //{ new OptionContract("AAPL", 120, new DateTime(2015, 12, 24), OptionType.Call)});
            //wrapper.RequestContinousPositionsData();
            Thread.Sleep(2000);
            string orderIdStr = wrapper.CreateOrder(new OptionContract("AAPL", 110, new DateTime(2015, 12, 24), OptionType.Call), new OrderData(OrderType.MKT, OrderAction.Sell, 1.8, 1));
            Console.WriteLine("Placed Order ID = " + orderIdStr);
            Thread.Sleep(10000);
            orderIdStr = wrapper.CreateOrder(new OptionContract("AAPL", 120, new DateTime(2015, 12, 24), OptionType.Call), new OrderData(OrderType.MKT, OrderAction.Sell, 1.8, 1));
            Console.WriteLine("Placed Order ID = " + orderIdStr);
            Thread.Sleep(10000);
            orderIdStr = wrapper.CreateOrder(new OptionContract("AAPL", 125, new DateTime(2015, 12, 24), OptionType.Call), new OrderData(OrderType.MKT, OrderAction.Sell, 1.8, 1));
            Console.WriteLine("Placed Order ID = " + orderIdStr);
            //string tags = "NetLiquidation,EquityWithLoanValue,BuyingPower,ExcessLiquidity,FullMaintMarginReq,FullInitMarginReq";
            //wrapper.RequestAccountSummary();
            Thread.Sleep(100000);
        }

    }
}