using MyGame.Game.Map.Maps;

namespace MyGame.Game.MapElements.Interactions
{
    public class NextMapToDisplay : IPlayerInteraction
    {
        private readonly IMap _nextMap;
        public NextMapToDisplay(IMap nextMap)
        {
            _nextMap = nextMap;
        }




        public IMap Execute()
        {
            return _nextMap;
        }
    }
}
