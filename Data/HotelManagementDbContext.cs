using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Data
{
    public class HotelManagementDbContext : DbContext
    {
        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingDetails> BookingDetails { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Params> Params { get; set; }

        // Configure entity relationships and properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureTimeStamps(modelBuilder);

            // User - Profile (One-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Role - User (One-to-Many)
            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // UserType - User (One-to-Many)
            modelBuilder.Entity<UserType>()
                .HasMany(ut => ut.Users)
                .WithOne(u => u.UserType)
                .HasForeignKey(u => u.UserTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // RoomType - Room (One-to-Many)
            modelBuilder.Entity<RoomType>()
                .HasMany(rt => rt.Rooms)
                .WithOne(r => r.RoomType)
                .HasForeignKey(r => r.RoomTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Booking - BookingDetails (One-to-Many)
            modelBuilder.Entity<Booking>()
                .HasMany(b => b.BookingDetails)
                .WithOne(bd => bd.Booking)
                .HasForeignKey(bd => bd.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - BookingDetails (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.BookingDetails)
                .WithOne(bd => bd.User)
                .HasForeignKey(bd => bd.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Booking - User (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Bookings)
                .WithOne(b => b.Booker)
                .HasForeignKey(b => b.BookerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Room - Booking (One-to-Many)
            modelBuilder.Entity<Room>()
                .HasMany(r => r.Bookings)
                .WithOne(b => b.Room)
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            // Invoice - Booking (One-to-One)
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Booking)
                .WithOne(b => b.Invoice)
                .HasForeignKey<Booking>(b => b.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Payment - Invoice (One-to-Many)
            modelBuilder.Entity<Payment>()
                .HasMany(p => p.Invoices)
                .WithOne(i => i.Payment)
                .HasForeignKey(i => i.PaymentId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        // Configure CreatedAt, UpdatedAt, DeletedAt properties
        private void ConfigureTimeStamps(ModelBuilder modelBuilder)
        {
            // detect provider (safer than Database.IsNpgsql() in some contexts)
            var isPostgres = Database.ProviderName != null && Database.ProviderName.Contains("Npgsql");

            string createdDefault = isPostgres ? "now()" : "SYSUTCDATETIME()";
            string updatedDefault = isPostgres ? "now()" : "SYSUTCDATETIME()";

            var entities = new Type[]
            {
        typeof(User),
        typeof(Profile),
        typeof(Role),
        typeof(UserType),
        typeof(RoomType),
        typeof(Room),
        typeof(Booking),
        typeof(BookingDetails),
        typeof(Invoice),
        typeof(Payment)
            };

            foreach (var entityType in entities)
            {
                var meta = modelBuilder.Model.FindEntityType(entityType);
                if (meta is null) continue;

                bool hasCreatedAt = meta.FindProperty("CreatedAt") is not null;
                bool hasUpdatedAt = meta.FindProperty("UpdatedAt") is not null;
                bool hasDeletedAt = meta.FindProperty("DeletedAt") is not null;

                if (hasCreatedAt)
                {
                    modelBuilder.Entity(entityType)
                        .Property<DateTime>("CreatedAt")
                        .HasDefaultValueSql(createdDefault)
                        .ValueGeneratedOnAdd();
                }

                if (hasUpdatedAt)
                {
                    modelBuilder.Entity(entityType)
                        .Property<DateTime>("UpdatedAt")
                        .HasDefaultValueSql(updatedDefault)
                        .ValueGeneratedOnAddOrUpdate();
                }

                if (hasDeletedAt)
                {
                    modelBuilder.Entity(entityType)
                        .Property<DateTime?>("DeletedAt")
                        .IsRequired(false);
                }
            }
        }

        // Override SaveChangesAsync to set timestamps
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;
            foreach (var entry in entries)
            {
                var hasUpdatedAt = entry.Metadata.FindProperty("UpdatedAt") is not null;
                var hasCreatedAt = entry.Metadata.FindProperty("CreatedAt") is not null;

                if (entry.State == EntityState.Added)
                {
                    if (hasCreatedAt && entry.Property("CreatedAt").CurrentValue is null)
                    {
                        entry.Property("CreatedAt").CurrentValue = utcNow;
                    }
                    if (hasUpdatedAt)
                    {
                        entry.Property("UpdatedAt").CurrentValue = utcNow;
                    }
                }
                else if (entry.State == EntityState.Modified)
                {
                    if (hasUpdatedAt)
                    {
                        entry.Property("UpdatedAt").CurrentValue = utcNow;
                    }
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
