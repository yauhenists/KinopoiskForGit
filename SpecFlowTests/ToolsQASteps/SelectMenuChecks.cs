using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dynamitey;
using KinopoiskSelenium;
using KinopoiskSelenium.Pages.ToolsQA;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowTests.ToolsQASteps
{
    [Binding]
    public sealed class SelectMenuChecks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ConciseApi _conciseApi;
        private SelectMenuPage _page;
        private List<string> _cars = new List<string>();

        public SelectMenuChecks(ScenarioContext scenarioContext, ConciseApi conciseApi)
        {
            _scenarioContext = scenarioContext;
            _conciseApi = conciseApi;
        }

        [Given(@"I have opened Select Menu page")]
        public void GivenIHaveOpenedSelectMenuPage()
        {
            _page = new SelectMenuPage(_conciseApi);
        }

        [When(@"I select (.*) style select menu")]
        public void WhenISelectStyleSelectMenu(string colour)
        {
            _page.SelectInOldStyleSelectMenu(colour);
        }

        [When(@"I select (.*) title")]
        public void WhenISelectTitle(string title)
        {
            _page.SelectTitle(title);
        }

        [When(@"I select cars")]
        public void WhenISelectCars(Table table)
        {
            dynamic carsTable = table.CreateDynamicInstance();
            foreach (var car in carsTable)
            {
                _page.SelectCar(car.Value, true);
                _cars.Add(car.Value);
            }
        }

        [Then(@"Selected style is (.*)")]
        [Scope(Tag = "SimpleDropDown")]
        public void ThenSelectedStyleIs(string colour)
        {
            Assert.True(_page.SelectedItemText == colour, $"Actual selected colour is {_page.SelectedItemText}");
        }

        [Then(@"Selected title is (.*)")]
        public void ThenSelectedTitleIs(string title)
        {
            Assert.True(_page.SelectedItemText == title, $"Actual selected title is {_page.SelectedItemText}");
        }

        [Then(@"All selected cars are matched")]
        public void ThenAllSelectedCarsAreMatched()
        {
            Console.WriteLine("The list of selected cars:");
            _page.WriteSelectedCars();
            //_cars.Remove("Volvo");
            //var res = _page.SelectedCars.Where(x => !_cars.Contains(x)).ToList();
            Assert.False(_page.SelectedCars.Where(x => !_cars.Contains(x)).ToList().Any());
            
        }
    }
}
