

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


       
       


        int x = 50, y = 15;



        calc.PrintResult(x, "plus", y);

        calc.PrintResult(x, "Minus", y);

        calc.PrintResult(x, "Mod" , y);

        calc.AddOperator(Mod);

        calc.Formatter = ResultFormatters.Raw;

        calc.PrintResult(x, "MOD", y);
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