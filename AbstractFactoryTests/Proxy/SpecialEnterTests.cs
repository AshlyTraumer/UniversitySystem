using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AbstractFactory.Proxy.Tests
{
    [TestClass()]
    public class SpecialEnterTests
    {
        [TestMethod()]
        public void SpecialEnterTest()
        {
            var name = "Ivan";
            
            // Real Object.
            var general = new GeneralEnter(name, false);

            // Proxy. 
            var special = new SpecialEnter(name, false);

            Assert.AreNotEqual(general.GetEnterByPermission(), special.GetEnterByPermission());
        }
    }
}