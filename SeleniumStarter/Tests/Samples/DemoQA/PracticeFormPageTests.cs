using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using SeleniumExtras.WaitHelpers;
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
        [SetUp]
        public void Init()
        {
            Driver.Navigate().GoToUrl(Pages.HomePage.Url);
           
        }

        [Test]
        public void FillOutForm()
        {
            Interaction.ClickElement(Pages.HomePage.FormsCard);

            Interaction.ClickElement(Pages.FormsPage.PracticeFormsLink);

            Interaction.GetElement(Pages.PracticeFormPage.FirstNameInput).SendKeys("First");
            Interaction.GetElement(Pages.PracticeFormPage.LastNameInput).SendKeys("Last");
            Interaction.GetElement(Pages.PracticeFormPage.EmailInput).SendKeys("test@test.com");
            Interaction.ClickElement(Pages.PracticeFormPage.MaleRadioClickWrapper);

            Interaction.GetElement(Pages.PracticeFormPage.MobileNumberInput).SendKeys("1234343123");

            Interaction.ClickElement(Pages.PracticeFormPage.SubjectsContainer);
            new Actions(Driver).SendKeys("A").Pause(TimeSpan.FromMilliseconds(500)).SendKeys(Keys.ArrowDown).SendKeys(Keys.Return).Build().Perform();

            Interaction.ClickElement(Pages.PracticeFormPage.SportsHobbyClickWrapper);
            Interaction.ClickElement(Pages.PracticeFormPage.ReadingHobbyClickWrapper);
            Interaction.ClickElement(Pages.PracticeFormPage.MusicHobbyClickWrapper);

            var testItemDir = Directory.GetCurrentDirectory() + "\\Tests\\Samples\\DemoQA\\Test.txt";
            Interaction.GetElement(Pages.PracticeFormPage.PictureUploadInput).SendKeys(testItemDir);

            Interaction.GetElement(Pages.PracticeFormPage.CurrentAddressTextArea).SendKeys("TextArea");

            //Asserts 
            Interaction.GetElement(Pages.PracticeFormPage.FirstNameInput).GetAttribute("value").Should().Be("First");
            Interaction.GetElement(Pages.PracticeFormPage.LastNameInput).GetAttribute("value").Should().Be("Last");
            Interaction.GetElement(Pages.PracticeFormPage.EmailInput).GetAttribute("value").Should().Be("test@test.com");
            Interaction.GetElement(Pages.PracticeFormPage.MaleRadioInput).Selected.Should().BeTrue();
            Interaction.GetElement(Pages.PracticeFormPage.FemaleRadioInput).Selected.Should().BeFalse();
            Interaction.GetElement(Pages.PracticeFormPage.OtherRadioInput).Selected.Should().BeFalse();
            Interaction.GetElement(Pages.PracticeFormPage.MobileNumberInput).GetAttribute("value").Should().Be("1234343123");
            Interaction.GetElement(Pages.PracticeFormPage.SportsHobbyRadioInput).Selected.Should().BeTrue();
            Interaction.GetElement(Pages.PracticeFormPage.ReadingHobbyRadioInput).Selected.Should().BeTrue();
            Interaction.GetElement(Pages.PracticeFormPage.MusicHobbyRadioInput).Selected.Should().BeTrue();

            Interaction.GetElement(Pages.PracticeFormPage.MusicHobbyRadioInput).Should().NotBeNull();


            Interaction.GetElement(Pages.PracticeFormPage.CurrentAddressTextArea).GetAttribute("value").Should().Be("TextArea");
            Interaction.GetElement(Pages.PracticeFormPage.PictureUploadInput).GetAttribute("value").Contains("Test.txt").Should().BeTrue();
        }
    }
}
