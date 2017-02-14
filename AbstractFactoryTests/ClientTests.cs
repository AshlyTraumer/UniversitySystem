using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AbstractFactory.Letter;
using AbstractFactory.Template;


namespace AbstractFactory.Tests
{
    [TestClass()]
    public class ClientTests
    {
        

        [TestMethod()]
        public void MakeListEnTest()
        {
            var list = new Client(new EnLetter())
                .MakeList("Helga", new DateTime(2017,02,13));

            var okList = $"{ Headers.EnHello}Helga{ Environment.NewLine }{ Contents.EnContent}{ Environment.NewLine }{Footers.EnFooter},2017-02-13";


            Assert.AreEqual(list, okList);
        }

        [TestMethod()]
        public void MakeListRuTest()
        {
            var list = new Client(new RuLetter())
                .MakeList("Helga", new DateTime(2017, 02, 13));

            var okList = $"{ Headers.RuHello}Helga{ Environment.NewLine }{ Contents.RuContent}{ Environment.NewLine }{Footers.RuFooter},2017-02-13";


            Assert.AreEqual(list, okList);
        }
    }
}