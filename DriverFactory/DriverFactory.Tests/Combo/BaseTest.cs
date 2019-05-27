using DriverFactory.Tests.Combo.Core;
using OpenQA.Selenium;

namespace DriverFactory.Tests.Combo
{
    public class BaseTest
    {
        public WebDriverFactory _driverFactory;
        public SauceCaps _sauceCaps;
        public IWebDriver _driver;
    }
}