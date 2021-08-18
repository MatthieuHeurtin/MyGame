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

            //AddImage();
        }

        public CaseTypes Type
        {
            get { return CaseTypes.PATH; }
        }

        public void AddImage()
        {

            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new System.Uri(@"C:\Users\matth\Documents\Visual Studio 2017\Projects\MyGame\MyGame\Game\GraphicElements\Characters\ressources/mainCharacter.png");
            b.EndInit();

            ImageViewer.Source = b;


        }
    }
}
