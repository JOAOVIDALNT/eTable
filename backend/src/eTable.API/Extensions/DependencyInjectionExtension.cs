using eTable.API.Data;
using eTable.API.Repositories;
using eTable.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eTable.API.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
        }

        public static void AddDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultDb"));
            });
        }
    }
}
