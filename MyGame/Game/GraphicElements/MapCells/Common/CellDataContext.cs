namespace MyGame.Game.GraphicElements.MapCells.Common
{
    public class CellDataContext : ICellDataContext
    {
        public ICellViewModel CellViewModel { get; }


        public CellDataContext()
        {
            CellViewModel = new CellViewModel();
        }
    }
}
