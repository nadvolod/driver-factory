namespace DriverFactory.Tests.AbstractFactory.Concrete
{
    public class ChromeDriverFactory : RemoteDriverFactory
    {
        public override RemoteDriver GetDriver()
        {
            return new RemoteChrome();
        }
    }
}
