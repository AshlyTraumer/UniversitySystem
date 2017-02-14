using AbstractFactory.Letter.Content;

namespace AbstractFactory.FactoryMethod
{
    public class EnFactoryMethod : IFactoryMethod
    {
        public IContent Create()
        {
            return new EnContent();
        }
    }
}
