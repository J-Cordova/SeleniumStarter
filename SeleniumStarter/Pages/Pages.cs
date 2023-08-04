using OpenQA.Selenium;
using SeleniumStarter.Framework;
using SeleniumStarter.Pages.Samples;
using SeleniumStarter.Pages.Samples.DemoQA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Pages
{
    public class Pages
    {
        public Interaction Interaction { get; set; }
        public IWebDriver Driver { get; set; }

        public CollectorSourceConfiguration CollectorSourceConfiguration { get; set; }
        public HomePage HomePage { get; set; }
        public FormsPage FormsPage { get; set; }
        public PracticeFormPage PracticeFormPage { get; set; }
        public LinksPage LinksPage { get; set; }
        public LoginPage LoginPage { get; set; }
        public BookStorePage BookStorePage { get; set; }
        public ProfilePage ProfilePage { get; set; }
        public Shared Shared { get; set; }

        


        public Pages(IWebDriver driver, Interaction interaction)
        {
            Driver = driver;
            Interaction = interaction;

            CollectorSourceConfiguration = new(driver, interaction);

            //DemoQA
            HomePage = new(driver, interaction);
            FormsPage = new(driver, interaction);
            PracticeFormPage = new(driver, interaction);
            LinksPage = new(driver, interaction);
            LoginPage = new(driver, interaction);
            BookStorePage = new(driver, interaction);
            ProfilePage = new(driver, interaction);
            Shared = new(driver, interaction);

        }
    }
}
