using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowTests
{
    public class StringHelper
    {
        public static string RemoveQuots(string input)
        {
            return input.Substring(1, input.Length - 2);
        }

        public static void ParseDate(string date, out int day, out int month, out int year)
        {
            DateTime dateTime = DateTime.Parse(date);
            day = dateTime.Day;
            month = dateTime.Month;
            year = dateTime.Month;
        }

        public static string GetDateTime(string date)
        {
            return DateTime.Parse(date).ToString("MM/dd/yyyy");
        }

        public static string GetMonthYearInEnglish(int month = 0)
        {
            return DateTime.Now.AddMonths(month).ToString("MMMM yyyy", CultureInfo.GetCultureInfo("en-en"));
        }

    }
}
