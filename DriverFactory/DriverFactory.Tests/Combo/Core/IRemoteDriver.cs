using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace DriverFactory.Tests.Combo.Core
{
    public interface IRemoteDriver
    {
        RemoteWebDriver GetRemoteDriver(DriverOptions browserOptions);
    }
}