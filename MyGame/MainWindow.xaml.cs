using MyGame.Game.Map.Maps;
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

            var t = new Game.GameEngine.Engine(new M0_StartingMap());

            t.Start();

            var p = new Game.GameEngine.Engine(new M1_StartingMap());

            p.Start();



        }
    }
}
