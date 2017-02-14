using System;
using AbstractFactory.Letter;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Language Name Year Month Day");
            var lang = Console.ReadLine()?.Split(' ');
            ILetter factory;
            switch (lang?[0])
            {
                case "en":
                    factory = new EnLetter();
                    break;

                case "ru":
                    factory = new RuLetter();
                    break;

                default:
                    throw new ArgumentNullException();
            }

            Console.WriteLine(new Client(factory)
                        .MakeList(lang[1], new DateTime(
                            int.Parse(lang[2]),
                            int.Parse(lang[3]),
                            int.Parse(lang[4])
                            )));

            Console.ReadKey();
        }
    }
}
