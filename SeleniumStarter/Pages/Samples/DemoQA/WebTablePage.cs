using OpenQA.Selenium;
using SeleniumStarter.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Pages.Samples.DemoQA
{
    public class WebTablePage : PageBase
    {
        public WebTablePage(IWebDriver driver, Interaction interaction) : base(driver, interaction) { }

        public readonly String Route = "/webtables";

        public By AddNewRecordButton => By.Id("addNewRecordButton");
        public By SearchBoxInput => By.Id("searchBox");

        #region Registration Form Fields
        public By FirstName => By.Id("firstName");
        public By LastName => By.Id("lastName");
        public By UserEmailInput => By.Id("userEmail");
        public By AgeInput => By.Id("age");
        public By SalaryInput => By.Id("salary");
        public By DepartmentInput => By.Id("department");
        public By SubmitButton => By.Id("submit");

        #endregion

        public By GetCelleByRowAndColumn(int row, int column)  
        {
            return By.XPath($"(//div[@class='rt-tbody']//div[@role='row'])[{row}]/div[@role='gridcell'][{column}]");
        }


    }
}
