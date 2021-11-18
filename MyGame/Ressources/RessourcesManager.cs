using MyGame.Game.Character.Characters;
using MyGame.Game.Item;
using MyGame.Game.MapElements;

namespace MyGame.Ressources
{
    public static class RessourcesManager
    {
        public const string MapCellsPath = @".\Ressources\Images\MapCells\";
        public const string ItemsPath = @"\Ressources\Images\Items\";
        public const string MenuPath = @".\Ressources\Menu\";
        public const string CharacterSpriteCellsPath = @".\..\..\..\..\Ressources\Images\CharactersSprites\";

        public static string GetPathFromElementMap(IMapElement mapElement)
        {
            string result = string.Empty;

            if (mapElement is ICharacter)
                result = CharacterSpriteCellsPath;
            else if (mapElement is IItem)
                result = ItemsPath;

            return result;
        }
    }
}
