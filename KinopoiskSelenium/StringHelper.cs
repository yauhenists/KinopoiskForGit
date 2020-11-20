using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskSelenium
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
            year = dateTime.Year;
        }
    }
}
