using MyGame.Game.Character.Routines;
using MyGame.Game.MapElements;

namespace MyGame.Game.Character.Characters
{
    public interface ICharacter : IMapElement
    {
        IRoutine Routine { get; set; }
        void SetRoutine(IRoutine routine);
        void StartRoutine();

    }
}
