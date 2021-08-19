namespace MyGame.Game.GraphicElements.MapCells
{
    public interface IMapCell
    {
        CaseTypes Type { get; }
        bool HasCharacter { get; set; }

    }


    public enum CaseTypes
    {
        FOREST,
        DESERT,
        GRASS,
        PATH
    }
}
