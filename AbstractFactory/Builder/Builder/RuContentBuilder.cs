using System;
using AbstractFactory.Template;


namespace AbstractFactory.Builder.Builder
{
    public class RuContentBuilder : IBuilder
    {
        private AbstractContent _content;

        public RuContentBuilder()
        {
            _content = new AbstractContent();
        }

        public AbstractContent Build()
        {
            return _content;
        }

        public IBuilder SetContent()
        {
            _content.Content = Contents.RuContent;
            return this;
        }

        public IBuilder SetFooter(DateTime date)
        {
            _content.Footer = $"{Footers.RuFooter}, {date.ToString("yyyy-MM-dd")}";
            return this;
        }

        public IBuilder SetHeader(string name)
        {
            _content.Header = $"{Headers.RuHello}{name}";
            return this;
        }
    }
}
