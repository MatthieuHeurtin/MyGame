using MyGame.Game.Map.Maps;
using MyGame.Game.MapCells;
using MyGame.Game.Views.Characters;
using System.Windows;
using System.Windows.Controls;

namespace MyGame.Game.Map
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : Window
    {


        public Map()
        {
            InitializeComponent();
            DataContext = new MapDataContext();

            ControlArea.Children.Add(new CharacterView());
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
                    var mapCell = map.MapCells[j, i];

                    var caseInst = mapCell.GetGui(); //create a userControl
                   
                    caseInst.ToolTip = j.ToString() + ";" + i.ToString();
                    //but we save the viewmodel of the UserControl
                    // really 'heavy' trick
                 //   GetViewModel().AddCell(j, i, (caseInst.DataContext as IGuiMapCellDataContext).GuiMapCellViewModel);

                    Grid.SetRow(caseInst, i);
                    Grid.SetColumn(caseInst, j);
                    GameArea.Children.Add(caseInst);
                }
            }



        }

        //allows me to delegate UI thread managment to window
        public MapViewModel GetViewModel()
        {
            MapViewModel p = null;
            Dispatcher.Invoke(() =>
            {
                p =  (DataContext as MapDataContext).MapViewModel;
            });
            return p;

        }




    }
}
