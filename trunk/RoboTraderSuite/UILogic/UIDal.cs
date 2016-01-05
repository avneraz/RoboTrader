using System.Collections.Generic;
using System.Linq;
using DAL;
using NHibernate;
using NHibernate.Linq;
using TNS.API.ApiDataObjects;

namespace UILogic
{
    public class UIDal
    {
        private ISession _session;

        public UIDal()
        {
            _session = DBSessionFactory.Instance.OpenSession();
        }

        public IList<OptionsPositionData> GetAllPositions()
        {
            return _session.Query<OptionsPositionData>().ToList();
        }

        public IList<OptionData> GetOptionsBySymbol(string symbolName)
        {
            return _session.Query<OptionData>().Where(a=> a.OptionContract.Symbol == symbolName && a.OptionContract.Strike == 101.0).ToList();
        }
    }
}
