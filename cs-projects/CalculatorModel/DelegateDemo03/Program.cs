





using DelegateDemo02;

delegate int Calculation(int a, int b);

class Program
{
    static void Main()
    {
        int x = 50, y = 15;
        var am = new AdvancedMath();


        Calculation[] calculations =
        {
            SimpleMath.Plus,
            SimpleMath.Minus,
            am.Multiply,
            am.Divide
        };

        foreach(var calculation in calculations)
        {
            
            var result = calculation(x, y);

            Console.WriteLine($"{x} {calculation.Method.Name}  {y} = {result}");
        }
    }
}
