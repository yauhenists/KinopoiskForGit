using System;
using System.Collections.Generic;
using System.Linq;
using BoDi;
using Gherkin.Ast;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecFlow.Assist.Dynamic;

namespace SpecFlowTests.Steps
{
    public class Calculator
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public int Result { get; set; }
        public ObjectB ObjectB;

        public Calculator()
        {
            ObjectB = new ObjectB(){Info = "Created in Calculator"};
        }
    }

    public class ObjectA
    {
        public string Info { get; set; } = "default info A";
    }

    public class ObjectB
    {
        public string Info { get; set; } = "default info B";
    }

    [Binding]
    public class SpecFlowFeature1Steps : TechTalk.SpecFlow.Steps
    {
        private IObjectContainer _container;
        private Calculator _calculator;
        private ObjectA _objectA;
        private ObjectB _objectB;

        public SpecFlowFeature1Steps(IObjectContainer container, Calculator calculator, ObjectA objectA)
        {
            _container = container;
            _calculator = calculator;
            _objectA = objectA;
            _objectA.Info = "ObjectA from constructor";

            _objectB = _container.Resolve<ObjectB>();
            Console.WriteLine("test constructor");
            Console.WriteLine(_objectB.Info);

        }

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int p0)
        {
            _calculator.FirstNumber = p0;
        }
        
        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int p0)
        {
            _calculator.SecondNumber = p0;
        }
        
        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _calculator.Result = _calculator.FirstNumber + _calculator.SecondNumber;
        }

        [When(@"I add to numbers")]
        public void WhenIAddToNumbers(Table table)
        {
            //var dynamicData = table.CreateDynamicInstance();
            //_calculator.FirstNumber = (int)dynamicData.ElementAt(0).Value;
            //_calculator.SecondNumber = (int)dynamicData.ElementAt(1).Value;
            //_calculator.Result = (int)dynamicData.ElementAt(2).Value;

            var data = table.CreateInstance<Calculator>();
            _calculator.FirstNumber = data.FirstNumber;
            _calculator.SecondNumber = data.SecondNumber;
            _calculator.Result = data.Result;
        
            //var data = table.CreateDynamicSet();
            //foreach (var d in data)
            //{
            //    _calculator.FirstNumber = d.FirstNumber;
            //    _calculator.SecondNumber = d.SecondNumber;
            //    _calculator.Result = d.Result;
            //}
            Console.WriteLine(_calculator.Result);
            //var calculators = table.CreateSet<Calculator>();
            //_calculator = calculators.ElementAt(2);

            //_objectA.Info = "Object A updated from step";
            //_objectA = new ObjectA(){Info = "Object A created from step" };

            //_objectB = new ObjectB(){Info = "Object B from step"};
            _objectB = _calculator.ObjectB;
            //_container.RegisterInstanceAs(_objectB);

            //some checks for Objects A and B
        }

        [Then(@"check the result")]
        [Scope(Tag = "SpecFlowSampleFeature")]
        public void ThenCheckTheResult()
        {
            Console.WriteLine($"FirstNumber = {_calculator.FirstNumber}");
            Console.WriteLine($"SecondNumber = {_calculator.SecondNumber}");
            Console.WriteLine($"Result = {_calculator.Result}");
            Assert.AreEqual(_calculator.Result, _calculator.FirstNumber + _calculator.SecondNumber);

            Console.WriteLine($"Getting info of Object A - {_objectA.Info}");
            Console.WriteLine($"Getting info of Object B - {_objectB.Info}");
        }

        [When(@"I add two numbers (.*), (.*)")]
        public void WhenIAddTwoNumbers(int p0, int p1)
        {
            _calculator.FirstNumber = p0;
            _calculator.SecondNumber = p1;
            _calculator.Result = _calculator.FirstNumber + _calculator.SecondNumber;
            //_calculator.Result = p2;
        }

        [When(@"I add to numbers (using dynamic table)")]
        public void WhenIAddToNumbersUsingDynamicTable(Table table)
        {
            //var calc = table.CreateDynamicSet();
            //_calculator.FirstNumber = calc.ElementAt(0).FirstNumber;
            //_calculator.SecondNumber = calc.ElementAt(0).SecondNumber;
            //_calculator.Result = calc.ElementAt(0).Result;

            //var calc = table.CreateDynamicInstance();
            //_calculator.FirstNumber = (int) calc.First(d => d.Key.Contains("FirstNumber")).Value;
            //_calculator.SecondNumber = (int)calc.ElementAt(1).Value;
            //_calculator.Result = (int)calc.ElementAt(2).Value;

            dynamic calc = table.CreateDynamicInstance();
            _calculator.FirstNumber = calc.FirstNumber;
            _calculator.SecondNumber = calc.SecondNumber;
            _calculator.Result = calc.Result;

            //_calculator = calculator;
        }


        [Then(@"check the result (.*)")]
        public void ThenCheckTheResult(int p0)
        {
            Assert.AreEqual(p0, _calculator.Result);

            List<Calculator> calculators = new List<Calculator>()
            {
                new Calculator()
                {
                    FirstNumber = 10,
                    SecondNumber = 20,
                    Result = 30
                },
                new Calculator()
                {
                    FirstNumber = 40,
                    SecondNumber = 50,
                    Result = 90
                }
            };

            ScenarioStepContext.Current["Calculators"] = calculators;
            

            var calcs = ScenarioStepContext.Current.Get<IEnumerable<Calculator>>("Calculators");
            foreach (var calculator in calcs)
            {
                Console.WriteLine($"{calculator.FirstNumber} + {calculator.SecondNumber} = {calculator.Result}");
            }

        }


        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            Assert.AreEqual(_calculator.Result, p0);
        }

        [Then(@"Write date (.* days from now) via custom step transformer")]
        public void ThenWriteDateViaCustomStepTransformer(DateTime date)
        {
            Console.WriteLine(date);
        }

        [Given(@"(two numbers .* and .* and result .*)")]
        public void GivenTwoNumbersAndAndResult(Calculator calculator)
        {
            _calculator = calculator;
        }

        [Then(@"check addition")]
        public void ThenCheckAddition()
        {
            string[] colHeader = {"FirstNumber", "SecondNumber", "Result"};
            string[] rowValues = {"35", "55", "90"};

            Table table = new Table(colHeader);
            table.AddRow(rowValues);

            WhenIAddToNumbers(table);
            ThenCheckTheResult();
        }

        [Given(@"Table for checking")]
        public void GivenTableForChecking(Table table)
        {
            List<Calculator> calculators = new List<Calculator>()
            {
                new Calculator()
                {
                    FirstNumber = 40,
                    SecondNumber = 60,
                    Result = 100
                },

                new Calculator()
                {
                    FirstNumber = 40,
                    SecondNumber = 70,
                    Result = 110
                },

                new Calculator()
                {
                    FirstNumber = 40,
                    SecondNumber = 60,
                    Result = 100
                }
            };

            //var result = table.FindInSet(calculators);
            //Console.WriteLine(result.Result);

            var res = table.FindAllInSet(calculators);
            Console.WriteLine(res.First().Result);
        }


    }
}
