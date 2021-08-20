namespace MyGame.Game.Character.Characters
{
    public class NonPlayableCharacter : AbstractCharacter
    {
        private readonly string _key;

        public NonPlayableCharacter(string key):base()
        {
            _key = key;
        }

        public override string Key
        {
            get { return _key; }
        }

        
    }
}
