using System.Globalization;
using MovieStore.Application.Common.Managers;
using MovieStore.Application.Common.Models;

namespace MovieStore.API.Configs;

public static class SettingsConfig
{
    public static IServiceCollection AddSettingsConfig(this IServiceCollection services, IConfiguration configuration)
    {
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");
        
        services.AddTransient<TokenManager>();
        services.Configure<TokenSettings>(configuration.GetSection("TokenSetting"));

        return services;
    }
}