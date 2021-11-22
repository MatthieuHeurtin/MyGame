using MyGame.Langages;
using MyGame.Ressources;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MyGame.Menu
{
    public class MainWindowViewModel :INotifyPropertyChanged
    {

        public string NewGame { get; set; }
        public string LoadGame { get; set; }
        public string Options { get; set; }
        public string FrenchFlag { get; set; }
        public string EnglishFlag { get; set; }

        private ICommand _languageSelected;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LanguageSelected
        {
            get
            {
                return (_languageSelected ?? (_languageSelected = new CommandRelay(UpdateLanguage, true)));
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
        }
    }
}
