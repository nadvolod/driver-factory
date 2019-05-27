using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace DriverFactory.Tests.Combo.Core
{
    public class RemoteDriver : IRemoteDriver
    {
        public RemoteDriver()
        {
        }

        public virtual RemoteWebDriver GetRemoteDriver(DriverOptions browserOptions)
        {
            return new RemoteWebDriver(new Uri("https://ondemand.saucelabs.com/wd/hub"),
                browserOptions.ToCapabilities(), TimeSpan.FromSeconds(600));
        }
    }
}