using OpenQA.Selenium;
using SeleniumStarter.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Pages.Samples.DemoQA
{
    public class PracticeFormPage : PageBase
    {
        public PracticeFormPage(IWebDriver driver, Interaction interaction) : base(driver, interaction)
        {}

        public readonly String Route = "/automation-practice-form";

        #region CustomMethods
        
        #endregion


        #region Selectors
        public By FirstNameInput => By.Id($"firstName");
        public By LastNameInput => By.Id($"lastName");
        public By EmailInput => By.Id($"userEmail");

        public By SubjectsContainer => By.Id($"subjectsContainer");

        public By MaleRadioButton => By.Id($"gender-radio-1");
        public By FemaleRadioButton => By.Id($"gender-radio-2");
        public By OtherRadioButton => By.Id($"gender-radio-2");

        public By SportsHobbyCheckbox => By.Id($"hobbies-checkbox-1");
        public By ReadingHobbyCheckbox => By.Id($"hobbies-checkbox-2");
        public By MusicHobbyCheckbox => By.Id($"hobbies-checkbox-3");

        public By PictureUploadInput => By.Id($"uploadPicture");

        public By CurrentAddressTextArea => By.XPath($"//textarea[@id='currentAddress']");

        public By StateDropDownMenuButton => By.Id($"state");

        private String StateDropDownMenuOptionsXpathByIndex = $"(//div[@id='state']//div[contains(@class, '-menu')]/div//div)[<index>]";
        public By GetStateDropDownMenuOptionbyIndex(int index = 1) => By.XPath(StateDropDownMenuOptionsXpathByIndex.Replace("<index>", index.ToString()));


        public By CityDropDownMenuButton => By.Id($"city");
        private String CityDropDownMenuOptionsXpathByIndex = $"(//div[@id='city']//div[contains(@class, '-menu')]/div//div)[<index>]";
        public By GetCityDropDownMenuOptionsByIndex(int index = 1) => By.XPath(CityDropDownMenuOptionsXpathByIndex.Replace("<index>", index.ToString()));

        public By SubmitButton => By.Id($"submit");

        #endregion
    }
}
