using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            HandleSymbolData<OptionContract>(data);
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
            //SaveContractDetailsIfNeeded<OptionContract>(data.GetContract());
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

            using (ITransaction transaction = _session.BeginTransaction())
            {
                var transactionData = unlOptions.Status == EStatus.Open ? unlOptions.OpenTransaction : unlOptions.CloseTransaction;
                int tdId = 0;
                //Save transaction first:
                //if (_session.Get<TransactionData>(transactionData.Id) == null)
                //{
                //    Logger.InfoFormat($"!@#$%^&* - Try to save new transaction:(Id=0) '{transactionData.OptionKey}'.");
                //    _session.Save(transactionData);
                //}
                //else
                //{
                //    tdId = transactionData.Id;
                //    Logger.InfoFormat($"!@#$%^&* - Try to Merge to existing transaction:(Id={tdId}) ==>'{transactionData.OptionKey}'.");
                //    _session.Merge(transactionData);
                //}

                string action = string.Empty;
                try
                {
                    if (_session.Get<UnlOptions>(unlOptions.Id) == null)
                    {
                        action = "!@#$%^&* - Try save new UnlOptions (Id=0) ==>'{data.OptionKey}'.";
                        _session.Save(unlOptions);
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
                _aggregator[data.GetContract().GetUniqueIdentifier()] = data;
            }
        }
        private void WriteBulk()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            using (IStatelessSession statelessSession = DBSessionFactory.Instance.OpenStatelessSession())
            using (ITransaction transaction = statelessSession.BeginTransaction())
            {
                foreach (var item in _aggregator.Values)
                {
                    statelessSession.Insert(item);
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

