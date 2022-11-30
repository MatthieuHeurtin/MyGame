using MyGame.Game.Map.Maps;
using MyGame.Game.MapCells;

namespace MyGame.Game.MapElements.Interactions
{
    public class DisaplayDialog : IPlayerInteraction
    {
        private readonly string _text;

        public DisaplayDialog(string text)
        {
            _text = text;
        }


        public string Execute()
        {
            throw new System.NotImplementedException();
        }

        public EventFromCellType GetEventType()
        {
            throw new System.NotImplementedException();
        }
    }
}
