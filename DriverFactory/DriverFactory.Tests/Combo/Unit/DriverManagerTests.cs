using DriverFactory.Tests.Combo.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DriverFactory.Tests.Combo.Unit
{
    [TestClass]
    public class DriverManagerTests
    {
        [TestMethod]
        public void ShouldAddSauceCapabilitiesForChrome()
        {
            var mockCapabilities = new Mock<SauceCaps>();
            var stubRemoteDriver = new Mock<RemoteDriver>();

            var manager = new DriverManager(stubRemoteDriver.Object);
            manager.GetRemoteChrome(mockCapabilities.Object);
            mockCapabilities.Verify(mock => mock.GetSauceOptions());
        }
        [TestMethod]
        public void ShouldAddSauceCapabilitiesForFirefox()
        {
            var mockCapabilities = new Mock<SauceCaps>();
            var stubRemoteDriver = new Mock<RemoteDriver>();

            var manager = new DriverManager(stubRemoteDriver.Object);
            manager.GetRemoteFirefox(mockCapabilities.Object);
            mockCapabilities.Verify(mock => mock.GetSauceOptions());
        }

        [TestMethod]
        public void ShouldReturnFirefoxOptions()
        {
            var sauceCaps = new SauceCaps
            {
                Browser = BrowserType.Firefox
            };
            var stubDriver = new Mock<IRemoteDriver>();

            var driverManager = new DriverManager(stubDriver.Object);
            driverManager.GetRemoteFirefox(sauceCaps);
            driverManager.FirefoxOptions.Should().NotBeNull();
            driverManager.FirefoxOptions.GetType().Name.Should().Be("FirefoxOptions");
        }

        [TestMethod]
        public void ShouldNotReturnFirefoxOptions()
        {
            var stubCaps = new Mock<SauceCaps>();
            var stubDriver = new Mock<IRemoteDriver>();

            var driverManager = new DriverManager(stubDriver.Object);
            driverManager.GetRemoteChrome(stubCaps.Object);
            driverManager.FirefoxOptions.Should().BeNull();
        }
    }
}
