using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinopoiskSelenium.Pages.ToolsQA;
using NUnit.Framework;

namespace KinopoiskSelenium.Tests.ToolsQA
{
    [TestFixture]
    public class AutoCompleteTests : BaseTest
    {
        [Test]
        public void SimpleCheckForMultipleSelecting()
        {
            AutoCompletePage page = new AutoCompletePage(ConciseApi);
            page.StartEnteringInAutoCompleteMultipleField("i");
            foreach (var color in page.GetListOfValuesInMultipleField())
            {
                Console.WriteLine(color);
            }
            Random rnd = new Random();
            var colorToChoose = page.GetListOfValuesInMultipleField()
                .ElementAt(rnd.Next(0, page.GetListOfValuesInMultipleField().Count));
            page.SelectColorInListOfMultipleValues(colorToChoose);
            Console.WriteLine($"First selected color is {page.GetListOfSelectedMultipleColors().FirstOrDefault()}");
            Console.WriteLine($"Number of selected colors = {page.GetListOfSelectedMultipleColors().Count}");

            page.StartEnteringInAutoCompleteMultipleField("i");
            foreach (var color in page.GetListOfValuesInMultipleField())
            {
                Console.WriteLine(color);
            }
            
            colorToChoose = page.GetListOfValuesInMultipleField()
                .ElementAt(rnd.Next(0, page.GetListOfValuesInMultipleField().Count));
            page.SelectColorInListOfMultipleValues(colorToChoose);
            Console.WriteLine("\n New Selected colors");
            foreach (var color in page.GetListOfSelectedMultipleColors())
            {
                Console.WriteLine(color);
            }
        }
    }
}
