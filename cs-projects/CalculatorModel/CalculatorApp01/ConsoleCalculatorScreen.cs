using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Calculators
{
    public class ConsoleCalculatorScreen : ICalculatorScreen
    {
        public void Show(object output)
        {
            Console.WriteLine(output);
        }
    }

    public class ColoredCalculatorScreen : ICalculatorScreen
    {
        public ConsoleColor Color { get; set; }
        public void Show(object output)
        {
            Console.ForegroundColor= Color;
            Console.WriteLine(output);
            Console.ResetColor();
        }
    }
}
