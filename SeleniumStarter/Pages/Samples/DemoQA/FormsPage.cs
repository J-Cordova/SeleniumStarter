using OpenQA.Selenium;
using SeleniumStarter.Framework;
using SeleniumStarter.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Pages.Samples.DemoQA
{
    public class FormsPage : PageBase
    {
        public FormsPage(IWebDriver driver, Interaction interaction) : base(driver, interaction) { }

        public readonly String Route = "/forms";

        public By PracticeFormsLink => By.XPath($"//span[contains(text(),'Practice Form')]");
    }
}
