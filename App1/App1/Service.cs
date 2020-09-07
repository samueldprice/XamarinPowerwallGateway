using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace App1
{
    public class Service<T>
    {
        private volatile ConcurrentDictionary<Guid, Action<T>> _listeners = new ConcurrentDictionary<Guid, Action<T>>();
        private volatile Task _task;
        private object _lockObj = new object();
        private CancellationTokenSource _cancellationTokenSource;

        public Guid Subscribe(Action<T> notify)
        {
            var key = Guid.NewGuid();
            _listeners.AddOrUpdate(key, notify, (a, b) => notify);
            return key;
        }

        public void Unsubscribe(Guid key)
        {
            _listeners.TryRemove(key, out _);
        }

        private void NotifySubscribers(T list)
        {
            foreach (var listener in _listeners)
            {
                listener.Value(list);
            }
        }

        public void Start(Func<T> worker, TimeSpan? delay = null)
        {
            lock (_lockObj)
            {
                if (_task == null || _task.IsCompleted)
                {
                    _cancellationTokenSource = new CancellationTokenSource();
                    _task = new Task(() => DoWork(worker), _cancellationTokenSource.Token);
                    _task.ConfigureAwait(false);
                    _task.Start();
                }
            }
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }

        private void DoWork(Func<T> worker, TimeSpan? delay = null)
        {
            delay = delay ?? TimeSpan.FromSeconds(1);
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                var result = worker();
                NotifySubscribers(result);
                Thread.Sleep(delay.Value);
            }
        }
    }
}
