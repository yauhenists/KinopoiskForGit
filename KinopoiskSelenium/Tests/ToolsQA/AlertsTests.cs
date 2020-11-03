using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinopoiskSelenium.Pages.ToolsQA;
using NUnit.Framework;

namespace KinopoiskSelenium.Tests.ToolsQA
{
    [TestFixture]
    public class AlertsTests : BaseTest
    {
        [Test]
        public void SimpleAlertTest()
        {
            AlertsPage page = new AlertsPage(ConciseApi);
            page.OpenAlert();
            page.ConfirmAlert();
        }

        [Test]
        public void TimerAlertTest()
        {
            AlertsPage page = new AlertsPage(ConciseApi);
            page.OpenTimerAlert();
            page.ConfirmAlert();
        }

        [Test]
        public void ConfirmAlertTest()
        {
            AlertsPage page = new AlertsPage(ConciseApi);
            page.OpenConfirmAlert();
            page.ActConfirmationAlert(true);
            page.OpenConfirmAlert();
            page.ActConfirmationAlert(false);
        }

        [Test]
        public void PromptAlertTest()
        {
            AlertsPage page = new AlertsPage(ConciseApi);
            page.OpenPromptAlert();
            page.ActPromptAlert(true);
            page.OpenPromptAlert();
            page.ActPromptAlert(false);
        }
    }
}
