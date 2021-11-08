using System;
using System.Threading;

namespace MyGame.Game.GameEngine
{
    public class Clock : IDisposable
    {
        private const int HEARTBEAT = 200;
        public ManualResetEvent ManualResetEvent { get { return _manualResetEvent; } }
        private ManualResetEvent _manualResetEvent;
        private Timer _timer;
        public Clock()
        {
            _manualResetEvent = new ManualResetEvent(false);
            _timer = new Timer(new TimerCallback(ResetEvent), null, 1000, HEARTBEAT);

        }

        private void ResetEvent(object state)
        {
            _manualResetEvent.Set();
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
