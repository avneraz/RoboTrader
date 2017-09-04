using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Infra.Bus;
using Infra.Enum;
using log4net;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using TNS.API.ApiDataObjects;

namespace DAL
{
    public class DBWriter : SmartBaseLogic
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(DBWriter));
        private ISession _session;

        private readonly TimeSpan WriteTimeOut = TimeSpan.FromSeconds(60);
        private readonly Dictionary<string, object> _aggregator;

        protected override string ThreadName => "DBWriter";

        public DBWriter(TimeSpan? writeTimeOut = null)
        {
            if (writeTimeOut != null)
            {
                WriteTimeOut = writeTimeOut.Value;
            }
            _aggregator = new Dictionary<string, object>();
            Connect();
        }

        private void Connect()
        {
            _session = DBSessionFactory.Instance.OpenSession();
            AddScheduledTask(WriteTimeOut, WriteBulk, true);
        }



        [MessageHandler]
        protected void HandleOptionMessage(OptionData data)
        {
            //HandleSymbolData<OptionContract>(data);
            //if (data.GetContract().IsNowWorkingTime)
            //{
                SaveContractDetailsIfNeeded<OptionContract>(data.GetContract());
                //SaveOptionData(data);
                _aggregator[data.GetContract().GetUniqueIdentifier()] = data;

           // }
        }

        [MessageHandler]
        protected void HandleStockData(SecurityData data)
        {
            HandleSymbolData<SecurityContract>(data);
        }

        [MessageHandler]
        protected void HandleOptionsPositionData(OptionsPositionData data)
        {
            HandleSymbolData<OptionContract>(data, false);
        }

        [MessageHandler]
        protected void HandleOrderStatusData(OrderStatusData data)
        {
            SaveContractDetailsIfNeeded<OptionContract>(data.GetContract());
            
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Evict(data);
                _session.SaveOrMerge(data, data.Id);
                try
                {
                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    Logger.Error("Could not write to DB", exception);
                }
            }
        }


        [MessageHandler]
        protected void HandleTransactionData(TransactionData data)
        {
            SaveContractDetailsIfNeeded<OptionContract>(data.GetContract());
            //_session.Evict(data);
            using (ITransaction transaction = _session.BeginTransaction())
            {
                var nmsg = $"Write Transaction {data.OptionKey}";
                int tdId = 0;
                try
                {
                    if (_session.Get<TransactionData>(data.Id) == null)
                    {
                        Logger.InfoFormat($"!@#$%^&* - Try to save new transaction:(Id={tdId}) '{data.OptionKey}'.");
                        tdId  =(int)_session.Save(data);
                    }
                    else
                    {
                        tdId = data.Id;
                        Logger.InfoFormat($"!@#$%^&* - Try to Merge to existing transaction:(Id={tdId}) ==>'{data.OptionKey}'.");
                        _session.Merge(data);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"!@#$%^&* - Trying save transaction:(Id={data.Id}) ==> '{data.OptionKey}'. was failed: {ex.Message}.", ex);
                }

                try
                {
                    transaction.Commit();
                    _transactionDataCommited = transaction.WasCommitted;
                    //var obj = _session.Load<TransactionData>(tdId);
                    //_session.Evict(obj);
                }
                catch (Exception exception)
                {
                    Logger.Error("!@#$%^&* - Could not write to DB (Id={tdId})", exception);
                }
            }
        }

        private bool _transactionDataCommited;
        [MessageHandler]
        protected void HandleUnlOptions(UnlOptions unlOptions)
        {
            try
            {
                SaveContractDetailsIfNeeded<OptionContract>(unlOptions.CloseTransaction == null
                    ? unlOptions.OpenTransaction.OptionData.OptionContract
                    : unlOptions.CloseTransaction.OptionData.OptionContract);
            }
            catch (Exception ex)
            {
                Logger.Error("Could not save OptionContract", ex);
                //transaction.Rollback();
               
            }
            using (ITransaction transaction = _session.BeginTransaction())
            {
                int uniOpID = 0;
                string action = string.Empty;
                try
                {
                    if (_session.Get<UnlOptions>(unlOptions.Id) == null)
                    {
                        action = "!@#$%^&* - Try save new UnlOptions (Id=0) ==>'{data.OptionKey}'.";
                        uniOpID = (int)_session.Save(unlOptions);
                    }
                    else
                    {
                        action = "!@#$%^&* - Merge UnlOptions (Id={tdId}) ==>'{data.OptionKey}'.";
                        _session.Merge(unlOptions);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"!@#$%^&* - Could not {action} {unlOptions.OptionKey}", ex);
                    //transaction.Rollback();
                    return;
                }
                try
                {
                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    Logger.Error($"!@#$%^&* - Could not write (commit) id:{unlOptions.Id} {unlOptions.OptionKey} to DB", exception);
                }
            }
        }

        private void SaveContractDetailsIfNeeded<T>(ContractBase contract)
        {
            if (_session.Get<T>(contract.Id) == null)
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(contract);
                    try
                    {
                        transaction.Commit();
                    }
                     catch (Exception exception)
                    {
                        Logger.Error("Could not write to DB", exception);
                    }
                }
            }
        }
        protected void HandleSymbolData<T>(ISymbolMessage data, bool checkWorkingTime=true)
        {
            //ATM position don't have working time data
            if (data.GetContract().IsNowWorkingTime || !checkWorkingTime)
            {
                SaveContractDetailsIfNeeded<T>(data.GetContract());
               // SaveOptionData(data, checkWorkingTime);
                _aggregator[data.GetContract().GetUniqueIdentifier()] = data;

            }
        }

        private void SaveOptionData(OptionData data, bool checkWorkingTime = true)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
               
                object guid =  _session.Save(data);
                try
                {
                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    Logger.Error("Could not write to DB", exception);
                }
                _session.Flush();
            }
        }
    
        private void WriteBulkNew()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int counter = 0;
            using (IStatelessSession statelessSession = DBSessionFactory.Instance.OpenStatelessSession())
            {
                using (ITransaction transaction = statelessSession.BeginTransaction())
                {
                    var valList = _aggregator.Values.ToList();
                    for (var i = valList.Count - 1; i > -1; i--)
                    {

                        try
                        {
                            var dd = valList[i];
                            //dd = valList[20];
                            counter++;
                            Debug.Write($"c:{counter}; ");
                            //    statelessSession.Insert(valList[i]);
                            //}
                            statelessSession.Insert(dd);
                        }
                        catch (Exception ex)
                        {
                            Logger.Error("Could not insert item: {valList[i]}", ex);
                        }
                    }

                    try
                    {
                        transaction.Commit();
                    }
                    catch (Exception exception)
                    {
                        Logger.Error("Could not write to DB", exception);
                    }

                }
            }
            stopwatch.Stop();
            var time = stopwatch.Elapsed;
            Logger.Debug($"Bulk insertion of {_aggregator.Values.Count} took {time.TotalMilliseconds} mSec");
            _aggregator.Clear();

        }

        private void WriteBulk()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int counter = 0;
            using (IStatelessSession statelessSession = DBSessionFactory.Instance.OpenStatelessSession())
            using (ITransaction transaction = statelessSession.BeginTransaction())
            {
                foreach (var item in _aggregator.Values)
                {
                    try
                    {
                        counter++;
                        statelessSession.Insert(item);

                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Could not insert item: {item}", ex);
                    }
                }
                try
                {
                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    Logger.Error("Could not write to DB", exception);
                }

            }

            stopwatch.Stop();
            var time = stopwatch.Elapsed;
            Logger.Debug($"Bulk insertion of {_aggregator.Values.Count} took {time.TotalMilliseconds} mSec");
            _aggregator.Clear();

        }

    }
}

