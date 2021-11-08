namespace MyGame.Game.MapCells.GraphicMapCell
{
    public class GuiMapCellDataContext : IGuiMapCellDataContext
    {
        public IGuiMapCellViewModel GuiMapCellViewModel { get; }

        public GuiMapCellDataContext()
        {
            GuiMapCellViewModel = new GuiMapCellViewModel();
        }
    }
}
