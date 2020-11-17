using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoDi;
using KinopoiskSelenium;
using KinopoiskSelenium.Pages.ToolsQA;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowTests.ToolsQASteps
{
    [Binding]
    public sealed class TooltipsSteps
    {
        private readonly IObjectContainer _container;
        private ConciseApi _conciseApi;
        private ToolTipsPage _page;

        public TooltipsSteps(IObjectContainer container)
        {
            _container = container;
            _conciseApi = _container.Resolve<ConciseApi>();
        }

        [Given(@"I have opened tooltips page")]
        public void GivenIHaveOpenedTooltipsPage()
        {
            _page = new ToolTipsPage(_conciseApi);
        }

        [When(@"I hover mouse over button")]
        public void WhenIHoverMouseOverButton()
        {
            _page.MoveCursorOnTooltipButton();
        }

        [Then(@"I see tooltip with text (.*)")]
        public void ThenISeeTooltipWithText(string tooltipText)
        {
            StringAssert.AreEqualIgnoringCase(tooltipText, _page.GetTooltipText());
        }

    }
}
