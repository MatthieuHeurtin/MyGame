using System;

namespace MyGame.Game.Map
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
