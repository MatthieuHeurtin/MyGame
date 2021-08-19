namespace MyGame.Game.Character.Characters
{
    public abstract class AbstractCharacter : ICharacter
    {
        public virtual int X { get { return 0; } }

        public virtual int Y { get { return 0; } }

        public virtual string Name { get { return "I'm no set"; } }

        public virtual string SpriteName { get { return "defaultCharacter.png"; } }

        public abstract string Key { get; }
    }
}
