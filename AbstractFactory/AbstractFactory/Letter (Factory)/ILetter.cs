using AbstractFactory.Letter.Content;
using AbstractFactory.Letter.Footer;
using AbstractFactory.Letter.Header;


namespace AbstractFactory.Letter
{
    public interface ILetter
    {
        IHeader MakeHeader();
        IContent MakeContent();
        IFooter MakeFooter();
    }
}
