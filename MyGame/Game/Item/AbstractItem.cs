using MyGame.Game.MapElements;

namespace MyGame.Game.Item
{
    public abstract class AbstractItem : AbstractMapElement, IItem
    {
        public virtual bool HasToDisapear { get; protected set; }


        public AbstractItem()
        {
            HasToDisapear = false;
        }
    }
}
