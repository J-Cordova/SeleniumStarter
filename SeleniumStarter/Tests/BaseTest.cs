using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumStarter.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumStarter.Pages;
using OpenQA.Selenium.Support.Extensions;

namespace SeleniumStarter.Tests
{
    public class BaseTest
    {
        public Interaction Interaction { get; set; }
        public IWebDriver Driver { get; set; }
        public WaitHelper WaitHelper { get; set; }
        public TestUtilities TestUtilities { get; set; }
        public Dictionary<String, String> Configuration { get; set; }
        public SeleniumStarter.Pages.Pages Pages { get; set; }
        public BaseTest()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("ignore-certificate-errors");

            Configuration = ConfigurationProvider.GetConfiguration();

            Driver = new ChromeDriver(Environment.CurrentDirectory + "\\chromedriver.exe", chromeOptions);
            WaitHelper = new WaitHelper(Driver);
            Interaction = new Interaction(Driver);
            TestUtilities = new TestUtilities(Driver, Configuration);
            Pages = new(Driver, Interaction);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
