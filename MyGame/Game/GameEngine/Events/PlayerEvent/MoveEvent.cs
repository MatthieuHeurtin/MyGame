﻿using System;
using MyGame.Game.Character.Characters;
using MyGame.Game.Map.Maps;

namespace MyGame.Game.GameEngine.Events.PlayerEvent
{
    internal class MoveEvent : IEvent
    {
        private readonly string direction;
        private IMap _map;
        private readonly ICharacter _player;
        private readonly Map.Map _graphicMap;

        public string Description { get { return "PLAYER : MOVE"; } }

        public MoveEvent(string direction, IMap map, Map.Map graphicMap, ICharacter player)
        {
            this.direction = direction;
            _map = map;
            _player = player;
            _graphicMap = graphicMap;
        }

        public void Execute()
        {
            int Xcurrent = _player.X;
            int Ycurrent = _player.Y;
            var dest = GetDestination(direction, Xcurrent, Ycurrent, _map.Height - 1, _map.Width - 1);
            if (Xcurrent == dest.Item1 && Ycurrent == dest.Item2
                || Xcurrent == dest.Item1 && Ycurrent == dest.Item2
                || _graphicMap.GetViewModel().IsOccupied(dest.Item1, dest.Item2)) return;

            _graphicMap.GetViewModel().RemoveCharacter(_player);
            _player.SetPosition(dest.Item1, dest.Item2);
            _graphicMap.GetViewModel().AddElement(_player);
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