using AbstractFactory.Template;

namespace AbstractFactory.Letter.Header
{
    class EnHeader : IHeader
    {
        public string Get(string name)
        {
            return string.Concat(Headers.EnHello,name);
        }
    }
}
