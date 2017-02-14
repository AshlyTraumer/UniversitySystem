using AbstractFactory.Template;

namespace AbstractFactory.Letter.Header
{
    class RuHeader : IHeader
    {
        public string Get(string name)
        {
            return $"{Headers.RuHello}{name}";
        }
    }
}
