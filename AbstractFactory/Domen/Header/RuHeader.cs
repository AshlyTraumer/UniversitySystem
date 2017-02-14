using AbstractFactory.Template;

namespace AbstractFactory.Letter.Header
{
    class RuHeader : IHeader
    {
        public string Get(string name)
        {
            return string.Concat(Headers.RuHello, name);
        }
    }
}
