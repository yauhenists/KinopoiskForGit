using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace KinopoiskSelenium.Pages.ToolsQA
{
    class PracticeFormPage : BasePage
    {
        private string _url = "https://demoqa.com/automation-practice-form";

        private By SportsCheckBox { get; } =By.Id("hobbies-checkbox-1");
        private By ReadingCheckBox { get; } = By.Id("hobbies-checkbox-2");
        private By MusicCheckBox { get; } = By.Id("hobbies-checkbox-3");
        private By MaleRadioButton { get; } = By.Id("gender-radio-1");
        private By FemaleRadioButton { get; } = By.Id("gender-radio-2");
        private By OtherRadioButton { get; } = By.Id("gender-radio-3");

        public PracticeFormPage(ConciseApi conciseApi) : base(conciseApi)
        {
            //OpenPage();
        }

        public override void OpenPage()
        {
            ConciseApi.Open(_url);
        }

        public void SelectRadioButton(Gender button)
        {
            By element = GetRadioButton(button);
            if (element != null)
            {
                ConciseApi.SelectRadioButton(element);
            }
        }

        public void SelectCheckBox(params Hobbies[] checkboxes)
        {
            List<By>listCheckBoxes = new List<By>();
            foreach (var checkBox in checkboxes)
            {
                By element = GetCheckBox(checkBox);
                if (element != null)
                {
                    listCheckBoxes.Add(element);
                }
            }
            
            ConciseApi.SelectCheckBox(listCheckBoxes.ToArray());
        }

        public bool IsRadioButtonSelected(Gender button)
        {
            By element = GetRadioButton(button);
            if (element != null)
            {
                return ConciseApi.IsElementSelected(element);
            }

            return false;
        }

        public bool IsCheckBoxSelected(Hobbies checkbox)
        {
            By element = GetCheckBox(checkbox);
            if (element != null)
            {
                return ConciseApi.IsElementSelected(element);
            }

            return false;
        }

        private By GetRadioButton(Gender button)
        {
            By element;
            switch (button)
            {
                case Gender.Male:
                    element = MaleRadioButton;
                    break;
                case Gender.Female:
                    element = FemaleRadioButton;
                    break;
                case Gender.Other:
                    element = OtherRadioButton;
                    break;
                default:
                    Console.WriteLine("No appropriate radio button to select/check");
                    return null;
            }

            return element;
        }

        private By GetCheckBox(Hobbies checkbox)
        {
            By element;
            switch (checkbox)
            {
                case Hobbies.Music:
                    element = MusicCheckBox;
                    break;
                case Hobbies.Reading:
                    element = ReadingCheckBox;
                    break;
                case Hobbies.Sports:
                    element = SportsCheckBox;
                    break;
                default:
                    Console.WriteLine("No appropriate checkbox to select/check");
                    return null;
            }

            return element;
        }
    }
}
