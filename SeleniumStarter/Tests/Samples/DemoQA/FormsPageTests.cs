using SeleniumStarter.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Tests.Samples.DemoQA
{
    public class FormsPageTests : BaseTest
    {
        [Test]
        public void CanNavigateToPracticeForm()
        {
            Driver.Navigate().GoToUrl(Pages.HomePage.Url);

            Interaction.ClickElement(Pages.HomePage.FormsCard);
            Interaction.ClickElement(Pages.FormsPage.PracticeFormsLink);

            WaitHelper.WaitFor(() => Driver.Url.Contains(Pages.PracticeFormPage.Route));

            Assert.That(Driver.Url.Contains(Pages.PracticeFormPage.Route));
        }
    }
}
