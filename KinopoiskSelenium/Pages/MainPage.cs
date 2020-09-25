using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace KinopoiskSelenium.Pages
{
    public class MainPage
    {
        private IWebDriver _driver;
        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Войти')]")]
        public IWebElement LoginButton { get; set; }

        public RegistrationPage GoToLoginPage()
        {
            LoginButton.Click();
            return new RegistrationPage(_driver);
        }
    }
}
