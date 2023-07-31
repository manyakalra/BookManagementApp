using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConceptArchitect.Calculators
{
    public class SmartCalculatorTests
    {
        [Fact]
        public void MethodStyleFormatterShouldReturnExpectedResultFormat()
        {
            var actual = ResultFormatters.MethodStyle(1, 2, "Hi", 0);

            Assert.Equal("Hi(1,2) = 0", actual);

        }

        class AssertResultFormatter
        {
            int expected;
            public AssertResultFormatter(int expected)
            {
                this.expected = expected;
            }
            public string Formatter(int v1, int v2, string opr, int result)
            {
                Assert.Equal(6, result);
                return "";
            }
        }
        
        

        [Fact]
		public void CalculatorShouldDisplayReturnValidResultForValidOperation()
        {
            var calc = new SmartClaculator();

            calc.Formatter = new AssertResultFormatter(6).Formatter;

            calc.PrintResult(4, "Plus", 2);

            
        }
  
        [Fact]
        public void CalculatorShouldDisplayInvalidOperatorMessageForInvalidOperator()
        {
            var calc=new SmartClaculator();
            var oprName = "Foo";
            
            calc.Screen = output => Assert.Equal($"Invalid Operator :{oprName}",output);

            calc.PrintResult(1, "Foo", 1);
        }

        [Fact]
        public void CalculatorPassesParameterV1AndV2ToOperators()
        {

        }
    }
}
