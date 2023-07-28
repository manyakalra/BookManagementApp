using ConceptArchitect.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp01
{
    internal class Program
    {
        static void Main()
        {
            //CalculatorV1Test();

            var calc = new ArithmeticCalculatorV2();

            calc.DisplayResult(2, new Plus(), 3);

            calc.Screen = new ColoredCalculatorScreen() { Color = ConsoleColor.Yellow };

            calc.DisplayResult(2, new Minus(), 1);

            //calc.DisplayResult(10, "mod", 2);

            //calc.DisplayResult(20, "Foo", 4);

        }

        private static void CalculatorV1Test()
        {
            var calc = new ArithmeticCalculator();


            calc.DisplayResult(2, "plus", 3);

            calc.DisplayResult(2, "minus", 1);

            calc.DisplayResult(10, "mod", 2);

            calc.DisplayResult(20, "Foo", 4);
        }
    }
}
