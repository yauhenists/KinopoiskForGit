using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KinopoiskSelenium.Pages.ToolsQA;
using TechTalk.SpecFlow;

namespace SpecFlowTests.ToolsQASteps
{
    [Binding]
    public sealed class CustomStepTransformer
    {
        [StepArgumentTransformation(@"(\w+) Gender")]
        public Gender GetGender(string gender)
        {

            if (Enum.TryParse(gender, out Gender result))
            {
                return result;
            }

            return Gender.Female;
        }
    }
}
