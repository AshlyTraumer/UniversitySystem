using System;

namespace AbstractFactory.Builder
{
    public class AbstractContent
    {
        public string Content { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }

        public string GetResult()
        {
            var str = Content;
            if (Header != null)
                str = $"{Header}{Environment.NewLine}{str}";
            if (Footer != null)
                str = $"{str}{Environment.NewLine}{Footer}";

            return str;
        }
    }
}
