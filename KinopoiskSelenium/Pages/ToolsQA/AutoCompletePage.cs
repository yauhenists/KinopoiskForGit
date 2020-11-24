using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace KinopoiskSelenium.Pages.ToolsQA
{
    public class AutoCompletePage : BasePage
    {
        private string _url = "https://demoqa.com/auto-complete";
        private By _autoCompleteMultipleField = By.XPath("//*[@id='autoCompleteMultiple']//*[contains(concat(' ',@class,' '),' auto-complete__value-container ')]//input");

        private By _autoCompleteMultipleInsideLabel =
            By.XPath("//*[@class='css-1rhbuit-multiValue auto-complete__multi-value']/div[1]");
        private By _valuesInListOfMultipleColors = By.XPath("//*[@class='auto-complete__menu-list auto-complete__menu-list--is-multi css-11unzgr']/div");

        public AutoCompletePage(ConciseApi conciseApi) : base(conciseApi)
        {
            OpenPage();
        }

        public override void OpenPage()
        {
            ConciseApi.Open(_url);
        }

        public void StartEnteringInAutoCompleteMultipleField(string text)
        {
            ConciseApi.EnterText(_autoCompleteMultipleField, text);
        }

        public List<string> GetListOfValuesInMultipleField()
        {
            return ConciseApi.GetValuesOfElements(_valuesInListOfMultipleColors);
        }

        public List<string> GetListOfSelectedMultipleColors()
        {
            return ConciseApi.GetValuesOfElements(_autoCompleteMultipleInsideLabel);
        }

        public void SelectColorInListOfMultipleValues(string color)
        {
            var element = ConciseApi.GetElements(_valuesInListOfMultipleColors).First(x => x.Text.Equals(color));
            ConciseApi.Click(element);
        }
    }
}
