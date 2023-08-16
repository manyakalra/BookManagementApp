
namespace AspnetWeb;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var app = builder.Build();

        app.ConfigureMiddlewares();

        app.Run();

    }
}




