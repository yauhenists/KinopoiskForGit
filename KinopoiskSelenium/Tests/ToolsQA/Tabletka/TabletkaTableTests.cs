using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinopoiskSelenium.Pages.ToolsQA.Tabletka;
using NUnit.Framework;

namespace KinopoiskSelenium.Tests.ToolsQA.Tabletka
{
    [TestFixture]
    public class TabletkaTableTests : BaseTest
    {
        [Test]
        public void CheckAllPrices()
        {
            TabletkaPage page = new TabletkaPage(ConciseApi);
            page.SearchPills("парацетамол ");
            TabletkaResultsPage pageResults = page.FollowRandomResult();

            pageResults.ReturnRowOfTable(2);
        }
    }
}
