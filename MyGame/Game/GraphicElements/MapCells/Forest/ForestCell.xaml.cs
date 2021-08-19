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

namespace MyGame.Game.GraphicElements.MapCells.Forest
{
    /// <summary>
    /// Interaction logic for ForestCell.xaml
    /// </summary>
    public partial class ForestCell : UserControl, IMapCell
    {
        private bool _hasCharacter;

        public CaseTypes Type
        {
            get { return CaseTypes.FOREST; }
        }

        public bool HasCharacter
        {
            get { return _hasCharacter; }
            set { _hasCharacter = value; }
        }
        public ForestCell()
        {
            InitializeComponent();
            DataContext = new CellDataContext(); ;
        }

    }
}
