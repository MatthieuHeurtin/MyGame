using MyGame.Game.Map.Maps;
using MyGame.Game.MapElements.Interactions;

namespace MyGame.Game.Item
{
    public class ChangingMapPoint : AbstractItem
    {
        private readonly string _key;
        private readonly IPlayerInteraction _nextMap;

        private readonly bool _isPhysical;
        public override bool IsPhysical
        {
            get { return _isPhysical; }
        }

        public ChangingMapPoint(string key, IMap map) : base()
        {
            _key = key;
            _nextMap = new NextMapToDisplay(map);
            _isPhysical = false;
        }

        public override string Key
        {
            get { return _key; }
        }
    }
}
