using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AbstractFactory.LazyInitialization.Tests
{
    [TestClass()]
    public class CustomCacheTests
    {
        [TestMethod()]
        public void GetDataByIdTest()
        {
            var custom = new CustomCache();
            var test = custom.GetDataById(5);

            Assert.IsTrue(!custom._lazy.IsValueCreated);
            Assert.IsTrue(test.Id == 5 && test.Title == null);
        }

        [TestMethod()]
        public void GetDataByIdLazyTest()
        {
            var custom = new CustomCache();
            var test = custom.GetDataByIdLazy(5);

            Assert.IsTrue(custom._lazy.IsValueCreated);
            Assert.IsTrue(test.Id == 5 && test.Title == null);
        }
    }
}