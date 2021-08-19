using MyGame.Game.GraphicElements.MapCells;
using MyGame.Game.Map.Maps;
using System.Windows;
using System.Windows.Controls;

namespace MyGame.Game.Map
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : Window
    {
        public MapViewModel MapViewModel { get; }

        public Map()
        {
            InitializeComponent();

            DataContext = new MapDataContext();
            MapViewModel = new MapViewModel();
        }


        public void BuildMap(IMap map)
        {
            for (int i = 0; i < map.Height; i++)
            {
                RowDefinition row = new RowDefinition();
                GameArea.RowDefinitions.Add(row);
            }

            for (int i = 0; i < map.Width; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                GameArea.ColumnDefinitions.Add(col);
            }

            for (int i = 0; i < map.Height; i++)
            {
                for (int j = 0; j < map.Width; j++)
                {
                    CaseTypes caseType = map.Cases[i, j];

                    UserControl caseInst = MapCellFactory.GetCaseFromType(caseType) as UserControl; //create a userControl

                    //but we save the viewmodel of the UserControl
                    // really 'heavy' trick
                    MapViewModel.AddCell(i, j, (caseInst.DataContext as ICellDataContext).CellViewModel); 

                    caseInst.Width = GameArea.Width / map.Width;
                    caseInst.Height = GameArea.Width / map.Height;
                    Grid.SetRow(caseInst, i);
                    Grid.SetColumn(caseInst, j);
                    GameArea.Children.Add(caseInst);
                }
            }



        }
    }
}
