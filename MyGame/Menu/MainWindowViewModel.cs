using MyGame.Game.Map.Maps;
using MyGame.Langages;
using MyGame.Ressources;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace MyGame.Menu
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        public string NewGame { get; set; }
        public string LoadGame { get; set; }
        public string Options { get; set; }
        public string FrenchFlag { get; set; }
        public string EnglishFlag { get; set; }
        public string CirclePath { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private MediaPlayer _backgroundMusic = new MediaPlayer();

        public bool IsNotGameRunning { get; set; }

        private ICommand _languageSelected;
        public ICommand LanguageSelected
        {
            get
            {
                return (_languageSelected ?? (_languageSelected = new CommandRelay(UpdateLanguage, true)));
            }
        }

        private ICommand _newGame;
        public ICommand NewGameAction
        {
            get
            {
                return (_newGame ?? (_newGame = new CommandRelay(StartNewGame, true)));
            }
        }

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

        private void StartNewGame(string obj)
        {
            using (var t1 = new Game.GameEngine.Engine(new S0_FirstStory()))
            {
                t1.Start();
                IsNotGameRunning = false;
                NotifyPropertyChanged(nameof(IsNotGameRunning));
            }

        }

        private void UpdateLanguage(string language)
        {
            LangagesManager.Set(language);
            NewGame = LangagesManager.Get().Dico[(nameof(NewGame))];
            LoadGame = LangagesManager.Get().Dico[(nameof(LoadGame))];
            Options = LangagesManager.Get().Dico[(nameof(Options))];
            NotifyPropertyChanged(nameof(NewGame));
            NotifyPropertyChanged(nameof(LoadGame));
            NotifyPropertyChanged(nameof(Options));
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindowViewModel()
        {
            UpdateLanguage("french");
            FrenchFlag = string.Concat(RessourcesManager.MenuPath, "french_flag.png");
            EnglishFlag = string.Concat(RessourcesManager.MenuPath, "british_flag.png");
            CirclePath = string.Concat(RessourcesManager.MenuPath, "circle.gif");
            IsNotGameRunning = true;
  StartBackgroundMusic();
        }
    }
}
