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


        public List<String> GetAllCellValuesInColumn(int column)
        {
            var rawValues = Interaction.GetElements(By.XPath($"//div[@class='rt-tbody']//div[contains(@class,'rt-tr') and @role='row']/div[@class='rt-td'][{column}]"));

            return rawValues.Where(x => !String.IsNullOrWhiteSpace(x.Text)).Select(x => x.Text).ToList();
        }

        public IList<IWebElement> GetCellByColumnValue(int column, string value)
        {
            return Interaction.GetElements(By.XPath($"//tr/td[{column} and text() = '{value}']"));
        }

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
