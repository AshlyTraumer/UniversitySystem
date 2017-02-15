using System.Runtime.InteropServices;

namespace AbstractFactory.Flyweight
{
    public abstract class Country
    {
        public string Language { get; set; }

        public abstract string Speak();

    }
}
