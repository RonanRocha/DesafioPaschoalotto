using DesafioPaschoalotto.Application.Interfaces;
using DesafioPaschoalotto.Application.Mapping;
using DesafioPaschoalotto.Application.Services;
using DesafioPaschoalotto.Domain.Repositories;
using DesafioPaschoalotto.Infrastructure.Context;
using DesafioPaschoalotto.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DesafioPaschoalotto.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();

            services.AddScoped<IRandomUserGeneratorApiService, RandomUserGeneratorApiService>();
            services.AddScoped<IUserService, UserService>();


            var connection = configuration.GetConnectionString("DefaultConnection");


            services.AddDbContext<AppDbContext>(options => {
                options.UseNpgsql(connection, b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
                options.UseLowerCaseNamingConvention();
                
            });

         


            services.AddAutoMapper(typeof(MappingProfile));

            services.AddHttpClient("RandomUserGeneratorApi", c =>
            {
                c.BaseAddress = new Uri("https://randomuser.me/");
            });

            return services;    
        }
    }
}
