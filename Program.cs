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
                // Core app services
                services.AddConfigurationService(context.Configuration)
                    .AddDatabaseService()
                    .AddAutoMapperService()
                    .AddGridifyService();

                // Domain services
                services.AddScoped<DatabaseSeeder>()
                    .AddTransient<IUserService, UserService>()
                    .AddTransient<IRoomService, RoomService>()
                    .AddTransient<IRoomTypeService, RoomTypeService>()
                    .AddTransient<IUnitOfWork, UnitOfWork>();

                // Forms
                services.AddTransient<LoginForm>();
                services.AddTransient<RoomManagementForm>();
            }).Build();

            // Seed database using a scope
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var seeder = services.GetRequiredService<DatabaseSeeder>();
                await seeder.SeedDatabaseAsync();
            }

            // Start WinForms app
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var context = new TrayIconApplicationContext(host.Services);
            Application.Run(context);
        }
    }
}