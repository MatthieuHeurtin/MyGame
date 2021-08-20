namespace MyGame.Game.Character.Characters
{
    public abstract class AbstractCharacter : ICharacter
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public virtual string Name { get; private set; }

        public virtual string SpriteName { get; private set; }


        public abstract string Key { get; }

        public AbstractCharacter()
        {
            SpriteName = "defaultCharacter.png";
            Name = "I have noname";
        }

        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void SetSpriteName(string spriteName)
        {
            SpriteName = spriteName;
        }
    }
}
