namespace MyGame.Game.Item
{
    internal class Treasure : AbstractItem
    {
        private readonly string _key;

        public override string Key
        {
            get { return _key; }
        }

        private readonly bool _isPhysical;
        public override bool IsPhysical
        {
            get { return _isPhysical; }
        }

        public Treasure(string key, string mapKey) : base()
        {
            _key = key;
         //   SetPlayerInteraction(new NextMapToDisplay(mapKey));
            _isPhysical = false;

        }
    }
}
