





using DelegateDemo02;

delegate int Calculation(int a, int b);

class Program
{
    static void Main()
    {
        int x = 50, y = 15;

        Calculation sum = new Calculation(SimpleMath.Plus);

        var result = sum.Invoke(x, y);

        Console.WriteLine(result);


        Calculation substract = SimpleMath.Minus;  //auto boxed to new Calculation(SimpleMath.Minus)

        result = substract(x, y); //implict invoke : substract.Invoke(x,y)

        Console.WriteLine(result);

        var am = new AdvancedMath();
        Calculation multiply = am.Multiply;
        result = multiply(x, y);
        Console.WriteLine(result);
    }
}
