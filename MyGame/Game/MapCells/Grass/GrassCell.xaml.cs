using MyGame.Game.MapCells.Common;
using MyGame.Ressources;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MyGame.Game.MapCells.Grass
{
    /// <summary>
    /// Interaction logic for GrassCell.xaml
    /// </summary>
    public partial class GrassCell : UserControl, IMapCell
    {
        public CaseTypes Type
        {
            get { return CaseTypes.GRASS; }
        }

        public GrassCell()
        {
            InitializeComponent();
            DataContext = new CellDataContext(); ;
            CellBackground.ImageSource = new BitmapImage(new Uri(string.Concat(RessourcesManager.MapCellsPath, "grass.jpg"), UriKind.Relative));
        }
    }
}
