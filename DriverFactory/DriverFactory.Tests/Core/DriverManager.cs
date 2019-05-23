using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DriverFactory.Tests.Core
{
    public class DriverManager : IDriverManager
    {
        private readonly IRemoteDriver _remoteDriver;
        public FirefoxOptions FirefoxOptions;
        public ChromeOptions ChromeOptions;

        public DriverManager()
        {
            _remoteDriver = new RemoteDriver();
        }

        public DriverManager(IRemoteDriver driver)
        {
            _remoteDriver = driver;
        }
        public virtual IWebDriver GetRemoteChrome(SauceCaps sauceCapabilities)
        {
            ChromeOptions = new ChromeOptions
            {
                BrowserVersion = sauceCapabilities.BrowserVersion,
                PlatformName = sauceCapabilities.Os,
                UseSpecCompliantProtocol = true
            };
            sauceCapabilities.SetSauceOptions(ChromeOptions);
            return _remoteDriver.GetRemoteDriver(ChromeOptions);
        }



        public virtual IWebDriver GetRemoteFirefox(SauceCaps sauceCaps)
        {
            FirefoxOptions = SetFirefoxOptions(sauceCaps);
            return _remoteDriver.GetRemoteDriver(FirefoxOptions);
        }

        public virtual FirefoxOptions SetFirefoxOptions(SauceCaps sauceCaps)
        {
            return new FirefoxOptions
            {
                BrowserVersion = sauceCaps.BrowserVersion, 
                PlatformName = sauceCaps.Os
            };
        }
    }
}