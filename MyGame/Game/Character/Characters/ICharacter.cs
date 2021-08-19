namespace MyGame.Game.Character.Characters
{
    public interface ICharacter
    {
        int X { get; }
        int Y { get; }
        string Name { get; }
        string Key { get; }
        string SpriteName { get; }
    }
}
