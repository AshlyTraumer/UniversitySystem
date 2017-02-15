namespace AbstractFactory.Flyweight
{
    public class Company
    {
        private string _title;
        private readonly Country _country;
        private int _count;

        public Company(string title, Country country, int count)
        {
            _title = title;
            _country = country;
            _count = count;
        }

        public Country GetCountry()
        {
            return _country;
        }
    }
}
