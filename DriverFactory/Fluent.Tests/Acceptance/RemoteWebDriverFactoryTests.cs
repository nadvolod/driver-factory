using Fluent.Tests.Unit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace Fluent.Tests.Acceptance
{
    [TestClass]
    public class RemoteWebDriverFactoryTests
    {
        public IWebDriver _driver;
        [TestCleanup]
        public void CleanUp()
        {
            _driver?.Quit();
        }

        [TestMethod]
        public void ShouldCreateDefaultDriverConfiguration()
        {
            var _driverFactory = new RemoteWebDriverFactory();
            _driver =  _driverFactory.WithBrowserCaps().GetInstance();
            _driver.GetType();
            //_driverFactory.Os.Should().Be("Windows 10");
            //_driverFactory.Browser.Should().Be(BrowserType.Chrome);
            //_driverFactory.BrowserVersion.Should().Be("latest");
        }
    }
}
