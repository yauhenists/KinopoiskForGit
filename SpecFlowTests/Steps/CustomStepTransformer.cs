using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowTests.Steps
{
    [Binding]
    public class CustomStepTransformer
    {
        [StepArgumentTransformation( @"(\d+) days from now")]
        public DateTime GetDateTime(int days)
        {
            return DateTime.Today.AddDays(days);
        }

        [StepArgumentTransformation(@"two numbers (\d+) and (\d+) and result (\d+)")]
        public Calculator GetCalculator(int firstNumber, int secondNumber, int result)
        {
            return new Calculator()
            {
                FirstNumber = firstNumber,
                SecondNumber = secondNumber,
                Result = result
            };
        }

        [StepArgumentTransformation(@"using dynamic table")]
        public Calculator GetCalculator(Table table)
        {
            dynamic calc = table.CreateDynamicInstance();
            return new Calculator()
            {
                FirstNumber = calc.FirstNumber,
                SecondNumber = calc.SecondNumber,
                Result = calc.Result
            };
        }
    }
}
