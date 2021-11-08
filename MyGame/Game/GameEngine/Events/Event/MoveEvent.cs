﻿using System;
using MyGame.Game.Map.Maps;
using MyGame.Game.MapElements;

namespace MyGame.Game.GameEngine.Events.Event
{
    internal class MoveEvent : IEvent
    {
        private readonly string direction;
        private IMap _map;
        private readonly IMapElement _character;

        public string Description { get { return "PLAYER : MOVE"; } }

        public MoveEvent(string direction, IMap map, IMapElement character)
        {
            this.direction = direction;
            _map = map;
            _character = character;
        }

        public void Execute()
        {
            int Xcurrent = _character.X;
            int Ycurrent = _character.Y;
            var dest = GetDestination(direction, Xcurrent, Ycurrent, _map.Height - 1, _map.Width - 1);
            if (Xcurrent == dest.Item1 && Ycurrent == dest.Item2
                  || _map.MapCells[dest.Item1, dest.Item2].IsOccupied) return;



            _map.MapCells[Xcurrent, Ycurrent].SetMapElement(null);
            _map.MapCells[dest.Item1, dest.Item2].SetMapElement(_character);
            _character.SetPosition(dest.Item1, dest.Item2);

        }
        private Tuple<int, int> GetDestination(string direction, int xcurrent, int ycurrent, int Ymax, int Xmax)
        {
            switch (direction)
            {
                case "Up":
                    if (ycurrent > 0) ycurrent = ycurrent - 1;
                    break;
                case "Down":
                    if (ycurrent < Ymax) ycurrent = ycurrent + 1;
                    break;
                case "Right":
                    if (xcurrent < Xmax) xcurrent = xcurrent + 1;
                    break;
                case "Left":
                    if (xcurrent > 0) xcurrent = xcurrent - 1;
                    break;
                default:
                    break;
            }
            return new Tuple<int, int>(xcurrent, ycurrent);
        }

        public void Dispose()
        {

        }


    }
}