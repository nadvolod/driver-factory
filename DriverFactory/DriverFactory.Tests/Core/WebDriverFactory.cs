using System;
using OpenQA.Selenium;

namespace DriverFactory.Tests.Core
{
    public class WebDriverFactory
    {
        public readonly SauceCaps SauceCapabilities;

        public WebDriverFactory(SauceCaps sauceCaps, IDriverManager manager)
        {
            DriverManager = manager;
            SauceCapabilities = sauceCaps;
        }

        public WebDriverFactory(SauceCaps sauceCaps)
        {
            SauceCapabilities = sauceCaps;
            DriverManager = new DriverManager();
        }

        public WebDriverFactory()
        {
            SauceCapabilities = new SauceCaps();
            DriverManager = new DriverManager();
        }

        public BrowserType Browser => SauceCapabilities.Browser;
        public string Os => SauceCapabilities.Os;

        public IDriverManager DriverManager { get; }
        public string BrowserVersion => SauceCapabilities.BrowserVersion;

        internal IWebDriver Create()
        {
            switch (SauceCapabilities.Browser)
            {
                case BrowserType.Chrome:
                    return DriverManager.GetRemoteChrome(SauceCapabilities);
                case BrowserType.Firefox:
                    return DriverManager.GetRemoteFirefox(SauceCapabilities);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}