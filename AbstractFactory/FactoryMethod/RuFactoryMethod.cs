using AbstractFactory.Letter.Content;

namespace AbstractFactory.FactoryMethod
{
    public class RuFactoryMethod : IFactoryMethod
    {
        public IContent Create()
        {
            return new RuContent();
        }
    }
}
