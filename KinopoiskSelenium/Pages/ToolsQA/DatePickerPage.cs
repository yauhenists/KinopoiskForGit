using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace KinopoiskSelenium.Pages.ToolsQA
{
    public class DatePickerPage : BasePage
    {
        private string _url = "https://demoqa.com/date-picker";
        private By _selectDateField = By.Id("datePickerMonthYearInput");

        private By _datePickerPrevious = By.XPath("//button[text()='Previous Month']");
        private By _datePickerNext = By.XPath("//button[text()='Next Month']");

        private By _datePickerCurrentMontYear =
            By.XPath("//*[contains(concat(' ',@class,' '), 'current-month--hasMonthDropdown')]");
        public DatePickerPage(ConciseApi conciseApi) : base(conciseApi)
        {
            OpenPage();
        }

        public override void OpenPage()
        {
            ConciseApi.Open(_url);
        }

        public void OpenDatePicker()
        {
            ConciseApi.Click(_selectDateField);
        }

        public void GetPreviousMonth(bool previous = true)
        {
            if (previous)
            {
                ConciseApi.Click(_datePickerPrevious);
            }
            else
            {
                ConciseApi.Click(_datePickerNext);
            }
        }

        public string GetDateFromDatePicker()
        {
            return ConciseApi.GetTextOfTheElement(_datePickerCurrentMontYear);
        }
    }
}
