using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
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
            Wait.Until(ExpectedConditions.AlertIsPresent());
            Driver.SwitchTo().Alert().Accept();
        }
    }
}
