using OpenQA.Selenium;
using SeleniumStarter.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Pages.Samples.DemoQA
{
    public class ProfilePage : PageBase
    {
        public ProfilePage(IWebDriver driver, Interaction interaction) : base(driver, interaction) { }

        public readonly String Route = "/profile";

        public By TitleTextLabel => By.XPath($"//div[@id='title-wrapper']//label[@id='userName-value']");
        public By SearchBoxInput => By.Id($"searchBox");
        public By GetRecordLinkByTitle(string title) => By.XPath($"//div[@class='rt-tbody']//a[contains(text(),'{title}')]");
    }
}
