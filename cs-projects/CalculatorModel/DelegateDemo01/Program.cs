


delegate string Messanger(string name);

class Program
{ 
    static void Main()
    {
        Console.WriteLine("hello delegates");

        Console.WriteLine(Greeter("Vivek")); //standard way to call the function

        Messanger messanger = new Messanger(Greeter);

        Console.WriteLine(messanger.Invoke("Ecolabs"));
    }

    static string Greeter(string name)
    {
        return $"Hello {name}, Welcome To C# Delegates";
    }
}
