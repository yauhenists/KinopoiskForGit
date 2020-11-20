using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace KinopoiskSelenium
{
    public class ConciseApiDatePicker : ConciseApi
    {
        public ConciseApiDatePicker(ConciseApi conciseApi) : base(conciseApi)
        {
        }
        public void SelectDayInDatePicker(By datePicker, int day)
        {
            var dayPickerElement = GetElements(datePicker);
            foreach (var dayElement in dayPickerElement)
            {
                if (int.Parse(dayElement.Text.Trim()) == day)
                {
                    dayElement.Click();
                    return;
                }
            }
            throw new Exception("The day you've entered is not found");
        }


    }
}
