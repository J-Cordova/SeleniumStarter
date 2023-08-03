using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Tests.Samples.DemoQA
{
    public class LoginPageTests : BaseTest
    {
        [SetUp]
        public void Init()
        {
            Driver.Navigate().GoToUrl(Pages.HomePage.Url + Pages.LoginPage.Route);
        }

        [Test]
        public void VerifyUrlInNewTab()
        {
            Interaction.ClickElement(Pages.LinksPage.HomeInNewTabLink);

            Driver.SwitchTo().Window(Driver.WindowHandles[Driver.WindowHandles.Count() - 1]);
            var str = Driver.Url;
            Driver.Url.Should().Contain(Pages.HomePage.Url);
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
            Driver.Url.Should().Contain(Pages.LinksPage.Route);
        }
    }
}
