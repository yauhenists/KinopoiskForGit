using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace KinopoiskSelenium
{
    public class ConciseApi
    {
        private IWebDriver Driver { get; }
        private DefaultWait<IWebDriver> Wait { get; }
        private Actions Actions { get; }
        private List<IWebElement>_checkedElements = new List<IWebElement>();

        public ConciseApi(IWebDriver driver)
        {
            Driver = driver;
            Wait = new DefaultWait<IWebDriver>(Driver)
            {
                PollingInterval = TimeSpan.FromMilliseconds(250),
                Timeout = TimeSpan.FromSeconds(9)
            };
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Actions = new Actions(Driver);
        }

        public void Open(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public IWebElement GetElement(By element)
        {
            return AssertThat(d => d.FindElement(element));
        }

        public void Click(By element)
        {
            GetElement(element).Click();
        }

        public void InsertText(By element, string text)
        {
            GetElement(element).SendKeys(text);
        }

        public string GetUrl()
        {
            return Driver.Url;
        }

        public string GetSourceCode()
        {
            return Driver.PageSource;
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }

        public void SelectRadioButton(By radioButton)
        {
            var button = GetElement(radioButton);
            if (button.Selected)
            {
                Console.WriteLine("Radio button is already selected");
            }
            else
            {
                PerformClickViaActions(button);
            }
        }

        public void SelectCheckBox(By checkBox)
        {
            var checkboxel = GetElement(checkBox);
            if (checkboxel.Selected)
            {
                Console.WriteLine("CheckBox is already selected. This action will uncheck it");
            }
            else
            {
                _checkedElements.Add(checkboxel);
                foreach (var el in _checkedElements)
                {
                    PerformClickViaActions(checkboxel);
                }
                Actions.Perform();
            }
        }

        public bool IsElementSelected(By element)
        {
            return GetElement(element).Selected;
        }

        public T AssertThat<T>(Func<IWebDriver, T> condition)
        {
            return Wait.Until(condition);
        }

        private void PerformClickViaActions(IWebElement element)
        {
            Actions.MoveToElement(element).Click();
            if (element.Selected)
            {
                return;
            }
            Actions.MoveToElement(element).Click();//.Perform();
            //Actions.Perform();
        }
    }
}
