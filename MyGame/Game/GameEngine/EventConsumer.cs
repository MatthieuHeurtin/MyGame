﻿using MyGame.Game.GameEngine.Events;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace MyGame.Game.GameEngine
{
    internal class EventConsumer : IDisposable
    {
        private const int MAX_THREAD = 10;
        private BlockingCollection<IEvent> _events;
        private Clock _clock;
        public EventConsumer(Clock clock)
        {
            _events = new BlockingCollection<IEvent>(MAX_THREAD);
            _clock = clock;
        }



        internal void QueueEvent(IEvent custonEvent)
        {
            _events.Add(custonEvent);
        }

        internal void Start()
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
                        _clock.ManualResetEvent.Reset();
                        ev.Dispose();
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
