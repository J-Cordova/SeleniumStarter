using FluentAssertions;
using SeleniumStarter.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Tests.Samples.DemoQA
{
    public class WebTableTests : BaseTest
    {
        [Test]
        public void TableDefaultUsersArePresent()
        {
            var DefaultFirstNameRecords = new List<string>() { "Cierra", "Alden", "Kierra" };

            Driver.Navigate().GoToUrl(Pages.HomePage.Url + Pages.WebTablePage.Route);

            var cellValues = Pages.WebTablePage.GetAllCellValuesInColumn(Pages.WebTablePage.FirstNameColumn);

            DefaultFirstNameRecords.Should().Contain(cellValues);
        }
    }
}
