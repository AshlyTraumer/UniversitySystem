using AbstractFactory.Template;

namespace AbstractFactory.Letter.Content
{
    class RuContent : IContent
    {
        public string Get()
        {
            return Contents.RuContent;
        }
    }
}
