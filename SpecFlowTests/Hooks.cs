using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using KinopoiskSelenium;
using KinopoiskSelenium.Tests;
using KinopoiskSelenium.Tests.Kinopoisk;
using KinopoiskSelenium.Tests.ToolsQA;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowTests
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _container;
        private readonly BaseTest _tests;
        private IWebDriver _driver;

        //private ConciseApi _conciseApi;
        //private IWebDriver _driver;

        public Hooks(IObjectContainer container, BaseTest tests)
        {
            _container = container;
            _tests = tests;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //_tests = new KinopoiskTests();
            //_tests = new PracticeFormTests();
            //_conciseApi = _tests.ConciseApi;
            _driver = _tests.Driver;
            //_container.RegisterInstanceAs(_tests);
            _container.RegisterInstanceAs(_driver);
            _tests.SetUp();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _tests.TearDown();
        }
    }
}
