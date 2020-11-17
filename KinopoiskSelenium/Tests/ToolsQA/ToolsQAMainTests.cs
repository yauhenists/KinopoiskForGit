using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinopoiskSelenium.Pages.ToolsQA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using StringAssert = NUnit.Framework.StringAssert;

namespace KinopoiskSelenium.Tests.ToolsQA
{
    [TestFixture]
    public class ToolsQAMainTests : BaseTest
    {
        [Test]
        public void CheckMainThings()
        {
            MainChecksPage mainPage = new MainChecksPage(ConciseApi);
            Assert.Multiple(() =>
                {
                    Assert.IsTrue(mainPage.IsCorrectTitle("What are all Selenium Webdriver Browser Commands in Java?", true));
                    Assert.IsTrue(mainPage.IsCorrectUrl("https://www.toolsqa.com/selenium-webdriver/selenium-webdriver-browser-commands/", true));
                    Assert.IsTrue(mainPage.IsCorrectPageSource("<html lang", false));
                }
                );
        }

        [Test]
        public void CheckTooltipText()
        {
            ToolTipsPage page = new ToolTipsPage(ConciseApi);
            page.MoveCursorOnTooltipButton();
            StringAssert.AreEqualIgnoringCase("You hovered over the Button", page.GetTooltipText());
        }
    }
}
