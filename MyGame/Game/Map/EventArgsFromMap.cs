using System;

namespace MyGame.Game.Map
{
    internal class EventArgsFromMap : EventArgs
    {
        public string Param { get; }
        public string Key { get; }
        public EventArgsFromMap(string key, string param) : base()
        {
            Param = param;
            Key = key;
        }
    }
}