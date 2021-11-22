namespace MyGame.Langages
{
    public class LangagesManager
    {
        private static ILangage _currentLangage;
        public static ILangage Get()
        {
            return _currentLangage;
        }
        public static void Set(string language)
        {
            switch (language)
            {
                case "french":
                    _currentLangage = new French();
                    break;
                case "english":
                    _currentLangage = new English();
                    break;
                default:
                    break;
            }
        }
    }
}
