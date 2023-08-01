using OpenQA.Selenium;
using SeleniumStarter.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Pages.Samples
{
    public class CollectorSourceConfiguration : PageBase
    {
        public CollectorSourceConfiguration(IWebDriver driver, Interaction interaction) : base(driver, interaction) { }

        public readonly string OpcLocalHostUrl = "opcda://vvq-dataserver.parcqa.com/HistorianPlayback.Paper.1";
        public By AddNewButton => By.XPath($"//span[text() ='Add New']/..");
        public By CollectorSourceConfigurationGroup => By.XPath($"(//*[@class = 'k-input-value-text'])[1]");
        public By CollectorSourceConfigurationInterface => By.XPath($"(//*[@class = 'k-input-value-text'])[2]");
        public By CollectorSourceConfigurationDatasourceType => By.XPath($"(//*[@class = 'k-input-value-text'])[3]");
        public By CollectorInstanceIdInput => By.XPath($"(//td[text() = 'Collector Instance Id']/following::input)[1]");
        public By AddNewOpcDaServerButton => By.XPath($"//span[text() = 'Add New']");
        public By OpcDaServerUrlInput => By.XPath($"(//td[text() = 'Opc Da Server(s)']/following-sibling::td[1]//input)[2]");
        public By SaveChangesButton => By.XPath($"//span[text() = 'Save Changes']");
        public By WarningDialog => By.XPath($"//div[contains(@class, 'k-window-title') and text() = 'Warning']");
        public By WarningDialogYesButton => By.XPath($"//div[contains(@class, 'k-dialog-content')]//*[text()='Yes']");
        public By WarningDialogNoButton => By.XPath($"//div[contains(@class, 'k-dialog-content')]//*[text()='No']");

    }
}
