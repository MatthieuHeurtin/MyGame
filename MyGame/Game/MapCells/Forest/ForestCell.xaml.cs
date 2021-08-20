using MyGame.Game.MapCells.Common;
using MyGame.Ressources;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MyGame.Game.MapCells.Forest
{
    /// <summary>
    /// Interaction logic for ForestCell.xaml
    /// </summary>
    public partial class ForestCell : UserControl, IMapCell
    {
        public CaseTypes Type
        {
            get { return CaseTypes.FOREST; }
        }

        public ForestCell()
        {
            InitializeComponent();
            DataContext = new CellDataContext();
            CellBackground.ImageSource = new BitmapImage(new Uri(string.Concat(RessourcesManager.MapCellsPath, "grass.jpg"), UriKind.Relative));
        }

    }
}
