using MyGame.Game.GraphicElements.MapCells;
using MyGame.Game.Map.Maps;
using System.Collections.Generic;
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

            DataContext = this;

            BuildMap(new M0_StartingMap());
        }


        private void BuildMap(IMap map)
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

                    IMapCell caseInst = MapCellFactory.GetCaseFromType(caseType);
                    (caseInst as UserControl).Width = GameArea.Width / map.Width;
                    (caseInst as UserControl).Height = GameArea.Width / map.Height; 
                    Grid.SetRow(caseInst as UserControl, i);
                    Grid.SetColumn(caseInst as UserControl, j);
                    GameArea.Children.Add(caseInst as UserControl);
                }
            }



        }
    }
}
