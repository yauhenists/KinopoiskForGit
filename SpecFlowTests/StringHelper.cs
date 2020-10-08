using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowTests
{
    public class StringHelper
    {
        public static string RemoveQuotest(string input)
        {
            return input.Substring(1, input.Length - 2);
        }
    }
}
