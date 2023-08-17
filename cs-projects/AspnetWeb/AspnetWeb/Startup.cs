namespace AspnetWeb
{
    public static class Startup
    {
        public  static void ConfigureMiddlewares(this IApplicationBuilder app)
        {
            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                Console.WriteLine($"Requested Path : {context.Request.Path}");
                await next(context); //pass request to the next middleware
                Console.WriteLine();
            });

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
    