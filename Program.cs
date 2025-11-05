using HotelManagementIt008.Data.Seeders;
using HotelManagementIt008.Extensions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HotelManagementIt008
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                // Register application services
                services.AddConfigurationService(context.Configuration)
                    .AddDatabaseService();

                // Register other services here
                services.AddTransient<DatabaseSeeder>();
            }).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var seeder = services.GetRequiredService<DatabaseSeeder>();
                await seeder.SeedDatabaseAsync();
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}