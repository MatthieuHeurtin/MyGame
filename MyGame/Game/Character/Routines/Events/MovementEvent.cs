using System;

namespace MyGame.Game.Character.Routines.Events
{
    public class MovementEvent : EventArgs, IRoutineEvent
    {


        public string Direction { get; set; }



        public string Key { get; set; }

        public event EventHandler OnRaise;

        public void Raise(string direction, string key)
        {
            Key = key;
            Direction = direction;
            OnRaise?.Invoke(this, this);
        }
    }
}
