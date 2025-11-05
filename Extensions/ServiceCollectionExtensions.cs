using HotelManagementIt008.Configuration;
using HotelManagementIt008.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HotelManagementIt008.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        extension(IServiceCollection services) // which adds the extension method
        {
            public IServiceCollection AddDatabaseService() // which method
            {
                services.AddDbContext<HotelManagementContext>((serviceProvider, options) =>
                {
                    var settings = serviceProvider.GetRequiredService<IOptions<EFCoreSettings>>().Value;
                    options.UseSqlServer(settings.DefaultConnection);
                });
                return services;
            }
        }

        extension(IServiceCollection services)
        {
            public IServiceCollection AddConfigurationService(IConfiguration configuration)
            {
                services.AddOptions<EFCoreSettings>()
                    .Bind(configuration.GetSection(EFCoreSettings.SettingsSection))
                    .ValidateDataAnnotations()
                    .ValidateOnStart();

                return services;
            }
        }
    }
}
