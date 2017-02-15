namespace AbstractFactory.Flyweight
{
    public class Belarus : Country
    {
        public Belarus()
        {
            Language = "Russian";
        }

        public override string Speak()
        {
            return $"Belarus: Speak into {Language}";
        }

    }
}
