using MyGame.Game.Character.Routines.Events;
using System.Threading;
using System.Threading.Tasks;

namespace MyGame.Game.Character.Routines
{
    public class MovementRoutine : IRoutine
    {
        private readonly string[] _directions;
        public IRoutineEvent RoutinedEvent { get; set; }

        public string Key { get; set; }

        public MovementRoutine(string[] directions, string key)
        {
            _directions = directions;
            RoutinedEvent = new MovementEvent();
            Key = key;
        }

        public void Start()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    foreach (var direction in _directions)
                    {
                        Thread.Sleep(200);
                        RoutinedEvent.Raise(direction, Key);
                    }
                }
            });
        }
    }
}
