using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.DOM;
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
        public By FormsDropDownOpenElement => By.XPath($"//div[@class='header-text' and contains(text(),'Forms')]");
        public By FormDropDownList => By.XPath("(//div[@class='header-text' and contains(text(),'Forms')]//preceding::div[@class='element-group'][1])//div[contains(@class,'element-list collapse')]");

        public bool IsFormDropDownOpen() => Interaction.GetElement(FormDropDownList).GetAttribute("class").Contains("open");     

    }
}
