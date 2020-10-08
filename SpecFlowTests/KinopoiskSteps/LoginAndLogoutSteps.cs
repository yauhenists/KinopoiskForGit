using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoDi;
using KinopoiskSelenium;
using KinopoiskSelenium.Pages.Kinopoisk;
using KinopoiskSelenium.Tests.Kinopoisk;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowTests.KinopoiskSteps
{
    [Binding]
    public sealed class LoginAndLogoutSteps
    {
        private readonly IObjectContainer _container;

        private readonly ConciseApi _conciseApi;

        private MainPage _mainPage;

        private RegistrationPage _registrationPage;
        //private readonly 

        public LoginAndLogoutSteps(IObjectContainer container, ConciseApi conciseApi)
        {
            _container = container;
            //_conciseApi = container.Resolve<ConciseApi>();
            _conciseApi = conciseApi;
        }

        [Given(@"I have opened home page")]
        public void GivenIHaveOpenedHomePage()
        {
            _mainPage = new MainPage(_conciseApi);
        }

        [Given(@"Go to registration page")]
        public void GivenGoToRegistrationPage()
        {
            _registrationPage = _mainPage.GoToLoginPage();
        }

        [When(@"I login with credentials")]
        public void WhenILoginWithCredentials(Table table)
        {
            dynamic credentials = table.CreateDynamicInstance();
            _registrationPage.LoginWithCredentials(credentials.Login, credentials.Password);
        }

        [Then(@"I should see avatar button on reloaded home page")]
        public void ThenIShouldSeeAvatarButtonOnReloadedHomePage()
        {
            Assert.IsTrue(_mainPage.IsUserLoggedIn());
        }

        [Then(@"I should see validation message")]
        public void ThenIShouldSeeValidationMessage()
        {
            Assert.IsTrue(_registrationPage.IsUserNotLoggedIn());
        }


    }
}
