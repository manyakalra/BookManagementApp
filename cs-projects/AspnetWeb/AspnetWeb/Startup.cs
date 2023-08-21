using AspnetWeb.Services;
using ConceptArchitect.BookManagement;
using ConceptArchitect.Data;
using System.Data;
using System.Data.SqlClient;

namespace AspnetWeb
{
    public static class Startup
    {
        public static void ConfigureAppServices(this IServiceCollection services)
        {
            services.AddStats();



            //services.AddSingleton<IGreetService, SimpleGreetService>();

            services.AddSingleton<ITimePrefix, EnglishTimePrefix>();


            //services.AddSingleton<IGreetService, TimedGreetService>();

            services.AddTransient<IGreetService,TimedGreetService>();

            services.AddSingleton<IGreetService, ConfigurableGreetService>();

            services.AddSingleton<IGreetService, AdvancedConfigurableGreetService>();



            //Author Services

            services.AddSingleton<Func<IDbConnection>>((s) =>
            {

                var config= s.GetRequiredService<IConfiguration>();
                return () =>
                {
                    var connection = new SqlConnection()
                    {
                        ConnectionString = config.GetConnectionString("bms")                        
                    };
                    connection.Open();
                    return connection;
                };

            }); 

            services.AddSingleton<DbManager>();

            

            services.AddSingleton<AuthorManager>();




            //services.AddSingleton<IVisitStatsService, InMemoryVisitStatsService>();


            services.AddMvc(opt =>
            {
                opt.EnableEndpointRouting = false;
            });
           
        }


        public  static void ConfigureMiddlewares(this IApplicationBuilder app)
        {
            var logger = app.ApplicationServices.GetService<ILogger<Program>>();

            var environment = app.ApplicationServices.GetService<IHostEnvironment>();

            logger.LogInformation($"Current Environment: {environment.EnvironmentName}");


            //fake data


            app.UseOnUrl("/add-fake-stats", async context =>
            {
                var service = context.RequestServices.GetService<IVisitStatsService>();
                for (int i = 0; i < 10;i++)
                    service.AddUrl("/authors");

                service.AddUrl("/author/vivek");
                service.AddUrl("/author/vivek");
                service.AddUrl("/author/vivek");
                service.AddUrl("/author/archer");
                service.AddUrl("/author/archer");
                service.AddUrl("/author/dinkar");

                await Task.Yield();
                context.Response.Redirect("/stats/visited");
            });

            app.UseStaticFiles();

            app.UseStats();

            
            app.UseMvcWithDefaultRoute();



            app.UseExceptionMapper<EntityNotFoundException>(404,false);


            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                Console.WriteLine($"Requested Path : {context.Request.Path}");
                await next(context); //pass request to the next middleware
                Console.WriteLine();
            });

            if(environment.EnvironmentName == "HarryPotter")
            {
                app.UseOnUrl("/934", async context =>
                {
                    await context.Response.WriteAsync("Welcome to Hogwards instutitue of Wizard and Witchcraft");
                });
            }

            


            app.UseOnUrl("/greet3", async context =>
            {
                var name = context.Request.Path.ToString().Split("/")[2];

                //var service = new SimpleGreetService();

                //manual creation
                //var service = new TimedGreetService(new EnglishTimePrefix());

                //Getting from service
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
                //var db = new DbManager(() =>
                // {
                //     var connection = new SqlConnection()
                //     {
                //         ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\MyWorks\Corporate\202307-ecolab-cs\booksdb3.mdf;Integrated Security=True;Connect Timeout=30"
                //     };
                //     connection.Open();
                //     return connection;
                // });

                //var authorManager = new AuthorManager(db);

                var authorManager = app.ApplicationServices.GetService<AuthorManager>();

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


           

         



            //app.Run(context =>
            //{
            //    Console.WriteLine($"Default Hanlder Received Request for {context.Request.Path} ");
            //    return context.Response.WriteAsync($"Welcome to Book's Server: {context.Request.Path}");
            //});


           

           

            Console.WriteLine("Middlewares configured");
        }
    }
}
    