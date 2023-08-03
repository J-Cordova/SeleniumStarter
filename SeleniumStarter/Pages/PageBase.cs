using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
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
        public WebDriverWait Wait { get; set; }

        public PageBase(IWebDriver driver, Interaction interaction)
        {
            Driver = driver;
            Interaction = interaction;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
        }

        public void AdjustPageZoom(int zoomPercent)
        {
            var html = Interaction.GetElement(By.TagName("html"));
            Driver.ExecuteJavaScript($"document.body.style.zoom='{zoomPercent}%'");
            //wait for page to adjust
            Thread.Sleep(500);
        }
    }
}
