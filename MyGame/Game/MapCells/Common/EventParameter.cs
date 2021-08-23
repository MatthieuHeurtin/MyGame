using System;

namespace MyGame.Game.MapCells.Common
{
    public class EventParameter : EventArgs
    {
        public readonly string Key;

        public EventParameter(string obj)
        {
            Key = obj;
        }
    }
}
