using MyGame.Game.Character.Routines;
using MyGame.Game.MapElements;
using System.Threading;

namespace MyGame.Game.Character.Characters
{
    public abstract class AbstractCharacter : AbstractMapElement, ICharacter
    {
        public AbstractCharacter() : base()
        {

        }

        public IRoutine Routine { get; set; }

        public virtual void SetRoutine(IRoutine routine)
        {
            //nothing because player does not have a default routine
        }

        public void StartRoutine(ManualResetEvent routineBlocker)
        {
            Routine.Start(routineBlocker);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
