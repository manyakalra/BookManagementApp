namespace AspnetWeb
{
    public static  class CustomMiddleWares
    {
        public static void UseOnUrl(this IApplicationBuilder app, string url,RequestDelegate action, bool exactMatch=true)
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
        }
    }
}
