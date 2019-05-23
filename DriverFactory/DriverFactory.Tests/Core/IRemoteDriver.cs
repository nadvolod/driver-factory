using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace DriverFactory.Tests.Core
{
    public interface IRemoteDriver
    {
        RemoteWebDriver GetRemoteDriver(DriverOptions browserOptions);
    }
}