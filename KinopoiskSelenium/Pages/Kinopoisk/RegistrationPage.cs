using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace KinopoiskSelenium.Pages.Kinopoisk
{
    public class RegistrationPage : BasePage
    {
        private readonly string _validLogin = "test.selenium2002";
        private readonly string _validPassword = "selenium123";
        private readonly string _invalidPassword = "selenium124";
        private By LoginField { get; } = By.Id("passp-field-login");
        private By PasswordField { get; } = By.Id("passp-field-passwd");
        private By SubmitButton { get; } = By.XPath("//button[@type='submit']");
        private By InvalidPasswordMessage { get; } = By.XPath("//div[contains(text(),\"Неверный пароль\")]");
        public RegistrationPage(ConciseApi conciseApi) : base(conciseApi)
        {
        }

        public T LoginWithCredentials<T>(bool isValidCredentials) where T : BasePage
        {
            var password = isValidCredentials ? _validPassword : _invalidPassword;
            InsertLoginAndSubmit(_validLogin);
            InsertPasswordAndSubmit(password);
            return isValidCredentials ? new MainPage(ConciseApi) as T : this as T;
        }
        private void InsertLoginAndSubmit(string login)
        {
            ConciseApi.InsertText(LoginField, login);
            ClickButton(SubmitButton);
        }

        private void InsertPasswordAndSubmit(string password)
        {
            ConciseApi.InsertText(PasswordField, password);
            ClickButton(SubmitButton);
        }
        
        private void ClickButton(By button)
        {
            ConciseApi.Click(button);
        }

        public bool IsUserNotLoggedIn()
        {
            return ConciseApi.AssertThat(ExpectedConditions.InvisibilityOfElementLocated(InvalidPasswordMessage));
        }

        public override void OpenPage()
        {
            throw new NotImplementedException();
        }
    }
}
