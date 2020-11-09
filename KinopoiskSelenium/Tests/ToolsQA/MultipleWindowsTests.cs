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
    public class MultipleWindowsTests : BaseTest
    {
        [Test]
        public void CheckTabs()
        {
            MultiplePages page = new MultiplePages(ConciseApi);
            page.OpenNewTab();
            page.SwitchToTab();
            Assert.AreEqual(2, page.WindowHandles.Count);
            page.GetNewTabText();
            page.SwitchToTheMainWindow();
            page.SwitchToTab();
            Assert.AreEqual(2, page.WindowHandles.Count);
            page.CloseAllWindowsExceptTheMain();
            Assert.AreEqual(1, page.WindowHandles.Count);

            page.OpenNewWindow();
            page.SwitchToTab();
            Assert.AreEqual(2, page.WindowHandles.Count);

            page.SwitchToTheMainWindow();
            page.OpenNewMsgWindow();
            page.SwitchToTab();
            Assert.AreEqual(3, page.WindowHandles.Count);
            //page.GetAllWindowsUrl();

            page.CloseAllWindowsExceptTheMain();
            Assert.AreEqual(1, page.WindowHandles.Count);

            page.OpenNewMsgWindow();
            page.OpenNewWindow();
            Assert.AreEqual(3, page.WindowHandles.Count);
            
            //page.GetMsgWindowText();
            
        }
    }
}
