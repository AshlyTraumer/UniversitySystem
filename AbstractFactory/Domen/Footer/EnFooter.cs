using System;
using AbstractFactory.Template;

namespace AbstractFactory.Letter.Footer
{
    class EnFooter : IFooter
    {
        public string Get(DateTime date)
        {
            return $"{Footers.EnFooter}, {date.ToString("yyyy-MM-dd")}";
        }
    }
}
