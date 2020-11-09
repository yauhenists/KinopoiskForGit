using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace KinopoiskSelenium.Pages.ToolsQA
{
    public class MultiplePages : BasePage
    {
        private readonly string _url = "https://demoqa.com/browser-windows";
        private By _tabButton = By.Id("tabButton");
        private By _windowButton = By.Id("windowButton");
        private By _msgWindowButton = By.Id("messageWindowButton");
        public string ParentWindowHandle { get; }
        public List<string> WindowHandles { get; private set; }
        public MultiplePages(ConciseApi conciseApi) : base(conciseApi)
        {
            OpenPage();
            ParentWindowHandle = ConciseApi.GetCurrentWindowHandle();
        }

        public override void OpenPage()
        {
            ConciseApi.Open(_url);
        }

        public void OpenNewTab()
        {
            ConciseApi.Click(_tabButton);
            UpdateWindowsList();
        }

        public void OpenNewWindow()
        {
            ConciseApi.ClickViaActions(_windowButton);
            UpdateWindowsList();
        }

        public void OpenNewMsgWindow()
        {
            ConciseApi.Click(_msgWindowButton);
            UpdateWindowsList();
        }

        public void SwitchToTab()
        {
            SwitchToTab(WindowHandles.Count == 2
                ? WindowHandles.First(x => x != ParentWindowHandle)
                : WindowHandles.FirstOrDefault());
            var temp = ConciseApi.GetCurrentWindowHandle();
        }

        public void SwitchToTheMainWindow()
        {
            ConciseApi.SwitchTabOrWindow(ParentWindowHandle);
        }

        public void CloseAllWindowsExceptTheMain()
        {
            foreach (var window in WindowHandles)
            {
                if (window == ParentWindowHandle)
                {
                    continue;
                }

                SwitchToTab(window);
                ConciseApi.CloseCurrentWindow();
            }

            UpdateWindowsList();
            SwitchToTheMainWindow();
        }

        public void GetNewTabText()
        {
            Console.WriteLine(ConciseApi.GetTextOfTheElement(By.XPath("//h1")));
        }

        public void GetMsgWindowText()
        {
            Console.WriteLine(ConciseApi.GetTextOfTheElement(By.TagName("body")));
        }

        public void GetAllWindowsUrl()
        {
            var currentWindow = ConciseApi.GetCurrentWindowHandle();
            foreach (var window in WindowHandles)
            {
                ConciseApi.SwitchTabOrWindow(window);
                Console.WriteLine(ConciseApi.GetUrl());
            }

            ConciseApi.SwitchTabOrWindow(currentWindow);
        }

        private void UpdateWindowsList()
        {
            WindowHandles = ConciseApi.GetWindowHandles();
        }

        private void SwitchToTab(string window)
        {
            ConciseApi.SwitchTabOrWindow(window);
        }
    }
}
