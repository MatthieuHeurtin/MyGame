namespace MyGame.Game.GraphicElements.MapCells.Common
{
    public class CellDataContext : ICellDataContext
    {
        public ICellViewModel CellViewModel { get; }

        public System.Windows.Media.ImageBrush r;

        public CellDataContext()
        {
            CellViewModel = new CellViewModel();
        }
    }
}
