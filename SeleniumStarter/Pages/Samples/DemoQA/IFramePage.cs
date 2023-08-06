using OpenQA.Selenium;
using SeleniumStarter.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Pages.Samples.DemoQA
{
    public class IFramePage : PageBase
    {
        public IFramePage(IWebDriver driver, Interaction interaction) : base(driver, interaction) { }

        public readonly String Route = "/frames";

        public By IFrame1 => By.XPath($"//div[@id='frame1Wrapper']//iframe");
        public By IFrame2 => By.XPath($"//div[@id='frame2Wrapper']//iframe");
        public By IFrameSamplePageTextContent => By.XPath($"//h1[text()='This is a sample page']");
        public By IFrameByIndex(int index) => By.XPath($"//iframe[{index}]");
    }
}
