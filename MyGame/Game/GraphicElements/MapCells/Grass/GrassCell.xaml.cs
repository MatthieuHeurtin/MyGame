using MyGame.Game.GraphicElements.MapCells.Common;
using System.Windows.Controls;

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
        }
    }
}
