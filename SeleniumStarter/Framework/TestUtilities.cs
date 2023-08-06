using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Framework
{
    public class TestUtilities
    {
        private IWebDriver driver;
        Dictionary<string, string> config;
        public TestUtilities(IWebDriver _driver, Dictionary<string, string> _config)
        {
            driver = _driver;
            config = _config;
        }

        public void NavigateToSite()
        {
            var envUrl = config.GetValueOrDefault("environment");
            driver.Navigate().GoToUrl(envUrl);
            WaitHelper.WaitFor(() => driver.Url == envUrl);
        }
    }
}
