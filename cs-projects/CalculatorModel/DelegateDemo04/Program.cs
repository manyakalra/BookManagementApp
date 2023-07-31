





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

        PrintResult(x, Mod, y);

        PrintResult(5,Custom1, 3); //Factorial(x)/Factorial(y)

        Calculation custom2 = delegate (int a, int b)
        {
            int fa = 1;
            while (a > 1)
                fa *= a--;

            int fb = 1;
            while (b > 1)
                fb *= b--;

            return fa / fb;
        };

        PrintResult(5, custom2, 3);

        PrintResult(5, delegate (int x, int y) { return (x + y) / (x - y); }, 3);
              

        Calculation c3 = (int a, int b) => { return a * a + b * b; };

        PrintResult(5, c3, 3);


        Calculation c4 = (a, b) =>
        {
            int fa = 1;
            while (a > 1)
                fa *= a--;

            int fb = 1;
            while (b > 1)
                fb *= b--;

            return fa / fb;
        };


        PrintResult(5, c4, 3);


       

        Calculation c6 = (i, j) => (i + j) * (i - j);
    
        PrintResult (5, c6, 3);


        PrintResult(5, (i, j) => (i + j) / 2  , 3);
    }

    static int Custom1(int a, int b)
    {
        int fa = 1;
        while (a > 1)
            fa *= a--;

        int fb = 1;
        while(b>1)
            fb*= b--;

        return fa / fb;
    }

    static int Mod(int a, int b)
    {
        return a % b;
    }

    private static void PrintResult(int x, Calculation calc, int y)
    {
        var result = calc(x, y);

        Console.WriteLine($"{x} {calc.Method.Name} {y}= {result}");
    }
}
