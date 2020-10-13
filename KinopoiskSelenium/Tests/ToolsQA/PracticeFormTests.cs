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
            Assert.True(page.IsRadioButtonSelected(Gender.Female));
            Assert.False(page.IsRadioButtonSelected(Gender.Male));

            //Selecting doesn't work
        }

        [Test]
        public void SelectFirstCheckBox()
        {
            PracticeFormPage page = new PracticeFormPage(ConciseApi);
            page.SelectCheckBox(Hobbies.Sports, Hobbies.Music);
            Assert.True(page.IsCheckBoxSelected(Hobbies.Sports));
            Assert.True(page.IsCheckBoxSelected(Hobbies.Music));
        }

    }
}
