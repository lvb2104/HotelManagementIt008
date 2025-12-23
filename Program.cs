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
        static void Main()
        {
            var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                // Core app services
                services.AddConfigurationService(context.Configuration)
                    .AddDatabaseService()
                    .AddAutoMapperService()
                    .AddGridifyService();

                // Domain services
                services.AddSingleton<ICurrentUserService, CurrentUserService>()
                    .AddScoped<DatabaseSeeder>()
                    .AddTransient<IUserService, UserService>()
                    .AddTransient<IRoomService, RoomService>()
                    .AddTransient<IRoomTypeService, RoomTypeService>()
                    .AddTransient<IParamService, ParamService>()
                    .AddTransient<IInvoiceService, InvoiceService>()
                    .AddTransient<IBookingService, BookingService>()
                    .AddTransient<IUnitOfWork, UnitOfWork>();

                // Forms
                services.AddTransient<LoginForm>();
                services.AddTransient<MainDashboardForm>();
                services.AddTransient<DashboardForm>();
                services.AddTransient<RoomManagementForm>();
                services.AddTransient<ParamForm>();
                services.AddTransient<BookingManagementForm>();
                services.AddTransient<BookingDetailForm>();
                services.AddTransient<InvoiceManagementForm>();
                services.AddTransient<PaymentManagementForm>();
                services.AddTransient<UserManagementForm>();
                services.AddTransient<ReportsForm>();
                services.AddTransient<SettingsForm>();
                services.AddTransient<UserDetailForm>();
            }).Build();

            // Seed database using a scope
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var seeder = services.GetRequiredService<DatabaseSeeder>();
                seeder.SeedDatabaseAsync().GetAwaiter().GetResult();
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