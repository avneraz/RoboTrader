using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using IBApi;
using Infra;
using log4net;
using TNS.API.ApiDataObjects;
using TNS.API.IBApiWrapper;
using TNS.BL;
using Infra.Bus;
using Infra.Configuration;
using MySql.Data.Entity;
using UILogic;
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

    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    //public class SchoolContext : DbContext
    //{
    //    public SchoolContext() : base()
    //    {

    //    }

    //    public DbSet<OptionData> Students { get; set; }

    //}
    class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));


        static void Main(string[] args)
        {
            //ConfigHandler h = new ConfigHandler();
            //AllConfigurations a = new AllConfigurations();
            //a.Application.DefaultHost = "host";
            //a.Application.AppClientId = 1;
            //a.Application.AppPort = 7496;
            //a.Application.MainAccount = "account";
            //a.Application.WDAppClientId = 1;
            //a.Session.AAPLHighLoadingStrike = 100;
            //a.Session.AAPLLowLoadingStrike = 200;
            //a.Session.AAPLSessionsToLoad = "20150821;20151016;20160115";
            //a.Trading.AAPLUnderlinedRange = "111";
            
            //h.SaveConfig(a);


            //var readConfig = h.ReadConfig();



            //UIDal a = new UIDal();
            //var positions = a.GetAllPositions();
            //var appleOptions = a.GetOptionsBySymbol("AAPL");
            //string conString = "server=localhost;port=3306;database=RobotDB;uid=root;password=tom90raz";
            DBWriter d = new DBWriter();
            d.Connect();
            //d.WriteToDB(new List<OptionData>() { new OptionData() { AskPrice = 5, Key = "a" } });
            //d.WriteToDB(new List<TestModal>() { new TestModal() { B = "a" } });
            //Example.ExecuteExample();




            //DbConfiguration.SetConfiguration(new MySqlEFConfiguration())





            Logger.Info("Start Program - Tester");
            //AppManager appManager = new AppManager();
            //appManager.InitializeAppManager(null);
            //appManager.ConnectToBroker();
            Consumer c = new Consumer();
            IBApiWrapper wrapper = new IBApiWrapper("127.0.0.1", 7496, 8, d, "U1450837");
            //var accMgr = new AccountManager(wrapper);
            //var mainSecMgr = new MainSecuritiesManager(wrapper);
            //d.SetManagers()


            



            wrapper.ConnectToBroker();
            wrapper.RequestAccountData();
            wrapper.RequestContinousContractData(new List<ContractBase>()
            {
                //new OptionContract("AAPL", 0, new DateTime(2015, 12, 31), OptionType.Call),
                new OptionContract("AAPL", new DateTime(2016, 1, 15), OptionType.Call),
                new SecurityContract("AAPL", SecurityType.Stock)
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
                new OrderData()
                {
                    OrderType = OrderType.MKT,
                    OrderAction = OrderAction.SELL,
                    Quantity = 1,
                    //LimitPrice = 0.2,
                    Contract = new OptionContract("AAPL", 110, new DateTime(2016, 1, 15), OptionType.Call)
                });

            


            //Console.WriteLine("Placed Order ID = " + orderIdStr);
            //string tags = "NetLiquidation,EquityWithLoanValue,BuyingPower,ExcessLiquidity,FullMaintMarginReq,FullInitMarginReq";
            //wrapper.RequestAccountSummary();
            Thread.Sleep(10000000);
            
        }
    }
}
