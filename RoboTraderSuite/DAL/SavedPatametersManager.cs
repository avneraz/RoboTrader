using System;
using System.Linq;
using Infra.Global;
using NHibernate;
using NHibernate.Linq;

namespace DAL
{
    public static class SavedPatametersManager
    {
        public static DateTime GetLastDBDillutionParameter()
        {
            using (var session = DBSessionFactory.Instance.OpenSession())
            {
                var savedParametersData = session.Query<SavedParametersData>().FirstOrDefault();
                if (savedParametersData == null)
                    throw new Exception("There are no record for SavedParametersData");
                DateTime startDate = savedParametersData.LastDBDillution;
                return startDate;
            }

        }
        public static double GetLastNetLiquiditionParameter()
        {
            using (ISession session = DBSessionFactory.Instance.OpenSession())
            {
                var savedParametersData = session.Query<SavedParametersData>().FirstOrDefault();
                if (savedParametersData == null)
                    throw new Exception("There are no record for SavedParametersData");
                var lastNetLiquidition = savedParametersData.LastNetLiquidition;
                return lastNetLiquidition;
            }
        }

        public static void SaveLastNetLiquiditionParameter(double pnl)
        {
            using (var session = DBSessionFactory.Instance.OpenSession())
            {
                var savedParametersData = session.Query<SavedParametersData>().FirstOrDefault();
                if (savedParametersData == null)
                    throw new Exception("There are no record for SavedParametersData");

                savedParametersData.LastNetLiquidition = pnl;
                savedParametersData.LastUpdate = DateTime.Now;
                session.Update(savedParametersData);
                session.Flush();
            }
        }

        public static SavedParametersData GetSavedParametersData()
        {
            using (var session = DBSessionFactory.Instance.OpenSession())
            {
                var savedParametersData = session.Query<SavedParametersData>().FirstOrDefault();
                if (savedParametersData == null)
                    throw new Exception("There are no record for SavedParametersData");
                return savedParametersData;
            }
        }
        public static void SaveParametersData(SavedParametersData savedParametersData)
        {
            savedParametersData.LastUpdate = DateTime.Now;
            using (var session = DBSessionFactory.Instance.OpenSession())
            {
                session.Update(savedParametersData);
                session.Flush();
            }

        }
    }
}

