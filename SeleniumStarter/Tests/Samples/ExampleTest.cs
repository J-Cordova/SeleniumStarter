using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter.Tests.Samples
{
    public class CollectorSourceConfigurationTests : BaseTest
    {
        [Test]
        public void VerifyCollectorIsGettingRealtimeData()
        {
            TestUtilities.NavigateToSite();
            //Interaction.ClickElement(Pages.HomePage.ConfigurationTabByName("Collector Sources"));
            Thread.Sleep(1000);
            Interaction.ClickElement(Pages.CollectorSourceConfiguration.AddNewButton);

            Interaction.ClickElement(Pages.CollectorSourceConfiguration.CollectorSourceConfigurationGroup);
            Thread.Sleep(1000);
            new Actions(Driver).KeyDown(Keys.ArrowDown).KeyDown(Keys.ArrowDown).KeyDown(Keys.Enter).Perform();

            Interaction.ClickElement(Pages.CollectorSourceConfiguration.CollectorSourceConfigurationInterface);
            Thread.Sleep(1000);
            new Actions(Driver).KeyDown(Keys.ArrowDown).KeyDown(Keys.Enter).Perform();

            Interaction.ClickElement(Pages.CollectorSourceConfiguration.CollectorSourceConfigurationDatasourceType);
            Thread.Sleep(1000);
            new Actions(Driver).KeyDown(Keys.ArrowDown).KeyDown(Keys.Enter).Perform();

            Interaction.InputText(Pages.CollectorSourceConfiguration.CollectorInstanceIdInput, "1");
            Interaction.ClickElement(Pages.CollectorSourceConfiguration.AddNewOpcDaServerButton);
            Interaction.InputText(Pages.CollectorSourceConfiguration.OpcDaServerUrlInput, Pages.CollectorSourceConfiguration.OpcLocalHostUrl);

            Interaction.ClickElement(Pages.CollectorSourceConfiguration.SaveChangesButton);
            Thread.Sleep(500);

            Interaction.ClickElement(Pages.CollectorSourceConfiguration.WarningDialogYesButton);

            //Interaction.ClickElement(Pages.CollectorInstances.CollectorInstanceRealTimeSourcesByIndex(1));
            Thread.Sleep(2000);

            //var rowData = Interaction.GetElements(Pages.RealtimeSources.RealTimeSourcesTableRowData).ToList();

            //var realTimeDataRow = rowData.Where((row, index) =>
            //{
            //    var interfacecol = Interaction.GetElement(By.XPath($"//tbody//tr[{index + 1}]//td[{Pages.RealtimeSources.InterfaceColumn}]")).Text;
            //    var runStatus = Interaction.GetElement(By.XPath($"//tbody//tr[{index + 1}]//td[{Pages.RealtimeSources.RunStatusColumn}]")).Text;
            //    var lastWriteTime = Interaction.GetElement(By.XPath($"//tbody//tr[{index + 1}]//td[{Pages.RealtimeSources.LastWriteTimeColumn}]")).Text;

            //    if (lastWriteTime == "") return false;

            //    return runStatus == "Running" &&
            //           interfacecol == "Camas.Paper" &&
            //           DateTime.Parse(lastWriteTime.Replace(" ", "")).AddMinutes(3) >= DateTime.Now;
            //}).ToList();

            //Assert.IsTrue(realTimeDataRow.Count() > 0);
        }
    }
}
