using Microsoft.VisualStudio.TestTools.UnitTesting;
using AbstractFactory.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Singleton.Tests
{
    [TestClass()]
    public class AppConfigTests
    {
        [TestMethod()]
        public void GetInstanceTest()
        {
            var config = AppConfig.GetInstance();
            config.SetConfig("lang", "rus");

            var configNew = AppConfig.GetInstance();
            var result = configNew.GetConfigByKey("lang");

            Assert.AreEqual(result, "rus");
        }
    }
}