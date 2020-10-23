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
    public class Hooks//<T> where T : BaseTest, new()
    {
        private readonly IObjectContainer _container;
        private PracticeFormTests _tests;
        private IWebDriver _driver;
        private ConciseApi _conciseApi;

        //private ConciseApi _conciseApi;
        //private IWebDriver _driver;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //_tests = new KinopoiskTests();
            //_tests = new PracticeFormTests();
            //_conciseApi = _tests.ConciseApi;
            //_tests = _container.Resolve<IBaseTest>();
            _tests = _container.Resolve<PracticeFormTests>();
            _conciseApi = _tests.ConciseApi;
            _driver = _tests.Driver;
            //_container.RegisterInstanceAs(_tests);
            _container.RegisterInstanceAs(_driver);
            _container.RegisterInstanceAs(_conciseApi);
            _tests.SetUp();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _tests.TearDown();
        }
    }
}
