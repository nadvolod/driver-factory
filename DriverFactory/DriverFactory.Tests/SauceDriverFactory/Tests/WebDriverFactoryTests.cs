using DriverFactory.Tests.SauceDriverFactory.Concrete;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DriverFactory.Tests.SauceDriverFactory.Tests
{
    [TestClass]
    public class WebDriverFactoryTests
    {
        [TestMethod]
        public void ItExists()
        {
            var factory = new WebDriverFactory();
            factory.Should().NotBeNull();
        }

        [TestMethod]
        public void ItReturnsRemoteChromeWithDefaultConstructor()
        {
            var factory = new WebDriverFactory();
            var driver = factory.CreateDriver();
            driver.Should().BeOfType<RemoteChrome>();
        }
    }

    public class WebDriverFactory
    {
        public RemoteDriver CreateDriver()
        {
            return new RemoteChrome();
        }
    }
}
