using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumStarter.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Pages.Samples.DemoQA
{
    public class BookStorePage : PageBase
    {
        public BookStorePage(IWebDriver driver, Interaction interaction) : base(driver, interaction) { }

        public readonly String Route = "/books";
        public By GetBookLinkByIndex(int index = 1) => By.XPath($"(//div[@class='rt-tbody']//div[contains(@class,'rt-tr ')])[<index>]//a".Replace("<index>", index.ToString()));

        public By AddToCollectionButton => By.XPath($"//button[contains(text(),'Add To Your Collection')]");
        public By BackToBookStoreButton => By.XPath($"//utton[contains(text(),'Back To Book Store')]");
        public By LoginButton => By.Id($"login");
        public By LogoutButton => By.XPath($"//button[text()='Log out']");
    }
}
