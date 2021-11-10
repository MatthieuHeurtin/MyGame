using System;
using System.Threading;
using System.Timers;


namespace MyGame.Game.GameEngine
{
    public class Clock : IDisposable
    {
        private const int HEARTBEAT = 200;
        public ManualResetEvent ManualResetEvent { get { return _manualResetEvent; } }

        public static int Default { get { return HEARTBEAT; } }

        private ManualResetEvent _manualResetEvent;
        private System.Timers.Timer _timer;
        public Clock()
        {
            _manualResetEvent = new ManualResetEvent(false);
            _timer = new System.Timers.Timer(HEARTBEAT);
            _timer.Elapsed += ResetEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;

        }

        private void ResetEvent(object source, ElapsedEventArgs e)
        {
            _manualResetEvent.Set();
        }

        public void Start()
        {
            _timer.Stop();
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        internal void Pause()
        {
            _timer.Stop();
        }

        internal void Resume()
        {
            _timer.Start();        }
    }
}
