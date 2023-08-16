namespace AspnetWeb
{
    public static class Startup
    {
        public  static void ConfigureMiddlewares(this WebApplication app)
        {
            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                await next(context); //pass request to the next middleware
            });



            app.Run(async context =>
            {
                await context.Response.WriteAsync($"Today is {DateTime.Now.ToLongDateString()}");

            });

            app.Run(context =>
            {
                return context.Response.WriteAsync($"Welcome to Book's Server: {context.Request.Path}");
            });
        }
    }
}
    