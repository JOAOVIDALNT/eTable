using eTable.API.Configs;
using eTable.API.Data;
using eTable.API.Repositories;
using eTable.API.Repositories.Interfaces;
using eTable.API.Services;
using eTable.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eTable.API.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddAppDependencies(this IServiceCollection services, IConfiguration config)
        {
            AddRepositories(services);
            AddServices(services);
            AddDatabase(services, config);
            AddAutoMapper(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
        }
        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultDb"));
            });
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new MappingConfig());
            }).CreateMapper());
        }

    }
}
