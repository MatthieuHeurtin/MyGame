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
        public ManualResetEvent RoutineBlocker { get; set; }

        public MovementRoutine(string[] directions )
        {
            _directions = directions;
            RoutinedEvent = new MovementEvent();
            
        }

        public void Start(ManualResetEvent routineBlocker)
        {
            RoutineBlocker = routineBlocker;
            Task.Run(() =>
            {
                while (true)
                {
                    RoutineBlocker.WaitOne();
                    foreach (var direction in _directions)
                    {
                        RoutinedEvent.Raise(direction, Key);
                    }

                }
            });
        }
    }
}
