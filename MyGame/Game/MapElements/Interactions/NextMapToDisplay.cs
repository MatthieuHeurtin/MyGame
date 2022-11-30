using MyGame.Game.MapCells;

namespace MyGame.Game.MapElements.Interactions
{
    public class NextMapToDisplay : IPlayerInteraction
    {
        private readonly string _nextMap;
        public NextMapToDisplay(string nextMap)
        {
            _nextMap = nextMap;
        }




        public string Execute()
        {
            return _nextMap;
        }

        public EventFromCellType GetEventType()
        {
            return EventFromCellType.ChangeMap;
        }
    }
}
