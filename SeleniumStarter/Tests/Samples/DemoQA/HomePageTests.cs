using SeleniumStarter.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumStarter.Tests.Samples.DemoQA
{
    public class HomePageTests : BaseTest
    {
        [Test]
        public void CanNavigate()
        {
            Driver.Navigate().GoToUrl(Pages.HomePage.Url);

            WaitHelper.WaitFor(() => Driver.Url.Contains(Pages.HomePage.Url));

            Assert.That(Driver.Url.Contains(Pages.HomePage.Url));
        }

        [Test]
        public void CanNavigateToFormsPage()
        {
            Driver.Navigate().GoToUrl(Pages.HomePage.Url);

            Interaction.ClickElement(Pages.HomePage.FormsCard);
            WaitHelper.WaitFor(() => Driver.Url.Contains(Pages.HomePage.Url));

            Assert.That(Driver.Url.Contains(Pages.FormsPage.Route));
        }
    }
}
