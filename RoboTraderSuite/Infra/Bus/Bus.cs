using System;
using System.Collections.Generic;
using System.Threading;
using Infra.Extensions;

namespace Infra.Bus
{
    public class Bus
    {
        private readonly Dictionary<Type, List<IBaseLogic>> _typesDic;
        private readonly ReaderWriterLockSlim _locker;

        public Bus()
        {
            _typesDic = new Dictionary<Type, List<IBaseLogic>>();
            _locker = new ReaderWriterLockSlim();
        }


        public void RegisterLogic(IBaseLogic logic, IEnumerable<Type> requestedTypes)
        {
            _locker.EnterWriteLock();
            try
            {
                foreach (var requestedType in requestedTypes)
                {
                    if (!_typesDic.ContainsKey(requestedType))
                    {
                        _typesDic.Add(requestedType, new List<IBaseLogic>());
                    }
                    var logicsList = _typesDic[requestedType];
                    logicsList.Add(logic);
                }
            }
            finally
            {
                _locker.ExitWriteLock();
            }

        }

        public void SendMessage(IMessage message)
        {
            _locker.EnterReadLock();

            try
            {
                _typesDic[message.GetType()].ForEach(logic =>
                {
                    var copiedObj = message.Copy();
                    logic.Enqueue(copiedObj);
                });
            }
            finally
            {
                _locker.ExitReadLock();
            }
        }
    }

}
