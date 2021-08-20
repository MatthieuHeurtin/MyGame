namespace MyGame.Game.MapCells
{
    public interface IMapCell
    {
        CaseTypes Type { get; }
    }


    public enum CaseTypes
    {
        FOREST,
        DESERT,
        GRASS,
        PATH
    }
}
