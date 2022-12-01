namespace MyGame.Game.Character.Models
{
    public class PlayerItem
    {
        public PlayerItem(string description, string spriteName)
        {
            Description= description;
            SpriteName= spriteName;
        }

        public string Icon { get; set; }
        public string Description { get; set; }
        public string SpriteName { get; set; }
    }
}
