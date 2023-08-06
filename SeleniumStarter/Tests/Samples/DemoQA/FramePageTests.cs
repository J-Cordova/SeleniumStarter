using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Tests.Samples.DemoQA
{
    public class FramePageTests : BaseTest
    {
        [Test]
        public void CanNavigateAndVerifyIFrameContents()
        {
            var iFrameTextContent = "This is a sample page";
            Driver.Navigate().GoToUrl(Pages.HomePage.Url + Pages.IFramePage.Route);

            var frame1 = Interaction.GetElement(Pages.IFramePage.IFrame1);
            Driver.SwitchTo().Frame(frame1);
            var textContent = Interaction.GetElement(Pages.IFramePage.IFrameSamplePageTextContent).Text;

            Driver.SwitchTo().DefaultContent();

            var frame2 = Interaction.GetElement(Pages.IFramePage.IFrame2);
            Driver.SwitchTo().Frame(frame2);
            var textContent2 = Interaction.GetElement(Pages.IFramePage.IFrameSamplePageTextContent).Text;

            textContent.Should().Be(iFrameTextContent);
            textContent2.Should().Be(iFrameTextContent);

        }
    }
}
