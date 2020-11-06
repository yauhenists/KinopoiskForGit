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
    public class IframesTests : BaseTest
    {
        [Test]
        public void CheckIframesNumber()
        {
            IframesPage page = new IframesPage(ConciseApi);
            Assert.AreEqual(2, page.GetIframesNumber(true));
            Assert.AreEqual(2, page.GetIframesNumber(false));
        }

        [Test]
        public void CheckSwitchingBetweenIframes()
        {
            IframesPage page = new IframesPage(ConciseApi);
            page.SwitchToIframe(WayToIframe.Index, 0);
            page.GetIframeText();
            page.SwitchToMainIframe();
            page.SwitchToIframe(WayToIframe.ID, "frame2");
            page.GetIframeText();
            page.SwitchToMainIframe();
            //page.SwitchToIframe(WayToIframe.WebElement, page.IframeElement);
            //page.GetIframeText();
            page.GetMainPageText();
        }

    }
}
