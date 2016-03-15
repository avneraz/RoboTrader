using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using Infra.Enum;
using Infra.Extensions;

namespace Infra.Bus
{
    public class MessageHandler : System.Attribute
    {
        
    }

    class TimedTask : IMessage
    {
        public TimedTask(Action t)
        {
            CurTask = t;
        }

        public Action CurTask { get; set; }
        public EapiDataTypes APIDataType { get; set; }
    }

    public abstract class SimpleBaseLogic : IBaseLogic
    {
        private readonly ConcurrentQueue<IMessage> _queue;
        private const int WORK_INTERVAL_MS = 100;

        protected SimpleBaseLogic()
        {
            _queue = new ConcurrentQueue<IMessage>();
        }

        protected virtual string ThreadName => "SimpleBaseLogic_Work";

        private void Work()
        {
            Thread.CurrentThread.Name = ThreadName;
            while (true)
            {
                IMessage message;
                if (_queue.TryDequeue(out message))
                {
                    TimedTask timedTask = message as TimedTask;
                    if (timedTask != null)
                    {
                        //calls the task delegate action
                        timedTask.CurTask();
                    }
                    else
                    {
                        if (_queue.Count > 10 && _queue.Count % 20 == 0)
                            Debug.Print($"Items in queue for {ThreadName} are : {_queue.Count}");
                        HandleMessage(message);
                    }

                }
                else
                {
                    Thread.Sleep(WORK_INTERVAL_MS);
                }
            }
        }

        public void Enqueue(IMessage message, bool duplicate=true)
        {
            _queue.Enqueue(duplicate ? message.Copy() : message);
        }

        public void Start()
        {
            var t = new Thread(Work) { IsBackground = true };
            t.Start();
        }

        protected abstract void HandleMessage(IMessage message);

        protected string AddScheduledTask(TimeSpan span, Action task, bool reOccuring = false)
        {
            string uniqueIdentifier = GeneralTimer.GeneralTimerInstance.AddTask(span, () =>
            {
                _queue.Enqueue(new TimedTask(task));
            }, reOccuring);
            return uniqueIdentifier;
        }

        protected void RemoveScheduledTask(string uniqueIdentifier)
        {
            GeneralTimer.GeneralTimerInstance.RemoveTask(uniqueIdentifier);
        }
    }


    public abstract class SmartBaseLogic : SimpleBaseLogic
    {
        //private readonly global::Infra.Bus.Bus _bus;
        private readonly Dictionary<Type, MethodInfo> _handledTypes;

        protected SmartBaseLogic()
        {
            //_bus = bus;
            _handledTypes = GetLogicHandledTypes();
            //_bus.RegisterLogic(this, _handledTypes.Keys);

        }
        private Dictionary<Type, MethodInfo> GetLogicHandledTypes()
        {
            return this.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(
                method => Attribute.IsDefined(method, typeof(MessageHandler)))
                .Select(method => new { method.GetParameters()[0].ParameterType, method })
                .ToDictionary(t => t.ParameterType, t => t.method);
        }

       

        protected override void HandleMessage(IMessage message)
        {
            MethodInfo method;
            if (_handledTypes.TryGetValue(message.GetType(), out method))
            {
                method.Invoke(this, new Object[] { message });
            }
                
        }
    }


}
