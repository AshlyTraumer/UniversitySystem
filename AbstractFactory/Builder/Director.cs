using System;

namespace AbstractFactory.Builder
{
    public class Director
    {
        public AbstractContent Constuct(IBuilder builder)
        {
            return builder
                .SetContent()
                .Build();
        }

        public AbstractContent Constuct(IBuilder builder, string name)
        {
            return builder
                .SetHeader(name)
                .SetContent()
                .Build();
        }

        public AbstractContent Constuct(IBuilder builder, string name, DateTime date)
        {
            return builder
                .SetHeader(name)
                .SetContent()
                .SetFooter(date)
                .Build();
        }
    }
}
