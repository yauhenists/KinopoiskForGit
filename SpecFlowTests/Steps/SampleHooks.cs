using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dynamitey.Internal.Optimization;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Steps
{
    [Binding]
    public sealed class SampleHooks
    {
        [BeforeFeature]
        public static void BeforeFeature()
        {
            Console.WriteLine("Before Feature");
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine("Before Scenario");
        }

        [BeforeScenarioBlock()]
        public void BeforeTestRun()
        {
            Console.WriteLine("Before Scenario Block");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("After Scenario");
        }
    }
}
