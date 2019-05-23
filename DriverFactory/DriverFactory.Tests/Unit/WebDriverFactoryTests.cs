using System;
using DriverFactory.Tests.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DriverFactory.Tests.Unit
{
    [TestClass]
    public class WebDriverFactoryTests : BaseTest
    {
        [TestInitialize]
        public void Setup()
        {
            _sauceCaps = new SauceCaps
            {
                Browser = It.IsAny<BrowserType>(),
                Os = It.IsAny<string>()
            };
        }
        [TestMethod]
        public void ShouldReturnDriverManager()
        {
            _driverFactory = new WebDriverFactory(_sauceCaps);
            _driverFactory.DriverManager.Should().BeOfType<DriverManager>();
        }

        [TestMethod]
        public void ShouldSetBrowserAndOs()
        {
            var expectedBrowser = BrowserType.Chrome;
            var expectedOs = "Windows 10";

            _sauceCaps = new SauceCaps
            {
                Browser = expectedBrowser,
                Os = expectedOs
            };
            _driverFactory = new WebDriverFactory(_sauceCaps);
            _driverFactory.Browser.Should().Be(expectedBrowser);
            _driverFactory.Os.Should().Be(expectedOs);
        }
        
        [TestMethod]
        public void ShouldThrowExceptionForNotImplementedBrowser()
        {
            _sauceCaps.Browser = BrowserType.Safari;
            var driverManagerStub = new Mock<IDriverManager>();

            _driverFactory = new WebDriverFactory(_sauceCaps, driverManagerStub.Object);
            Action act = () => _driverFactory.Create();
            act.Should().Throw<NotImplementedException>();
        }

        [TestMethod]
        public void ShouldCallGetFirefox()
        {
            _sauceCaps.Browser = BrowserType.Firefox;
            var driverManagerStub = new Mock<IDriverManager>();

            _driverFactory = new WebDriverFactory(_sauceCaps, driverManagerStub.Object);
            _driverFactory.Create();
            driverManagerStub.Verify(m => m.GetRemoteFirefox(_sauceCaps));
        }

        [TestMethod]
        public void ShouldCallGetChrome()
        {
            _sauceCaps.Browser = BrowserType.Chrome;
            var driverManagerMock = new Mock<IDriverManager>();

            _driverFactory = new WebDriverFactory(_sauceCaps, driverManagerMock.Object);
            var driver = _driverFactory.Create();
            driverManagerMock.Verify(m => m.GetRemoteChrome(_sauceCaps));
        }

        [TestMethod]
        public void ItSetsCapsAndManager()
        {
            _driverFactory = new WebDriverFactory();
            _driverFactory.DriverManager.Should().BeOfType<DriverManager>();
            _driverFactory.SauceCapabilities.Should().BeOfType<SauceCaps>();
            _driverFactory.DriverManager.Should().NotBeNull();
            _driverFactory.SauceCapabilities.Should().NotBeNull();
        }
    }
}
