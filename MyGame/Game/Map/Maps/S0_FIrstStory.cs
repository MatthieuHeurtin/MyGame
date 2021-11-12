using System.Collections.Generic;

namespace MyGame.Game.Map.Maps
{
    public class S0_FirstStory : IStory
    {
        public string Title = "Main story";
        private IDictionary<string, IMap> _storyMaps;

        public IDictionary<string, IMap> StoryMaps { get { return _storyMaps; } }


        public S0_FirstStory()
        {
            _storyMaps = new Dictionary<string, IMap>();

            var m0 = new M0_Village();
            _storyMaps.Add(m0.Key, m0);


            var m1 = new M1_VillageBorder();
            _storyMaps.Add(m1.Key, m1);


        }
    }
}
