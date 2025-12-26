using AutoMapper;

using Gridify;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HotelManagementIt008.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // AddDatabaseService: Register DbContext used Npgsql (Postgres)
        extension(IServiceCollection services)
        {
            public IServiceCollection AddDatabaseService()
            {
                services.AddDbContext<HotelManagementDbContext>((serviceProvider, options) =>
                {
                    // Get EFCoreSettings from DI
                    var settings = serviceProvider.GetRequiredService<IOptions<EFCoreSettings>>().Value;

                    // Use Npgsql (Postgres)
                    options.UseNpgsql(settings.DefaultConnection, npgsqlOptions =>
                    {
                        // Options for Npgsql can be configured here
                        // npgsqlOptions.MigrationsHistoryTable("__EFMigrationsHistory");
                    });
                });

                return services;
            }

            // AddConfigurationService: Bind options from appsettings.json
            public IServiceCollection AddConfigurationService(IConfiguration configuration)
            {
                services.AddOptions<EFCoreSettings>()
                    .Bind(configuration.GetSection(EFCoreSettings.SettingsSection))
                    .ValidateDataAnnotations()
                    .ValidateOnStart();

                services.AddOptions<SecuritySettings>()
                    .Bind(configuration.GetSection(SecuritySettings.SettingsSection))
                    .ValidateDataAnnotations()
                    .ValidateOnStart();

                return services;
            }

            // AddAutoMapperService: Register AutoMapper
            public IServiceCollection AddAutoMapperService()
            {
                // Register Mapper configuration as a singleton
                services.AddSingleton(provider =>
                {
                    // Get logger factory from DI
                    var loggerFactory = provider.GetService<ILoggerFactory>();

                    // Create Mapper configuration expression (contains mapping profiles)
                    var configExpression = new MapperConfigurationExpression();

                    // Scan and add all profiles in the assembly
                    configExpression.AddMaps(typeof(ServiceCollectionExtensions).Assembly);

                    // Create Mapper configuration
                    var config = new MapperConfiguration(configExpression, loggerFactory);

                    // Validate the configuration
                    config.AssertConfigurationIsValid();

                    return config;
                });

                // Register IMapper as a singleton
                services.AddSingleton<IMapper>(sp =>
                    new Mapper(
                        sp.GetRequiredService<MapperConfiguration>(), // Get the registered MapperConfiguration from above
                        sp.GetService)); // Use the service provider to resolve dependencies

                return services;
            }

            // AddGridifyService: Register Gridify
            public IServiceCollection AddGridifyService()
            {
                // Enable Entity Framework compatibility layer to optimize Gridify for EF Core
                GridifyGlobalConfiguration.EnableEntityFrameworkCompatibilityLayer();
                GridifyGlobalConfiguration.DefaultDateTimeKind = DateTimeKind.Utc;
                services.AddGridifyMappers(typeof(Program).Assembly);
                return services;
            }
        }
    }
}
