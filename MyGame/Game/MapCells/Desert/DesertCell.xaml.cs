using MyGame.Game.MapCells.Common;
using MyGame.Ressources;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MyGame.Game.MapCells.Desert
{
    /// <summary>
    /// Interaction logic for DesertCell.xaml
    /// </summary>
    public partial class DesertCell : UserControl, IMapCell
    {
        public CaseTypes Type
        {
            get { return CaseTypes.DESERT; }
        }

        public DesertCell()
        {
            InitializeComponent();
            DataContext = new CellDataContext();
            CellBackground.ImageSource = new BitmapImage(new Uri(string.Concat(RessourcesManager.MapCellsPath, "desert.jpg"), UriKind.Relative));
        }
    }
}
