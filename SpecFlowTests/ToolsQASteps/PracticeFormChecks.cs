using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoDi;
using KinopoiskSelenium;
using KinopoiskSelenium.Tests.ToolsQA;
using TechTalk.SpecFlow;
using KinopoiskSelenium.Pages.ToolsQA;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SpecFlowTests.ToolsQASteps
{
    [Binding]
    public sealed class PracticeFormChecks
    {
        private readonly IObjectContainer _container;
        private readonly ConciseApi _conciseApi;
        private readonly PracticeFormTests _tests;
        private PracticeFormPage _page;
        private Gender _gender;
        private Hobbies _firstHobby;
        private Hobbies _secondHobby;

        public PracticeFormChecks(IObjectContainer container, PracticeFormTests tests)
        {
            _container = container;
            _tests = tests;
            _conciseApi = _container.Resolve<ConciseApi>();
            //_container.RegisterInstanceAs(_tests.ConciseApi);
        }

        [Given(@"I have opened Practice Form page")]
        public void GivenIHaveOpenedPracticeFormPage()
        {
            _page = new PracticeFormPage(_conciseApi);
        }


        [When(@"I select (.*) Gender")]
        public void WhenISelectGender(string gender)
        {
            if (Enum.TryParse(gender, out _gender))
            {
                _page.SelectRadioButton(_gender);
            }

            else
            {
                Console.WriteLine("Gender is not valid");
            }

            _page.SelectRadioButton(_gender);
            
        }

        [Then(@"It's selected")]
        public void ThenItSSelected()
        {
            Console.WriteLine($"Selected Gender is {_gender}");
            Assert.IsTrue(_page.IsRadioButtonSelected(_gender));
        }

        [When(@"I select (.*) and (.*) As Hobbies")]
        public void WhenISelectSportsAndReadingAsHobbies(string firstHobby, string secondHobby)
        {
            if (Enum.TryParse(firstHobby, out _firstHobby) && Enum.TryParse(secondHobby, out _secondHobby))
            {
                _page.SelectCheckBox(_firstHobby, _secondHobby);
            }
            else
            {
                Console.WriteLine("Not valid hobby or hobbies");
            }
            
        }

        [Then(@"They are selected")]
        public void ThenTheyAreSelected()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(_page.IsCheckBoxSelected(_firstHobby));
                Assert.IsTrue(_page.IsCheckBoxSelected(_secondHobby));
            });
        }


    }
}
