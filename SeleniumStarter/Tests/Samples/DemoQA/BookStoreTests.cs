using FluentAssertions;
using OpenQA.Selenium;
using SeleniumStarter.Framework;
using SeleniumStarter.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Tests.Samples.DemoQA
{
    public class BookStoreTests : BaseTest
    {
        [SetUp]
        public void Init()
        {
            Driver.Navigate().GoToUrl(Pages.HomePage.Url + Pages.LoginPage.Route);

            if (Interaction.GetElement(Pages.LoginPage.LogoutButton) == null)
            {
                Pages.LoginPage.Login();
            }

            Driver.Navigate().GoToUrl(Pages.HomePage.Url + Pages.BookStorePage.Route);

        }

        [Test]
        public void AddBookToCollection()
        {
            Interaction.ClickElement(Pages.BookStorePage.GetBookLinkByIndex());
            var bookTitle = Interaction.GetElement(Pages.ProfilePage.TitleTextLabel).Text;
            Interaction.ClickElement(Pages.BookStorePage.AddToCollectionButton);
            Pages.BookStorePage.AcceptAddToCollectionAlert();

            Driver.Navigate().GoToUrl(Pages.HomePage.Url + Pages.ProfilePage.Route);
            Interaction.GetElement(Pages.ProfilePage.SearchBoxInput).SendKeys(bookTitle + Keys.Tab);

            var bookInGridTitle = Interaction.GetElement(Pages.ProfilePage.GetRecordLinkByTitle(bookTitle)).Text;

            bookInGridTitle.Should().Be(bookTitle);
        }


        [TearDown]
        public void Cleanup()
        {
        }
    }
}
