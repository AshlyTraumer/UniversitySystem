using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AbstractFactory.Prototype.Tests
{
    [TestClass()]
    public class ContentCloneTests
    {
        [TestMethod()]
        public void CloneTest()
        {
            var headerClone = new HeaderClone();
            headerClone.SetHeader();
            var newHeaderClone = headerClone.CustomClone() as HeaderClone;

            Assert.AreEqual(headerClone.GetHeader(), newHeaderClone.GetHeader());
            Assert.IsFalse(ReferenceEquals(headerClone, newHeaderClone));
        }
    }
}