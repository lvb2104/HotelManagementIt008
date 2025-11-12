using AutoMapper;
using Gridify;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HotelManagementIt008.Extensions; // nếu cần tham chiếu cùng namespace

namespace HotelManagementIt008.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // AddDatabaseService: đăng ký DbContext dùng Npgsql (Postgres)
        public static IServiceCollection AddDatabaseService(this IServiceCollection services)
        {
            services.AddDbContext<HotelManagementDbContext>((serviceProvider, options) =>
            {
                // Lấy cấu hình EFCoreSettings đã được Bind trong AddConfigurationService()
                var settings = serviceProvider.GetRequiredService<IOptions<EFCoreSettings>>().Value;

                // Sử dụng Npgsql (Postgres)
                options.UseNpgsql(settings.DefaultConnection, npgsqlOptions =>
                {
                    // Các tuỳ chọn provider nếu cần (ví dụ migrations history table)
                    // npgsqlOptions.MigrationsHistoryTable("__EFMigrationsHistory");
                });

            });

            return services;
        }

        // AddConfigurationService: bind options từ appsettings.json
        public static IServiceCollection AddConfigurationService(this IServiceCollection services, IConfiguration configuration)
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

        // AddAutoMapperService: đăng ký AutoMapper
        public static IServiceCollection AddAutoMapperService(this IServiceCollection services)
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

        // AddGridifyService: đăng ký Gridify
        public static IServiceCollection AddGridifyService(this IServiceCollection services)
        {
            services.AddGridifyMappers(typeof(Program).Assembly);
            return services;
        }
    }
}
