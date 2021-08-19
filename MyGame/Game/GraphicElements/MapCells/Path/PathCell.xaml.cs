using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MyGame.Game.GraphicElements.MapCells.Path
{
    /// <summary>
    /// Interaction logic for PathCell.xaml
    /// </summary>
    public partial class PathCell : UserControl, IMapCell
    {
        private bool _hasCharacter;
        public PathCell()
        {
            InitializeComponent();

            DataContext = new CellDataContext();
        }

        public CaseTypes Type
        {
            get { return CaseTypes.PATH; }
        }

        public bool HasCharacter
        {
            get { return _hasCharacter; }
            set { _hasCharacter = value; }
        }
    }
}
