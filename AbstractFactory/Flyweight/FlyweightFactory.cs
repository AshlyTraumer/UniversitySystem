using System.Collections.Generic;
using System.IO;

namespace AbstractFactory.Flyweight
{
    public class FlyweightFactory
    {
        private Dictionary<string, Country> flyweights;

        // Constructor
        public FlyweightFactory()
        {
            flyweights = new Dictionary<string, Country>
            {
                {"USA", new Usa()},
                {"Belarus", new Belarus()}
            };

        }
        
        public Country GetCountry(string key)
        {
            if (flyweights.ContainsKey(key))
            {
                return ((Country)flyweights[key]);
            }
            else
            {
               Country country;

                switch (key)
                {
                    case "USA":
                        country = new Usa();
                        break;

                    case "Belarus":
                        country = new Belarus();
                        break;

                    default:
                        throw new InvalidDataException();
                }

                flyweights.Add(key, country);
                return country;
            }
        }
    }
}
