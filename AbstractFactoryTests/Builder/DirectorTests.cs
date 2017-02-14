using System;
using AbstractFactory.Builder.Builder;
using AbstractFactory.Template;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AbstractFactory.Builder.Tests
{
    [TestClass()]
    public class DirectorTests
    {
        [TestMethod()]
        public void ConstuctTest()
        {
            var director = new Director();
            var list = director.Constuct(new EnContentBuilder(), "Helga", new DateTime(2017, 02, 13)).GetResult();
            
            var okList =$"{ Headers.EnHello}Helga{ Environment.NewLine }{ Contents.EnContent}{ Environment.NewLine }{Footers.EnFooter}2017-02-13";

            Assert.AreEqual(list, okList);
        }

        [TestMethod()]
        public void ConstuctTest2()
        {
            var director = new Director();
            var list = director.Constuct(new RuContentBuilder(), "Helga").GetResult();

            var okList = $"{ Headers.RuHello}Helga{ Environment.NewLine }{ Contents.RuContent}";


            Assert.AreEqual(list, okList);
        }


    }
}