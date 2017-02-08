using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac.Extras.Moq;
using Castle.Components.DictionaryAdapter;
using ClassLibrary;
using Moq;
using UniversitySystem.Core.Csvs;
using UniversitySystem.Core.Csvs.Interfaces;

namespace UniversitySystem.Controllers.Tests
{
    [TestClass()]
    public class ZipControllerTests
    {
        [TestMethod()]
        public void Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var test = new List<Departament>
                {
                    new Departament()
                    {
                        Title = "qwe",
                        Id = 1
                    }
                };

                mock.Mock<ICommonRepository>().Setup(x => x.GetAll<Departament>()).Returns(test);

                var q = new CsvWrapper(mock.Mock<ICommonRepository>().Object, new CsvHelper(), new CsvZipper());
                var w = q.Export();

               mock.Mock<ICommonRepository>().Setup(x => x.AddOrUpdate(test));
                var qq = new CsvWrapper(mock.Mock<ICommonRepository>().Object, new CsvHelper(), new CsvZipper());
                qq.Import(w);

                mock.Mock<ICommonRepository>().Verify(x => x.AddOrUpdate(test));

            }
        }






    }
}