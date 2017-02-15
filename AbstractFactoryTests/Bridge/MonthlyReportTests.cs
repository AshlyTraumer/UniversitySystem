using Microsoft.VisualStudio.TestTools.UnitTesting;
using AbstractFactory.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Bridge.Tests
{
    [TestClass()]
    public class MonthlyReportTests
    {
        [TestMethod()]
        public void MakeReportTest()
        {
            var reports = new List<IBridgeReport>
            {
                new AnnualReport(new EnLanguage()),
                new AnnualReport(new RuLanguage()),
                new MonthlyReport(new EnLanguage()),
                new MonthlyReport(new RuLanguage())
            };

            var reportString = reports.Select(report => report.MakeReport()).ToList();

            var reportsOk = new List<string>
            {
                "Type: AnnualReport, Language: English",
                "Type: AnnualReport, Language: Russian",
                "Type: MonthlyReport, Language: English",
                "Type: MonthlyReport, Language: Russian"
            };

            Assert.IsTrue(reportString.SequenceEqual(reportsOk));
        }
    }
}