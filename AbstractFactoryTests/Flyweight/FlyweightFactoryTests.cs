using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AbstractFactory.Flyweight.Tests
{
    [TestClass()]
    public class FlyweightFactoryTests
    {
        [TestMethod()]
        public void GetCountryTest()
        {
            var companyList = new List<Company>();
            var factory = new FlyweightFactory();
            companyList.Add(new Company("Company1", factory.GetCountry("USA"), 100));
            companyList.Add(new Company("Company2", factory.GetCountry("Belarus"), 60));
            companyList.Add(new Company("Company3", factory.GetCountry("Belarus"), 35));

            Assert.AreEqual(companyList[1].GetCountry(), companyList[2].GetCountry());
        }
    }
}