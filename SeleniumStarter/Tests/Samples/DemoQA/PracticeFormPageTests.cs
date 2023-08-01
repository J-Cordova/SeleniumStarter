using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumStarter.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Tests.Samples.DemoQA
{
    public class PracticeFormPageTests : BaseTest
    {
        [Test]
        public void FillOutForm()
        {
            Driver.Navigate().GoToUrl(Pages.HomePage.Url);

            Interaction.ClickElement(Pages.HomePage.FormsCard);
            Interaction.ClickElement(Pages.FormsPage.PracticeFormsLink);

            Interaction.GetElement(Pages.PracticeFormPage.FirstNameInput).SendKeys("First");
            Interaction.GetElement(Pages.PracticeFormPage.LastNameInput).SendKeys("Last");
            Interaction.GetElement(Pages.PracticeFormPage.EmailInput).SendKeys("test@test.com");

            Interaction.ClickElement(Pages.PracticeFormPage.SubjectsContainer);
            Actions action = new Actions(Driver);
            action.SendKeys("A").SendKeys(Keys.ArrowDown).SendKeys(Keys.Return); 
            action.Build().Perform();
       

            Interaction.ClickElement(Pages.PracticeFormPage.SportsHobbyCheckbox);
            Interaction.ClickElement(Pages.PracticeFormPage.ReadingHobbyCheckbox);
            Interaction.ClickElement(Pages.PracticeFormPage.MusicHobbyCheckbox);

            Interaction.GetElement(Pages.PracticeFormPage.CurrentAddressTextArea).SendKeys("TextArea");

            Interaction.ClickElement(Pages.PracticeFormPage.StateDropDownMenuButton);
            Interaction.ClickElement(Pages.PracticeFormPage.GetStateDropDownMenuOptionbyIndex());

            Interaction.ClickElement(Pages.PracticeFormPage.CityDropDownMenuButton);
            Interaction.ClickElement(Pages.PracticeFormPage.GetCityDropDownMenuOptionsByIndex());

            var x = 7;
        }
    }
}
