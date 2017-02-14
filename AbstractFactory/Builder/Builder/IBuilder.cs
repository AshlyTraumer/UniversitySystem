using System;

namespace AbstractFactory.Builder
{
    public interface IBuilder
    {
        IBuilder SetHeader(string name);
        IBuilder SetContent();
        IBuilder SetFooter(DateTime date);
        AbstractContent Build();

    }
}
