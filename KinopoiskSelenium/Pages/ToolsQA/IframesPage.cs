using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace KinopoiskSelenium.Pages.ToolsQA
{
    public class IframesPage : BasePage
    {
        private string _url = "https://demoqa.com/frames";
        public By IframeElement { get;} = By.XPath("//*[@id='frame1Wrapper']//h1");
        private By MainPageText { get; } = By.XPath("//*[@id='framesWrapper']/div[1]");
        public IframesPage(ConciseApi conciseApi) : base(conciseApi)
        {
            OpenPage();
        }

        public override void OpenPage()
        {
            ConciseApi.Open(_url);
        }

        public int GetIframesNumber(bool byJS)
        {
            int res;

            if (byJS)
            {
                res = ConciseApi.GetIframeNumberViaJs();
                Console.WriteLine($"Number of iframes receive via JS = {res}");
            }
            else
            {
                res = ConciseApi.GetIframeNumberViaTagName();
                Console.WriteLine($"Number of iframes receive via tag name = {res}");
            }

            return res;
        }

        public void SwitchToIframe(WayToIframe way, object obj)
        {
            ConciseApi.SwitchToIframe(way, obj);
        }

        public void SwitchToMainIframe()
        {
            ConciseApi.SwitchToMainIframe();
        }

        public void GetIframeText()
        {
            Console.WriteLine(ConciseApi.GetTextOfTheElement(By.XPath("//h1")));
        }

        public void GetMainPageText()
        {
            Console.WriteLine(ConciseApi.GetTextOfTheElement(MainPageText));
        }
    }
}
