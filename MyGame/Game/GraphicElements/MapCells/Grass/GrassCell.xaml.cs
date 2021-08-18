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

namespace MyGame.Game.GraphicElements.MapCells.Grass
{
    /// <summary>
    /// Interaction logic for GrassCell.xaml
    /// </summary>
    public partial class GrassCell : UserControl, IMapCell
    {

        public CaseTypes Type
        {
            get { return CaseTypes.GRASS; }
        }

        public GrassCell()
        {
            InitializeComponent();
        }
    }
}
