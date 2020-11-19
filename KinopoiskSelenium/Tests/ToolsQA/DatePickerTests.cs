using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinopoiskSelenium.Pages.ToolsQA;
using NUnit.Framework;

namespace KinopoiskSelenium.Tests.ToolsQA
{
    [TestFixture]
    public class DatePickerTests : BaseTest
    {
        [Test]
        public void CheckMonthYearInDatePicker()
        {
            DatePickerPage page = new DatePickerPage(ConciseApi);
            page.OpenDatePicker();
            Assert.AreEqual(DateTime.Now.ToString("MMMM yyyy", CultureInfo.GetCultureInfo("en-en")), page.GetDateFromDatePicker());
            page.GetPreviousMonth();
            Assert.AreEqual(DateTime.Now.AddMonths(-1).ToString("MMMM yyyy", CultureInfo.GetCultureInfo("en-en")), page.GetDateFromDatePicker());
        }
    }
}
