using MyGame.Game.Character.Routines;
using System.Threading;

namespace MyGame.Game.Character.Characters
{
    public interface ICharacter
    {
        IRoutine Routine { get; set; }
        void SetRoutine(IRoutine routine);
        void StartRoutine(ManualResetEvent routineBlocker);

    }
}
