using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace DriverFactory.Tests.Combo.Core
{
    public interface IDriverManager
    {
        IWebDriver GetRemoteChrome(SauceCaps sauceCapabilities);
        IWebDriver GetRemoteFirefox(SauceCaps sauceCapabilities);
        FirefoxOptions SetFirefoxOptions(SauceCaps stubCapabilities);
    }
}