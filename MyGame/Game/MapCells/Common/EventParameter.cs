using System;

namespace MyGame.Game.MapCells.Common
{
    public class EventParameter : EventArgs
    {
        public readonly string Param;

        public EventParameter(string obj)
        {
            Param = obj;
        }
    }
}
