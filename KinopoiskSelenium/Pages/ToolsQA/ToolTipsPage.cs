using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace KinopoiskSelenium.Pages.ToolsQA
{
    public class ToolTipsPage : BasePage
    {
        private string _url = "https://demoqa.com/tool-tips";
        private By _tooltip = By.XPath("//*[@class='tooltip-inner']");
        private By _tooltipButton = By.Id("toolTipButton");

        public ToolTipsPage(ConciseApi conciseApi) : base(conciseApi)
        {
            OpenPage();
        }

        public override void OpenPage()
        {
            ConciseApi.Open(_url);
        }

        public void MoveCursorOnTooltipButton()
        {
            ConciseApi.HoverCursorOverElement(_tooltipButton);
        }

        public string GetTooltipText()
        {
            return ConciseApi.GetTextOfTheElement(_tooltip);
        }
    }
}
