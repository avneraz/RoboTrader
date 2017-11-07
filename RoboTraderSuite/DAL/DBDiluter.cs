using System;
using System.Collections.Generic;
using System.Linq;
using Infra;
using Infra.Global;
using log4net;
using NHibernate;
using NHibernate.Linq;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using TNS.API.ApiDataObjects;

namespace DAL
{
    public class DBDiluter
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(DBDiluter));

        /// <summary>
        /// Dilute options and securities data from db, the start date is from the last dilution, till today.
        /// </summary>
        public int DiluteFromAllUnLs()
        {
            int count = 0;
           using (_session = DBSessionFactory.Instance.OpenSession())
            {
                _savedParametersData = _session.Query<SavedParametersData>().FirstOrDefault();
                if (_savedParametersData == null)
                    throw new Exception("There are no record for SavedParametersData");
                DateTime startDate = _savedParametersData.LastDBDillution;

                DateTime endDate = DateTime.Today;

                count = DiluteOptionsFromAllUnLs(startDate, endDate);//
                DiluteSecuritiesFromAllUnLs(startDate, endDate);

                //Update DB
                _savedParametersData.LastDBDillution = DateTime.Now;
                _savedParametersData.LastUpdate = DateTime.Now;
                _session.Update(_savedParametersData);
                _session.Flush();

            }
            return count;
        }
       

        private SavedParametersData _savedParametersData;
        private ISession _session;

        public int DiluteOptionsFromAllUnLs(DateTime startDate, DateTime endDate)
        {
            Logger.InfoFormat("Start dilute options from DB.");
            if(_session == null) _session = DBSessionFactory.Instance.OpenSession();

            List<ManagedSecurity> activeUNLList = _session.Query<ManagedSecurity>()
                .Where(contract => contract.IsActive && contract.OptionChain).ToList();
            int count = 0;
            foreach (var managedSecurity in activeUNLList)
            {
                count += DiluteOneOptionPerMinute(managedSecurity.Symbol, startDate, endDate);
            }
            return count;
        }

        public int DiluteOneOptionPerMinute(string symbol, DateTime startDate, DateTime endDate)
        {
            //endDate = new DateTime(2017, 11, 1, 0, 1, 0);
            //startDate = new  DateTime(2017,10,31,0,1, 0);
            startDate = startDate.Date;
            DateTime dueDate = startDate;
            int counter = 0;
            List<OptionData> unlList = null;
            //Do it in step of 1 day to illuminate the huge possible records!
            
            while (dueDate < endDate)
            {
                try
                {
                    //var dueDate = startDate;
                    var theDate = dueDate;
                    var options = _session.Query<OptionData>()
                        .Where(optionData =>
                            optionData.OptionContract.Symbol.Equals(symbol) &&
                            optionData.LastUpdate >= theDate &&
                            optionData.LastUpdate < theDate.AddHours(4))/*.Take(100000)*/ .ToList();// &&
                            //optionData.Account.Equals(AllConfigurations.AllConfigurationsObject
                            //    .Application.MainAccount)).ToList() /*.Take(100000)*/;


                    //var list = options.Where(od => od.OptionContract.Symbol.Equals(symbol)).ToList();
                    unlList = options.OrderBy(optionData => optionData.LastUpdate).ToList();
                    if (unlList.Count == 0)
                        return 0;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        var toString = ex.InnerException.ToString();
                        if (toString.Contains("canceling statement due to statement timeout"))
                        {
                            Logger.Error(ex.Message,ex);
                            throw new Exception("Canceling task due to Timeout!!!!");
                        }
                    }
                }
                finally
                {
                    dueDate = dueDate.AddHours(4);
                }
                if (unlList != null)
                {
                    var lastTimeItems = new TimeItems(unlList[0].LastUpdate);

                    for (var index = 1; index < unlList.Count; index++)
                    {
                        var optionData = unlList[index];
                        var currenTimeItems = new TimeItems(optionData.LastUpdate);

                        if (lastTimeItems.IsNewMinute(currenTimeItems))
                        {
                            lastTimeItems = currenTimeItems;
                        }
                        else
                        {
                            //delete row
                            _session.Delete(optionData);
                            counter++;
                        }
                    }
                }
                _session.Flush();

            } 
            Logger.InfoFormat($"DBDiluter Diluted {counter} options from {symbol}, between dates:{startDate} :: {endDate}");
            return counter;
        }
        public int DiluteSecuritiesFromAllUnLs(DateTime startDate,DateTime endDate)
        {
            Logger.InfoFormat("Start dilute securities from DB.");
            //startDate = new DateTime(2017, 01, 30, 0, 1, 0);
            List<ManagedSecurity> activeUNLList = _session.Query<ManagedSecurity>()
                .Where(contract => contract.IsActive).ToList();

            int count = 0;

            foreach (var managedSecurity in activeUNLList)
            {
                //if(managedSecurity.Symbol.Equals("AMZN") == false ) continue;
                count += DiluteOneSecurityPerMinute(managedSecurity.Symbol, startDate, endDate);
            }
            return count;
        }

        public int DiluteOneSecurityPerMinute(string symbol, DateTime startDate, DateTime endDate)
        {
            var securities = _session.Query<SecurityData>()
                .Where(securityData =>
                    securityData.LastUpdate >= startDate &&
                    securityData.LastUpdate < endDate);


            var unlList = securities.Where(sd => sd.SecurityContract.Symbol.Equals(symbol) &&
                                              sd.Account.Equals(AllConfigurations.AllConfigurationsObject.Application
                                                  .MainAccount))
                .OrderBy(securityData => securityData.LastUpdate).ToList();
            if (unlList.Count == 0)
                return 0;
            var lastTimeItems = new TimeItems(unlList[0].LastUpdate);
            int counter = 0;
            for (var index = 1; index < unlList.Count; index++)
            {
                var securityData = unlList[index];
                var currenTimeItems = new TimeItems(securityData.LastUpdate);

                if (lastTimeItems.IsNewMinute(currenTimeItems))
                {
                    lastTimeItems = currenTimeItems;
                }
                else
                {
                    //delete row
                    _session.Delete(securityData);
                    counter++;
                }
            }
            _session.Flush();
            Logger.InfoFormat($"DBDiluter Diluted {counter} securities from {symbol}, between dates:{startDate} :: {endDate}");
            return counter;
        }
    }
   
    class TimeItems
    {

        private DateTime _asociatedDateTime;

        public TimeItems(DateTime asociatedDateTime)
        {
            AsociatedDateTime = asociatedDateTime;
        }

        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public DateTime AsociatedDateTime
        {
            get => _asociatedDateTime;
            set
            {
                _asociatedDateTime = value;
                Hour = _asociatedDateTime.Hour;
                Minute = _asociatedDateTime.Minute;
                Second = _asociatedDateTime.Second;
            }
        }

        public bool IsNewMinute(TimeItems newTimeItem)
        {
            if(newTimeItem.Hour == Hour &&  newTimeItem.Minute != Minute) return true;

            return newTimeItem.Hour != Hour;
        }
        public bool IsNewHour(TimeItems newTimeItem)
        {
            if (newTimeItem.Hour != Hour) return true;

            return false;
        }
    }

}
