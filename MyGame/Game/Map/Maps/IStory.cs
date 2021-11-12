using System.Collections.Generic;

namespace MyGame.Game.Map.Maps
{
    public interface IStory
    {
        IDictionary<string, IMap> StoryMaps { get; }
    }
}