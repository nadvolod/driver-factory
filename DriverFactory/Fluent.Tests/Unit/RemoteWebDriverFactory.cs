using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Fluent.Tests.Unit
{
    public class RemoteWebDriverFactory
    {
        public DriverOptions BrowserOptions { get; set; } = new ChromeOptions();

        public IWebDriver GetInstance()
        {
            //todo not testable, need to encapsulate in an interface
            return new RemoteWebDriver(new Uri("https://ondemand.saucelabs.com/wd/hub"),
                BrowserOptions.ToCapabilities(), TimeSpan.FromSeconds(600));
        }

        public void WithBrowserCaps()
        {
            throw new NotImplementedException();
        }
    }
}