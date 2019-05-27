using DriverFactory.Tests.SauceDriverFactory.Concrete;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DriverFactory.Tests.SauceDriverFactory.Tests
{
    [TestClass]
    public class WebDriverFactoryTests
    {
        private RemoteWebDriverFactory _factory;

        [TestInitialize]
        public void Setup()
        {
            _factory = new RemoteWebDriverFactory();
        }
        [TestMethod]
        public void ItExists()
        {
            _factory.Should().NotBeNull();
        }

        [TestMethod]
        public void ItReturnsRemoteChromeFromDefaultConstructor()
        {
            var driver = _factory.CreateDriver();
            driver.Should().BeOfType<RemoteChrome>();
        }

        [TestMethod]
        public void ItReturnsLinuxFromDefaultConstructor()
        {
            var driver = _factory.CreateDriver();
            _factory.Session.Os.Should().Be("Linux");
        }

        [TestMethod]
        public void ItReturnsLatestBrowserFromDefaultConstructor()
        {
            var driver = _factory.CreateDriver();
            _factory.Session.BrowserVersion.Should().Be("latest");
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
        public string BrowserVersion { get; set; } = "latest";
    }
}
