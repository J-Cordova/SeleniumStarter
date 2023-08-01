using OpenQA.Selenium;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Framework
{
    public class Interaction
    {
        private IWebDriver _driver;

        public Interaction(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement GetElement(By by)
        {
            Policy.Handle<Exception>().WaitAndRetry(10, _ => TimeSpan.FromMilliseconds(500)).Execute(() => {
                WaitHelper.WaitFor(() => _driver.FindElement(by) != null);
            });
            return _driver.FindElement(by);
        }
        public IList<IWebElement> GetElements(By by)
        {
            Policy.Handle<Exception>().WaitAndRetry(10, _ => TimeSpan.FromMilliseconds(500)).Execute(() => {
                WaitHelper.WaitFor(() => _driver.FindElements(by) != null);
            });
            return _driver.FindElements(by);
        }

        public void ClickElement(By by)
        {
            Policy.Handle<Exception>().WaitAndRetry(10, _ => TimeSpan.FromMilliseconds(500)).Execute(() => {
                var el = GetElement(by);
                el.Click();
            });
        }

        public void InputText(By by, string text, bool clearInput = true)
        {
            Policy.Handle<Exception>().WaitAndRetry(10, _ => TimeSpan.FromMilliseconds(500)).Execute(() => {
                var el = GetElement(by);
                if (clearInput) el.Clear();
                el.SendKeys(text);
            });
        }

        public void SetAttribute(By by, String attName, String attValue)
        {
            Policy.Handle<Exception>().WaitAndRetry(10, _ => TimeSpan.FromMilliseconds(500)).Execute(() => {
                var el = GetElement(by);
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);", el, attName, attValue);
            });
        }

        public void SetElementTextDirect(By by, String attValue)
        {
            Policy.Handle<Exception>().WaitAndRetry(10, _ => TimeSpan.FromMilliseconds(500)).Execute(() => {
                var el = GetElement(by);
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].innerHTML = arguments[2];", el, attValue);

            });
        }

        public void WaitUntilUrlContains(string contains)
        {
            Policy.Handle<Exception>().WaitAndRetry(10, _ => TimeSpan.FromMilliseconds(500)).Execute(() => {
                if (_driver.Url.Contains(contains))
                {
                    return _driver.Url;
                }
                else
                {
                    throw new NotFoundException();
                }
            });
        }
    }
}
