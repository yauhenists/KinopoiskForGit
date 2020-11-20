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

        private By _datePickerCurrentMonthByYear =
            By.XPath("//*[contains(concat(' ',@class,' '), 'current-month--hasMonthDropdown')]");

        private By _datePicker = By.ClassName("react-datepicker__month-container");
        private By _datePickerMonth = By.ClassName("react-datepicker__month-select");
        private By _datePickerYear = By.ClassName("react-datepicker__year-select");

        private By _datePickerDay =
            By.XPath("//*[contains(concat(' ',@class,' '), 'react-datepicker__day react-datepicker__day')]");

        private By _datePickerDate =
            By.XPath("//*[contains(concat(' ',@class,' '), 'react-datepicker__day react-datepicker__day')]");

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
            return ConciseApi.GetTextOfTheElement(_datePickerCurrentMonthByYear);
        }

        public string GetSelectedDate()
        {
            return ConciseApi.GetAttributeValue(_selectDateField, "value");
        }

        public bool IsDatePickerPresented()
        {
            bool isPresented = false;
            try
            {
                isPresented = ConciseApi.GetElement(_datePicker).Displayed;
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine(e.GetType());
            }

            return isPresented;
        }

        public void SelectDateInDatePicker(string date)
        {
            StringHelper.ParseDate(date, out int day, out int month, out int year);

            ConciseApi.SelectDropDownByValue(_datePickerMonth, (--month).ToString());
            ConciseApi.SelectDropDownByText(_datePickerYear, year.ToString());

            ConciseApiDatePicker datePicker = new ConciseApiDatePicker(ConciseApi);
            datePicker.SelectDayInDatePicker(_datePickerDay, day);
        }

    }
}
