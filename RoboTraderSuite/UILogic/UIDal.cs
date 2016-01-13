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

        public List<OptionData> GetOptionsBySymbol(string symbolName)
        {
            var list = _session.Query<OptionData>().Where(a => a.OptionContract.Symbol == symbolName).
                OrderByDescending(od=>od.LastUpdate).Take(70).ToList();
            return list;
            //return _session.Query<OptionData>().Where(a=> a.OptionContract.Symbol == symbolName).ToList();
        }

        public IList<OptionData> GetLastOptionData()
        {

            return 
                _session.CreateSQLQuery(@"
                                        select o.*
                                        from optionsdata o
                                        inner join (
                                            select optioncontract_id, max(lastupdate) as MaxDate
                                            from optionsdata
                                            group by optioncontract_id
                                        ) om on o.optioncontract_id = om.optioncontract_id and o.lastupdate = om.MaxDate
                                        ")
                                        .AddEntity(typeof(OptionData))
                                        .List<OptionData>();
        }

        public IList<SecurityData> GetLastSeucirtyData()
        {

            return
                _session.CreateSQLQuery(@"
                                        select o.*
                                         from securitydata o
                                         inner join (
                                             select securitycontract_id, max(lastupdate) as MaxDate
                                             from securitydata
                                             group by securitycontract_id
                                         ) om on o.securitycontract_id = om.securitycontract_id and o.lastupdate = om.MaxDate
                                        ")
                                        .AddEntity(typeof(SecurityData))
                                        .List<SecurityData>();
        }



    }
}
