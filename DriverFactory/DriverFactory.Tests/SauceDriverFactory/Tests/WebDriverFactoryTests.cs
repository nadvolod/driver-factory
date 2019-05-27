using DriverFactory.Tests.SauceDriverFactory.Concrete;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DriverFactory.Tests.SauceDriverFactory.Tests
{
    [TestClass]
    public class WebDriverFactoryTests
    {
        private RemoteWebDriverFactory factory;

        [TestInitialize]
        public void Setup()
        {
            factory = new RemoteWebDriverFactory();
        }
        [TestMethod]
        public void ItExists()
        {
            factory.Should().NotBeNull();
        }

        [TestMethod]
        public void ItReturnsRemoteChromeFromDefaultConstructor()
        {
            var driver = factory.CreateDriver();
            driver.Should().BeOfType<RemoteChrome>();
        }

        [TestMethod]
        public void ItReturnsLinuxFromDefaultConstructor()
        {
            var driver = factory.CreateDriver();
            factory.Session.Os.Should().Be("Linux");
        }
    }

    public class RemoteWebDriverFactory
    {
        public RemoteDriver CreateDriver()
        {
            return new RemoteChrome();
        }

        public SauceSession Session => new SauceSession();
    }

    public class SauceSession
    {
        public string Os { get; set; } = "Linux";
    }
}
