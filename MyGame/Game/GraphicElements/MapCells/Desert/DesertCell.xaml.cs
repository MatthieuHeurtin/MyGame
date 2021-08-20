using MyGame.Game.GraphicElements.MapCells.Common;
using System.Windows.Controls;

namespace MyGame.Game.GraphicElements.MapCells.Desert
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
            Item.Template = FindResource("Item") as ControlTemplate;
        }
    }
}
