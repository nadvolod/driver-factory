﻿using DriverFactory.Tests.SauceDriverFactory.Concrete;
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
            _factory.Options.Os.Should().Be("Linux");
        }

        [TestMethod]
        public void ItReturnsLatestBrowserFromDefaultConstructor()
        {
            var driver = _factory.CreateDriver();
            _factory.Options.BrowserVersion.Should().Be("latest");
        }

        [TestMethod]
        public void ItReturnsFirefoxWithDefaultSettings()
        {
            var sauceCaps = new SauceOptions {Browser = "Firefox"};
            var driver = _factory.CreateDriver(sauceCaps);
            driver.Should().BeOfType<RemoteFirefox>();
        }

        [TestMethod]
        public void ItReturnsLinuxWhenOnlyBrowserIsSet()
        {
            var sauceCaps = new SauceOptions { Browser = "Firefox" };
            _factory.CreateDriver(sauceCaps);
            _factory.Options.Os.Should().Be("Linux");
        }
    }

    public class RemoteWebDriverFactory
    {
        public RemoteDriver CreateDriver()
        {
            return new RemoteChrome();
        }

        public SauceOptions Options => new SauceOptions();

        public RemoteDriver CreateDriver(SauceOptions sauceOptions)
        {
            switch (sauceOptions.Browser.ToLower())
            {
                case "firefox":
                    return new RemoteFirefox();
                default:
                    return new RemoteChrome();
            }
        }
    }

    public class SauceOptions
    {
        public string Os { get; set; } = "Linux";
        public string BrowserVersion { get; set; } = "latest";
        public string Browser { get; set; }
    }
}
