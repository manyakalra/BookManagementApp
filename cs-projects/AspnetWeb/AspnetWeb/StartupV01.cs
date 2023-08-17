namespace AspnetWeb
{
    public static class StartupV1
    {
        public  static void ConfigureMiddlewaresV1(this IApplicationBuilder app)
        {
            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                Console.WriteLine($"Requested Path : {context.Request.Path}");
                await next(context); //pass request to the next middleware
                Console.WriteLine();
            });

            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                if (context.Request.Path == "/favicon.ico")
                {
                    context.Response.StatusCode = 404; //Not Found
                    await context.Response.WriteAsync($"No Fav Icons available");
                }
                else
                {
                    Console.WriteLine("FabIcon Middleware Passing to next middleware");
                    await next(context);
                }
            });

            

            app.Use( next =>
           {

               return async context =>
              {
                  if (context.Request.Path == "/date")
                  {
                      await context.Response.WriteAsync($"Today is {DateTime.Now.ToLongDateString()}");
                  }
                  else
                  {
                      Console.WriteLine("Date Handler Middleware Passing to next middleware");
                      await next(context);
                  }

              };
               
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
    