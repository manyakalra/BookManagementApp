using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Calculators
{

    public class ColoredConsole
    {
        ConsoleColor color;

        public ColoredConsole(ConsoleColor color)
        {
            this.color = color;
        }

        public  void Show(string output)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(output);
            Console.ResetColor();
        }
    }

    public class Screens
    {
        public static void SimpleConsole(string output)
        {
            System.Console.WriteLine(output);
        }

        
    }
}
