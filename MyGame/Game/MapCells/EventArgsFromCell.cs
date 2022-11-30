using System;

namespace MyGame.Game.MapCells
{
    public class EventArgsFromCell : EventArgs
    {
        public EventFromCellType Type { get; }
        public string Key { get; }
        public EventArgsFromCell(EventFromCellType type,string key) : base()
        {
            Type = type;
            Key = key;
        }
    }

    public enum EventFromCellType
    {
        UpdateControlArea,
        ChangeMap,
        Treasure
    }
}
