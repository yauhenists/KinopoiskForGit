using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace KinopoiskSelenium.Tests
{
    public abstract class BaseTest
    {
        public ConciseApi ConciseApi { get; private set; }
        public IWebDriver Driver { get; private set; }

        public BaseTest()
        {
            Driver = new ChromeDriver();
            ConciseApi = new ConciseApi(Driver);
        }

        [SetUp]
        public void SetUp()
        {
            //Driver = new ChromeDriver();
            //ConciseApi = new ConciseApi(Driver);
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
