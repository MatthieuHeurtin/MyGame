using MyGame.Game.Character.Routines;

namespace MyGame.Game.Character.Characters
{
    public interface ICharacter
    {
        IRoutine Routine { get; set; }
        void SetRoutine(IRoutine routine);
        void StartRoutine();

    }
}
