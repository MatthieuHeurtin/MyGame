using MyGame.Game.Character.Characters;

namespace MyGame.Game.Characters.Character
{
    public class PlayableCharacter : AbstractCharacter
    {
        private readonly string _key;
        private readonly string _name;
        private int _Y;
        private int _X;
        private readonly string _spriteName;

        public override string Name
        {
            get { return _name; }
        }

        public override string Key
        {
            get { return _key; }
        }

        public override int X
        {
            get { return _X; }
        }

        public override int Y
        {
            get { return _Y; }
        }

        public override string SpriteName
        {
            get { return _spriteName; }
        }

        public PlayableCharacter()
        {
            _X = 7;
            _Y = 7;
            _name = "Matt";
            _key = "player";
            _spriteName = "mainCharacter.png";
        }
    }
}
