using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyGame.Game.GameEngine
{
    public class Clock :IDisposable
    {
        private const int HEARTBEAT = 100;
        public ManualResetEvent ManualResetEvent { get { return _manualResetEvent; } }
        private ManualResetEvent _manualResetEvent;
        public Clock()
        {
            _manualResetEvent = new ManualResetEvent(false);
        }

        public void Start()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(HEARTBEAT);
                    _manualResetEvent.Set();
                }
            });
        }

        public void Dispose()
        {
           
        }
    }
}
