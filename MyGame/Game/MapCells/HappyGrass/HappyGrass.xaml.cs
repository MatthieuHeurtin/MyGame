using MyGame.Game.MapCells.Common;
using MyGame.Ressources;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MyGame.Game.MapCells.HappyGrass
{
    /// <summary>
    /// Interaction logic for HappyGrass.xaml
    /// </summary>
    public partial class HappyGrass : UserControl, IMapCell
    {
        public HappyGrass()
        {
            InitializeComponent();
            DataContext = new CellDataContext(); ;
            CellBackground.ImageSource = new BitmapImage(new Uri(string.Concat(RessourcesManager.MapCellsPath, "happyGrass.png"), UriKind.Relative));
        }

        public CaseTypes Type
        {
            get { return CaseTypes.GRASS; }
        }
    }

}
