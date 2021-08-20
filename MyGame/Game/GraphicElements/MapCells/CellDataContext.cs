namespace MyGame.Game.GraphicElements.MapCells
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
