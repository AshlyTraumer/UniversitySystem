using System;
using AbstractFactory.Template;

namespace AbstractFactory.Letter.Footer
{
    class RuFooter : IFooter
    {
        public string Get(DateTime date)
        {
            return $"{Footers.RuFooter} {date.ToString("dd.MM.yyyy")}";
        }
    }
}
