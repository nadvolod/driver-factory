using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fluent.Tests.Unit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RemoteWebDriver_Instantiated_Returns()
        {
            var factory = new RemoteWebDriverFactory();
            factory.Should().NotBeNull();
        }
    }

    public class RemoteWebDriverFactory
    {
    }
}
