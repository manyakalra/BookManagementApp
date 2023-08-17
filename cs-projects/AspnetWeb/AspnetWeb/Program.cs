
using AspnetWeb.Services;

namespace AspnetWeb;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.ConfigureAppServices();
        

        var app = builder.Build();

        app.ConfigureMiddlewares();

        Console.WriteLine("Starting the Server");
        app.Run();

    }
}




