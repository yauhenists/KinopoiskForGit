using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using KinopoiskSelenium;
using KinopoiskSelenium.Tests.Kinopoisk;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowTests
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _container;
        private KinopoiskTests _tests;
        private IWebDriver _driver;

        //private ConciseApi _conciseApi;
        //private IWebDriver _driver;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _tests = new KinopoiskTests();
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
