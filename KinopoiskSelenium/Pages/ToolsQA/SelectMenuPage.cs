
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace KinopoiskSelenium.Pages.ToolsQA
{
    public class SelectMenuPage : BasePage
    {
        private const string _url = "https://demoqa.com/select-menu";
        private By _oldStyleSelectMenu = By.Id("oldSelectMenu");
        private By _carsDropDown = By.Id("cars");
        private By _selectedTitleMenu = By.XPath("//*[contains(concat(' ',@class,' '),'singleValue')]");
        private By _selectTitleMenu = By.Id("selectOne");
        private string _selectOneXpath = "//div[contains(text(),'')]";
        public string SelectedItemText { get; private set; }

        public List<string> SelectedCars { get; private set; }
        public SelectMenuPage(ConciseApi conciseApi) : base(conciseApi)
        {
        }

        public override void OpenPage()
        {
            ConciseApi.Open(_url);
        }

        public void SelectInOldStyleSelectMenu(int index)
        {
            ConciseApi.SelectDropDownByIndex(_oldStyleSelectMenu, index);
            SelectedItemText = ConciseApi.GetSelectElementTextFromDropDown(_oldStyleSelectMenu);
        }

        public void SelectInOldStyleSelectMenu(string value, bool isText = true)
        {
            if (isText)
            {
                ConciseApi.SelectDropDownByText(_oldStyleSelectMenu, value);
            }
            else
            {
                ConciseApi.SelectDropDownByValue(_oldStyleSelectMenu, value);
            }
                
            SelectedItemText = ConciseApi.GetSelectElementTextFromDropDown(_oldStyleSelectMenu);
        }

        public void SelectCar(string car, bool byText = false)
        {
            if (byText)
            {
                ConciseApi.SelectDropDownByText(_carsDropDown, car);
            }
            else
            {
                ConciseApi.SelectDropDownByValue(_carsDropDown, car);
            }
            
        }
        
        public void WriteSelectedCars()
        {
            SelectedCars = ConciseApi.GetListOfSelectedOptions(_carsDropDown);

        }

        public void SelectTitle(string value)
        {
            ConciseApi.Click(_selectTitleMenu);
            var xpath = _selectOneXpath.Insert(_selectOneXpath.IndexOf('\'') + 1, value);
            ConciseApi.Click(By.XPath(xpath));

            SelectedItemText = ConciseApi.GetTextOfTheElement(_selectedTitleMenu);
        }

        public string GetSelectedTitle()
        {
            return ConciseApi.GetTextOfTheElement(_selectedTitleMenu);
        }
    }
}
