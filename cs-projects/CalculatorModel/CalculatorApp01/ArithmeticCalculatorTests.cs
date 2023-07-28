using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalculatorApp01
{
    public class ArithmeticCalculatorTests
    {
        ArithmeticCalculator calc;
        int x = 50, y = 15;

        public ArithmeticCalculatorTests()
        {
            calc= new ArithmeticCalculator();
        }

        [Fact]
        public void CalculatorCanPlusTwoValues()
        {
            calc.DisplayResult(x, "plus", y);

            Assert.Equal(x + y, calc.Result);
        }
    }
}