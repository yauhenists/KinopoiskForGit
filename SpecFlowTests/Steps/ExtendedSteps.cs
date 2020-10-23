using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoDi;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Steps
{
    [Binding]
    public sealed class ExtendedSteps
    {
        
        private readonly Calculator _calculator;
        private  ObjectA _objectA;
        private  ObjectB _objectB;
        private readonly IObjectContainer _container;

        public ExtendedSteps(IObjectContainer container, Calculator calculator, ObjectA objectA)
        {
            _calculator = calculator;
            _objectA = objectA;
            //_objectB = container.Resolve<ObjectB>(); //new ObjectB(){Info = "Created in Extended constructor"};
            _objectB = _calculator.ObjectB;
            //_objectB.Info = "Updated in extended constructor";
            //_container.RegisterInstanceAs(_objectB);

            Console.WriteLine("extended hooks constructor");
        }

        [Then(@"check result from Extended steps")]
        public void ThenCheckResultFromExtendedSteps()
        {
            Console.WriteLine("Getting values from extended step");

            Console.WriteLine($"FirstNumber = {_calculator.FirstNumber}");
            Console.WriteLine($"SecondNumber = {_calculator.SecondNumber}");
            Console.WriteLine($"Result = {_calculator.Result}");

            Console.WriteLine($"Object A from extended step - {_objectA.Info}");
            Console.WriteLine($"Object B from extended step - {_objectB.Info}");

            _objectA.Info = "Object A updated from extended step";
            
            _objectB.Info = "Object B updated from extended step";
            _objectA = new ObjectA(){Info = "Extended info"};
            
        }



    }
}
