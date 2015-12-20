using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIDataObjects;
using IBApiWrapper;
using Infra;
using static System.Console;

namespace Tester
{
    class Consumer : SimpleBaseLogic
    {
        protected override void HandleMessage(IMessage meesage)
        {
            Console.WriteLine(meesage);//meesage + 
            if (meesage is OptionData)
            {
                var msg = ((meesage as OptionData).Contract);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Consumer c = new Consumer();
            IBApiWrapper.IBApiWrapper wrapper = new IBApiWrapper.IBApiWrapper("127.0.0.1", 7496, 4, c, "U1450837");
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
