using Bogus;

using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Data.Seeders
{
    public class DatabaseSeeder
    {
        private readonly HotelManagementDbContext _context;
        private readonly Random _rng = new();

        public DatabaseSeeder(HotelManagementDbContext context)
        {
            _context = context;
        }

        public async Task SeedDatabaseAsync()
        {
            // Only seed if database is empty
            if (await IsAlreadySeededAsync())
            {
                return;
            }

            // Increase command timeout for long seeding operations (in seconds)
            _context.Database.SetCommandTimeout(180);

            // Wrap the whole seeding in a DB transaction for atomicity and speed
            await using var transaction = await _context.Database.BeginTransactionAsync();

            // Improve performance for bulk inserts
            var originalAutoDetect = _context.ChangeTracker.AutoDetectChangesEnabled;
            try
            {
                _context.ChangeTracker.AutoDetectChangesEnabled = false;

                var salt = BCrypt.Net.BCrypt.GenerateSalt();
                var passwordHash = BCrypt.Net.BCrypt.HashPassword("password123", salt);

                // Phase 1: Seed lookup tables (Roles, UserTypes, RoomTypes, Payments)
                var roles = await SeedRoles();
                var userTypes = await SeedUserTypes();
                var roomTypes = await SeedRoomTypes();
                var payments = await SeedPayments();

                // Phase 2: Seed rooms
                var rooms = await SeedRooms(roomTypes);

                // Phase 3: Seed users and profiles
                var admin = await SeedAdmin(roles, passwordHash);
                var staffs = await SeedStaffs(roles, passwordHash);
                var customers = await SeedCustomersAndProfiles(roles, userTypes);

                // Phase 4: Seed system parameters (needed for booking calculations)
                var systemParams = await SeedParams();

                // Phase 5: Seed bookings, invoices, and booking details
                await SeedBookingsInvoicesAndDetails(customers, rooms, payments, roomTypes, userTypes, systemParams);

                // Commit transaction
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                // Restore AutoDetectChanges setting
                _context.ChangeTracker.AutoDetectChangesEnabled = originalAutoDetect;
            }
        }

        // Robust seed guard: if any core tables have data, assume seeded
        private async Task<bool> IsAlreadySeededAsync()
        {
            var anyUsers = await _context.Users.AnyAsync();
            if (anyUsers) return true;

            var anyRooms = await _context.Rooms.AnyAsync();
            if (anyRooms) return true;

            var anyBookings = await _context.Bookings.AnyAsync();
            if (anyBookings) return true;

            return false;
        }

        private async Task<List<Role>> SeedRoles()
        {
            var roles = new List<Role>
            {
                new Role
                {
                    Id = Guid.NewGuid(),
                    Type = RoleType.Admin,
                    Description = "System administrator with full access"
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Type = RoleType.Staff,
                    Description = "Hotel staff member"
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Type = RoleType.Customer,
                    Description = "Hotel customer/guest"
                }
            };

            await _context.Set<Role>().AddRangeAsync(roles);
            await _context.SaveChangesAsync();
            return roles;
        }

        private async Task<List<UserType>> SeedUserTypes()
        {
            var userTypes = new List<UserType>
            {
                new UserType
                {
                    Id = Guid.NewGuid(),
                    Type = UserTypeType.Local,
                    Description = "Local customer",
                    SurchargeRate = 1.0m
                },
                new UserType
                {
                    Id = Guid.NewGuid(),
                    Type = UserTypeType.Foreign,
                    Description = "Foreign customer",
                    SurchargeRate = 2.5m
                }
            };

            await _context.Set<UserType>().AddRangeAsync(userTypes);
            await _context.SaveChangesAsync();
            return userTypes;
        }

        private async Task<List<RoomType>> SeedRoomTypes()
        {
            var roomTypeNames = new[]
            {
                ("Standard Single", "Basic single room with essential amenities", 50.0m),
                ("Standard Double", "Comfortable double room for two guests", 80.0m),
                ("Deluxe", "Spacious room with premium amenities", 120.0m),
                ("Suite", "Luxury suite with separate living area", 200.0m),
                ("Presidential Suite", "Ultimate luxury accommodation", 500.0m),
                ("Family Room", "Large room suitable for families", 150.0m),
                ("Twin Room", "Room with two single beds", 85.0m),
                ("Executive Room", "Business-class room with workspace", 130.0m)
            };

            var roomTypeFaker = new Faker<RoomType>()
                .RuleFor(rt => rt.Id, f => Guid.NewGuid())
                .RuleFor(rt => rt.Name, f => string.Empty)
                .RuleFor(rt => rt.Description, f => string.Empty)
                .RuleFor(rt => rt.PricePerNight, f => 0.0m);

            var roomTypes = roomTypeNames.Select((rt, index) =>
            {
                var roomType = roomTypeFaker.UseSeed(index).Generate();
                roomType.Name = rt.Item1;
                roomType.Description = rt.Item2;
                roomType.PricePerNight = rt.Item3;
                return roomType;
            }).ToList();

            await _context.Set<RoomType>().AddRangeAsync(roomTypes);
            await _context.SaveChangesAsync();
            return roomTypes;
        }

        private async Task<List<Payment>> SeedPayments()
        {
            var paymentFaker = new Faker<Payment>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.Method, f => f.PickRandom<PaymentMethod>())
                .RuleFor(p => p.Amount, f => Math.Round(f.Random.Decimal(50, 2000), 2))
                .RuleFor(p => p.Status, f => f.PickRandom<PaymentStatus>())
                .RuleFor(p => p.CreatedAt, f => f.Date.Between(DateTime.UtcNow.AddMonths(-6), DateTime.UtcNow));

            var payments = paymentFaker.Generate(80);

            await _context.Set<Payment>().AddRangeAsync(payments);
            await _context.SaveChangesAsync();
            return payments;
        }

        private async Task<List<Room>> SeedRooms(List<RoomType> roomTypes)
        {
            var rooms = new List<Room>();
            var roomNumber = 100;

            var roomFaker = new Faker<Room>()
                .RuleFor(r => r.Id, f => Guid.NewGuid())
                .RuleFor(r => r.RoomNumber, f => (roomNumber++).ToString())
                .RuleFor(r => r.Note, f => f.Random.Bool(0.3f) ? f.Lorem.Sentence() : null)
                .RuleFor(r => r.Status, f => f.PickRandom<RoomStatus>())
                .RuleFor(r => r.RoomTypeId, f => f.PickRandom(roomTypes).Id);

            foreach (var roomType in roomTypes)
            {
                var roomsForType = _rng.Next(8, 15);
                for (int i = 0; i < roomsForType; i++)
                {
                    var room = roomFaker.Generate();
                    room.RoomTypeId = roomType.Id;
                    rooms.Add(room);
                }
            }

            await _context.Set<Room>().AddRangeAsync(rooms);
            await _context.SaveChangesAsync();
            return rooms;
        }

        private async Task<User> SeedAdmin(List<Role> roles, string passwordHash)
        {
            var adminRole = roles.First(r => r.Type == RoleType.Admin);
            var admin = new User
            {
                Id = Guid.NewGuid(),
                Username = "admin",
                PasswordHash = passwordHash,
                RoleId = adminRole.Id,
            };
            await _context.Users.AddAsync(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        private async Task<List<User>> SeedStaffs(List<Role> roles, string passwordHash)
        {
            var staffRole = roles.First(r => r.Type == RoleType.Staff);
            var staffFaker = new Faker<User>()
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.Username, f => f.Internet.UserName())
                .RuleFor(u => u.PasswordHash, f => passwordHash)
                .RuleFor(u => u.RoleId, f => staffRole.Id);
            // 10% Staff (20 users)
            var staffs = staffFaker.Generate(20);
            await _context.Users.AddRangeAsync(staffs);
            await _context.SaveChangesAsync();
            return staffs;
        }

        private async Task<List<User>> SeedCustomersAndProfiles(List<Role> roles, List<UserType> userTypes)
        {
            var customerRole = roles.First(r => r.Type == RoleType.Customer);

            var customerFaker = new Faker<User>()
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.RoleId, f => customerRole.Id)
                .RuleFor(u => u.UserTypeId, f => f.PickRandom(userTypes).Id);

            // 80% Customer (160 users)
            var customers = customerFaker.Generate(160);

            await _context.Users.AddRangeAsync(customers);
            await _context.SaveChangesAsync();

            // Create profiles for all customers
            var profileFaker = new Faker<Profile>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.FullName, f => f.Name.FullName())
                .RuleFor(p => p.Nationality, f => f.Address.Country())
                .RuleFor(p => p.Status, f => ProfileStatus.Active)
                .RuleFor(p => p.Dob, f => f.Date.Between(DateTime.UtcNow.AddYears(-80), DateTime.UtcNow.AddYears(-18)))
                .RuleFor(p => p.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.Address, f => f.Address.FullAddress())
                .RuleFor(p => p.IdentityCardNumber, f => f.Random.Replace("##########"))
                .RuleFor(p => p.UserId, f => Guid.Empty);

            var profiles = new List<Profile>();
            foreach (var customer in customers)
            {
                var profile = profileFaker.Generate();
                profile.UserId = customer.Id;
                profiles.Add(profile);
            }

            await _context.Profiles.AddRangeAsync(profiles);
            await _context.SaveChangesAsync();

            return customers;
        }

        private async Task SeedBookingsInvoicesAndDetails(List<User> customers, List<Room> rooms, List<Payment> payments, List<RoomType> roomTypes, List<UserType> userTypes, Dictionary<string, string> systemParams)
        {
            // Parse system parameters
            var taxRate = decimal.Parse(systemParams["TAX_RATE"]);
            var maxGuestsPerRoom = int.Parse(systemParams["MAX_GUESTS_PER_ROOM"]);
            var foreignSurchargeRate = decimal.Parse(systemParams["FOREIGN_SURCHARGE_RATE"]);
            var extraGuestSurcharge = decimal.Parse(systemParams["EXTRA_GUEST_SURCHARGE"]);

            var availablePayments = payments.ToList();
            var potentialGuests = customers.Take(50).ToList(); // Pool of potential guests

            var bookingFaker = new Faker<Booking>()
                .RuleFor(b => b.Id, f => Guid.NewGuid())
                .RuleFor(b => b.CheckInDate, f => f.Date.Between(DateTime.UtcNow.AddMonths(-6), DateTime.UtcNow.AddMonths(3)))
                .RuleFor(b => b.CheckOutDate, (f, b) => b.CheckInDate.AddDays(f.Random.Int(1, 14)))
                .RuleFor(b => b.BookerId, f => f.PickRandom(customers).Id)
                .RuleFor(b => b.RoomId, f => f.PickRandom(rooms).Id)
                .RuleFor(b => b.TotalPrice, f => 0.0m);

            var bookings = bookingFaker.Generate(300);

            // Create booking details (guests) first to determine guest count for price calculation
            var bookingGuestCounts = new Dictionary<Guid, int>();
            var bookingDetails = new List<BookingDetails>();

            foreach (var booking in bookings)
            {
                var guestCount = _rng.Next(1, 6); // 1-5 guests per booking (some may exceed max)
                bookingGuestCounts[booking.Id] = guestCount;

                for (int i = 0; i < guestCount; i++)
                {
                    var detail = new BookingDetails
                    {
                        Id = Guid.NewGuid(),
                        BookingId = booking.Id,
                        UserId = potentialGuests[_rng.Next(potentialGuests.Count)].Id
                    };
                    bookingDetails.Add(detail);
                }
            }

            // Calculate total price for each booking using system params
            foreach (var booking in bookings)
            {
                var room = rooms.First(r => r.Id == booking.RoomId);
                var roomType = roomTypes.First(rt => rt.Id == room.RoomTypeId);
                var booker = customers.First(u => u.Id == booking.BookerId);
                var userType = userTypes.First(ut => ut.Id == booker.UserTypeId);

                var daysStayed = (booking.CheckOutDate - booking.CheckInDate).Days;
                var guestCount = bookingGuestCounts[booking.Id];

                // Base price = room price * days only (no surcharges)
                var basePrice = roomType.PricePerNight * daysStayed;

                // Calculate surcharges separately
                var subtotal = basePrice;

                // Apply foreign surcharge if customer is foreign
                if (userType.Type == UserTypeType.Foreign)
                {
                    subtotal *= foreignSurchargeRate;
                }

                // Apply extra guest surcharge if exceeding max guests
                if (guestCount > maxGuestsPerRoom)
                {
                    var extraGuests = guestCount - maxGuestsPerRoom;
                    subtotal += subtotal * extraGuestSurcharge * extraGuests;
                }

                subtotal = Math.Round(subtotal, 2);
                var taxPrice = Math.Round(subtotal * taxRate, 2);
                booking.TotalPrice = subtotal + taxPrice;
            }

            await _context.Set<Booking>().AddRangeAsync(bookings);
            await _context.SaveChangesAsync();

            // Save booking details
            await _context.Set<BookingDetails>().AddRangeAsync(bookingDetails);
            await _context.SaveChangesAsync();

            // Create invoices for bookings (Invoice references Booking via BookingId)
            var invoices = new List<Invoice>();
            for (int i = 0; i < bookings.Count; i++)
            {
                var booking = bookings[i];
                var room = rooms.First(r => r.Id == booking.RoomId);
                var roomType = roomTypes.First(rt => rt.Id == room.RoomTypeId);
                var booker = customers.First(u => u.Id == booking.BookerId);
                var userType = userTypes.First(ut => ut.Id == booker.UserTypeId);

                var daysStayed = (booking.CheckOutDate - booking.CheckInDate).Days;
                var guestCount = bookingGuestCounts[booking.Id];

                // Base price = room price * days only (no surcharges)
                var basePrice = roomType.PricePerNight * daysStayed;

                // Calculate surcharges separately
                var subtotal = basePrice;

                // Apply foreign surcharge if customer is foreign
                if (userType.Type == UserTypeType.Foreign)
                {
                    subtotal *= foreignSurchargeRate;
                }

                // Apply extra guest surcharge if exceeding max guests
                if (guestCount > maxGuestsPerRoom)
                {
                    var extraGuests = guestCount - maxGuestsPerRoom;
                    subtotal += subtotal * extraGuestSurcharge * extraGuests;
                }

                subtotal = Math.Round(subtotal, 2);
                var taxPrice = Math.Round(subtotal * taxRate, 2);
                var totalPrice = subtotal + taxPrice;

                // BasePrice = pure base (per night * days), TaxPrice = tax on subtotal, TotalPrice = subtotal + tax
                var invoice = new Invoice
                {
                    Id = Guid.NewGuid(),
                    BasePrice = Math.Round(basePrice, 2),
                    TaxPrice = taxPrice,
                    TotalPrice = totalPrice,
                    DaysStayed = daysStayed,
                    Status = _rng.Next(100) < 70 ? InvoiceStatus.Paid : (_rng.Next(100) < 20 ? InvoiceStatus.Pending : InvoiceStatus.Cancelled),
                    PaymentId = availablePayments[i % availablePayments.Count].Id,
                    BookingId = booking.Id
                };

                invoices.Add(invoice);
            }

            await _context.Set<Invoice>().AddRangeAsync(invoices);
            await _context.SaveChangesAsync();
        }

        private async Task<Dictionary<string, string>> SeedParams()
        {
            var parameters = new List<Params>
            {
                new Params
                {
                    Id = Guid.NewGuid(),
                    Key = "TAX_RATE",
                    Value = "0.10",
                    Description = "Standard tax rate applied to bookings (10%)"
                },
                new Params
                {
                    Id = Guid.NewGuid(),
                    Key = "MAX_GUESTS_PER_ROOM",
                    Value = "3",
                    Description = "Maximum number of guests allowed per room before surcharge"
                },
                new Params
                {
                    Id = Guid.NewGuid(),
                    Key = "FOREIGN_SURCHARGE_RATE",
                    Value = "1.5",
                    Description = "Surcharge multiplier for foreign customers"
                },
                new Params
                {
                    Id = Guid.NewGuid(),
                    Key = "EXTRA_GUEST_SURCHARGE",
                    Value = "0.25",
                    Description = "Surcharge rate per extra guest exceeding MAX_GUESTS_PER_ROOM (25%)"
                },
            };

            await _context.Set<Params>().AddRangeAsync(parameters);
            await _context.SaveChangesAsync();

            return parameters.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
