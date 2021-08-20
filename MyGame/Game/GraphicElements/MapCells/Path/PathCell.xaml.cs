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



        }

        public CaseTypes Type
        {
            get { return CaseTypes.PATH; }
        }

    }
}
