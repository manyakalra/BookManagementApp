using AspnetWeb.Services;
using ConceptArchitect.BookManagement;
using ConceptArchitect.Data;
using System.Data.SqlClient;

namespace AspnetWeb
{
    public static class Startup
    {
        public static void ConfigureAppServices(this IServiceCollection services)
        {
            //services.AddSingleton<IGreetService, SimpleGreetService>();

            services.AddSingleton<ITimePrefix, EnglishTimePrefix>();


            services.AddSingleton<IGreetService, TimedGreetService>();
        }


        public  static void ConfigureMiddlewares(this IApplicationBuilder app)
        {
            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                Console.WriteLine($"Requested Path : {context.Request.Path}");
                await next(context); //pass request to the next middleware
                Console.WriteLine();
            });

            app.UseOnUrl("/greet3", async context =>
            {
                var name = context.Request.Path.ToString().Split("/")[2];

                //var service = new SimpleGreetService();
                var service = app.ApplicationServices.GetService<IGreetService>();

                var greetingMessage = service.Greet(name);
                


                await context.Response.WriteAsync(greetingMessage);
            },false);


            app.UseOnUrl("/greet2", async context =>
            {
                var name = context.Request.Query["name"];
                if (string.IsNullOrEmpty(name))
                    name = "World";

                //var service = new SimpleGreetService();

                var service = context.RequestServices.GetService<IGreetService>();

                var greetingMessage = service.Greet(name);

                await context.Response.WriteAsync(greetingMessage);
            });


            app.UseOnUrl("/greet", async context =>
            {
               
                //var service = new SimpleGreetService();

                var service = app.ApplicationServices.GetService<IGreetService>();

                var greetingMessage = service.Greet("World");

                await context.Response.WriteAsync(greetingMessage);
            });




            app.UseOnUrl("/authors", async context =>
            {
                var db = new DbManager(() =>
                 {
                     var connection = new SqlConnection()
                     {
                         ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\MyWorks\Corporate\202307-ecolab-cs\booksdb3.mdf;Integrated Security=True;Connect Timeout=30"
                     };
                     connection.Open();
                     return connection;
                 });

                var authorManager = new AuthorManager(db);

                var authors = authorManager.GetAllAuthors();
               
                await context.Response.WriteAsync("<h1>List of All Authors</h1>");
                await context.Response.WriteAsync("<ul>");
                foreach (var author in authors)
                    await context.Response.WriteAsync($"<li>{author.Name}</li>");
                await context.Response.WriteAsync("</ul>");
            });

            app.UseOnUrl("/authors", async context =>
            {
                var paths = context.Request.Path.ToString().Split("/");
                var id = paths[2];
                var db = new DbManager(() =>
                {
                    var connection = new SqlConnection()
                    {
                        ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\MyWorks\Corporate\202307-ecolab-cs\booksdb3.mdf;Integrated Security=True;Connect Timeout=30"
                    };
                    connection.Open();
                    return connection;
                });

                var authorManager = new AuthorManager(db);

                var author = authorManager.GetAuthorById(id);

                await context.Response.WriteAsync($"<h1>About {author.Name}</h1>");
                await context.Response.WriteAsync($"<p><img src='{author.Photo}' width='300' alt='{author.Name}'/>");
                await context.Response.WriteAsync($"{author.Biography}</p>");

            }, false);

            app.UseOnUrl("time", async context => await context.Response.WriteAsync($"Time is {DateTime.Now.ToLongTimeString()}"), false);
           

            app.UseOnUrl("/favicon.icon", async context =>
            {
                context.Response.StatusCode = 404; //Not Found
                await context.Response.WriteAsync($"No Fav Icons available");
            });

            app.UseOnUrl("/date", async context =>
            {
                await context.Response.WriteAsync($"Today is {DateTime.Now.ToLongDateString()}");
            });


           

         



            app.Run(context =>
            {
                Console.WriteLine($"Default Hanlder Received Request for {context.Request.Path} ");
                return context.Response.WriteAsync($"Welcome to Book's Server: {context.Request.Path}");
            });


           

           

            Console.WriteLine("Middlewares configured");
        }
    }
}
    