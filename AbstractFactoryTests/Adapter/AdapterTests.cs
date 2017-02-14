using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AbstractFactory.Adapter.Tests
{
    [TestClass()]
    public class AdapterTests
    {
        [TestMethod()]
        public void AdapterTest()
        {
            IConsoleWrite adapter = new ReportWriter("SomeReportConsole");
            adapter.Write();

            adapter = new Adapter("file.txt","SomeReportFile");
            adapter.Write();

            Assert.IsTrue(true);
        }
    }
}