using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskSelenium.Pages
{
    public abstract class BasePage
    {
        public ConciseApi ConciseApi { get; }

        public BasePage(ConciseApi conciseApi)
        {
            ConciseApi = conciseApi;
        }

        public abstract void OpenPage();
    }
}
