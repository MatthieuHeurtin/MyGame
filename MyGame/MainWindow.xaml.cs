using MyGame.Menu;
using MyGame.Ressources;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

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
            CellBackground.ImageSource = new BitmapImage(new Uri(string.Concat(RessourcesManager.MenuPath, "menu_background.jpg"), UriKind.Relative));
            
            DataContext = new MainWindowViewModel();


        }




      




    }
}
