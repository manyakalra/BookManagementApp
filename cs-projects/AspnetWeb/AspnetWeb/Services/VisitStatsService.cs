using System.Text;

namespace AspnetWeb.Services
{
    public interface IVisitStatsService
    {
        void AddUrl(string url, int status = 200);
        Dictionary<string, int> GetStats();
    }

    public interface INotFoundStatsService
    {
        void AddUrl(string url, int status = 200);
        Dictionary<string, int> Get404Stats();
    }

    public class InMemoryVisitStatsService : IVisitStatsService, INotFoundStatsService
    {
        Dictionary<string, int> visitedStats = new Dictionary<string, int>();
        Dictionary<string, int> notFoundStats = new Dictionary<string, int>();

        public void AddUrl(string url, int status = 200)
        {
            Dictionary<string, int> target = visitedStats;
            if (status == 404)
            {
                target = notFoundStats;
            }

            url = url.ToLower();

            if (target.ContainsKey(url))
            {
                target[url]++;
            }
            else
            {
                target[url] = 1;
            }
        }

        public Dictionary<string, int> GetStats()
        {
            return visitedStats;
        }

        public Dictionary<string, int> Get404Stats()
        {
            return notFoundStats;
        }
    }

    public static class VisitedStatsMiddleware
    {
        public static IApplicationBuilder UseStats(this IApplicationBuilder app)
        {
            //middleware 1
            app.UseBefore( context =>
            {
                var service = app.ApplicationServices.GetService<IVisitStatsService>();
                service.AddUrl(context.Request.Path);
                return Task.CompletedTask;
            });

            //middleware 2
            app.UseOnUrl("/stats/visited", async context =>
            {
                var service = context.RequestServices.GetService<IVisitStatsService>();
                var html = new StringBuilder();
                html.Append("<html><head><title>Site Visit Stats</title></head>");
                html.Append("<body><h1>Site Visit Stats</h1>");
                html.Append("<table><thead><tr><th>Url</th><th>Visits</th></tr></thead><tbody>");

                var items = service.GetStats();
                foreach(var key in items.Keys)
                {
                    html.Append($"<tr><td>{key}</td><td>{items[key]}</td></tr>");
                }
                html.Append("</tbody></table></body></html>");

                await context.Response.WriteAsync(html.ToString());

            });

            //we can have more middlewares configured

            return app;
        }

        public static IServiceCollection AddStats(this IServiceCollection services)
        {
            services.AddSingleton<IVisitStatsService, InMemoryVisitStatsService>();
            //may add more services here
            return services;
        }
    }


}
