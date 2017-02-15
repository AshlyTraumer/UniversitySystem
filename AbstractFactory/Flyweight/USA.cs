namespace AbstractFactory.Flyweight
{
    public class Usa : Country
    {
        public Usa()
        {
            Language = "English";
        }

        public override string Speak()
        {
            return $"USA: Speak into {Language}";
        }
    }
}
