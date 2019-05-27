namespace DriverFactory.Tests.AbstractFactory.Concrete
{
    class FirefoxDriverFactory : RemoteDriverFactory
    {
        public override RemoteDriver GetDriver()
        {
            return new RemoteFirefox();
        }
    }
}
