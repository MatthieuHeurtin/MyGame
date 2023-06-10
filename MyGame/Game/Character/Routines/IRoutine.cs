using MyGame.Game.Character.Routines.Events;
using System.Threading;

namespace MyGame.Game.Character.Routines
{
    public interface IRoutine
    {
        IRoutineEvent RoutinedEvent { get; set; }
        string Key { get; set; }
        void Start(ManualResetEvent routineBlocker);
        ManualResetEvent RoutineBlocker { get; set; }
    }
}
