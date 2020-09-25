using System;
using KinopoiskSelenium.Pages;
using NUnit.Framework;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace KinopoiskSelenium
{
    [TestFixture]
    public class Kinopoisk
    {
        public IWebDriver Driver;

        [SetUp]
        public void Initialize()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.kinopoisk.ru");
        }


        [Test]
        public void TestMethod1()
        {
            //IWebElement loginButton = Driver.FindElement(By.XPath("//button[contains(text(),'Войти')]"));
            //loginButton.Click();
            MainPage mainPage = new MainPage(Driver);
            RegistrationPage registrationPage = mainPage.GoToLoginPage();
            RegistrationPageSecond registrationPageSecond = registrationPage.InsertLoginAndSubmit();
            registrationPageSecond.InsertPasswordAndSubmit();

            Console.WriteLine("Test passed");
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
