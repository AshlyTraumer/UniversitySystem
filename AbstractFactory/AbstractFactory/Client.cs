using System;
using System.Collections.Generic;
using AbstractFactory.Letter;
using AbstractFactory.Letter.Content;
using AbstractFactory.Letter.Footer;
using AbstractFactory.Letter.Header;

namespace AbstractFactory
{
    public class Client
    {
        private readonly IHeader _header;
        private readonly IContent _content;
        private readonly IFooter _footer;

        public Client(ILetter letter)
        {
            _header = letter.MakeHeader();
            _content = letter.MakeContent();
            _footer = letter.MakeFooter();
        }

        public string MakeList(string name, DateTime date)
        {
            var list = new List<string>
            {
                _header.Get(name),
                _content.Get(),
                _footer.Get(date)
            };

            return string.Join("\n", list);
        }
    }
}
