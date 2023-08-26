using  ConceptArchitect.BookManagement;

using  BooksWeb02.Extensions;
using ConceptArchitect.BookManagement.Repositories.EFRepository;

namespace BooksWeb02
{ 
    public static class Startup
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            
            services.AddControllersWithViews();

            // services.AddAdoBMSRepository();
            /*services.AddSingleton<IAuthorService, PersistentAuthorService>();

            services.AddSingleton<IBookService, PersistentBookService>();*/

            services.AddEFBmsRepository();

            services.AddTransient<IAuthorService, PersistentAuthorService>();

            services.AddTransient<IBookService, PersistentBookService>();

            return services;
        }

        public static IApplicationBuilder ConfigureMiddlewares(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");




            }
            else
            {
                app.UseOnUrl("/admin/createdb", async context =>
                {
                    var bmsContext = context.RequestServices.GetService<BMSContext>();
                    await bmsContext.Database.EnsureCreatedAsync();
                    context.Response.Redirect("/");
                });
            }


            app.UseOnUrl("/admin/seed/authors", async context =>
            {
                var authorService = context.RequestServices.GetService<IAuthorService>();

                await authorService.AddAuthor(new Author()
                {
                    Id = "dinkar",
                    Name = "Ramdhari Singh Dinkar",
                    Biography = "The National Poet of India",
                    Photo = "https://pbs.twimg.com/profile_images/1269658848777785345/2bY35KV0_400x400.jpg",
                    Tags = "poet, historian",
                    BirthDate = new DateTime(1906, 1, 1),
                    DeathDate = new DateTime(1976, 1, 1)
                });
                await authorService.AddAuthor(new Author()
                {
                    Id = "mahatma-gandhi",
                    Name = "Mahamta Gandhi",
                    Biography = "The Father of the Nation for India",
                    Photo = "https://pbs.twimg.com/media/FAqPzrrUYAM8pCu.jpg",
                    BirthDate = new DateTime(1869, 10, 2),
                    Tags = "freedom fighter, social reformer",
                    DeathDate = new DateTime(1948, 1, 30)
                });
                await authorService.AddAuthor(new Author()
                {
                    Id = "jeffrey-archer",
                    Name = "Jeffrey Archer",
                    Biography = "One of the conemporary best-seleller british author, pariliamentarian, ex-convict",
                    Photo = "https://pbs.twimg.com/profile_images/3751745623/11bd5e198e1f0f7de40ffdf08f556293_400x400.jpeg",
                    BirthDate = new DateTime(1946, 1, 1),
                    Tags = "best-seller, english, british"

                });
                context.Response.Redirect("/author");
            });

            app.UseOnUrl("/admin/seed/books", async context =>
            {
                var authorService = context.RequestServices.GetService<IAuthorService>();
                var bookService = context.RequestServices.GetService<IBookService>();

                await bookService.AddBook(new Book()
                {
                    Id = "my-experiments-with-truth",
                    Title = "My Experiements with Truth",
                    AuthorId = "mahatma-gandhi",
                    Cover = "https://m.media-amazon.com/images/I/71GWX22G92L._AC_UY327_FMwebp_QL65_.jpg",
                    Description = "The autobiography of Mahatma Gandhi presnted as his experiments with truth. A must read"
                });

                await bookService.AddBook(new Book()
                {
                    Id = "kurukshetra",
                    Title = "Kurukshetra",
                    AuthorId = "dinkar",
                    Cover = "https://m.media-amazon.com/images/I/51rZ7I5lG8L._SX331_BO1,204,203,200_.jpg",
                    Description = "An epic poem, a conversastion between Bhisma and Yudhishthira about the necessity of war"

                });

                context.Response.Redirect("/book");
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            return app;
        }

    }
}
