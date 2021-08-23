using System;

namespace MyGame.Game.Character.Routines.Events
{
    public interface IRoutineEvent
    {
        void Raise(string direction, string key);
        event EventHandler OnRaise;
        string Key { get; set; }
    }
}
