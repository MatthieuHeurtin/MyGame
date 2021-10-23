using System;

namespace MyGame.Game.GameEngine.Events
{
    internal interface IEvent : IDisposable
    {
        void Execute();
        string Description { get; }
    }
}
