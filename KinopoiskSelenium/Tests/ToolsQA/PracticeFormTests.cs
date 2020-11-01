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
    public class PracticeFormTests : BaseTest
    {
        [Test]
        public void SelectFirstRadioButton()
        {
            PracticeFormPage page = new PracticeFormPage(ConciseApi);
            page.SelectRadioButton(Gender.Female);
            page.SelectRadioButton(Gender.Male);
            Assert.True(page.IsRadioButtonSelected(Gender.Male));
            Assert.False(page.IsRadioButtonSelected(Gender.Female));

            //Selecting doesn't work
        }

        [Test]
        public void SelectCheckBoxes()
        {
            PracticeFormPage page = new PracticeFormPage(ConciseApi);
            page.SelectCheckBox(Hobbies.Sports, Hobbies.Music);
            page.SelectCheckBox(Hobbies.Music, Hobbies.Reading);
            Assert.True(page.IsCheckBoxSelected(Hobbies.Sports));
            Assert.False(page.IsCheckBoxSelected(Hobbies.Music));
            Assert.True(page.IsCheckBoxSelected(Hobbies.Reading));
        }

        [Test]
        public void SelectMultipleDropDownMenu()
        {
            SelectMenuPage page = new SelectMenuPage(ConciseApi);
            page.SelectInOldStyleSelectMenu(1);
            Assert.True(page.SelectedItemText == "Blue");
            page.SelectInOldStyleSelectMenu("Black");
            Assert.True(page.SelectedItemText == "Black");
            page.SelectInOldStyleSelectMenu("10", false);
            Assert.True(page.SelectedItemText == "Aqua");
            page.SelectCar("volvo");
            page.SelectCar("opel");
            page.WriteSelectedCars();
        }

        [Test]
        public void SelectDynamicDropDown()
        {
            SelectMenuPage page = new SelectMenuPage(ConciseApi);
            page.SelectTitle("Mr.");
            Assert.True(page.GetSelectedTitle() == "Mr.");
        }

    }
}
