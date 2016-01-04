using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Engine;
using NHibernate.Id;
using NHibernate.Tool.hbm2ddl;
using TNS.API.ApiDataObjects;

namespace DAL
{


    public class NHibTest2
    {
        private static ISessionFactory _sessionFactory;

        public static void Main()
        {
            //creating database 
            string conString = "server=localhost;port=3306;database=RobotDB;uid=root;password=tom90raz";
            try
            {
                CreateDatabase(conString);
            }
            catch (Exception err)
            {
                int a = 6;
            }
            
            Console.WriteLine("Database Created sucessfully");

            var optContract = new OptionContract("AAPL", 50, DateTime.Now, OptionType.Call);
            //creating a object of customer
            OptionData option = new OptionData
            {
                AskPrice = 1,
                OptionContract = optContract

            };

            var stockContract = new SecurityContract("AAPL", SecurityType.Stock);
            SecurityData stock = new SecurityData()
            {
                AskPrice = 2,
                SecurityContract = stockContract
            };

            OptionsPositionData pos = new OptionsPositionData(optContract, 2,3 );

            OrderData orderData = new OrderData() {Contract = optContract, LimitPrice = 12323};
            OrderStatusData status = new OrderStatusData("5", orderData);

            ISession session = _sessionFactory.OpenSession();

            using (ITransaction transaction = session.BeginTransaction())
            {

                session.Save(stockContract);

                session.Save(optContract);
                session.Save(option);
                session.Save(stock);
                session.Save(pos);
                session.Save(status);
                transaction.Commit();
                


            }
            var res = session.QueryOver<OptionData>().List();
            var st = session.QueryOver<SecurityData>().List();
            var se = session.QueryOver<PositionData>().List();
            var stat = session.QueryOver<OrderStatusData>().List();
            Console.WriteLine("Customer Saved");

        }

        static void CreateDatabase(string connectionString)
        {
            var configuration = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(connectionString).ShowSql)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OptionDataMapping>()
                .Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never()))
                .BuildConfiguration();

            var exporter = new SchemaExport(configuration);
            exporter.Execute(true, true, false);

            _sessionFactory = configuration.BuildSessionFactory();
        }

    }
}
