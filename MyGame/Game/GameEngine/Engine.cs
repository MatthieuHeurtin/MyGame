using System;
using MyGame.Game.Character.Characters;
using MyGame.Game.Map;
using MyGame.Game.Map.Maps;

namespace MyGame.Game.GameEngine
{
    public class Engine
    {
        private readonly IMap _map;
        private Map.Map _graphicMap;
        private readonly ICharacter _player;

        public Engine(IMap map)
        {
            _map = map;
            _player = map.Player;
        }

        public void Start()
        {
            //Init Map
            _graphicMap = new Map.Map();
            _graphicMap.BuildMap(_map);

            //add npc (set character to a cell)
            foreach (var character in _map.Characters)
            {
                _graphicMap.GetViewModel().AddCharacter(character.Value);
            }

            //add players
            _graphicMap.GetViewModel().AddCharacter(_map.Player);

            //subscribe to events coming from the map
            _graphicMap.GetViewModel().RaiseMovement += Move;

            //display
            _graphicMap.Show();
        }

        private void Move(object sender, EventArgs e)
        {
            string direction = (e as EventParameter).Param;
            int Xcurrent = _map.Player.X;
            int Ycurrent = _map.Player.Y;
            var dest = GetDestination(direction, Xcurrent, Ycurrent,_map.Height - 1, _map.Width - 1);
            if (Xcurrent == dest.Item1 && Ycurrent == dest.Item2 
                || Xcurrent == dest.Item1 && Ycurrent == dest.Item2
                || _graphicMap.GetViewModel().IsOccupied(dest.Item1, dest.Item2)) return;

            _graphicMap.GetViewModel().RemoveCharacter(_map.Player);
            _map.Player.SetPosition(dest.Item1, dest.Item2);
            _graphicMap.GetViewModel().AddCharacter(_map.Player);
        }

        private Tuple<int,int> GetDestination(string direction, int xcurrent, int ycurrent, int Ymax, int Xmax)
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
            return new Tuple<int,int>(xcurrent, ycurrent);
        }

    }
}
