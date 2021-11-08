using MyGame.Game.Characters.Character;
using MyGame.Game.MapCells.GraphicMapCell;
using MyGame.Game.MapElements;
using MyGame.Game.MapElements.Interactions;
using MyGame.Ressources;
using System;
using System.Windows.Media.Imaging;

namespace MyGame.Game.MapCells
{
    public class MapCell : IMapCell
    {
        public CaseTypes Type { get; }
        public IMapElement MapElement { get { return _mapElement; } }

        public bool IsOccupied { get; private set; }

        private GuiMapCell _guiMapCell;
        private IGuiMapCellViewModel _guiMapCellViewModel;
        private IMapElement _mapElement;

        public event EventHandler ForwardEventToTheMap;

        public MapCell(CaseTypes type)
        {
            Type = type;
            _guiMapCell = new GuiMapCell();
            _guiMapCellViewModel = (_guiMapCell.DataContext as GuiMapCellDataContext).GuiMapCellViewModel;
            _guiMapCellViewModel.RaiseClickOnCell += ForwardEventToMap;
            _guiMapCell.CellBackground.ImageSource = new BitmapImage(new Uri(string.Concat(RessourcesManager.MapCellsPath, GetImageFromCellType(Type)), UriKind.Relative));
        }

        //just to be sure to separate Cellules to full map, it might be a disaster for performances
        private void ForwardEventToMap(object sender, EventArgs e)
        {
            ForwardEventToTheMap?.Invoke(this, e);
        }

        public void SetMapElement(IMapElement mapElement)
        {

            if (mapElement is PlayableCharacter && _mapElement != null)// if the player is arriving on the current cell
            {
                EventArgsFromCell e = new EventArgsFromCell(EventFromCellType.ChangeMap, _mapElement.Key);
                ForwardEventToTheMap?.Invoke(this, e);
            }

            if (mapElement == null)
            {
                _guiMapCellViewModel.SetSprite(null);
                _mapElement = null;
                IsOccupied = false;
                return;
            }

            string folderRessourcesPath = RessourcesManager.GetPathFromElementMap(mapElement);
            _guiMapCellViewModel.SetSprite(string.Concat(folderRessourcesPath, mapElement.SpriteName));
            IsOccupied = mapElement.IsPhysical;
            _mapElement = mapElement;
            _guiMapCellViewModel.SetElement(_mapElement);
        }

        public GuiMapCell GetGui()
        {
            return _guiMapCell;
        }

        private string GetImageFromCellType(CaseTypes type)
        {
            switch (type)
            {
                case CaseTypes.GRASS:
                    return "grass.jpg";
                case CaseTypes.STONE_PATH:
                    return "stonePath.jpg";
                case CaseTypes.PATH:
                    return "path.jpg";
                case CaseTypes.DESERT:
                    return "desert.jpg";
                case CaseTypes.HAPPY_GRASS:
                    return "happyGrass.png";
                default:
                    return "happyGrass.png";
            }
        }
    }
}
