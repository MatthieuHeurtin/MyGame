using System.Windows.Controls;

namespace MyGame.Game.MapCells.GraphicMapCell
{
    /// <summary>
    /// Interaction logic for GuiMapCell.xaml
    /// </summary>
    public partial class GuiMapCell : UserControl
    {
        public GuiMapCell()
        {
            InitializeComponent();
            DataContext = new GuiMapCellDataContext(); ;
        }
    }
}
