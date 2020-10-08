using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Steps
{
    [Binding]
    public sealed class ScopeBindingExample
    {
        private readonly Calculator _calculator;

        public ScopeBindingExample(Calculator calculator)
        {
            _calculator = calculator;
        }

        [Then(@"check the result")]
        [Scope(Tag = "scopeBinding")]
        public void ThenCheckTheResult()
        {
            Console.WriteLine($"FirstNumber = {_calculator.FirstNumber}");
            Console.WriteLine($"SecondNumber = {_calculator.SecondNumber}");
            Console.WriteLine($"Result = {_calculator.Result}");
            Console.WriteLine("Checking from scope binding class...");
            Assert.AreEqual(_calculator.Result, _calculator.FirstNumber + _calculator.SecondNumber);
        }
    }
}
