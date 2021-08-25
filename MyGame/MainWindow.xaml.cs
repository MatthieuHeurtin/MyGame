using MyGame.Game.Map.Maps;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MyGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<IMap> maps = new List<IMap>();
            maps.Add(new M0_Village());
            maps.Add(new M1_VillageBorder());
            var t1 = new Game.GameEngine.Engine(maps);

            t1.Start();


            Console.WriteLine("All Map started");
        }
    }
}
