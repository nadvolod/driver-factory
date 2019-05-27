using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;

namespace DriverFactory.Tests.Combo.Core
{
    public class SauceCaps
    {
        public BrowserType Browser { get; set; } = BrowserType.Chrome;
        public string Os { get; internal set; } = "Windows 10";
        public string UserName
        {
            get
            {
                //TODO turn this into method CheckIfUserNameExists and then make sure that it returns appropriate value in testing
                var sauceUserName = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
                if (sauceUserName == null)
                    throw new SauceEnvironmentVariableNotSetException();
                else return sauceUserName;
            }
            set
            {
                sauceUserName = value;
            }
        }

        public string BrowserVersion { get; internal set; } = "latest";

        private string sauceUserName;
        public virtual Dictionary<string, object> GetSauceOptions()
        {
            var sauceOptions = new Dictionary<string, object>
            {
                //TODO temporary hardcoding
                ["username"] = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User),
                ["accessKey"] = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User)
            };
            return sauceOptions;
        }

        internal void SetSauceOptions(ChromeOptions chromeOptions)
        {
            chromeOptions.AddAdditionalCapability("sauce:options", GetSauceOptions(), true);
        }
    }
}