using DriverFactory.Tests.Combo.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DriverFactory.Tests.Combo.Unit
{
    [TestClass]
    public class SauceCapsTests
    {
        private SauceCaps _caps;

        [TestInitialize]
        public void Setup()
        {
            _caps = new SauceCaps();

        }
        [TestMethod]
        public void ShouldContainAtLeastUsernameAndAccessKey()
        {
            _caps.GetSauceOptions().Should().ContainKeys("username", "accessKey");
        }
        [TestMethod]
        public void DefaultShouldBeChrome()
        {
            _caps.Browser.Should().Be(BrowserType.Chrome);
        }
        [TestMethod]
        public void DefaultShouldBeWindows10()
        {
            _caps.Os.Should().Be("Windows 10");
        }
        [TestMethod]
        public void DefaultShouldBeLatestBrowserVersion()
        {
            _caps.BrowserVersion.Should().Be("latest");
        }
    }
}
