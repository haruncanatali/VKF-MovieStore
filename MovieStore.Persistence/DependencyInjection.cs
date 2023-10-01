using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieStore.Application.Common.Interfaces;

namespace MovieStore.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServer_Dev")));
        
        services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationContext>());
        return services;
    }
}