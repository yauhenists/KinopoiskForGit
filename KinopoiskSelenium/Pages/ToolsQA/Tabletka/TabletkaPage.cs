using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace KinopoiskSelenium.Pages.ToolsQA.Tabletka
{
    public class TabletkaPage : BasePage
    {
        private const string _url = "https://tabletka.by/";
        private By _inputField = By.ClassName("ls-select-input");
        private string _searchedItem = "//*[contains(concat(' ',@class,' '),' original ')]//ul[@class='select-check-list ls-select']/li[@class='select-check-item']";

        private By _submitButton =
            By.XPath("//*[contains(concat(' ',@class,' '),' original ')]//button[@type='submit']");
        public TabletkaPage(ConciseApi conciseApi) : base(conciseApi)
        {
        }

        public override void OpenPage()
        {
            ConciseApi.Open(_url);
        }

        public void SearchPills(string value)
        {
            ConciseApi.EnterText(_inputField, value);
        }

        public TabletkaResultsPage FollowRandomResult()
        {

            var max = ConciseApi.GetCountOfElements(By.XPath(_searchedItem));
            var xpath = _searchedItem + $"[{new Random().Next(1,2)}]";
            ConciseApi.ClickViaActions(By.XPath(xpath));
            ConciseApi.Click(_submitButton);

            return new TabletkaResultsPage(ConciseApi);
        }
    }
}
