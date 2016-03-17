﻿using System;
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
            Logger.Debug($"Bulk insertion of {_aggregator.Values.Count} took {time}");
            _aggregator.Clear();

        }

     

       
    }
}

