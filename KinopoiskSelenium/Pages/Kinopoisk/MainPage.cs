using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace KinopoiskSelenium.Pages.Kinopoisk
{
    public class MainPage : BasePage
    {
        private By LoginButton { get; } = By.XPath("//button[contains(text(),'Войти')]");
        private By AvatarButton { get; } = By.XPath("//div//div//div//div//div//button//div//div");

        public MainPage(ConciseApi conciseApi) : base(conciseApi)
        {
            OpenPage();
        }

        public RegistrationPage GoToLoginPage()
        {
            ConciseApi.Click(LoginButton);
            
            return new RegistrationPage(ConciseApi);
        }

        public bool IsUserLoggedIn()
        {
            return ConciseApi.AssertThat(ExpectedConditions.ElementExists(AvatarButton)).Enabled;
        }

        public sealed override void OpenPage()
        {
            ConciseApi.Open("https://www.kinopoisk.ru");
        }
     
    }
}
