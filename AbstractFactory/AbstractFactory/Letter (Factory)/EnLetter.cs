using AbstractFactory.Letter.Content;
using AbstractFactory.Letter.Footer;
using AbstractFactory.Letter.Header;

namespace AbstractFactory.Letter
{
    public class EnLetter : ILetter
    {
        public IHeader MakeHeader()
        {
            return new EnHeader();
        }

        public IContent MakeContent()
        {
            return new EnContent();
        }

        public IFooter MakeFooter()
        {
           return new EnFooter();
        }
    }
}
