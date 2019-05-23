using DriverFactory.Tests.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace DriverFactory.Tests.Acceptance
{
    [TestClass]
    public class WebDriverFactoryAcceptanceTests : BaseTest
    {
        [TestCleanup]
        public void CleanUp()
        {
            _driver?.Quit();
        }

        [TestMethod]
        [TestCategory("Acceptance")]
        public void ShouldReturnRemoteDriver()
        {
            _sauceCaps = new SauceCaps
            {
                Browser = BrowserType.Chrome,
                Os = "Windows 10"
            };
            _driverFactory = new WebDriverFactory(_sauceCaps);

            _driver = _driverFactory.Create();
            _driver.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldCreateDefaultDriverConfiguration()
        {
            _driverFactory = new WebDriverFactory();
            _driver =  _driverFactory.Create();
            _driverFactory.Os.Should().Be("Windows 10");
            _driverFactory.Browser.Should().Be(BrowserType.Chrome);
            _driverFactory.BrowserVersion.Should().Be("latest");
        }
    }
}
