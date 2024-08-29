using eTable.Application.Services.Interfaces;
using eTable.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using eTable.Application.Configs;
using eTable.Application.Security;

namespace eTable.Application.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration config)
        {
            AddServices(services);
            AddAutoMapper(services);
            AddPassEncrypter(services,config);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new MappingConfig());
            }).CreateMapper());
        }

        private static void AddPassEncrypter(IServiceCollection services, IConfiguration config)
        {
            var secretKey = config.GetValue<string>("Settings:Password:SecretKey");
            services.AddScoped(options => new PasswordEncrypter(secretKey!));
        }

    }
}
