using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskSelenium.Pages.ToolsQA
{
    public class MainChecksPage : BasePage
    {
        private string Url { get; } = "https://www.toolsqa.com/selenium-webdriver/selenium-webdriver-browser-commands/";

        public MainChecksPage(ConciseApi conciseApi) : base(conciseApi)
        {
            OpenPage();
        }

        public sealed override void OpenPage()
        {
            ConciseApi.Open(Url);
        }

        public bool IsCorrectUrl(string url, bool consoleWrite = false)
        {
            var pageUrl = ConciseApi.GetUrl();
            if (consoleWrite)
            {
                Console.WriteLine(pageUrl);
            }
            return pageUrl.Equals(url);
        }

        public bool IsCorrectTitle(string title, bool consoleWrite = false)
        {
            var pageTitle = ConciseApi.GetPageTitle();
            if (consoleWrite)
            {
                Console.WriteLine(pageTitle);
            }
            return pageTitle.Equals(title);
        }

        public bool IsCorrectPageSource(string start, bool consoleWrite = false)
        {
            var pageSorceCode = ConciseApi.GetSourceCode();
            if (consoleWrite)
            {
                Console.WriteLine(pageSorceCode);
            }

            return pageSorceCode.StartsWith(start);
        }
    }
}
