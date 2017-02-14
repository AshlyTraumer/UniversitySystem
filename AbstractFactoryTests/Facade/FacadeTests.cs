using Microsoft.VisualStudio.TestTools.UnitTesting;
using AbstractFactory.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Template;

namespace AbstractFactory.Facade.Tests
{
    [TestClass()]
    public class FacadeTests
    {
        [TestMethod()]
        public void FacadeTest()
        {
            var facade = new Facade("Ivan", new DateTime(2017,02,14));
            var enReport = facade.GetEnReport();
            var ruReport = facade.GetRuReport();

            var ruOk = string.Join(Environment.NewLine, new string []
            {
                $"{Headers.RuHello}Ivan",
                $"{Contents.RuContent}",
                $"{Footers.RuFooter} 14.02.2017"
            });
             
            var enOk = string.Join(Environment.NewLine, new string[]
            {
                $"{Headers.EnHello}Ivan",
                $"{Contents.EnContent}",
                $"{Footers.EnFooter} 2017-02-14"
            });

            Assert.AreEqual(enReport, enOk);
            Assert.AreEqual(ruReport, ruOk);
        }
    }
}