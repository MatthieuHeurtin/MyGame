using System;

namespace MyGame.Game.GraphicElements.MapCells
{
    public class CellViewModel : ICellViewModel
    {
        private string _spriteImagePath;

        public string SpriteImagePath { get { return _spriteImagePath; } }

        public void SetSprite(string spriteName)
        {
            _spriteImagePath = String.Concat("./../Characters/ressources/", spriteName);
        }
    }
}
