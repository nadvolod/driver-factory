using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace Fluent.Tests.Unit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RemoteWebDriver_Instantiated_Returns()
        {
            var factory = new RemoteWebDriverFactory();
            factory.Should().NotBeNull();
        }

        [TestMethod]
        public void RemoteWebDriver_Instantiated_SetsBrowserOptions()
        {
            var factory = new RemoteWebDriverFactory();
            factory.BrowserOptions.Should().NotBeNull();
        }

        [TestMethod]
        public void RemoteWebDriver_Instantiated_SetsBrowserOptionsToChrome()
        {
            var factory = new RemoteWebDriverFactory();
            factory.BrowserOptions.Should().BeOfType<ChromeOptions>();
        }
    }
}
