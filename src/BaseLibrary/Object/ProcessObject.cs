using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseLibrary.Object
{
    public interface IInitializable
    {
        bool Initialize();
        void Terminate();
    }

    public class ProcessObject : LogEventObject, IInitializable
    {
        public ProcessObject(string process)
        {
            ProcessName = process;
        }

        public string ProcessName;

        public volatile bool IsRunning;

        #region init

        public virtual bool Initialize()
        {
            Info($"Process [{ProcessName}] Initialize!");
            return true;
        }


        public virtual void Terminate()
        {
            Stop();
            Info($"Process [{ProcessName}] Terminate!");
        }

        #endregion

        #region process manage

        private Thread _process;

        public virtual void Start()
        {
            if (IsRunning)
            {
                Warning($"Process [{ProcessName}] Is Running!");
                return;
            }

            if (_process != null)
            {
                Warning($"Process [{ProcessName}] Is Not Null!");
                _process = null;
            }

            _process = new Thread(Process)
            {
                IsBackground = true,
            };
            _process.Start();
            Info($"Process [{ProcessName}] Start!");
        }

        public virtual void Stop()
        {
            if (!IsRunning)
            {
                Warning($"Process [{ProcessName}] Is Not Running!");
                return;
            }

            if (_process != null)
            {
                IsRunning = false;
                while (_process.IsAlive)
                {
                    Application.DoEvents();
                }
                _process.Join();
                _process = null;
                Info($"Process [{ProcessName}] Stop!");
            }
        }

        public virtual void Reset()
        {
            Info($"Process [{ProcessName}] Reset!");
        }

        private async void Process()
        {
            Info($"Thread [{ProcessName}] Start!");
            IsRunning = true;

            while (IsRunning)
            {
                RunJob();

                await RunJobAsync();
            }

            Info($"Thread [{ProcessName}] Finish!");
        }

        protected virtual void RunJob()
        {
        }

        protected virtual async Task RunJobAsync()
        {
            await Task.FromResult(true);
        }

        #endregion

        #region events

        public event Action<object> ProcessStartEvent;
        public event Action<object> ProcessStateEvent;
        public event Action<object> ProcessFinsihEvent;

        protected virtual void OnProcessStartEvent(object obj)
        {
            ProcessStartEvent?.Invoke(obj);
        }
        protected virtual void OnProcessStateEvent(object obj)
        {
            ProcessStateEvent?.Invoke(obj);
        }
        protected virtual void OnProcessFinsihEvent(object obj)
        {
            ProcessFinsihEvent?.Invoke(obj);
        }

        #endregion
    }


    public class Process<TResult> : LogEventObject, IInitializable where TResult : TestResultObject
    {
        public string ProcessName;
        public volatile bool IsRunning;

        public Process(string process)
        {
            ProcessName = process;
        }

        public virtual bool Initialize()
        {
            Info($"Process [{ProcessName}] Initialize!");
            return true;
        }

        public virtual void Terminate()
        {
            Stop();
            Info($"Process [{ProcessName}] Terminate!");
        }

        #region process

        private Thread _thread;

        public virtual void Start()
        {
            if (IsRunning)
            {
                Warning($"Process [{ProcessName}] Is Running!");
                return;
            }

            if (_thread != null)
            {
                Warning($"Process [{ProcessName}] Is Not Null!");
                _thread = null;
            }

            _thread = new Thread(RunProcess)
            {
                IsBackground = true,
            };
            _thread.Start();
            Info($"Process [{ProcessName}] Start!");
        }

        public virtual void Stop()
        {
            if (!IsRunning)
            {
                Warning($"Process [{ProcessName}] Is Not Running!");
                return;
            }

            if (_thread != null)
            {
                IsRunning = false;
                while (_thread.IsAlive)
                {
                    Application.DoEvents();
                }
                _thread.Join();
                _thread = null;
                Info($"Process [{ProcessName}] Stop!");
            }
        }

        public virtual void Reset()
        {
            Info($"Process [{ProcessName}] Reset!");
        }

        private async void RunProcess()
        {
            Info($"RunProcess [{ProcessName}] Start!");
            IsRunning = true;

            while (IsRunning)
            {
                RunJob();

                await RunJobAsync();
            }

            Info($"RunProcess [{ProcessName}] Finish!");
        }

        protected virtual void RunJob()
        {
        }

        protected virtual async Task RunJobAsync()
        {
            await Task.FromResult(true);
        }

        #endregion

        #region events

        public event Action<TResult> ProcessStartEvent;
        public event Action<string> ProcessStateEvent;
        public event Action<TResult> ProcessFinsihEvent;

        protected virtual void OnProcessStartEvent(TResult obj)
        {
            ProcessStartEvent?.Invoke(obj);
        }
        protected virtual void OnProcessStateEvent(string obj)
        {
            ProcessStateEvent?.Invoke(obj);
        }
        protected virtual void OnProcessFinsihEvent(TResult obj)
        {
            ProcessFinsihEvent?.Invoke(obj);
        }

        #endregion
    }
}