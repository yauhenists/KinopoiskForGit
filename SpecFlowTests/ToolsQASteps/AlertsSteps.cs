using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoDi;
using KinopoiskSelenium;
using KinopoiskSelenium.Pages.ToolsQA;
using KinopoiskSelenium.Tests.ToolsQA;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowTests.ToolsQASteps
{
    [Binding]
    public sealed class AlertsSteps
    {
        private readonly ConciseApi _conciseApi;
        private readonly AlertsTests _tests;
        private AlertsPage _page;

        public AlertsSteps(IObjectContainer container)
        {
            _conciseApi = container.Resolve<ConciseApi>();
        }

        [Given(@"I have opened alerts page")]
        public void GivenIHaveOpenedAlertsPage()
        {
            _page = new AlertsPage(_conciseApi);
        }

        [When(@"I click simple alert button")]
        public void WhenIClickSimpleAlertButton()
        {
            _page.OpenAlert();
        }

        [Then(@"I see alerts text (.*)")]
        public void ThenISeeAlertsTextYouClickedAButton(string text)
        {
            Assert.True(_page.AlertText == text, $"Actual text is {_page.AlertText}");
        }

        [Then(@"I confirm alert")]
        public void ThenIConfirmAlert()
        {
            _page.ConfirmAlert();
        }

        [When(@"I click confirm alert button")]
        public void WhenIClickConfirmAlertButton()
        {
            _page.OpenConfirmAlert();
        }

        [Then(@"I confirm confirmation alert")]
        public void ThenIConfirmConfirmationAlert()
        {
            _page.ActConfirmationAlert(true);
        }

        [Then(@"I see text of confirmation (.*)")]
        public void ThenISeeTextOfConfirmation(string text)
        {
            if (String.Equals(text, "is empty"))
            {
                Assert.True(_page.ConfirmationResult == String.Empty, $"Actual text is {_page.ConfirmationResult}");
            }
            else
            {
                Assert.True(_page.ConfirmationResult == text, $"Actual text is {_page.ConfirmationResult}");
            }
            
        }

        [When(@"I cancel confirmation alert")]
        public void WhenICancelConfirmationAlert()
        {
            _page.ActConfirmationAlert(false);
        }

        [When(@"I click prompt alert button")]
        public void WhenIClickPromptAlertButton()
        {
            _page.OpenPromptAlert();
        }

        [Then(@"I confirm prompt alert")]
        public void ThenIConfirmPromptAlert()
        {
            _page.ActPromptAlert(true);
        }

        [When(@"I cancel prompt alert")]
        public void WhenICancelPromptAlert()
        {
            _page.ActPromptAlert(false);
        }

        [When(@"I click timer alert button")]
        public void WhenIClickTimerAlertButton()
        {
            _page.OpenTimerAlert();
        }

        [Then(@"I confirm timer alert")]
        public void ThenIConfirmTimerAlert()
        {
            ThenIConfirmAlert();
        }

        [Then(@"Time of alert appearing is (.*) seconds")]
        public void ThenTimeOfAlertAppearingIsSeconds(int seconds)
        {
            Assert.AreEqual(seconds, _page.Seconds, $"Actual number of seconds is {_page.Seconds}");
        }

    }
}
