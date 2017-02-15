namespace AbstractFactory.Bridge
{
    public class RuLanguage : ILanguage
    {
        public string Make()
        {
            return "Language: Russian";
        }
    }
}
