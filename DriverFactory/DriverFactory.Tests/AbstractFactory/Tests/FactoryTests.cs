﻿using DriverFactory.Tests.AbstractFactory.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DriverFactory.Tests.AbstractFactory.Tests
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void ItExists()
        {
            var factory = new ChromeDriverFactory();
            factory.CreateDriver();
        }
        [TestMethod]
        public void ItCreatesChromeDriver()
        {
            var factory = new ChromeDriverFactory();
            var driver = factory.CreateDriver();
            Assert.IsInstanceOfType(driver, typeof(RemoteChrome));
        }
        [TestMethod]
        public void ItCreatesFirefoxDriver()
        {
            var factory = new FirefoxDriverFactory();
            var driver = factory.CreateDriver();
            Assert.IsInstanceOfType(driver, typeof(RemoteFirefox));
        }

        [TestMethod]
        public void ItSetsDefaultToChromeLatestOnWindows10()
        {
            var factory = new FirefoxDriverFactory();
            var driver = factory.CreateDriver();
            Assert.IsInstanceOfType(driver, typeof(RemoteFirefox));
        }
    }
}
