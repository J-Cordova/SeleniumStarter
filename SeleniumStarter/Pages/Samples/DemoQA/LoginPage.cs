using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumStarter.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Pages.Samples.DemoQA
{
    public class LoginPage : PageBase
    {
        public LoginPage(IWebDriver driver, Interaction interaction) : base(driver, interaction) { }

        public readonly String Route = "/login";

        private readonly String UserName = "Test@88";
        private readonly String Password = "Test@88";

        public By UserNameInput => By.Id($"userName");
        public By PasswordInput => By.Id($"password");
        public By LoginButton => By.Id($"login");
        public By LogoutButton => By.XPath($"//button[text()='Logout']");


        public void Login()
        {
            Interaction.GetElement(UserNameInput).SendKeys(UserName);
            Interaction.GetElement(PasswordInput).SendKeys(Password);
            Interaction.ClickElement(LoginButton);

            Wait.Until(ExpectedConditions.ElementIsVisible(LogoutButton));
        }
    }
}
