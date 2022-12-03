using System.Collections.Generic;

namespace MyGame.Langages
{
    public class French : ILangage
    {
        public Dictionary<string, string> Dico { get { return _french; } }


        private Dictionary<string, string> _french = new Dictionary<string, string>
        {
            {"NewGame", "Nouvelle Partie" },
            {"LoadGame", "Charger une Partie" },
            { "Options", "Options" },
             { "VillageTitle", "Village" },
              { "VillageBorderTitle", "Sortie du Village" },
        };

    }
}
