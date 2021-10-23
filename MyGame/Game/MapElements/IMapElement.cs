using MyGame.Game.MapElements.Interactions;

namespace MyGame.Game.MapElements
{
    public interface IMapElement
    {
        int X { get; }
        int Y { get; }
        string Name { get; }
        string Key { get; }
        string SpriteName { get; }
        bool IsPhysical { get; } //if the player can't get over it

        void SetPosition(int item1, int item2);

        IPlayerInteraction PlayerInteraction { get; }


    }
}
