





using DelegateDemo02;

delegate int Calculation(int a, int b);

class Program
{
    static void Main()
    {
        int x = 50, y = 15;
        var am = new AdvancedMath();

        PrintResult(x, SimpleMath.Plus, y);
        PrintResult(x, SimpleMath.Minus, y);
        PrintResult(x, am.Multiply, y);
    }

    private static void PrintResult(int x, Calculation calc, int y)
    {
        var result = calc(x, y);

        Console.WriteLine($"{x} {calc.Method.Name} {y}= {result}");
    }
}
