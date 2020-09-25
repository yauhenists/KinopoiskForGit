using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace KinopoiskSelenium.Pages
{
    public class RegistrationPage
    {
        private readonly string _validLogin = "test.selenium2002";
        protected readonly string ValidPassword = "selenium123";
        private readonly string _invalidPassword = "selenium124";
        private IWebDriver _driver;
        public RegistrationPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "passp-field-login")]
        public IWebElement LoginField { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement SubmitButton { get; set; }


        public RegistrationPageSecond InsertLoginAndSubmit()
        {
            LoginField.SendKeys(_validLogin);
            ClickButton(SubmitButton);
            return new RegistrationPageSecond(_driver);
        }

        

        protected void ClickButton(IWebElement button)
        {
            button.Click();
        }

    }
}
