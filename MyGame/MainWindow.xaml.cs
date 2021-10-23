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

            var t1 = new Game.GameEngine.Engine(new M0_Village());

            t1.Start();

         //   var t2 = new Game.GameEngine.Engine(new M1_VillageBorder());

           //t2.Start();

            Console.WriteLine("All Map started");
        }
    }
}
