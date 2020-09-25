using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinopoiskSelenium.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace KinopoiskSelenium.Pages
{
    public class RegistrationPageSecond : RegistrationPage
    {
        public RegistrationPageSecond(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "passp-field-passwd")]
        public IWebElement PasswordField { get; set; }

        public void InsertPasswordAndSubmit()
        {
            //PageFactory.InitElements(_driver, this);
            PasswordField.SendKeys(ValidPassword);
            ClickButton(SubmitButton);
        }
    }
}
