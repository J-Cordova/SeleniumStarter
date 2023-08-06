using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Framework
{

    public class WaitHelper
    {
        private IWebDriver _driver;
        public WebDriverWait Wait;

        public WaitHelper(IWebDriver driver)
        {
            _driver = driver;
            Wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
        }

        public static void WaitFor(Func<bool> action, int trys = 10, TimeSpan waitInterval = default)
        {
            if (waitInterval == default) waitInterval = TimeSpan.FromMilliseconds(500);

            for (int i = 1; i < trys; i++)
            {
                var result = action();
                if (result)
                {
                    WaitFor(500, "Allow for UI Refesh");
                    break;
                }
                else if (i == trys)
                {
                    throw new TimeoutException($"Timeout occured after {trys} attempts");
                }
                else
                {
                    Task.Delay(waitInterval).Wait();
                }
            }
        }

        public static void WaitFor(int time, string reason)
        {
            Thread.Sleep(time);
        }

        public IWebElement WaitForElementExists(By by)
        {
            IWebElement el = Wait.Until(ExpectedConditions.ElementExists(by));
            return el;
        }

        public IWebElement WaitForElementVisible(By by)
        {
            IWebElement el = Wait.Until(ExpectedConditions.ElementIsVisible(by));
            return el;
        }

        public IWebElement WaitForElementClickable(By by)
        {
            IWebElement el = Wait.Until(ExpectedConditions.ElementToBeClickable(by));
            return el;
        }

        public ICollection<IWebElement> WaitForElementsVisible(By by)
        {
            var els = Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
            return els.ToList();
        }

        public IWebElement WaitForElementInvisible(By by)
        {
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
            return _driver.FindElement(by);
        }
    }
}
