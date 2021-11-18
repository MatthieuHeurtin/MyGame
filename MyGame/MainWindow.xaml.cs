using MyGame.Game.Map.Maps;
using MyGame.Ressources;
using System;
using System.Windows;
using System.Windows.Media;
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
            frenchFlag.ImageSource = new BitmapImage(new Uri(string.Concat(RessourcesManager.MenuPath, "french_flag.png"), UriKind.Relative));
            britishFlag.ImageSource = new BitmapImage(new Uri(string.Concat(RessourcesManager.MenuPath, "british_flag.png"), UriKind.Relative));


            StartBackgroundMusic();
            //    t1.Start();

            // var t2 = new Game.GameEngine.Engine(new M1_VillageBorder());

            //t2.Start();

            Console.WriteLine("All Map started");
        }


        private MediaPlayer _backgroundMusic = new MediaPlayer();


        public void StartBackgroundMusic()
        {
            _backgroundMusic.Open(new Uri(string.Concat(RessourcesManager.MenuPath, "main_menu_music.wav"), UriKind.Relative));
            _backgroundMusic.MediaEnded += new EventHandler(BackgroundMusic_Ended);
            _backgroundMusic.Play();
        }

        private void BackgroundMusic_Ended(object sender, EventArgs e)
        {
            _backgroundMusic.Position = TimeSpan.Zero;
            _backgroundMusic.Play();
        }


        public void start_new_game(object sender, RoutedEventArgs e)
        {
            var t1 = new Game.GameEngine.Engine(new S0_FirstStory());
            t1.Start();
            _backgroundMusic.Close();
            this.Close();
        }

    }
}
