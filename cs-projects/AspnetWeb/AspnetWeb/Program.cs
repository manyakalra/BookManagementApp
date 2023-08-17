
namespace AspnetWeb;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var app = builder.Build();

        app.ConfigureMiddlewares();

        Console.WriteLine("Starting the Server");
        app.Run();

    }
}




