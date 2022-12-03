using System.Collections.Generic;

namespace MyGame.Langages
{
    public class English : ILangage
    {
        public Dictionary<string, string> Dico { get { return _english; } }


        private Dictionary<string, string> _english = new Dictionary<string, string>
        {
            {"NewGame", "New Game" },
            {"LoadGame", "Load" },
            { "Options", "Options" },
            { "VillageTitle", "Village" },
            {"VillageBorderTitle", "Village  Border"},
        };

}
}
