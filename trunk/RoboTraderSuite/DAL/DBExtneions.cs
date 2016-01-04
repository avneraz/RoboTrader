using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using TNS.API.ApiDataObjects;

namespace DAL
{
    public static class DBExtneions
    {
        public static void SaveOrMerge(this ISession session, object data, object id )
        {
            if (session.Get<OrderStatusData>(id) == null)
            {
                session.Save(data);
            }
            else
            {
                session.Merge(data);
            }
        }
    }
}
