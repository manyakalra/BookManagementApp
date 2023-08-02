

using ConceptArchitect.Calculators;

class Program
{
    static void Main()
    {
        Console.WriteLine("Calculator App");

        var calc = new SmartClaculator();

        calc.Screen = output =>
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(output);
            Console.ResetColor();
        };


        calc.Formatter = (v1, v2, opr, result) => $"{v1} {opr} {v2} = {result}";

        calc.AddOperator((n, r) => Factorial(n) / Factorial(n - r), "permutation", "per");


        int x = 50, y = 15;



        calc.PrintResult(x, "plus", y);

        calc.PrintResult(x, "add", y);

        calc.PrintResult(x, "sum", y);



        calc.PrintResult(5, "permutation", 3);

        calc.PrintResult(x, "Minus", y);

        calc.PrintResult(x, "-", y );

        calc.PrintResult(x, "Mod" , y);

        calc.AddOperator(Mod);

        



        calc.Formatter = ResultFormatters.Raw;

        calc.PrintResult(x, "MOD", y);
    }

    static int Factorial(int x)
    {
        if (x <= 1)
            return 1;
        else
            return x * Factorial(x - 1);
           
    }

    static int Mod(int x,int y)
    {
        return x % y;
    }

    static void DecoratedScreen(string output)
    {
        Console.WriteLine($"*** {output} ***");
    }


    static string InfixFormat(int v1, int v2, string opr, int result)
    {
        return $"{v1} {opr} {v2} = {result}";
    }

}