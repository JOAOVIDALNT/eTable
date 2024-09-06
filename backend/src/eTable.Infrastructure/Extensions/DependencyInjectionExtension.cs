using eTable.Domain.Interfaces;
using eTable.Infrastructure.Data.Repositories;
using eTable.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Azure.Core;

namespace eTable.Infrastructure.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            AddRepositories(services);

            if (config.IsUnitTestEnvironment())
                return;

            AddDatabase(services, config);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
        }
        private static void AddDatabase(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultDb"));
            });
        }

        private static bool IsUnitTestEnvironment(this IConfiguration config)
        {
            return config.GetValue<bool>("InMemoryTest");
        }
    }
}
