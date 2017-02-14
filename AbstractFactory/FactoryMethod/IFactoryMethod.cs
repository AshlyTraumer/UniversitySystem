using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Letter.Content;

namespace AbstractFactory.FactoryMethod
{
    public interface IFactoryMethod
    {
        IContent Create();
    }
}
