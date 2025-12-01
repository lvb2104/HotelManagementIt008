using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HotelManagementIt008.Data
{
    public class HotelManagementDbContextFactory : IDesignTimeDbContextFactory<HotelManagementDbContext>
    {
        public HotelManagementDbContext CreateDbContext(string[] args)
        {
            // Build configuration
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Get connection string
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Create options builder
            var builder = new DbContextOptionsBuilder<HotelManagementDbContext>();
            builder.UseNpgsql(connectionString);

            // Return context
            return new HotelManagementDbContext(builder.Options);
        }
    }
}
