using OpenQA.Selenium;
using SeleniumStarter.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Pages
{
    public abstract class PageBase
    {
        public Interaction Interaction { get; set; }
        public IWebDriver Driver { get; set; }
        public PageBase(IWebDriver driver, Interaction interaction)
        {
            Driver = driver;
            Interaction = interaction;
        }
    }
}
