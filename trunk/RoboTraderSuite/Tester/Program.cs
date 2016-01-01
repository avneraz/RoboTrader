using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IBApi;
using log4net;
using TNS.API.ApiDataObjects;
using TNS.API.IBApiWrapper;
using TNS.BL;
using Infra.Bus;
using static System.Console;


[assembly: log4net.Config.XmlConfigurator(Watch = true)]



namespace Tester
{
    class Consumer : SimpleBaseLogic
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));
        protected override void HandleMessage(IMessage message)
        {
            Logger.Info(message);

        }
        protected override void DoWorkAfterConnection()
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));


        static void Main(string[] args)
        {
            
            Logger.Info("Start Program - Tester");
            //AppManager appManager = new AppManager();
            //appManager.InitializeAppManager(null);
            //appManager.ConnectToBroker();
            Consumer c = new Consumer();
            //Distributer d = new Distributer();
            IBApiWrapper wrapper = new IBApiWrapper("127.0.0.1", 7496, 8, c, "U1450837");
            //var accMgr = new AccountManager(wrapper);
            //var mainSecMgr = new MainSecuritiesManager(wrapper);
            //d.SetManagers()

            

            
            
            wrapper.ConnectToBroker();
            wrapper.RequestAccountData();
            wrapper.RequestContinousContractData(new List<ContractBase>()
            {
                new OptionContract("AAPL", 120, new DateTime(2015, 12, 31), OptionType.Call),
                //new StockContract("AAPL")
            });

            wrapper.RequestContinousPositionsData();
            //Thread.Sleep(2000);
            //string orderIdStr = wrapper.CreateOrder(new OptionContract("AAPL", 120, new DateTime(2015, 12, 24), OptionType.Call), new OrderData(OrderType.MKT, OrderAction.Sell, 1.8, 1));
            //Console.WriteLine("Placed Order ID = " + orderIdStr);
            //Thread.Sleep(10000);
            //orderIdStr = wrapper.CreateOrder(new OptionContract("AAPL", 125, new DateTime(2015, 12, 24), OptionType.Call), new OrderData(OrderType.MKT, OrderAction.Sell, 1.8, 1));
            //Console.WriteLine("Placed Order ID = " + orderIdStr);
            //Thread.Sleep(10000);
            Thread.Sleep(1000);
            var orderIdStr = wrapper.CreateOrder(
                new OrderData(OrderType.LMT, OrderAction.SELL, 0.2, 1, new OptionContract("AAPL", 110, new DateTime(2015, 12, 31), OptionType.Call)));
            Thread.Sleep(10000);
            
            //Console.WriteLine("Placed Order ID = " + orderIdStr);
            //string tags = "NetLiquidation,EquityWithLoanValue,BuyingPower,ExcessLiquidity,FullMaintMarginReq,FullInitMarginReq";
            //wrapper.RequestAccountSummary();
            Thread.Sleep(10000000);
            
        }
    }
}
