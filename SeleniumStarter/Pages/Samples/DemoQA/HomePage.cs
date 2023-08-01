using OpenQA.Selenium;
using SeleniumStarter.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Pages.Samples.DemoQA
{
    public class HomePage : PageBase
    {
        public HomePage(IWebDriver driver, Interaction interaction) : base(driver, interaction){ }

        public readonly String Url = "https://demoqa.com";

        public By FormsCard => By.XPath($"//h5[contains(text(), 'Forms')]/ancestor::div[contains(@class, 'card ')]");
    }
}
