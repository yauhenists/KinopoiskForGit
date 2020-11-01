using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace KinopoiskSelenium.Pages.ToolsQA.Tabletka
{
    public class TabletkaResultsPage : BasePage
    {
        private By _table = By.Id("base-select");
        public TabletkaResultsPage(ConciseApi conciseApi) : base(conciseApi)
        {
        }

        public override void OpenPage()
        {
            
        }

        public void ReturnRowOfTable(int row)
        {
            ConciseApi.WriteParticularRowWithColumnsForTable(_table, row);
        }
    }
}
