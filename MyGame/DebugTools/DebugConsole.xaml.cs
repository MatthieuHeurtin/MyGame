using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using MyGame.Game.Character.Characters;
using MyGame.Game.Characters.Character;
using MyGame.Game.GameEngine.Events.Event;
using MyGame.Game.MapElements;

namespace MyGame.DebugTools
{
    /// <summary>
    /// Interaction logic for Console.xaml
    /// </summary>
    public partial class DebugConsole : Window
    {
        public ObservableCollection<DebugConsoleElement> Elements { get; set; }

        public DebugConsole()
        {
            InitializeComponent();
            DataContext = this;
            Elements = new ObservableCollection<DebugConsoleElement>();
        }
        public void AppendText(string text)
        {
            DebugConsoleElement dce = new DebugConsoleElement
            {
                Type = "action",
                Name = text,
                Color = GetColorFromType("action")
            };


            Dispatcher.Invoke(() =>
            {
                Elements.Add(dce);
            });




        }

        public void AppendElement(KeyValuePair<string, IMapElement> element)
        {
            DebugConsoleElement dce = new DebugConsoleElement
            {
                Key = element.Key,
                Name = element.Value.Key,
                Description = element.Value.ToString(),
                Routine = (element.Value as ICharacter)?.Routine?.ToString(),
                Type = GetType(element.Value),
                Color = GetColorFromType(GetType(element.Value))
            };

            Dispatcher.Invoke(() =>
            {
                Elements.Add(dce);
            });
        }



        private string GetColorFromType(string type)
        {
            switch (type)
            {
                case "npc event":
                    return "Blue";
                case "npc":
                    return "Blue";
                case "player":
                    return "White";
                case "action":
                    return "red";
                default:
                    return string.Empty;
            }

        }

        private string GetType(IMapElement element)
        {

            if (element is NonPlayableCharacter)
                return "npc";
            else if (element is PlayableCharacter)
                return "player";
            else
                return string.Empty;


        }

        internal void AddEvent(MoveEvent ev, string direction, string key)
        {
            DebugConsoleElement dce = new DebugConsoleElement
            {
                Key = key,
                Name = key,
                Description = direction,
                Type = "npc event",
                Color = GetColorFromType("npc event")
            };

            Dispatcher.Invoke(() =>
            {
                Elements.Add(dce);
            });
        }

        private void ListView_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}
