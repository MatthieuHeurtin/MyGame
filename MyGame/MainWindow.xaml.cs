using MyGame.Game.Map.Maps;
using System;
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


            var t1 = new Game.GameEngine.Engine(new M0_Village(), true);

            t1.Start();

            //var t = new Game.GameEngine.Engine(new M1_VillageBorder());

            //t.Start();

            //var p = new Game.GameEngine.Engine(new M1_StartingMap());

            //p.Start();

            Console.WriteLine("All Map started");
        }
    }
}
