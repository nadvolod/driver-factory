namespace DriverFactory.Tests.SauceDriverFactory.Concrete
{
    class FirefoxDriverFactory : RemoteDriverFactory
    {
        public override RemoteDriver GetDriver()
        {
            return new RemoteFirefox();
        }
    }
}
