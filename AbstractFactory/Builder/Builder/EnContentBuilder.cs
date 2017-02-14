using AbstractFactory.Template;
using System;

namespace AbstractFactory.Builder
{
    public class EnContentBuilder : IBuilder
    {
        private AbstractContent _content;

        public EnContentBuilder()
        {
            _content = new AbstractContent();
        }

        public AbstractContent Build()
        {
            return _content;
        }

        public IBuilder SetContent()
        {
            _content.Content = Contents.EnContent;
            return this;
        }

        public IBuilder SetFooter(DateTime date)
        {
            _content.Footer = $"{Footers.EnFooter}{date.ToString("yyyy-MM-dd")}";
            return this;
        }

        public IBuilder SetHeader(string name)
        {
            _content.Header = $"{Headers.EnHello}{name}";
            return this;
        }
    }
}
