using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamitey.DynamicObjects;
using Gherkin.Events.Args.Pickle;
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
        private Actions Actions { get; set; }
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
            Wait.IgnoreExceptionTypes(typeof(NoAlertPresentException));
        }

        public void Open(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public IWebElement GetElement(By element)
        {
            return AssertThat(d => d.FindElement(element));
        }

        public IWebElement GetElement(IWebElement baseElement, By element)
        {
            return AssertThat(d => baseElement.FindElement(element));
        }

        public List<IWebElement> GetElements(By element)
        {
            return AssertThat(d => d.FindElements(element)).ToList();
        }

        public List<IWebElement> GetElements(IWebElement basElement, By element)
        {
            return AssertThat(d => basElement.FindElements(element)) .ToList();
        }

        public void Click(By element)
        {
            GetElement(element).Click();
        }

        public void ClickViaActions(By element)
        {
            Actions actions = new Actions(Driver);
            actions.Click(GetElement(element)).Perform();
        }

        public void WriteParticularRowWithColumnsForTable(By table, int row)
        {
            //the first column is skipped
            var tableElement = GetElement(table);

            List<string> columns = GetElements(tableElement, By.XPath(".//thead//th")).Select(x => x.Text).ToList();
            columns.RemoveAt(0);

            var rowsNumber = GetElements(tableElement, By.XPath(".//tbody/tr")).Count;

            if (rowsNumber == 0)
            {
                Console.WriteLine("No results of search");
                return;
            }

            if (row > rowsNumber)
            {
                row = rowsNumber;
            }

            List<string> rowsExceptLastColumn =
                GetElements(tableElement, By.XPath($".//tbody/tr[{row}]/td//div[@class='tooltip-info-header']"))
                    .Select(x => x.Text).ToList();

            var price = GetElement(tableElement, By.XPath($".//tbody/tr[{row}]//td[@class='price']/span[1]")).Text;

            for (int i = 0; i < columns.Count -1; i++)
            {
                Console.WriteLine(columns[i] + " - " + rowsExceptLastColumn[i]);
            }

            Console.WriteLine($"Price is \"{price}\"");
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
            SetActions();
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

        public void SelectCheckBox(params By[] checkBoxes)
        {
            SetActions();
            var elements = new List<IWebElement>();
            foreach (var checkBox in checkBoxes)
            {
                var element = GetElement(checkBox);
                elements.Add(element);

                if (element.Selected)
                {
                    Console.WriteLine("CheckBox is already selected. This action will uncheck it");
                }

                Actions.Click(element).Build();
            }

            Actions.Perform();
            
        }

        public bool IsElementSelected(By element)
        {
            return GetElement(element).Selected;
        }

        public void SelectDropDownByIndex(By element, int index)
        {
            SelectElement select = new SelectElement(GetElement(element));
            select.SelectByIndex(index);
        }

        public void SelectDropDownByText(By element, string text)
        {
            SelectElement select = new SelectElement(GetElement(element));
            select.SelectByText(text);
        }

        public void SelectDropDownByValue(By element, string value)
        {
            SelectElement select = new SelectElement(GetElement(element));
            select.SelectByValue(value);
        }

        public string GetSelectElementTextFromDropDown(By element)
        {
            SelectElement select = new SelectElement(GetElement(element));
            return select.SelectedOption.Text;
        }

        public bool IsMultiSelectDropDown(By element)
        {
            return new SelectElement(GetElement(element)).IsMultiple;
        }

        public List<string> GetListOfSelectedOptions(By element)
        {
            SelectElement select = new SelectElement(GetElement(element));
            var list = select.AllSelectedOptions;
            var cars = new List<string>();
            Console.WriteLine("Selected items:");
            foreach (var item in list)
            {
                cars.Add(item.Text);
                Console.WriteLine(item.Text);
            }

            return cars;
        }

        public string GetTextOfTheElement(By element)
        {
            return GetElement(element).Text;
        }

        public void EnterText(By element, string text)
        {
            GetElement(element).SendKeys(text);
        }

        public int GetCountOfElements(By element)
        {
            return GetElements(element).Count;
        }

        public T AssertThat<T>(Func<IWebDriver, T> condition)
        {
            return Wait.Until(condition);
        }

        public IAlert GetAlert()
        {
            return AssertThat(d => d.SwitchTo().Alert());
        }

        private void PerformClickViaActions(params IWebElement[] elements)
        {
            foreach (var element in elements)
            {
                Actions.Click(element);
            }

            Actions.Build().Perform();
        }

        private void SetActions()
        {
            Actions = new Actions(Driver);
        }
    }
}
