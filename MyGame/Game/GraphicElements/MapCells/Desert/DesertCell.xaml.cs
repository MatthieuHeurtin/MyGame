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

namespace MyGame.Game.GraphicElements.MapCells.Desert
{
    /// <summary>
    /// Interaction logic for DesertCell.xaml
    /// </summary>
    public partial class DesertCell : UserControl, IMapCell
    {
        private bool _hasCharacter;

        public CaseTypes Type
        {
            get { return CaseTypes.DESERT; }
        }

        public bool HasCharacter
        {
            get { return _hasCharacter; }
            set { _hasCharacter = value; }
        }

        public DesertCell()
        {
            InitializeComponent();
            DataContext = new CellDataContext();
        }
    }
}
