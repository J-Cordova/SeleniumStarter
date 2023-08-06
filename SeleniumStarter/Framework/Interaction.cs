using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Polly;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            try
            {
                WaitHelper.WaitFor(() => _driver.FindElement(by) != null);
                return _driver.FindElement(by);
            }
            catch (NoSuchElementException ex)
            {
                return null;
            }
        }

        public IList<IWebElement> GetElements(By by)
        {
            try
            {
                WaitHelper.WaitFor(() => _driver.FindElements(by).Count > 0);
                return _driver.FindElements(by);
            }
            catch (NoSuchElementException ex)
            {
                return null;
            }
        }

        public void ClickElement(By by)
        {
            Policy.Handle<Exception>().WaitAndRetry(10, _ => TimeSpan.FromMilliseconds(500)).Execute(() => {
                try
                {
                    var el = GetElement(by);
                    el.Click();
                }
                catch (ElementClickInterceptedException ex)
                {
                    var el = GetElement(by).FindElement(By.XPath(".."));
                    ClickElement(el);
                }
            });
            WaitHelper.WaitFor(200, "For UI refesh after click");
        }

        public void ClickElement(IWebElement el)
        {
            Policy.Handle<Exception>().WaitAndRetry(10, _ => TimeSpan.FromMilliseconds(500)).Execute(() => {
                try
                {
                    el.Click();
                }
                catch (ElementClickInterceptedException ex)
                {
                    var pel = el.FindElement(By.XPath(".."));
                    ClickElement(pel);
                }
            });
            WaitHelper.WaitFor(200, "For UI refesh after click");
        }

        public void JavaScriptClick(By by)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].click();", GetElement(by));

            //var elementToClick = GetElement(by);
            //Actions action = new Actions(_driver);
            //action.MoveToElement(elementToClick).Build().Perform();
            //elementToClick.Click();

            //((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].style.visibility='visible'", elementToClick);
            //elementToClick.Click();
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

        public By SelectDropdownOption(string nameContains) => By.XPath($"//div[contains(@class, 'k-animation-container-shown')]//span[contains(text(),'{nameContains}')]");

        public string GetCurrentDateTimeInFileFormat() => DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();

        #region KendoGridInteraction
        public int GetGridCount(int tableIndex = 1)
        {
            var gridData = "";
            WaitHelper.WaitFor(() =>
            {
                gridData = GetElement(GridPager(tableIndex)).Text;
                return gridData != "";
            });
            return gridData == "0 of 0" ? 0 : int.Parse(gridData.Split()[4]);
        }
        public By GridPager(int tableIndex = 1) => By.XPath($"(//div[contains(@class,'k-pager-info')])[{tableIndex}]");
        public By AccessTable(int row, int column, int tableIndex = 1) => By.XPath($"(((//table[contains(@class,'k-grid-table')])[{tableIndex}]//tbody//tr)[{row}]//td)[{column}]");
        public By AccessTable(string rowName, int column, int tableIndex = 1) => By.XPath($"((//table[contains(@class,'k-grid-table')])[{tableIndex}]//tbody//tr/td[text() ='{rowName}'])/..//td[{column}]");
        public By AccessTableForDropDown(int row, int column, int tableIndex = 1) => By.XPath($"((((//table[contains(@class,'k-grid-table')])[{tableIndex}]//tbody//tr)[{row}]//td)[{column}]).//span[1]");
        public By AccessTableForDropDownClickDropDown(int row, int column, int tableIndex = 1) => By.XPath($"((((//table[contains(@class,'k-grid-table')])[{tableIndex}]//tbody//tr)[{row}]//td)[{column}]//span)[1]");
        public By AccessDropDownList => By.XPath($"//div[@class = 'k-list-content']//ul");
        public void SetTextForTd(By by, string text, bool clearText = false)
        {
            var parentEl = GetElement(by);
            ClickElement(by);
            if (GetElement(by) != null)
            {
                ClickElement(by);
            }

            if (clearText)
            {
                if (parentEl != null)
                {
                    parentEl.FindElement(By.XPath("(.//input)[1]")).Clear();
                    parentEl.FindElement(By.XPath("(.//input)[1]")).SendKeys(text);
                }
                else
                {
                    GetElement(by).FindElement(By.XPath("(.//input)[1]")).Clear();
                    GetElement(by).FindElement(By.XPath("(.//input)[1]")).SendKeys(text);
                }
            }
            else
            {
                if (parentEl != null)
                {
                    if (clearText) parentEl.FindElement(By.XPath("(.//input)[1]")).Clear();
                    parentEl.FindElement(By.XPath("(.//input)[1]")).SendKeys(text);
                }
                else
                {
                    if (clearText) parentEl.FindElement(By.XPath("(.//input)[1]")).Clear();
                    GetElement(by).FindElement(By.XPath("(.//input)[1]")).SendKeys(text);
                }
            }
        }
        public void SetDropDownForTDByName(By by, string text)
        {
            ClickElement(by);
            if (GetElement(AccessDropDownList) == null)
            {
                ClickElement(by);
            }
            ClickElement(GetElement(By.XPath($".//div[@class = 'k-list-content']//li//span[text()='{text}']")));
        }
        public void SetDropDownForTDByIndex(By by, int index)
        {
            ClickElement(by);
            if (GetElement(AccessDropDownList) == null)
            {
                ClickElement(by);
            }
            ClickElement(GetElement(by).FindElement(By.XPath($"(.//div[@class = 'k-list-content']//li)[{index}]")));
        }
        public IWebElement GetRowByName(string name, int tableIndex = 1)
        {
            var editButtonXpath = $"(//table[contains(@class,'k-table')])[{tableIndex}]//tr//td[text() ='{name}']";
            return GetElement(By.XPath(editButtonXpath));
        }
        public void EditRowByName(string name, int tableIndex = 1)
        {
            var editButtonXpath = $"((//table[contains(@class,'k-table')])[{tableIndex}]//tr//td[text() ='{name}']/following-sibling::td)[last() -1]//button";
            var editButton = GetElement(By.XPath(editButtonXpath));

            ClickElement(editButton);
        }
        public void DeleteRowByName(string name, int tableIndex = 1, int offsetFromLast = 0)
        {
            var deleteButtonTdXpath = $"((//table[contains(@class,'k-table')])[{tableIndex + 1}])//tr//td[contains(text(), '{name}')]/following-sibling::td[last()-{(1 + offsetFromLast).ToString()}]";
            var deleteButtonXpath = $"(//input[contains(@value, '{name}')]/parent::td/following-sibling::td)[last()-1]//button";
            var deleteButtonUneditableNameXpath = $"(//table[contains(@class,'k-table')])[{tableIndex + 1}]//td[contains(text(), '{name}')]/following-sibling::td[last()-{(1 + offsetFromLast).ToString()}]//button";

            ClickElement(By.XPath(deleteButtonTdXpath));
            if (GetElement(By.XPath(deleteButtonXpath)) == null)
            {
                ClickElement(By.XPath(deleteButtonUneditableNameXpath));
            }
            else
            {
                ClickElement(By.XPath(deleteButtonXpath));
            }
        }
        #endregion
    }

}
