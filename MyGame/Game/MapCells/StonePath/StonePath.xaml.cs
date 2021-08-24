using MyGame.Game.MapCells.Common;
using MyGame.Ressources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyGame.Game.MapCells.StonePath
{
    /// <summary>
    /// Interaction logic for StonePath.xaml
    /// </summary>
    public partial class StonePath : UserControl, IMapCell
    {
        public StonePath()
        {
            InitializeComponent();
            DataContext = new CellDataContext();
            CellBackground.ImageSource = new BitmapImage(new Uri(string.Concat(RessourcesManager.MapCellsPath, "stonePath.jpg"), UriKind.Relative));


        }

        public CaseTypes Type
        {
            get { return CaseTypes.PATH; }
        }
    }
}
