using System.Security.Cryptography;
using System.Text;

using Bogus;

using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Data.Seeders
{
    internal class DatabaseSeeder
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
            if (await _context.Users.AnyAsync())
            {
                return;
            }

            var passwordHash = HashPassword("password123");

            // Phase 1: Seed lookup tables
            var roles = await SeedRoles();
            var userTypes = await SeedUserTypes();
            var roomTypes = await SeedRoomTypes();
            var payments = await SeedPayments();

            // Phase 2: Seed rooms
            var rooms = await SeedRooms(roomTypes);

            // Phase 3: Seed users and profiles
            var users = await SeedUsersAndProfiles(roles, userTypes, passwordHash);

            // Phase 4: Seed bookings, invoices, and booking details
            await SeedBookingsInvoicesAndDetails(users, rooms, payments, roomTypes, userTypes);

            // Phase 5: Seed system parameters
            await SeedParams();
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create(); // Use SHA256 for hashing
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password)); // Convert password to byte array
            return Convert.ToBase64String(bytes); // Convert byte array to Base64 string
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
                    SurchargeRate = 1.0
                },
                new UserType
                {
                    Id = Guid.NewGuid(),
                    Type = UserTypeType.Foreign,
                    Description = "Foreign customer",
                    SurchargeRate = 2.5
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
                ("Standard Single", "Basic single room with essential amenities", 50.0),
                ("Standard Double", "Comfortable double room for two guests", 80.0),
                ("Deluxe", "Spacious room with premium amenities", 120.0),
                ("Suite", "Luxury suite with separate living area", 200.0),
                ("Presidential Suite", "Ultimate luxury accommodation", 500.0),
                ("Family Room", "Large room suitable for families", 150.0),
                ("Twin Room", "Room with two single beds", 85.0),
                ("Executive Room", "Business-class room with workspace", 130.0)
            };

            var roomTypeFaker = new Faker<RoomType>()
                .RuleFor(rt => rt.Id, f => Guid.NewGuid())
                .RuleFor(rt => rt.Name, f => string.Empty)
                .RuleFor(rt => rt.Description, f => string.Empty)
                .RuleFor(rt => rt.PricePerNight, f => 0.0);

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
                .RuleFor(p => p.Amount, f => Math.Round(f.Random.Double(50, 2000), 2))
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

        private async Task<List<User>> SeedUsersAndProfiles(List<Role> roles, List<UserType> userTypes, string passwordHash)
        {
            var adminRole = roles.First(r => r.Type == RoleType.Admin);
            var staffRole = roles.First(r => r.Type == RoleType.Staff);
            var customerRole = roles.First(r => r.Type == RoleType.Customer);

            var userFaker = new Faker<User>()
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.PasswordHash, f => passwordHash)
                .RuleFor(u => u.RoleId, f => f.PickRandom(roles).Id)
                .RuleFor(u => u.UserTypeId, f => f.PickRandom(userTypes).Id);

            var users = new List<User>();

            // 5% Admin (10 users)
            for (int i = 0; i < 10; i++)
            {
                var user = userFaker.Generate();
                user.RoleId = adminRole.Id;
                users.Add(user);
            }

            // 15% Staff (30 users)
            for (int i = 0; i < 30; i++)
            {
                var user = userFaker.Generate();
                user.RoleId = staffRole.Id;
                users.Add(user);
            }

            // 80% Customer (160 users)
            for (int i = 0; i < 160; i++)
            {
                var user = userFaker.Generate();
                user.RoleId = customerRole.Id;
                users.Add(user);
            }

            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();

            // Create profiles for all users
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
            foreach (var user in users)
            {
                var profile = profileFaker.Generate();
                profile.UserId = user.Id;
                profiles.Add(profile);
            }

            await _context.Profiles.AddRangeAsync(profiles);
            await _context.SaveChangesAsync();

            // Update users with profile IDs
            for (int i = 0; i < users.Count; i++)
            {
                users[i].ProfileId = profiles[i].Id;
            }
            await _context.SaveChangesAsync();

            return users;
        }

        private async Task SeedBookingsInvoicesAndDetails(List<User> users, List<Room> rooms, List<Payment> payments, List<RoomType> roomTypes, List<UserType> userTypes)
        {
            var customers = users.Where(u => u.RoleId == users.First(x => x.RoleId != Guid.Empty).RoleId).ToList();
            var availablePayments = payments.ToList();

            var bookingFaker = new Faker<Booking>()
                .RuleFor(b => b.Id, f => Guid.NewGuid())
                .RuleFor(b => b.CheckInDate, f => f.Date.Between(DateTime.UtcNow.AddMonths(-6), DateTime.UtcNow.AddMonths(3)))
                .RuleFor(b => b.CheckOutDate, (f, b) => b.CheckInDate.AddDays(f.Random.Int(1, 14)))
                .RuleFor(b => b.BookerId, f => f.PickRandom(customers).Id)
                .RuleFor(b => b.RoomId, f => f.PickRandom(rooms).Id)
                .RuleFor(b => b.TotalPrice, f => 0.0);

            var bookings = bookingFaker.Generate(300);
            await _context.Set<Booking>().AddRangeAsync(bookings);
            await _context.SaveChangesAsync();

            // Create invoices for bookings
            var invoices = new List<Invoice>();
            for (int i = 0; i < bookings.Count; i++)
            {
                var booking = bookings[i];
                var room = rooms.First(r => r.Id == booking.RoomId);
                var roomType = roomTypes.First(rt => rt.Id == room.RoomTypeId);
                var booker = users.First(u => u.Id == booking.BookerId);
                var userType = userTypes.First(ut => ut.Id == booker.UserTypeId);

                var daysStayed = (booking.CheckOutDate - booking.CheckInDate).Days;
                var basePrice = Math.Round(roomType.PricePerNight * daysStayed * userType.SurchargeRate, 2);
                var taxPrice = Math.Round(basePrice * 0.1, 2); // 10% tax
                var totalPrice = basePrice + taxPrice;

                var invoice = new Invoice
                {
                    Id = Guid.NewGuid(),
                    BasePrice = basePrice,
                    TaxPrice = taxPrice,
                    TotalPrice = totalPrice,
                    DaysStayed = daysStayed,
                    Status = _rng.Next(100) < 70 ? InvoiceStatus.Paid : (_rng.Next(100) < 20 ? InvoiceStatus.Pending : InvoiceStatus.Cancelled),
                    PaymentId = availablePayments[i % availablePayments.Count].Id,
                    BookingId = booking.Id
                };

                booking.TotalPrice = totalPrice;
                invoices.Add(invoice);
            }

            await _context.Set<Invoice>().AddRangeAsync(invoices);
            await _context.SaveChangesAsync();

            // Update bookings with invoice IDs
            for (int i = 0; i < bookings.Count; i++)
            {
                bookings[i].InvoiceId = invoices[i].Id;
            }
            await _context.SaveChangesAsync();

            // Create booking details (guests)
            var bookingDetails = new List<BookingDetails>();
            foreach (var booking in bookings)
            {
                var guestCount = _rng.Next(1, 5); // 1-4 guests per booking
                var potentialGuests = users.Take(50).ToList(); // Pool of potential guests

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

            await _context.Set<BookingDetails>().AddRangeAsync(bookingDetails);
            await _context.SaveChangesAsync();
        }

        private async Task SeedParams()
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
                    Value = "4",
                    Description = "Maximum number of guests allowed per room"
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
                    Key = "CANCELLATION_DEADLINE_HOURS",
                    Value = "24",
                    Description = "Hours before check-in to allow free cancellation"
                },
                new Params
                {
                    Id = Guid.NewGuid(),
                    Key = "MAX_BOOKING_DAYS",
                    Value = "30",
                    Description = "Maximum number of days for a single booking"
                },
                new Params
                {
                    Id = Guid.NewGuid(),
                    Key = "EARLY_CHECKIN_FEE",
                    Value = "20.00",
                    Description = "Additional fee for early check-in requests"
                },
                new Params
                {
                    Id = Guid.NewGuid(),
                    Key = "LATE_CHECKOUT_FEE",
                    Value = "25.00",
                    Description = "Additional fee for late check-out requests"
                }
            };

            await _context.Set<Params>().AddRangeAsync(parameters);
            await _context.SaveChangesAsync();
        }
    }
}
