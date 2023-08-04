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

        #region Table Columns
        public int FirstNameColumn = 1;
        public int LastNameColumn = 2;
        public int AgeColumn = 3;
        public int EmailColumn = 4;
        public int Salary = 5;
        public int Department = 6;
        #endregion


        //need to add a function that checks value by column--

        //one more test needed for Iframes as well

        public void DeleteRowByCellValue(string value)
        {
            Interaction.ClickElement(By.XPath($"(//div[@class='rt-td' and text() = '{value}']/following-sibling::div[@class='rt-td'])[last()]//span[contains(@id, 'delete-record')]"));
        }
        
        public void EditRowByCellValue(string value, string firstname, string lastname, string email, int age, double salary, string department)
        {
            Interaction.ClickElement(By.XPath($"(//div[@class='rt-td' and text() = '{value}']/following-sibling::div[@class='rt-td'])[last()]//span[contains(@id, 'edit-record')]"));
        }

        public By GetCellByRowAndColumn(int row, int column)  
        {
            return By.XPath($"(//div[@class='rt-tbody']//div[@role='row'])[{row}]/div[@role='gridcell'][{column}]");
        }


    }
}
