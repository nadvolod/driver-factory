using DriverFactory.Tests.Core;
using OpenQA.Selenium;

namespace DriverFactory.Tests
{
    public class BaseTest
    {
        public WebDriverFactory _driverFactory;
        public SauceCaps _sauceCaps;
        public IWebDriver _driver;
    }
}