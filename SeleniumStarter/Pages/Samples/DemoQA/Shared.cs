using OpenQA.Selenium;
using SeleniumStarter.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Pages.Samples.DemoQA
{
    public class Shared : PageBase
    {
        public Shared(IWebDriver driver, Interaction interaction) : base(driver, interaction) { }

        public void AcceptBrowserAlert()
        {
            Driver.SwitchTo().Alert().Accept();
        }
    }
}
