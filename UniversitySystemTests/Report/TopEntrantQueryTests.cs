using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace UniversitySystem.Report.Tests
{
    [TestClass()]
    public class TopEntrantQueryTests
    {
        [TestMethod()]
        public void GetTest()
        {
            RepositoryContext context = new RepositoryContext();
            var list = new TopEntrantQuery(context).Get();
            Assert.Fail();
        }
    }
}