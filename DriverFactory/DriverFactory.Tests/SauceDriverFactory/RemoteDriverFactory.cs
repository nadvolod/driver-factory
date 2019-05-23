namespace DriverFactory.Tests.SauceDriverFactory
{
    public abstract class RemoteDriverFactory
    {
        public RemoteDriver CreateDriver()
        {
            return GetDriver();
        }

        public abstract RemoteDriver GetDriver();
    }
}
