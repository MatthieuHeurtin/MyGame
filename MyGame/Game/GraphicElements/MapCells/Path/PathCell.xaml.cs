using MyGame.Game.GraphicElements.MapCells.Common;
using MyGame.Ressources;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MyGame.Game.GraphicElements.MapCells.Path
{
    /// <summary>
    /// Interaction logic for PathCell.xaml
    /// </summary>
    public partial class PathCell : UserControl, IMapCell
    {
        public PathCell()
        {
            InitializeComponent();

            DataContext = new CellDataContext();
            CellBackground.ImageSource = new BitmapImage(new Uri(string.Concat(RessourcesManager.MapCellsPath, "path.jpg"), UriKind.Relative));


        }

        public CaseTypes Type
        {
            get { return CaseTypes.PATH; }
        }

    }
}
