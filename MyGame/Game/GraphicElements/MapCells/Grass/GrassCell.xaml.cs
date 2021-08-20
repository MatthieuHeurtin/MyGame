using MyGame.Game.GraphicElements.MapCells.Common;
using MyGame.Ressources;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MyGame.Game.GraphicElements.MapCells.Grass
{
    /// <summary>
    /// Interaction logic for GrassCell.xaml
    /// </summary>
    public partial class GrassCell : UserControl, IMapCell
    {
        private bool _hasCharacter;

        public CaseTypes Type
        {
            get { return CaseTypes.GRASS; }
        }

        public bool HasCharacter
        {
            get { return _hasCharacter; }
            set { _hasCharacter = value; }
        }

        public GrassCell()
        {
            InitializeComponent();
            DataContext = new CellDataContext(); ;
            CellBackground.ImageSource = new BitmapImage(new Uri(string.Concat(RessourcesManager.MapCellsPath, "grass.jpg"), UriKind.Relative));
        }
    }
}
