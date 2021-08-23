using MyGame.Game.Character.Routines.Events;

namespace MyGame.Game.Character.Routines
{
    public interface IRoutine
    {
        IRoutineEvent RoutinedEvent { get; set; }
        void Start();
        string Key { get; set; }
    }
}
