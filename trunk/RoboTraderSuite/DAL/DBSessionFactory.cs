using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace DAL
{
    public class DBSessionFactory
    {
        private ISessionFactory _sessionFactory;
        #region Singleton stuff
        static DBSessionFactory() { }
        private static DBSessionFactory _instance = new DBSessionFactory();
        public static DBSessionFactory Instance { get { return _instance; } }
        #endregion

        private DBSessionFactory()
        {
            var conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var configuration = Fluently.Configure()
                .Database(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(conString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OptionDataMapping>()
                    .Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never()))
                .ExposeConfiguration(TreatConfiguration);

            //var exporter = new SchemaExport(_configuration);
            //exporter.Execute(true, true, false);
            _sessionFactory = configuration.BuildSessionFactory();
        }

        protected virtual void TreatConfiguration(NHibernate.Cfg.Configuration configuration)
        {
            var update = new SchemaUpdate(configuration);
            update.Execute(false, true);
        }

        public IStatelessSession OpenStatelessSession()
        {
            return _sessionFactory.OpenStatelessSession();
        }

        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
     



    }
}
