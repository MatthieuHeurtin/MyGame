namespace MyGame.Game.Item
{
    public class House : AbstractItem, IItem
    {
        private readonly string _key;

        public override string Key
        {
            get { return _key; }
        }

        public House(string key) : base()
        {
            _key = key;
        }
    }
}
