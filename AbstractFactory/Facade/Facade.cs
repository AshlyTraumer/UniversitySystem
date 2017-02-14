using System;
using AbstractFactory.Letter.Content;
using AbstractFactory.Letter.Footer;
using AbstractFactory.Letter.Header;

namespace AbstractFactory.Facade
{
    public class Facade
    {
        private IHeader _header;
        private IContent _content;
        private IFooter _footer;
        private readonly string _name;
        private readonly DateTime _date;

        public Facade(string name, DateTime date )
        {
            _name = name;
            _date = date;
        }

        public string GetEnReport()
        {
            _header = new EnHeader();
            _content = new EnContent();
            _footer = new EnFooter();

            return string.Join(Environment.NewLine, new string[]
            {
                _header.Get(_name),
                _content.Get(),
                _footer.Get(_date)
            });
        }

        public string GetRuReport()
        {
            _header = new RuHeader();
            _content = new RuContent();
            _footer = new RuFooter();

            return string.Join(Environment.NewLine, new string[]
            {
                _header.Get(_name),
                _content.Get(),
                _footer.Get(_date)
            });

        }
    }
}
