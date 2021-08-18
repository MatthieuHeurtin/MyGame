using MyGame.Game.Character.Characters;

namespace MyGame.Game.Characters.Character
{
    public class PlayableCharacter : ICharacter
    {
        private string _key;
        private string _name;
        private int _Y;
        private int _X;

        public string Name
        {
            get { return _name; }
        }

        public string Key
        {
            get { return _key; }
        }

        public int X
        {
            get { return _X; }
        }

        public int Y
        {
            get { return _Y; }
        }

        public PlayableCharacter()
        {
            _X = 7;
            _Y = 7;
            _name = "Matt";
            _key = "player";
        }
    }
}
