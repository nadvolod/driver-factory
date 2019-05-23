namespace DriverFactory.Tests.SauceDriverFactory.Concrete
{
    public class ChromeDriverFactory : RemoteDriverFactory
    {
        public override RemoteDriver GetDriver()
        {
            return new RemoteChrome();
        }
    }
}
