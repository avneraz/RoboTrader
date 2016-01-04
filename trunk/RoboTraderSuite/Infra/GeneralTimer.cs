using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infra
{
    class ScheduledTask
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromNow"></param>
        /// <param name="actionCB"></param>
        /// <param name="reOccuring"></param>
        /// <param name="occuringTimes">If it's grater than 1 and reOccuring = false, the task will be run occuringTimes</param>
        public ScheduledTask(TimeSpan fromNow, Action actionCB, bool reOccuring, int occuringTimes = 1)
        {
            InvokeTime = DateTime.Now + fromNow;
            ActionCB = actionCB;
            ReOccuring = reOccuring;
            Span = fromNow;
            OccuringTimes = occuringTimes;
        }

        public void ReScedule()
        {
            InvokeTime = DateTime.Now + Span;
        }

        public TimeSpan Span { get; set; }
        public bool ReOccuring { get; set; }
        public DateTime InvokeTime { get; private set; }
        public Action ActionCB { get; private set; }

        /// <summary>
        /// Determines the number of times the task will be run, work only if the ReOccuring is false.
        /// </summary>
        public int OccuringTimes { get; set; }


    }
    public class GeneralTimer
    {
        private GeneralTimer()
        {
            _tasksList = new Dictionary<string, ScheduledTask>();
            var thread = new Thread(Work) { IsBackground = true, Name = "GeneralTimerNew" };
            thread.Start();
        }

        private bool _doWork = true;
        private static GeneralTimer _generalTimerInstance;

        /// <summary>
        /// Gets the singleton of the GeneralTimerNew object.
        /// </summary>
        /// <value>
        /// The general timer new instance.
        /// </value>
        public static GeneralTimer GeneralTimerInstance =>
            _generalTimerInstance ?? (_generalTimerInstance = new GeneralTimer());

        public string AddTask(TimeSpan span, Action task, int occuringTimes = 1)
        {
            lock (_locker)
            {
                string uniqueIdentifier = Guid.NewGuid().ToString();
                _tasksList.Add(uniqueIdentifier, new ScheduledTask(span, task, false, occuringTimes));    
                return uniqueIdentifier;
            }
        }
        public string AddTask(TimeSpan span, Action task, bool reOccuring = false)
        {
            lock (_locker)
            {
                string uniqueIdentifier = Guid.NewGuid().ToString();
                _tasksList.Add(uniqueIdentifier, new ScheduledTask(span, task, reOccuring));
                return uniqueIdentifier;
            }
        }

        public void RemoveTask(string id)
        {
            lock (_locker)
            {
                if(string.IsNullOrEmpty(id) == false)
                    _tasksList.Remove(id);    
            }
        }
        public  void StopGeneralTimer()
        {
            _doWork = false;
        }
        private void Work()
        {
            while (_doWork)
            {
                lock (_locker)
                {
                    var tasksToRemove = new List<string>();
                    foreach (var task in _tasksList)
                    {
                        if (task.Value.InvokeTime < DateTime.Now)
                        {
                            Task.Run(task.Value.ActionCB);
                            tasksToRemove.Add(task.Key);
                        }
                    }
                    tasksToRemove.ForEach(t =>
                    {
                        var previousTask = _tasksList[t];
                        if (previousTask.ReOccuring)
                        {
                            previousTask.ReScedule();
                        }
                        else if (previousTask.OccuringTimes > 1)
                        {
                            previousTask.OccuringTimes -= 1;
                            previousTask.ReScedule();
                        }
                        else
                        {
                            _tasksList.Remove(t);    
                        }
                        
                    });
                }
                Thread.Sleep(50);
            }
        }

        private readonly Dictionary<string,ScheduledTask> _tasksList;
        private readonly object _locker = new object();
    }
}
