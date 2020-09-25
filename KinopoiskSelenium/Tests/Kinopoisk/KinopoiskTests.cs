using System;
using KinopoiskSelenium.Pages;
using KinopoiskSelenium.Pages.Kinopoisk;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KinopoiskSelenium.Tests.Kinopoisk
{
    [TestFixture]
    public class KinopoiskTests : BaseTest
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            MainPage mainPage = new MainPage(ConciseApi);
            RegistrationPage registrationPage = mainPage.GoToLoginPage();
            mainPage = registrationPage.LoginWithCredentials<MainPage>(true);

            Assert.True(mainPage.IsUserLoggedIn());
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            MainPage mainPage = new MainPage(ConciseApi);
            RegistrationPage registrationPage = mainPage.GoToLoginPage();
            registrationPage.LoginWithCredentials<RegistrationPage>(false);

            Assert.True(registrationPage.IsUserNotLoggedIn());
        }


    }
}
