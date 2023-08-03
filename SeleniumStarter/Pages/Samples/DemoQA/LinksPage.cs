using OpenQA.Selenium;
using SeleniumStarter.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Pages.Samples.DemoQA
{
    public class LinksPage : PageBase
    {
        public LinksPage(IWebDriver driver, Interaction interaction) : base(driver, interaction) { }

        public readonly String Route = "/links";

        public By HomeInNewTabLink => By.Id($"simpleLink");


    }
}
