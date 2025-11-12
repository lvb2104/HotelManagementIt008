using HotelManagementIt008.Repositories;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HotelManagementIt008
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                // Register application services
                services.AddConfigurationService(context.Configuration)
                    .AddDatabaseService()
                    .AddAutoMapperService()
                    .AddGridifyService();

                // Register other services here
                services.AddScoped<DatabaseSeeder>()
                    .AddScoped<IUserService, UserService>()
                    .AddScoped<IRoomService, RoomService>()
                    .AddScoped<IRoomTypeService, RoomTypeService>()
                    .AddScoped<IUnitOfWork, UnitOfWork>();

                // Register Forms
                services.AddScoped<LoginForm>();
                services.AddScoped<RoomManagementForm>();
            }).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var seeder = services.GetRequiredService<DatabaseSeeder>();
                await seeder.SeedDatabaseAsync();
            }

            ApplicationConfiguration.Initialize();
            var loginForm = host.Services.GetRequiredService<LoginForm>();
            Application.Run(loginForm);
        }
    }
}