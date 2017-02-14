using AbstractFactory.Letter.Content;
using AbstractFactory.Letter.Footer;
using AbstractFactory.Letter.Header;

namespace AbstractFactory.Letter
{
    public class RuLetter : ILetter
    {
        public IHeader MakeHeader()
        {
            return new RuHeader();
        }

        public IContent MakeContent()
        {
            return new RuContent();
        }

        public IFooter MakeFooter()
        {
            return new RuFooter();
        }
    }
}
