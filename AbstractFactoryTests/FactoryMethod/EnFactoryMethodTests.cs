using System;
using System.Collections.Generic;
using System.Linq;
using AbstractFactory.Template;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AbstractFactory.FactoryMethod.Tests
{
    [TestClass()]
    public class EnFactoryMethodTests
    {
        [TestMethod()]
        public void CreateTest()
        {
           /* IFactoryMethod[] factories = {new EnFactoryMethod(), new RuFactoryMethod()};
            var test = new List<string>();

            foreach (var factory in factories)
            {
                test.Add(factory.Create().Get());
            }

            var okTest = new List<string>() {Contents.EnContent, Contents.RuContent};
            Assert.IsTrue(test.SequenceEqual(okTest));*/
           // var action = FactoryMethod.Success(); //bool
        }
    }
}