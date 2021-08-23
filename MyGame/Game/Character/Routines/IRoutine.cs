using MyGame.Game.Character.Routines.Events;

namespace MyGame.Game.Character.Routines
{
    public interface IRoutine
    {
        IRoutineEvent RoutinedEvent { get; set; }
        string Key { get; set; }

        void Start();
    }
}
