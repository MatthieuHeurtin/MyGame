using MyGame.Game.MapElements.Interactions;

namespace MyGame.Game.Item
{
    public class ChangingMapPoint : AbstractItem
    {
        private readonly string _key;

        

        private readonly bool _isPhysical;
        public override bool IsPhysical
        {
            get { return _isPhysical; }
        }

        public ChangingMapPoint(string key, string mapKey) : base()
        {
            _key = key;
            SetPlayerInteraction(new NextMapToDisplay(mapKey));
            _isPhysical = false;

        }

        public override string Key
        {
            get { return _key; }
        }
    }
}
