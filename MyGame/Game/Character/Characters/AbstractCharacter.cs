namespace MyGame.Game.Character.Characters
{
    public abstract class AbstractCharacter : ICharacter
    {
        public int X { get; set; }

        public int Y { get; set; }

        public virtual string Name { get { return "I'm no set"; } }

        public virtual string SpriteName { get { return "defaultCharacter.png"; } }

        public abstract string Key { get; }

        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
