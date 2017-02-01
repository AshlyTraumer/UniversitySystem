using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversitySystem.Core.Csvs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace UniversitySystem.Core.Csvs.Tests
{
    [TestClass()]
    public class CsvHelperTests
    {
        [TestMethod()]
        public void ExportTest()
        {
            var list = new List<Subject>
            {
                new Subject
                {
                    Title = "t1",
                    Id = 1,
                    Form = "f1"
                },
                new Subject
                {
                    Title = "t2",
                    Id = 2,
                    Form = "f2"
                }
            };

            var file = new CsvHelper().Export(list);
            new CsvZipper().Zip(new List<CsvFile> { file });
            Assert.Fail();
        }
    }
}