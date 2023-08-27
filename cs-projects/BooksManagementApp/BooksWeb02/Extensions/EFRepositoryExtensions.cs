using ConceptArchitect.BookManagement;
using ConceptArchitect.Utils;

using ConceptArchitect.BookManagement.Repositories.EFRepository;
using ConceptArchitect.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BooksWeb02.Extensions
{
    public static  class EFRepositoryExtensions
    {
        public static IServiceCollection AddEFBmsRepository(this IServiceCollection services)
        {
            //Add the EF Context (BMSContext)
            //WE don't add context object using AddSingleton
            //services.AddSingleton<DbContext, BMSContext>();


            services.AddDbContext<BMSContext>((serviceProvider, contextBuilder) =>
            {
                var config = serviceProvider.GetRequiredService<IConfiguration>();
                var connectionString = config.GetConnectionString("EFContext2");
                contextBuilder.UseSqlServer(connectionString);
            });

            services.AddTransient<IRepository<Author, string>, EFAuthorRepository>();
            services.AddTransient<IRepository<Book, string>, EFBookRepository>();
            services.AddTransient<IRepository<User,string>,EFUserRepository>();
            services.AddTransient<IRepository<Review, string>, EFReviewRepository>();

            return services;

        }
    }
}
