using MyGame.DebugTools;
using MyGame.Game.GameEngine.Events;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace MyGame.Game.GameEngine
{
    public class EventConsumer : IDisposable
    {
        private const int MAX_THREAD = 1;
        private BlockingCollection<IEvent> _events;
        private Clock _clock;
        private ManualResetEvent _manualEvent = new ManualResetEvent(false);

 
        public EventConsumer(Clock clock)
        {
            _events = new BlockingCollection<IEvent>(MAX_THREAD);
            _clock = clock;

        }

        internal void QueueEvent(IEvent custonEvent)
        {
            if (_events.Count < 10)
            {
                _events.Add(custonEvent);
            }
        }


        public void Start()
        {
            Task.Run(() =>
            {
                IEvent ev = null;
                while (!_events.IsCompleted)
                {

                    try
                    {
                        ev = _events.Take();
                    }
                    catch (InvalidOperationException) { }

                    if (ev != null)
                    {
                        _clock.ManualResetEvent.WaitOne();
                        ev.Execute();
                        ev.Dispose();
                        _clock.ManualResetEvent.Reset();
                    }
                }
            }
            );
        }
        public void Dispose()
        {
            _events.CompleteAdding();
        }

    }
}
