using AbstractFactory.Template;

namespace AbstractFactory.Letter.Content
{
    class EnContent : IContent
    {
        public string Get()
        {
            return Contents.EnContent;
        }
    }
}
