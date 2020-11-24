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
    public sealed class DatePickerSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ConciseApi _conciseApi;
        private DatePickerPage _page;
        private string _date;

        public DatePickerSteps(IObjectContainer _objectContainer)
        {
            _objectContainer = _objectContainer;
            _conciseApi = _objectContainer.Resolve<ConciseApi>();
        }

        [Given(@"I have opened DatePicker page")]
        public void GivenIHaveOpenedDatePickerPage()
        {
            _page = new DatePickerPage(_conciseApi);
        }

        [When(@"I Open DatePicker")]
        public void WhenIOpenDatePicker()
        {
            _page.OpenDatePicker();
        }

        [Then(@"I should see DatePicker component")]
        public void ThenIShouldSeeDatePickerComponent()
        {
            Assert.True(_page.IsDatePickerPresented());
        }

        [When(@"I select date (.*)")]
        public void WhenISelectDate(string date)
        {
            _date = date;
            _page.SelectDateInDatePicker(date);
        }

        [Then(@"I should see selected date in date field")]
        public void ThenIShouldSeeSelectedDateInDateField()
        {
            Assert.AreEqual(StringHelper.GetDateTime(_date), _page.GetSelectedDate());
        }

        [Then(@"I should not see DatePicker component")]
        public void ThenIShouldNotSeeDatePickerComponent()
        {
            Assert.False(_page.IsDatePickerPresented());
        }

        [When(@"I select previous month")]
        public void WhenISelectPreviousMonth()
        {
            _page.GetPreviousMonth();
        }

        [Then(@"I should see current moth and year in DatePicker")]
        public void ThenIShouldSeeCurrentMothAndYearInDatePicker()
        {
            Assert.AreEqual(StringHelper.GetMonthYearInEnglish(), _page.GetDateFromDatePicker());
        }


        [Then(@"I should see correct moth and year in DatePicker")]
        public void ThenIShouldSeeCorrectMothAndYearInDatePicker()
        {
            Assert.AreEqual(StringHelper.GetMonthYearInEnglish(-1), _page.GetDateFromDatePicker());
        }

        

    }
}
