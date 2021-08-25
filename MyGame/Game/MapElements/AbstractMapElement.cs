namespace MyGame.Game.MapElements
{
    public abstract class  AbstractMapElement : IMapElement
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public virtual string Name { get; private set; }

        public virtual string SpriteName { get; private set; }


        public abstract string Key { get; }

        public AbstractMapElement()
        {
            SpriteName = "defaultCharacter.png";
            Name = "I have no name";
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
        public override string ToString()
        {
           return string.Format("Name : {0} ,X={1} Y={2}, SpriteName={3}"  ,Name, X, Y, SpriteName);
        }
    }
}
