namespace AspnetWeb
{
    public static  class CustomMiddleWares
    {
        public static IApplicationBuilder UseOnUrl(this IApplicationBuilder app, string url,RequestDelegate action, bool exactMatch=true)
        {
            app.Use(next =>
           {
               return async context =>
               {
                   var path = context.Request.Path.ToString();
                   if(exactMatch && path==url || (!exactMatch && path.Contains(url)))
                   {
                       await action(context);
                   }
                   else
                   {
                       await next(context);
                   }
               };
           });

            return app;
        }
    
    
        public static IApplicationBuilder UseBefore(this IApplicationBuilder app, RequestDelegate handler )
        {
            app.Use(next =>
           {
               return async context =>
               {
                   await handler(context);
                   await next(context);
               };
           });

            return app;
        }
    
        public static IApplicationBuilder UseExceptionMapper<T>(this IApplicationBuilder app, int status, bool includeMessage=true, string customPage="wwwroot/404.html") 
        {
            app.Use(next =>
            {
                return async context =>
                {
                    try
                    {
                        await next(context);
                    }
                    catch(Exception ex)
                    {
                        if (ex is T)
                        {
                            context.Response.StatusCode = status;
                            if (includeMessage)
                            {
                                await context.Response.WriteAsync(ex.Message);
                            }
                            else
                            {
                                IHostEnvironment env = context.RequestServices.GetService<IHostEnvironment>();

                                var fullPath = $"{env.ContentRootPath}/{customPage}";
                                context.Response.ContentType = "text/html";
                                await context.Response.SendFileAsync(fullPath);
                            }
                                
                        }
                        else
                            throw;
                    }
                    
                };
            });

            return app;
        }


    }
}
