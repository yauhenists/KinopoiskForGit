using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace KinopoiskSelenium
{
    public class ConciseApi
    {
        private IWebDriver Driver { get; }
        private DefaultWait<IWebDriver> Wait { get; }

        public ConciseApi(IWebDriver driver)
        {
            Driver = driver;
            Wait = new DefaultWait<IWebDriver>(Driver)
            {
                PollingInterval = TimeSpan.FromMilliseconds(250),
                Timeout = TimeSpan.FromSeconds(7)
            };
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
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

        public T AssertThat<T>(Func<IWebDriver, T> condition)
        {
            return Wait.Until(condition);
        }
    }
}
