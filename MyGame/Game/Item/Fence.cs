namespace MyGame.Game.Item
{
    public class Fence : AbstractItem
    {
        private readonly string _key;

        public override string Key
        {
            get { return _key; }
        }

        public Fence(string key) : base()
        {
            _key = key;
        }
    }
}
