using MyGame.Game.Character.Characters;

namespace MyGame.Game.Characters.Character
{
    public class PlayableCharacter : AbstractCharacter
    {
        private readonly string _key;
        private readonly string _name;
        private readonly string _spriteName;

        public override string Name
        {
            get { return _name; }
        }

        public override string Key
        {
            get { return _key; }
        }

        public override string SpriteName
        {
            get { return _spriteName; }
        }

        public PlayableCharacter()
        {
            X = 2;
            Y = 3;
            _name = "Matt";
            _key = "player";
            _spriteName = "mainCharacter.png";
        }
    }
}
